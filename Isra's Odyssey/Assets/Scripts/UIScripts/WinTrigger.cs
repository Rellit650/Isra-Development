using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{

    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        winPanel.SetActive(true);
    }
}
