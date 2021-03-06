using UnityEngine;

public class MainController : MonoBehaviour {

    private int state = 0;

    public ModelController model;

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

    public int getState()
    {
        return state;
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
                model.InsertNewMatchAndRound();
                recordPanel.GetComponent<RecordPanel>().pc.SetupPlayerNumber();
                recordPanel.SetActive(true);
                break;
            case 4:
                model.EndRound();
                PlayerPrefs.SetInt("round", model.dbmanager.round_id);
                GetComponent<SceneControl>().OpenMatchStatistic();
                break;
        }
    }
}
