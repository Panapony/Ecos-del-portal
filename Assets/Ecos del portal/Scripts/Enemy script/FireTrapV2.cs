using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;

    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;

    private Health playerHealth; // referencia al jugador

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<Health>();

            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            if (active && playerHealth != null)
                playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth = null;
        }
    }

    private IEnumerator ActivateFiretrap()
    {
        triggered = true;
        spriteRend.color = Color.red;

        yield return new WaitForSeconds(activationDelay);

        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        // si el jugador sigue encima cuando se activa
        if (playerHealth != null)
            playerHealth.TakeDamage(damage);

        yield return new WaitForSeconds(activeTime);

        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}