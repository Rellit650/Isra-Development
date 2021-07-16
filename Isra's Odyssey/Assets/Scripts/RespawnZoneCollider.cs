using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZoneCollider : MonoBehaviour
{
    private RespawnAreaScript respawnController;

    private void Start()
    {
        respawnController = FindObjectOfType<RespawnAreaScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            respawnController.Respawn();
        }
    }
}
