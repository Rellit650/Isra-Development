using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionScript : MonoBehaviour
{
    private GameObject playerObject;
    private PlayerAbilitiesScript playerAbilityRef;
    private RaycastHit hit;
    private MeshRenderer mr;
    [HideInInspector]
    public bool Aggroed;
    public float DetectionRange;
    public LayerMask raycastTargets;

    private void Start()
    {
        playerObject = FindObjectOfType<PlayerTriggerInteraction>().gameObject;
        playerAbilityRef = FindObjectOfType<PlayerAbilitiesScript>();
        mr = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
       
        Vector3 temp = playerObject.transform.position;
        temp.y += 1;

        Debug.DrawRay(transform.position, temp - transform.position, Color.red);
        if (Physics.Raycast(transform.position, temp - transform.position, out hit, DetectionRange, raycastTargets.value))
        {
            if (hit.collider.gameObject == playerObject)
            {
                Debug.Log("Hit player");
                if (playerAbilityRef.GetShroudMode())
                {
                    //if we are in shroud mode then detection does not happen
                    Aggroed = false;
                    mr.material.color = Color.green;
                }
                else
                {
                    Aggroed = true;
                    mr.material.color = Color.red;
                }
            }
            else 
            {
                mr.material.color = Color.green;
            }
        }
        else 
        {
            mr.material.color = Color.green;
        }
    }
}
