using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrowthScript : MonoBehaviour
{
    [System.Flags]
    public enum Axis
    {
        x = 1,
        y = 2,
        z = 4
    }

    public float Growth;
    public float deltaTime;
    public Axis axisToGrow;
    public GameObject ObjectToGrow;

    private Vector3 initialScale;
    private Vector3 growedScale;
    private float timer = 0f;
    private float decayTimer = 0f;
    private bool grown = false;
    private bool smallest = true;
    private bool coroutineRunning = false;

    private void Start()
    {
        initialScale = transform.localScale;
        growedScale = initialScale;

        if (axisToGrow.HasFlag(Axis.x))
        {
            growedScale.x += Growth;
        }
        if (axisToGrow.HasFlag(Axis.y))
        {
            growedScale.y += Growth;
        }
        if (axisToGrow.HasFlag(Axis.z))
        {
            growedScale.z += Growth;
        }
    }

    private void FixedUpdate()
    {
        if (!grown && !coroutineRunning && !smallest) 
        {
            decayTimer += Time.deltaTime;
            if (decayTimer >= 1f) 
            {
                Debug.Log("Decay coroutine call");
                StartCoroutine(SmoothDecayScale());
            }
        }
    }

    public void Grow() 
    {
        if (grown)
            return;
        decayTimer = 0f;
        if (!coroutineRunning)
        {
            Debug.Log("Grow coroutine call");
            StartCoroutine(SmoothScale());
        }
    }

    IEnumerator SmoothScale() 
    {
        coroutineRunning = true;
        timer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(initialScale, growedScale, timer / deltaTime);
        if (timer >= deltaTime)
        {
            grown = true;
        }
        yield return new WaitForEndOfFrame();
        coroutineRunning = false;
    }
    IEnumerator SmoothDecayScale()
    {
        coroutineRunning = true;
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0f;
            smallest = true;
        }
        else 
        {
            smallest = true;
        }
        transform.localScale = Vector3.Lerp(initialScale, growedScale, timer / deltaTime);
        yield return new WaitForEndOfFrame();
        coroutineRunning = false;
    }

}
