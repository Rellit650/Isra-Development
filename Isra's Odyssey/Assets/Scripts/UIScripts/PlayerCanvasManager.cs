using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject controlPanelPauseScreen;

    public bool pauseScreenActivated;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen.SetActive(false);
        controlPanelPauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreenActivated = !pauseScreenActivated;
        }

        if (pauseScreenActivated)
        {
            pauseScreen.SetActive(true);

        }

        if (!pauseScreenActivated)
        {
            pauseScreen.SetActive(false);
            controlPanelPauseScreen.SetActive(false);
        }
    }
}
