using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool enable;
    public Vector3 offset = new Vector3(0, 12, -4);
    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            Vector3 playerPos = Player.P.pos;
            transform.position = playerPos + offset;
        }

    }
}
