using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGlyphScript : MonoBehaviour
{
    public int glyphID;
    public Material activatedMat;
    public Material unactivatedMat;


    private WallGlyphManager PuzzleManager;
    private SphereCollider colliderRef;
    // Start is called before the first frame update
    void Start()
    {
       
        PuzzleManager = FindObjectOfType<WallGlyphManager>();
        colliderRef = gameObject.GetComponent<SphereCollider>();
    }

    public void activated() 
    {
        //We only handle our own collider and materials the puzzle logic is worked out in the wallGlyphManager script
        gameObject.GetComponent<MeshRenderer>().material = activatedMat;

        //Disable collider to not have any interaction if we are activated
        colliderRef.enabled = false;

        //Send data to puzzle manager to see if the puzzle is valid
        PuzzleManager.checkGlyph(glyphID,gameObject);
    }

    public void deactivated() 
    {
        //return to unactivated state
        gameObject.GetComponent<MeshRenderer>().material = unactivatedMat;

        //re-enable our collider
        colliderRef.enabled = true;
    }  
}
