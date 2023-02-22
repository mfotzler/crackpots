using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float potPushForce = 100f;
    [SerializeField] private float potPushProximity = 0.5f;
    void Update()
    {
        if (!IsOwner)
            return;

        var movementVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.A) == true)
            movementVector.x -= 1;
        if (Input.GetKey(KeyCode.D) == true)
            movementVector.x += 1;

        if (Input.GetKeyDown(KeyCode.Space))
            PushPotServerRpc();


        transform.position += movementVector * (movementSpeed * Time.deltaTime);
    }

    [ServerRpc(RequireOwnership = false)]
    public void PushPotServerRpc(ServerRpcParams serverRpcParams = default)
    {
        var clientId = serverRpcParams.Receive.SenderClientId;
        if (NetworkManager.ConnectedClients.ContainsKey(clientId))
        {
            var client = NetworkManager.ConnectedClients[clientId];
            var playerPosition = client.PlayerObject.transform.position;
            var pots = ReferenceManager.Pots;
            var transforms = pots.GetComponentsInChildren<Transform>();
            foreach (Transform potTransform in transforms)
            {
                if (potTransform == pots.transform)
                    continue;

                var distance = Mathf.Abs(potTransform.position.x - playerPosition.x);
                if (distance < potPushProximity)
                {
                    potTransform.GetComponent<Rigidbody>().AddForce(Vector3.back * potPushForce);
                }
            }
        }
    }
}
