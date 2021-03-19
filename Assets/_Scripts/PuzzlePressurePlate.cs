using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePressurePlate : MonoBehaviour
{
    public int plateNumber;
    public PuzzleController controller;
    public float pressDistance = 0.375f;
    private bool _pressed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<PuzzleController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPlate()
    {
        transform.Translate(0, pressDistance, 0);
        _pressed = false;
        GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void Press()
    {
        transform.Translate(0, -pressDistance, 0);
        _pressed = true;
        if (controller.Check(plateNumber))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!_pressed && collision.gameObject.CompareTag("Player")){
            Press();
        }
    }
}
