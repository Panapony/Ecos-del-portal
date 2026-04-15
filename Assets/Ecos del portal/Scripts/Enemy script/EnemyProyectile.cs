using UnityEngine;

public class EnemyProyectile : EnemyDamange
{

    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

 public void ActivateProyectile()
 {
lifetime=0;
gameObject.SetActive(true);
 }

 private void Update()
 {
    float movementSpeed = speed*Time.deltaTime;
    transform.Translate(movementSpeed,0,0);

    lifetime += Time.deltaTime;
    if(lifetime > resetTime)
    gameObject.SetActive(false);

 }
  
  private void OnTriggerEnter2D(Collider2D colision)
  {
    base.OnTriggerEnter2D(colision); //llama la función principal para ejecutarla
gameObject.SetActive(false);
  }
}
