using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class FlareAbilityScript : MonoBehaviour
{
    public float LifeSpan = 10f;
    public float rotateSpeed = 0.3f;
    public LensFlareDataSRP srpData;

    float internalTimer = 0.0f;
    bool hitSomething = false;
    // Start is called before the first frame update


    /*
     
     */
    void Start()
    {
        srpData.elements[1].rotation = 0;
        srpData.elements[2].rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer += Time.deltaTime;
        if (internalTimer >= LifeSpan) 
        {
            HandleDestroy();
        }

        srpData.elements[1].rotation += rotateSpeed; 
        srpData.elements[2].rotation -= rotateSpeed; 
    }

    void HandleDestroy() 
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    IEnumerator FlareDestroyTimer() 
    {
        hitSomething = true;
        yield return new WaitForSeconds(25f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hitSomething) 
        {
            StartCoroutine(FlareDestroyTimer());
        }
    }
}