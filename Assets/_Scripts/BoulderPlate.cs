using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPlate : MonoBehaviour
{

    public GameObject boulderSet;

    private void OnCollisionEnter(Collision collision)
    {
        if (Player.strength >= 3)
        {
            boulderSet.SetActive(false);
        }
    }

}
