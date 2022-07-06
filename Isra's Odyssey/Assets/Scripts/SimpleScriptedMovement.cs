using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScriptedMovement : MonoBehaviour
{
    public float yStart;
    public float yEnd;
    public float speed = 0.1f;
    Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yEnd, transform.position.z), speed);
        if (transform.position.y - yEnd < 0.05f) 
        {
            transform.position = new Vector3(transform.position.x,yStart,transform.position.z);
        }
    }
}
