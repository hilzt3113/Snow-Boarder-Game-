using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScript : MonoBehaviour
{
    public HelpPanelScript helpPanel;
    public AboutPanelScript aboutPanel;

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Help()
    {
        helpPanel.Appear();
    }

    public void About()
    {
        aboutPanel.Appear();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
