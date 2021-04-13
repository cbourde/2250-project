using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPlate : MonoBehaviour
{

    public GameObject boulderSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Player.strength >= 3)
        {
            boulderSet.SetActive(false);
        }
    }

}
