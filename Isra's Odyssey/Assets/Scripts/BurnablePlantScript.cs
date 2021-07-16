using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnablePlantScript : MonoBehaviour
{
    public Material BurningMat;

    public void ActivateBurnMat() 
    {
        gameObject.GetComponent<MeshRenderer>().material = BurningMat;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        StartCoroutine(destroyPlant());
    }

    IEnumerator destroyPlant() 
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

}
