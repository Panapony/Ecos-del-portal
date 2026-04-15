using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
   [SerializeField] private float healthValue;
   private void OnTriggerEnter2D(Collider2D colision)
   {
    if(colision.tag=="Player")
    {colision.GetComponent<Health>().AddHealth(healthValue);
        gameObject.SetActive(false);
    }
   }
}
