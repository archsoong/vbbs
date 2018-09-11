using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PanelCenter : MonoBehaviour {

    public GameObject[] arrayA;
    public GameObject[] arrayB;
    public GameObject[] arraySkill;

    public ModelController model;

    public void SetupPlayerNumber()
    {
        clearPlayerNumber();
        for (int i = 0; i < model.teamPlayers.Count; i++)
        {
            arrayA[i].SetActive(true);
            arrayA[i].GetComponentInChildren<Text>().text = model.teamPlayers[i].ToString();
        }
        
        for (int i = 0; i < model.enemyPlayers.Count; i++)
        {
            arrayB[i].SetActive(true);
            arrayB[i].GetComponentInChildren<Text>().text = model.enemyPlayers[i].ToString();
        }
    }

    private void clearPlayerNumber()
    {
        foreach (GameObject p in arrayA)
        {
            p.SetActive(false);
        }

        foreach (GameObject p in arrayB)
        {
            p.SetActive(false);
        }
    }

    public void selectPA(GameObject obj)
    {
        clearPA();
        Image img = obj.GetComponent<Image>();
        img.sprite = Resources.Load("btn_playerSelect-01", typeof(Sprite)) as Sprite;
        Text txt = obj.GetComponentInChildren<Text>();
        model.team_player = Convert.ToInt32(txt.text);
    }

    public void clearPA()
    {
        if(model.team_player == 0)
        {
            return;
        }

        for(int i = 0; i < arrayA.Length; i++)
        {
            if(arrayA[i].GetComponentInChildren<Text>().text == model.team_player.ToString())
            {
                Image img = arrayA[i].GetComponent<Image>();
                img.sprite = Resources.Load("btn_playerA-01", typeof(Sprite)) as Sprite;
                break;
            }
        }
    }

    public void selectPB(GameObject obj)
    {
        clearPB();
        Image img = obj.GetComponent<Image>();
        img.sprite = Resources.Load("btn_playerSelect-01", typeof(Sprite)) as Sprite;
        Text txt = obj.GetComponentInChildren<Text>();
        model.enemy_player = Convert.ToInt32(txt.text);
    }

    public void clearPB()
    {
        if (model.enemy_player == 0)
        {
            return;
        }

        for (int i = 0; i < arrayB.Length; i++)
        {
            if (arrayB[i].GetComponentInChildren<Text>().text == model.enemy_player.ToString())
            {
                Image img = arrayB[i].GetComponent<Image>();
                img.sprite = Resources.Load("btn_playerB-01", typeof(Sprite)) as Sprite;
                break;
            }
        }
    }

    public void selectSkill(int skill)
    {
        clearSkillButton();
        Image img = arraySkill[skill].GetComponent<Image>();
        if (skill == 0)
        {
            img.sprite = Resources.Load("btn_ServeSelect-01", typeof(Sprite)) as Sprite;
        }
        else if (skill == 1)
        {
            img.sprite = Resources.Load("btn_AttackSelect-01", typeof(Sprite)) as Sprite;
        }
        else if (skill == 2)
        {
            img.sprite = Resources.Load("btn_BackSelect-01", typeof(Sprite)) as Sprite;
        }

        model.skill = skill;
        model.updatePanel();
    }

    public void clearSkillButton()
    {
        Image img0 = arraySkill[0].GetComponent<Image>();
        img0.sprite = Resources.Load("btn_Serve-01", typeof(Sprite)) as Sprite;
        Image img1 = arraySkill[1].GetComponent<Image>();
        img1.sprite = Resources.Load("btn_Attack-01", typeof(Sprite)) as Sprite;
        Image img2 = arraySkill[2].GetComponent<Image>();
        img2.sprite = Resources.Load("btn_Back-01", typeof(Sprite)) as Sprite;
    }
}
