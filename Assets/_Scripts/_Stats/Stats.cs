﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats //basic statistic
{
    [SerializeField]
    private int baseValue;
  
    public int GetValue()
    {
        return baseValue;
    }
}
