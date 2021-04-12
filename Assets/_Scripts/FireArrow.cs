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
        GameObject clone = Instantiate<GameObject>(Arrow, transform.position, transform.rotation);
        clone.transform.position = transform.position;
        Projectile p = clone.GetComponent<Projectile>();
        p.damage = Player.P.attackDamage;
     }
     //based on the position of the player that is the direction the projectile will be fired

}
