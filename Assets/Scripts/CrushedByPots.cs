using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCrushKiller : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            Destroy(gameObject);
        }
    }
}
