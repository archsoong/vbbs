using System;
using UnityEngine;
using UnityEngine.UI;

public class MatchSetting : MonoBehaviour {

    public GameObject status1;
    public GameObject status2;

    public Text date;
    public Text time;
    public Text location;
    public Text match;
    public Text team;
    public Text enemy;

    public Image match3;
    public Image match5;
    public Image Rule15;
    public Image Rule25;
    
    private int matchStyle = 0;
    private int ruleStyle = 0;

    public ModelController model;
    public MainController controller;

    void Start()
    {
        status1.SetActive(false);
        status2.SetActive(false);
        DateTime today = DateTime.Now;
        date.text = today.Date.ToShortDateString();
        time.text = today.TimeOfDay.Hours + " : " + today.TimeOfDay.Minutes;
    }

    public void SelectMatchStyle(int style)
    {
        if (style == 3)
        {
            match3.sprite = Resources.Load("match3-02", typeof(Sprite)) as Sprite;
            match5.sprite = Resources.Load("match5-01", typeof(Sprite)) as Sprite;
            matchStyle = style;
        }
        else if (style == 5)
        {
            match3.sprite = Resources.Load("match3-01", typeof(Sprite)) as Sprite;
            match5.sprite = Resources.Load("match5-02", typeof(Sprite)) as Sprite;
            matchStyle = style;
        }
    }

    public void SelectRuleStyle(int style)
    {
        if (style == 15)
        {
            Rule15.sprite = Resources.Load("score15-02", typeof(Sprite)) as Sprite;
            Rule25.sprite = Resources.Load("score25-01", typeof(Sprite)) as Sprite;
            ruleStyle = style;
        }
        else if (style == 25)
        {
            Rule15.sprite = Resources.Load("score15-01", typeof(Sprite)) as Sprite;
            Rule25.sprite = Resources.Load("score25-02", typeof(Sprite)) as Sprite;
            ruleStyle = style;
        }
    }

    public void SubmitMatch()
    {
        string s_date = date.text;
        string s_time = time.text;
        string s_location = location.text;
        string s_match = match.text;
        string s_team = team.text;
        string s_enemy = enemy.text;

        if (s_date == "" || s_time == "" || s_location == "" || s_match == "" || s_team == "" || s_enemy == "")
        {
            status2.SetActive(false);
            status1.SetActive(true);
            return;
        }
        else if (matchStyle == 0 || ruleStyle == 0)
        {
            status1.SetActive(false);
            status2.SetActive(true);
            return;
        }

        model.AddNewMatch(s_date, s_time, s_location, s_match, s_team, s_enemy, matchStyle, ruleStyle);
        controller.NextState();
    }
}
