using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject[] pressurePlates;
    public GameObject objectToReveal;

    private int _currentPlate = 1;

    void Start()
    {
        objectToReveal.SetActive(false);
    }
    
    public bool Check(int plateNum)
    {
        if (plateNum == _currentPlate)
        {
            _currentPlate++;
            if (_currentPlate > pressurePlates.Length)
            {
                objectToReveal.SetActive(true);
            }
            return true;
        }
        else
        {
            Invoke("ResetPlates", 1);
            _currentPlate = 1;
            return false;
        }
    }

    private void ResetPlates()
    {
        foreach (GameObject p in pressurePlates)
        {
            PuzzlePressurePlate plate = p.GetComponent<PuzzlePressurePlate>();
            if (plate.isPressed() == true)
            {
                plate.ResetPlate();
            }
            
        }
    }
}
