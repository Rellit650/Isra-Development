using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetMainLightVars : MonoBehaviour
{
    [SerializeField] Light mainLight;
    private void Update()
    {
        Shader.SetGlobalVector("_ToonLightDirection", -transform.forward);
        Shader.SetGlobalColor("_ToonLightColor", mainLight.color);
        Shader.SetGlobalFloat("_ToonLightIntensity", mainLight.intensity);
    }
}
