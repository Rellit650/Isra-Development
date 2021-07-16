using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAreaScript : MonoBehaviour
{
    public GameObject[] respawnPoints;


    private int levelProgress = 0;
    private GameObject PlayerRef;

    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
    }
    public void setProgress(int CurProgress, GameObject self) 
    {
        if (CurProgress > levelProgress) 
        {
            levelProgress = CurProgress;          
        }
        self.SetActive(false);
    }

    public void Respawn() 
    {
        //While this may seem strange this is needed as the character controller does not like to teleport the player especially while moving 
        //so we disable it here to allow for a quick respawn teleport and then re-enable it
        PlayerRef.GetComponent<CharacterController>().enabled = false;
        PlayerRef.transform.position = respawnPoints[levelProgress].transform.position;
        PlayerRef.GetComponent<CharacterController>().enabled = true;
    }

    public void CheatTeleport(int i) 
    {
        PlayerRef.GetComponent<CharacterController>().enabled = false;
        PlayerRef.transform.position = respawnPoints[i].transform.position;
        PlayerRef.GetComponent<CharacterController>().enabled = true;
    }
}
