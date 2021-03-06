using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
[System.Serializable]
public class Dialogue : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] sentences;
}
