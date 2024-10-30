using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPanelScript : MonoBehaviour
{
    public GameObject aboutPanel;
    public void Appear()
    {
        aboutPanel.SetActive(true);
    }
    public void Close()
    {
        aboutPanel.SetActive(false);
    }
}
