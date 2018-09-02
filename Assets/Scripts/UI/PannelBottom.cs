using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PannelBottom : MonoBehaviour {
    public GameObject[] arrayPoint;
    public ModelController model;
    public GameObject good;
    public GameObject check;
    public GameObject scoreA;
    public GameObject scoreB;
    public PanelCenter pc;

    public void selectCheckClear()
    {
        clearPointButton();
        Image img = good.GetComponent<Image>();
        img.sprite = Resources.Load("btn_GoodBall-01", typeof(Sprite)) as Sprite;
        pc.clearPA();
        pc.clearPB();
        pc.clearSkillButton();
        for (int i = 0; i < model.arrayPanel.Length; i++)
        {
            GameObject p = (GameObject) model.arrayPanel[i];
            p.SetActive(false);
        }

        model.good = 0;
        model.score = 0;
        model.attacker = 0;
    }

    public void selectCheck()
    {

        if (model.score == 1)
        {
            model.team_score ++;
            Text txt = scoreA.GetComponent<Text>();
            txt.text = model.team_score.ToString();

        }
        else if (model.score == 2)
        {
            model.enemy_score ++;
            Text txt = scoreB.GetComponent<Text>();
            txt.text = model.enemy_score.ToString();
        }


 
    }

    public void selectPoint(int score)
    {
        clearPointButton();
        Image img = arrayPoint[score].GetComponent<Image>();

        if (score == 1)
        {
            img.sprite = Resources.Load("btn_PointGetSelect-01", typeof(Sprite)) as Sprite;
        }
        else if (score == 2)
        {
            img.sprite = Resources.Load("btn_PointLoseSelect-01", typeof(Sprite)) as Sprite;
        }

        model.score = score;
        model.updatePanel();   //刷新跳出視窗
    }

    public void clearPointButton()
    {
        Image img1 = arrayPoint[1].GetComponent<Image>();
        img1.sprite = Resources.Load("btn_PointGet-01", typeof(Sprite)) as Sprite;
        Image img2 = arrayPoint[2].GetComponent<Image>();
        img2.sprite = Resources.Load("btn_PointLose-01", typeof(Sprite)) as Sprite;
    }

    public void selectGoodBall()
    {
        Image img = good.GetComponent<Image>();
        if(img.sprite.name == "btn_GoodBall-01")
        {
            img.sprite = Resources.Load("btn_GoodBallSelect-01", typeof(Sprite)) as Sprite;
            model.good = 1;
        }
        else
        {
            img.sprite = Resources.Load("btn_GoodBall-01", typeof(Sprite)) as Sprite;
            model.good = 0;
        }
    }
}
