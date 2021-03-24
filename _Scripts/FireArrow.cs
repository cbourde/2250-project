using UnityEngine;

public class FireArrow : MonoBehaviour
{
  public GameObject Arrow;


   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
    {
       if (Input.GetKeyDown(KeyCode.Mouse0))
       {
         shootArrow();
       }
     }
     void shootArrow(){
        GameObject clone = Instantiate(Arrow, transform.position, transform.rotation);
        clone.transform.position = this.transform.position;
     }

}
