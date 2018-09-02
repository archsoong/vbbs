using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PanelBottomUp : MonoBehaviour {
    public GameObject[] arrayReason;
    public ModelController model;

    public void selectReason(int score_reason)
    {
        clearReasonButton();
        Image img = arrayReason[score_reason].GetComponent<Image>();
        if (score_reason == 0)
        {
            img.sprite = Resources.Load("btn_ServeGetSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 1 ;
        }
        else if (score_reason == 1)
        {
            img.sprite = Resources.Load("btn_ErrorGetSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 6;
        }
        else if (score_reason == 2)
        {
            img.sprite = Resources.Load("btn_AttackGetSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 2;
        }
        else if (score_reason == 3)
        {
            img.sprite = Resources.Load("btn_BlockErrorGetSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 7;
        }
        else if (score_reason == 4)
        {
            img.sprite = Resources.Load("btn_ErrorGetSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 6;
        }
        else if (score_reason == 5)
        {
            img.sprite = Resources.Load("btn_ErrorGetSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 4;
        }
        else if (score_reason == 6)
        {
            img.sprite = Resources.Load("btn_BlockGetSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 3;
        }
        else if (score_reason == 7)
        {
            img.sprite = Resources.Load("btn_ReserveLoseSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 13;
        }
        else if (score_reason == 8)
        {
            img.sprite = Resources.Load("btn_ErrorLoseSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 14;
        }
        else if (score_reason == 9)
        {
            img.sprite = Resources.Load("btn_ErrorLoseSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 9;
        }
        else if (score_reason == 10)
        {
            img.sprite = Resources.Load("btn_BlockLoseSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 10;
        }
        else if (score_reason == 11)
        {
            img.sprite = Resources.Load("btn_DefendLoseSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 12;
        }
        else if (score_reason == 12)
        {
            img.sprite = Resources.Load("btn_BlockErrorLoseSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 11;
        }
        else if (score_reason == 13)
        {
            img.sprite = Resources.Load("btn_ErrorLoseSelect-01-01", typeof(Sprite)) as Sprite;
            model.score_reason = 14;
        }


    }

    public void clearReasonButton()
    {
        Image img0 = arrayReason[0].GetComponent<Image>();
        img0.sprite = Resources.Load("btn_ServeGet-01", typeof(Sprite)) as Sprite;
        Image img1 = arrayReason[1].GetComponent<Image>();
        img1.sprite = Resources.Load("btn_ErrorGet-01", typeof(Sprite)) as Sprite;
        Image img2 = arrayReason[2].GetComponent<Image>();
        img2.sprite = Resources.Load("btn_AttackGet-01", typeof(Sprite)) as Sprite;
        Image img3 = arrayReason[3].GetComponent<Image>();
        img3.sprite = Resources.Load("btn_BlockErrorGet-01", typeof(Sprite)) as Sprite;
        Image img4 = arrayReason[4].GetComponent<Image>();
        img4.sprite = Resources.Load("btn_ErrorGet-01", typeof(Sprite)) as Sprite;
        Image img5 = arrayReason[5].GetComponent<Image>();
        img5.sprite = Resources.Load("btn_ErrorGet-01", typeof(Sprite)) as Sprite;
        Image img6 = arrayReason[6].GetComponent<Image>();
        img6.sprite = Resources.Load("btn_BlockGet-01", typeof(Sprite)) as Sprite;
        Image img7 = arrayReason[7].GetComponent<Image>();
        img7.sprite = Resources.Load("btn_ReserveLose-01", typeof(Sprite)) as Sprite;
        Image img8 = arrayReason[8].GetComponent<Image>();
        img8.sprite = Resources.Load("btn_ErrorLose-01", typeof(Sprite)) as Sprite;
        Image img9 = arrayReason[9].GetComponent<Image>();
        img9.sprite = Resources.Load("btn_ErrorLose-01", typeof(Sprite)) as Sprite;
        Image img10 = arrayReason[10].GetComponent<Image>();
        img10.sprite = Resources.Load("btn_BlockLose-01", typeof(Sprite)) as Sprite;
        Image img11 = arrayReason[11].GetComponent<Image>();
        img11.sprite = Resources.Load("btn_DefendLose-01", typeof(Sprite)) as Sprite;
        Image img12 = arrayReason[12].GetComponent<Image>();
        img12.sprite = Resources.Load("btn_BlockErrorLose-01", typeof(Sprite)) as Sprite;
        Image img13 = arrayReason[13].GetComponent<Image>();
        img13.sprite = Resources.Load("btn_ErrorLose-01", typeof(Sprite)) as Sprite;
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
