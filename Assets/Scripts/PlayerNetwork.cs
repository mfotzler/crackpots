using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 6f;
    void Update()
    {
        if (!IsOwner)
            return;

        var movementVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A) == true)
            movementVector.x -= 1;
        if (Input.GetKey(KeyCode.D) == true)
            movementVector.x += 1;

        transform.position += movementVector * (movementSpeed * Time.deltaTime);
    }
}
