using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public GameObject[] SoundObjects;
    public int startingSound = -1;

    GameObject TempAmbientSound;

    private void Start()
    {
        if (startingSound != -1)
        {
            //clamp starting sound ID
            Instantiate(SoundObjects[Mathf.Clamp(startingSound, 0, SoundObjects.Length)]);           
        }
    }

    public void playAudio(int id) 
    {
        //Clamp id to always be in array for no errors
        id = Mathf.Clamp(id, 0, SoundObjects.Length);
        //Our first two ids are ambient sounds so we want to handle those differently
        if (id != 0 && id != 1)
        {
            //Play sound (sounds delete themselves after they finish)
            Instantiate(SoundObjects[id]);
        }
        else 
        {
            //Check for first time run through so we dont get any nullref errors
            if (TempAmbientSound != null) 
            {
                //Delete old ambient sound
                Destroy(TempAmbientSound);
            }         
            //Create new ambient sound based on our id
            TempAmbientSound = Instantiate(SoundObjects[id]);
        }
        
    }

    public GameObject referencePlayAudio(int id) 
    {
        //Returns a ref to the audio gameObject this is only used for the light beam ability sound (consider moving the control of that to here instead)
        return Instantiate(SoundObjects[id]);
    }
}
