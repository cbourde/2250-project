﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Enemy"))
      {
          other.gameObject.SetActive(false);
      }
    }
}
