using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGlyphManager : MonoBehaviour
{
    public int maxNumberOfGlyphs;
    public GameObject wall;

    //For when we open the door
    private Animator doorAnimator;
    //This will hold what part of the puzzle we are on
    private int index = 1;
    //This will be for if the puzzle fails and we need to reset all glyphs
    private List<GameObject> currentActivateGlyphs = new List<GameObject>();


    private void Start()
    {
        doorAnimator = wall.GetComponentInChildren<Animator>();
    }

    public void checkGlyph(int glyphID, GameObject selfRef) 
    {
        
        if (glyphID == index)
        {
            //add current object to list if its the one we are looking for
            currentActivateGlyphs.Add(selfRef);
            //Adjust index for next glyph
            index++;
            //If we have done the number of glyphs there are we are done
            if (index > maxNumberOfGlyphs)
            {
                // Open door
                //wall.SetActive(false);
                doorAnimator.SetBool("PuzzleCompleted", true);
                wall.GetComponentInChildren<BoxCollider>().enabled = false;
            }
        }
        else 
        {           
            for(int i = 0; i < currentActivateGlyphs.Count; i++) 
            {
                if(currentActivateGlyphs[i] != null) 
                {
                    //reset our glyphs
                    currentActivateGlyphs[i].GetComponent<WallGlyphScript>().deactivated();
                    currentActivateGlyphs[i] = null;
                }
            }
            //dont forget to handle the current object
            selfRef.GetComponent<WallGlyphScript>().deactivated(); 
            // clear our list to reset it for the next attempt
            currentActivateGlyphs.Clear();
            //Reset index for next attempt
            index = 1;
        }
    }
}
