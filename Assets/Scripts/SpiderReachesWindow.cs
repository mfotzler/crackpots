using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpiderReachesWindow : NetworkBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!IsServer)
            return;

        if (collision.gameObject.CompareTag("Window"))
        {
            // lose a life and despawn the spider this is attached to

        }
    }
}
