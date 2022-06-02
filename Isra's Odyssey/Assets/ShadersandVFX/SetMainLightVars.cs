using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

[ExecuteInEditMode]
public class SetMainLightVars : MonoBehaviour
{
    [SerializeField] Light mainLight;
    [SerializeField] HDAdditionalLightData testLight;

    public List<HDAdditionalLightData> SceneLights = new List<HDAdditionalLightData>(4);

    GameObject Player;
    private void Start()
    {
        Player = FindObjectOfType<BasicMovementScript>().gameObject;
        /*
        HDAdditionalLightData[] lightArray = FindObjectsOfType<HDAdditionalLightData>(true);
        foreach (HDAdditionalLightData light in lightArray) 
        {
            if (light.gameObject.activeSelf) 
            {
                if (light.type == HDLightType.Point) //|| light.type == HDLightType.Spot || light.type == HDLightType.Area) 
                {
                    if (!light.CompareTag("Lights"))
                    {
                        SceneLights.Add(light);
                    }
                    else 
                    {
                        Debug.LogError(gameObject.name);
                    }
                }
            }      
        }
        */
        updateMainDirectionalLight();
        updateClosestPointLights();
    }

    private void Update()
    {
        updateMainDirectionalLight();
        updateClosestPointLights();
        //CheckClosestLights();
    }

    private void updateMainDirectionalLight() 
    {
        Shader.SetGlobalVector("_ToonLightDirection", -transform.forward);
        Shader.SetGlobalColor("_ToonLightColor", mainLight.color);
        Shader.SetGlobalFloat("_ToonLightIntensity", mainLight.intensity);
    }

    private void updateClosestPointLights() 
    {
        HDAdditionalLightData[] lightsToUpdate = SceneLights.ToArray();//CheckClosestLights();

        //Debug.Log(SceneLights.Count);
        Vector3 playerLoc = Player.transform.position;

        if (!(lightsToUpdate.Length > 0)) 
        {
            return;
        }

        Vector3 direction = lightsToUpdate[0].transform.position - playerLoc;
        float distance = Vector3.Distance(playerLoc, lightsToUpdate[0].transform.position);

        Shader.SetGlobalVector("_NDLightDirection1", direction.normalized);
        Shader.SetGlobalColor("_NDLightColor1", lightsToUpdate[0].color);
        Shader.SetGlobalFloat("_NDLightIntensity1", lightsToUpdate[0].intensity * Mathf.Min(1f, Mathf.Max(0f,lightsToUpdate[0].range - distance)));
        
        

        if (!(lightsToUpdate.Length > 1))
        {
            return;
        }

        direction = lightsToUpdate[1].transform.position - playerLoc;
        distance = Vector3.Distance(playerLoc, lightsToUpdate[1].transform.position);

        Shader.SetGlobalVector("_NDLightDirection2", direction.normalized);
        Shader.SetGlobalColor("_NDLightColor2", lightsToUpdate[1].color);
        Shader.SetGlobalFloat("_NDLightIntensity2", lightsToUpdate[1].intensity * Mathf.Min(1f, Mathf.Max(0f, lightsToUpdate[1].range - distance)));

        if (!(lightsToUpdate.Length > 2))
        {
            return;
        }

        direction = lightsToUpdate[2].transform.position - playerLoc;
        distance = Vector3.Distance(playerLoc, lightsToUpdate[2].transform.position);

        Shader.SetGlobalVector("_NDLightDirection3", direction.normalized);
        Shader.SetGlobalColor("_NDLightColor3", lightsToUpdate[2].color);
        Shader.SetGlobalFloat("_NDLightIntensity3", lightsToUpdate[2].intensity * Mathf.Min(1f, Mathf.Max(0f, lightsToUpdate[2].range - distance)));

        if (!(lightsToUpdate.Length > 3))
        {
            return;
        }

        direction = lightsToUpdate[3].transform.position - playerLoc;
        distance = Vector3.Distance(playerLoc, lightsToUpdate[3].transform.position);

        Shader.SetGlobalVector("_NDLightDirection4", direction.normalized);
        Shader.SetGlobalColor("_NDLightColor4", lightsToUpdate[3].color);
        Shader.SetGlobalFloat("_NDLightIntensity4", lightsToUpdate[3].intensity * Mathf.Min(1f, Mathf.Max(0f, lightsToUpdate[3].range - distance)));
    }

    
    private HDAdditionalLightData[] CheckClosestLights() 
    {
        //If we dont have more than 4 scene lights then no need for sorting
        if (SceneLights.Count <= 4) 
        {
            switch (SceneLights.Count) 
            {
                case 0:
                    return new HDAdditionalLightData[0];
                case 1:
                    return new HDAdditionalLightData[] { SceneLights[0]};
                case 2:
                    return new HDAdditionalLightData[] { SceneLights[0] , SceneLights[1]};
                case 3:
                    return new HDAdditionalLightData[] { SceneLights[0] , SceneLights[1], SceneLights[2] };
                case 4:
                    return new HDAdditionalLightData[] { SceneLights[0] , SceneLights[1], SceneLights[2], SceneLights[3]};
            }
        }     

        float[] array = new float[SceneLights.Count];
        
        for (int i = 0; i < SceneLights.Count; i++)
        {
            array[i] = Vector3.Distance(SceneLights[i].transform.position, Player.transform.position);
        }
        
        lightHeapsort(ref array);

        HDAdditionalLightData[] retArr = new HDAdditionalLightData[] { SceneLights[0], SceneLights[1], SceneLights[2], SceneLights[3] };
        Vector3 playerLoc = Player.transform.position;
        Debug.DrawRay(playerLoc, SceneLights[0].transform.position - playerLoc, Color.red);
        Debug.DrawRay(playerLoc, SceneLights[1].transform.position - playerLoc, Color.red);
        Debug.DrawRay(playerLoc, SceneLights[2].transform.position - playerLoc, Color.red);
        Debug.DrawRay(playerLoc, SceneLights[3].transform.position - playerLoc, Color.red);

        return retArr;
    }

    //Heap sorting taken from https://www.geeksforgeeks.org/heap-sort/
    public void lightHeapsort(ref float[] arr)
    {
        int n = arr.Length;

        // Build heap (rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
            heapify(ref arr, n, i);

        // One by one extract an element from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            float temp = arr[0];
            HDAdditionalLightData lTemp = SceneLights[0];
            arr[0] = arr[i];
            SceneLights[0] = SceneLights[i];
            arr[i] = temp;
            SceneLights[i] = lTemp;

            // call max heapify on the reduced heap
            heapify(ref arr, i, 0);
        }
    }

    // To heapify a subtree rooted with node i which is
    // an index in arr[]. n is size of heap
    void heapify(ref float[] arr, int n, int i)
    {
        int largest = i; // Initialize largest as root
        int l = 2 * i + 1; // left = 2*i + 1
        int r = 2 * i + 2; // right = 2*i + 2

        // If left child is larger than root
        if (l < n && arr[l] > arr[largest])
            largest = l;

        // If right child is larger than largest so far
        if (r < n && arr[r] > arr[largest])
            largest = r;

        // If largest is not root
        if (largest != i)
        {
            float swap = arr[i];
            HDAdditionalLightData lSwap = SceneLights[i];
            arr[i] = arr[largest];
            SceneLights[i] = SceneLights[largest];
            arr[largest] = swap;
            SceneLights[largest] = lSwap;

            // Recursively heapify the affected sub-tree
            heapify(ref arr, n, largest);
        }
    }

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
