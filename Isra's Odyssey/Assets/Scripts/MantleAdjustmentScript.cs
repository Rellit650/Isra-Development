using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantleAdjustmentScript : MonoBehaviour
{
    [Range(0,1)]
    public float mantleColliderSize;
    private float boxColliderSize;

    //private Renderer mantleRenderer;

    private BoxCollider parentCollider;
    private BoxCollider mantleCollider;

    private void OnValidate()
    {
        mantleCollider = GetComponent<BoxCollider>();
        parentCollider = transform.parent.GetComponent<BoxCollider>();

        //mantleRenderer = transform.parent.GetComponent<Renderer>();

        Quaternion storedRotation = transform.parent.transform.rotation;
        transform.parent.rotation = Quaternion.identity;

        //boxColliderSize = mantleRenderer.bounds.extents.y * 2f - mantleColliderSize;

        //mantleCollider.size = new Vector3(mantleRenderer.bounds.extents.x * 2f, mantleColliderSize, mantleRenderer.bounds.extents.z * 2f);
        //mantleCollider.center = new Vector3(0f, (0f + mantleRenderer.bounds.extents.y) - (mantleColliderSize / 2f), 0f);

        //parentCollider.size = new Vector3(mantleRenderer.bounds.extents.x * 2f, boxColliderSize, mantleRenderer.bounds.extents.z * 2f);
        //parentCollider.center = new Vector3(0f, (0f - mantleRenderer.bounds.extents.y) + (boxColliderSize / 2f), 0f);

        //MantleCollider = GetComponent<BoxCollider>();
        //ParentCollider = transform.parent.GetComponent<BoxCollider>();

        mantleCollider.size = new Vector3(1f, mantleColliderSize, 1f);
        mantleCollider.center = new Vector3(0f, 0.5f - (mantleColliderSize * 0.5f), 0f);

        parentCollider.size = new Vector3(1f, 1f - mantleColliderSize, 1f);
        parentCollider.center = new Vector3(0f, mantleColliderSize * -0.5f, 0f);

        transform.parent.rotation = storedRotation;
    }
}
