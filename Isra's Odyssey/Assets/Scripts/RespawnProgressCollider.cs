using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnProgressCollider : MonoBehaviour
{
    public int ZoneProgressID;

    private RespawnAreaScript RespawnController;

    private void Start()
    {
        RespawnController = FindObjectOfType<RespawnAreaScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            RespawnController.setProgress(ZoneProgressID, gameObject);
        }
    }
}
