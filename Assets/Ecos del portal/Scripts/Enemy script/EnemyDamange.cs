using UnityEngine;

public class EnemyDamange : MonoBehaviour
{
    [SerializeField] protected float damage;
    protected void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.tag=="Player")
        colision.GetComponent<Health>().TakeDamage(damage);
    }
}