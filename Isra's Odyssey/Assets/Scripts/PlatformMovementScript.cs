using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementScript : MonoBehaviour
{
    
    public GameObject parent;

    public Vector3 direction;

    private int dir;
    private float magn;
    int boundsMask = 1 << 11;

    private void Start()
    {
        //Determine which direction these platforms can move 
        if (direction.x != 0)
        {
            dir = 0;
            magn = direction.x;
        }
        else if (direction.y != 0)
        {
            dir = 1;
            magn = direction.y;
        }
        else 
        {
            dir = 2;
            magn = direction.z;
        }
        
    }
    public void MoveParent() 
    {
        RaycastHit boundsHit;
        magn *= 1000;
        float clampedMagn = Mathf.Clamp(magn, -1, 1);
        if (dir == 2) 
        {
            if (!Physics.Raycast(parent.transform.position, parent.transform.forward * clampedMagn, out boundsHit, 3.5f, boundsMask))
            {
                parent.transform.position += direction;
            }
            else 
            {
                Debug.Log(boundsHit.collider.gameObject);
            }
        }
        if (dir == 1)
        {
            if (!Physics.Raycast(parent.transform.position, parent.transform.up * clampedMagn, out boundsHit, 3.5f, boundsMask))
            {
                
                parent.transform.position += direction;
            }
            else
            {
                Debug.Log(boundsHit.collider.gameObject);
            }
        }
        if (dir == 0)
        {
            if (!Physics.Raycast(parent.transform.position, parent.transform.right * clampedMagn, out boundsHit, 3.5f, boundsMask))
            {
                
                parent.transform.position += direction;
            }
            else
            {
                Debug.Log(boundsHit.collider.gameObject);
            }
        }

    }
}
