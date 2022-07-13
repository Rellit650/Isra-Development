using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerInteraction : MonoBehaviour
{
    BasicMovementScript playerRef;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GetComponentInParent<BasicMovementScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mantle")) 
        {
            Debug.Log("Hit Mantle");
            Vector3 hitPoint = other.ClosestPoint(gameObject.transform.position);
            float height = other.transform.parent.position.y + (other.transform.parent.localScale.y * 0.5f);
            playerRef.BeginMantle(hitPoint, height);
        }
    }
}
