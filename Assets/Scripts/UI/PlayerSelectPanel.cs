using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectPanel : MonoBehaviour
{
    public GameObject[] arrayPA;
    public GameObject[] arrayCA;
    public GameObject status;

    private ArrayList playerArray;

    public ModelController model;
    public MainController controller;

    public void PickPlayer(int playerNo)
    {
        Image img = arrayPA[playerNo].GetComponent<Image>();

        if (playerArray.Count < 8)
        {
            img.sprite = Resources.Load("btn_playerSelect-01", typeof(Sprite)) as Sprite;
            playerArray.Add(playerNo + 1);
            arrayCA[playerArray.Count-1].GetComponentInChildren<Text>().text = (playerNo + 1).ToString();
        }
    }

    public void ResetPlayerSelection(string team)
    {
        foreach (GameObject obj in arrayPA)
        {
            Image img = obj.GetComponent<Image>();
            if (team == "team")
            {
                img.sprite = Resources.Load("btn_playerA-01", typeof(Sprite)) as Sprite;
            }
            else if(team == "enemy")
            {
                img.sprite = Resources.Load("btn_playerB-01", typeof(Sprite)) as Sprite;
            }
        }

        int no = 1;

        foreach (GameObject obj in arrayCA)
        {
            Text text = obj.GetComponentInChildren<Text>();
            text.text = no.ToString();
            no++;
        }

        status.gameObject.SetActive(false);
        ResetArray();
    }


    public void SubmitPlayerData(string team)
    {
        if (playerArray.Count < 6)
        {
            status.SetActive(true);
            return;
        }

        model.SetNewPlayerData(team, playerArray);
        controller.NextState();
    }

    public void ResetArray()
    {
        playerArray = new ArrayList();
    }
}
