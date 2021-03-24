using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealWithHighWisdom : MonoBehaviour
{
    // Hides an object unless the player's Wisdom score is high enough
    public int wisdomRequired = 3;

    public MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (Player.wisdom < wisdomRequired)
        {
            mesh.forceRenderingOff = true;
        }
        else
        {
            mesh.forceRenderingOff = false;
        }
    }
}
