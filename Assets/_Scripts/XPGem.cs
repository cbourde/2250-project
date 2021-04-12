using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPGem : MonoBehaviour
{
    public float rotationSpeed = 0.5f;
    public int xpValue = 40;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Player.P.AwardXP(xpValue);
            
        }
    }
}
