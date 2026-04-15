using UnityEngine;

public class Camarafollow : MonoBehaviour
{
public Transform target;
public bool isFollowing=true;

private void LateUpdate()
{
    
    if(isFollowing && target !=null)
    {
        transform.position=new Vector3(target.position.x,target.position.y,transform.position.z);
     }
 }
    
    

}
 