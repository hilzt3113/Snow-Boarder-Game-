using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanelScript : MonoBehaviour
{
    public GameObject helpPanel;
    public void Appear()
    {
        helpPanel.SetActive(true);
    }
    public void Close()
    {
        helpPanel.SetActive(false);
    }
}
