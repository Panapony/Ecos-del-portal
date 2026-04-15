using UnityEngine;
using System.Collections;

public class PushableBox : MonoBehaviour
{
    public float moveDistance = 0.32f;
    public float moveSpeed = 4f;
    public LayerMask floorLayer;

    private bool moving = false;

    public void Push(float direction)
    {
        if (moving) return;

        Vector2 targetPos = new Vector2(
            transform.position.x + direction * moveDistance,
            transform.position.y
        );

        RaycastHit2D groundCheck = Physics2D.Raycast(
            targetPos,
            Vector2.down,
            0.8f,
            floorLayer
        );

        if (groundCheck.collider != null)
        {
            StartCoroutine(MoveBox(targetPos));
        }
    }

    IEnumerator MoveBox(Vector2 target)
    {
        moving = true;

        while (Vector2.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        transform.position = target;
        moving = false;
    }
}