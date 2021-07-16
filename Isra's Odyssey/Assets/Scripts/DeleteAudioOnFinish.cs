using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAudioOnFinish : MonoBehaviour
{
    public AudioSource AudioRef; 
    // Start is called before the first frame update
    void Start()
    {
        AudioRef = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if done
        if (!AudioRef.isPlaying) 
        {
            //If we are delete ourselves
            Destroy(gameObject);
        }
    }
}
