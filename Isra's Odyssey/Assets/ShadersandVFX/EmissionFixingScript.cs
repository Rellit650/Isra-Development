using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionFixingScript : MonoBehaviour
{
    public Material burnPlants;
    // Start is called before the first frame update
    void Start()
    {
        //MaterialProperty _Emission = ShaderGUI.FindProperty("_Emission", properties);
        burnPlants.globalIlluminationFlags = MaterialGlobalIlluminationFlags.BakedEmissive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
