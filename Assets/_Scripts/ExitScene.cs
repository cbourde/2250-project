using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitScene : MonoBehaviour
{
    public GameObject exitTrigger;
    public string sceneName;
     void Start()
    {
        exitTrigger.GetComponent<Collider>().isTrigger = false;
    }
    
    void OnCollisionEnter(Collision col)
    {   
        if (col.collider.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
