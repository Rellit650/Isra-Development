using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullFunctionality : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerAbilitiesScript>())
    }
}
