using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPlate : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        Swing.S.ON = true;
    }

}
