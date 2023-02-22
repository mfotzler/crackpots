using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RespawnOnGroundHit : NetworkBehaviour
{
    public Vector3 SpawnPosition;
    public Quaternion SpawnRotation;
    public override void OnNetworkSpawn()
    {
        if (!IsServer)
            return;

        SpawnPosition = transform.position;
        SpawnRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsServer)
            return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            var rigidBody = transform.GetComponent<Rigidbody>();
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            rigidBody.Sleep();
            transform.position = SpawnPosition;
            transform.rotation = SpawnRotation;
        }
    }
}
