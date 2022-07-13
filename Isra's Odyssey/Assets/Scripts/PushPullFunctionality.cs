using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullFunctionality : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerAbilitiesScript>()) 
        {
            other.GetComponent<PlayerAbilitiesScript>().SetPushPullRef(gameObject);
            other.GetComponent<BasicMovementScript>().SetPushPullRef(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerAbilitiesScript>())
        {
            other.GetComponent<PlayerAbilitiesScript>().SetPushPullRef(null);
            other.GetComponent<BasicMovementScript>().SetPushPullRef(null);
        }
    }
}
