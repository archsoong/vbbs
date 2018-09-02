using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    private int state = 0;

    public GameObject matchSettingPanel;
    public GameObject pickAPanel;
    public GameObject pickBPanel;
    public GameObject recordPanel;

    public GameObject PlaneL;
    public GameObject PlaneR;

    private void Start()
    {
        pickAPanel.SetActive(false);
        pickBPanel.SetActive(false);
        recordPanel.SetActive(false);
    }

    public void NextState()
    {
        state += 1;
        CheckState();
    }

    public void PreviousState()
    {
        state -= 1;
        CheckState();
    }

    public void CheckState()
    {
        matchSettingPanel.SetActive(false);
        pickAPanel.SetActive(false);
        pickBPanel.SetActive(false);
        recordPanel.SetActive(false);

        switch (state)
        {
            case 1:
                pickAPanel.GetComponent<PlayerSelectPanel>().ResetArray();
                pickAPanel.SetActive(true);
                break;
            case 2:
                pickBPanel.GetComponent<PlayerSelectPanel>().ResetArray();
                pickBPanel.SetActive(true);
                break;
            case 3:
                recordPanel.SetActive(true);
                break;
        }
    }
}
