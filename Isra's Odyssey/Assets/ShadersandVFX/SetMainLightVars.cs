using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SetMainLightVars : MonoBehaviour
{
    [SerializeField] Light mainLight;
    [SerializeField] HDAdditionalLightData mainLightData;

    void Start()
    {
        //mainLightData.range
        Shader.SetGlobalVector("_MainLightDirection", mainLight.transform.forward * -1);
        Debug.Log("Set Direction to: " + mainLight.transform.forward);
        Shader.SetGlobalFloat("_MainLightAttenuation", mainLight.range * 10);
        Debug.Log("Set Attenuation to: " + mainLight.range);
        Shader.SetGlobalColor("_MainLightColor", mainLight.color);
        Debug.Log("Set Color to: " + mainLight.color);
    }
}
