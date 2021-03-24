using UnityEngine;

public class FireArrow : MonoBehaviour
{
  public GameObject Arrow;
   void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
       {
         shootArrow();
       }
       //on a mouse click a projectile will fire
     }
     void shootArrow(){
        GameObject clone = Instantiate(Arrow, transform.position, transform.rotation);
        clone.transform.position = this.transform.position;
     }
     //based on the position of the player that is the direction the projectile will be fired

}
