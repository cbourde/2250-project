using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPGem : MonoBehaviour
{
    public int xpValue = 40;
    private bool _hasCollided = false;

    private void OnCollisionEnter(Collision collision)  //XP gem is destroyed and player is rewarded
    {
        if (!_hasCollided && collision.gameObject.CompareTag("Player"))
        {
            _hasCollided = true;    // Fixes issue where multiple collisions can occur, awarding experience multiple times
            Destroy(gameObject);
            Player.P.AwardXP(xpValue);
            
        }
    }
}
