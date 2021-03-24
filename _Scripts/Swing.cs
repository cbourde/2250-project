using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Vector3 pivotOffset = new Vector3(-2.5f, 5, -3);
    private Vector3 _pivot;
    private float _currentAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        _pivot = transform.position + pivotOffset;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(_pivot, Vector3.back, rotationSpeed);
        _currentAngle += rotationSpeed;
        
        if (_currentAngle >= 180 || _currentAngle < 0)
        {
            rotationSpeed = -rotationSpeed;
        }
        
    }
}
