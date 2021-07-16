using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject controlPanel;

    public GameObject pauseScreen;
    public GameObject controlPanelPauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        controlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("AHarropLevelDesign");
    }

    public void ControlPanel()
    {
        mainMenuPanel.SetActive(false);
        controlPanel.SetActive(true);
    }

    public void goBackToMainMenu()
    {
        controlPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainTitleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void goBackToPauseScreen()
    {
        controlPanelPauseScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void goToControlPanelPauseScreen()
    {
        controlPanelPauseScreen.SetActive(true);
    }

    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainTitleScene");
    }
}
