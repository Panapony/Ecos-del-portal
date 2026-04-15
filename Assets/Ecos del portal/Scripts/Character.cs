using UnityEngine;
using TMPro;
using System.Collections;


public class Character : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D rb2D;
     
    
    private float move;
    public float jumpForce=3;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius=0.1f;
    public LayerMask groundLayer;

    private bool canMove=true;

private Animator animator;

private int coins;
public TMP_Text CoinCount;  

/////variables para coins y el game manager///

[Header("Configuración de coins")]
public int targetCoins=5;
public GameObject mainCoin;

public GameObject victoryMenu;
public float cameraFocusTime = 2F;
public float cameraSpeed= 5f;

    void Start()
    {
        rb2D= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();

        ////la coin principal estará deactivada//
        if (mainCoin != null)
        {
            mainCoin.SetActive(false);
        }
    }


    void Update()
    {
        if(!canMove)return;
        move= Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity=new Vector2(move*speed, rb2D.linearVelocity.y);
  if(move != 0)
  transform.localScale =new Vector3(Mathf.Sign(move),1,1);
   if(Input.GetButtonDown("Jump")&& isGrounded)
   {
    rb2D.linearVelocity=new Vector2(rb2D.linearVelocity.x,jumpForce);
   }
   animator.SetFloat("Speed",Mathf.Abs(move));
animator.SetFloat("VerticalVelocity",rb2D.linearVelocity.y);
animator.SetBool("isGrounded", isGrounded);


    }
    private void FixedUpdate()
    {
        isGrounded=Physics2D.OverlapCircle(groundCheck.position, groundRadius,groundLayer);
    }

private void OnTriggerEnter2D(Collider2D colision)
{
if(colision.transform.CompareTag("Coin"))
{
    Destroy(colision.gameObject);
    coins ++;
    CoinCount.text= coins.ToString();
}
    ////desbloquea el coin princpial
    if(coins >= targetCoins)
    {
        UnlockPrincipalCoin();
    }


if(colision.transform.CompareTag("MainCoin"))
{
   
Destroy(colision.gameObject);
GameManager.Instance.Victory();


}

}


IEnumerator CinematicaMonedaPrincipal()
{
canMove =false;
rb2D.linearVelocity=Vector2.zero;
animator.SetFloat("Speed",0);

Camera mainCam=Camera.main;
Camarafollow scriptCamara = mainCam.GetComponent<Camarafollow>();

if(scriptCamara !=null)
scriptCamara.isFollowing=false;



mainCoin.SetActive(true);


Vector3 playerPos=mainCam.transform.position;
Vector3 targetPos=new Vector3(mainCoin.transform.position.x,mainCoin.transform.position.y, playerPos.z);

/// mueve la cámara hacia la moneda
float t=0;
while(t<1)
{
  t += Time.deltaTime * cameraSpeed;
            mainCam.transform.position = Vector3.Lerp(playerPos, targetPos, t);
            yield return null;  
}
//// espera un momento
yield return new WaitForSeconds(cameraFocusTime);

        // 3. Volver al jugador
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * cameraSpeed;
            mainCam.transform.position = Vector3.Lerp(targetPos, playerPos, t);
            yield return null;
        }

if (scriptCamara != null) 
        scriptCamara.isFollowing = true;
        
        canMove = true; // Devolvemos el control

}

void AbrirMenuVictoria()
    {
        if (victoryMenu != null)
        {
            victoryMenu.SetActive(true);
            Time.timeScale = 0f; // Congela el juego
        }
    }



void UnlockPrincipalCoin()
{
if(mainCoin != null && !mainCoin.activeSelf)
{
    mainCoin.SetActive(true);
    Debug.Log(" Fragmento debloqueado");

}


/////para que el jugador empuje
void OnCollisionStay2D(Collision2D collision)
{
    PushableBox box = collision.gameObject.GetComponent<PushableBox>();

    if (box != null && move != 0)
    {
        box.Push(move);
    }
}

}

}

