using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCrushKiller : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            Destroy(gameObject);
        }
    }
}
