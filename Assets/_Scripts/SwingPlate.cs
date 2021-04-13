using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPlate : MonoBehaviour
{
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
        GetComponent<MeshRenderer>().material.color = Color.red;
        Swing.S.ON = true;
    }

}
