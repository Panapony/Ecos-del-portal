using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
 [SerializeField] private float startingHealth;
 public float currentHealth{get;private set;}
 private Animator anim;
 private bool dead;

 private void Awake()
 {
    currentHealth=startingHealth;
    anim=GetComponent<Animator>();
 } 

 public void TakeDamage(float _damage)
 {
    currentHealth = Mathf.Clamp(currentHealth-_damage,0,startingHealth);
    if(currentHealth>0)
    {
//sufre daño
anim.SetTrigger("Injured");
    }
    else
    {
        if(!dead)
        {
//muere
anim.SetTrigger("Death");
GetComponent<Character>().enabled=false;
dead=true;
if(GameManager.Instance != null)
{
    GameManager.Instance.GameOver();
}

        }


    }
 }

private void Update()
{
  
}

public void AddHealth(float _value)
{
    currentHealth=Mathf.Clamp(currentHealth+_value,0,startingHealth);
}

}
