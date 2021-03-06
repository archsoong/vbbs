using System.Collections;
using UnityEngine;
using System;

public class ModelController : MonoBehaviour {

    // Match Data
    public string date;
    public string time;
    public string location;
    public string matchName;
    public string team;
    public string enemy;
    public int matchStyle;
    public int ruleStyle;

    // Round Data
    public int round;
    public int teamScore;
    public int enemyScore;    

    // Ball Data
    public float start_X = 0;
    public float start_Y = 0;
    public float end_X = 0;
    public float end_Y = 0;
    public int attacker = 0;
    public int team_player = 0;
    public int enemy_player = 0;
    public int skill = -1;
    public int good = 0;
    public int score = 0;
    public int score_reason;
    public int team_change;
    public int team_switch;
    public int team_position;
    public int team_score = 0;
    public int enemy_score = 0;
    public int enemy_change;
    public int enemy_switch;
    public int enemy_position;

    public GameObject[] arrayPanel;
    public PanelCenter pc;

    public ArrayList teamPlayers;
    public ArrayList enemyPlayers;

    public DatabaseManager dbmanager;

    private void Start()
    {
        for (int i = 0; i < arrayPanel.Length; i++)
        {
            arrayPanel[i].SetActive(false);
        }
    }

    public void resetPanelBottomUp()
    {
        for (int i = 0; i < arrayPanel.Length; i++)
        {
            arrayPanel[i].SetActive(false);
        }
    }

    public void AddNewMatch(string date, string time, string location, string matchName, string team, string enemy, int matchStyle, int ruleStyle)
    {
        this.date = date;
        this.time = time;
        this.location = location;
        this.matchName = matchName;
        this.team = team;
        this.enemy = enemy;
        this.matchStyle = matchStyle;
        this.ruleStyle = ruleStyle;
    }

    public void InsertNewMatchAndRound()
    {
        dbmanager.InsertNewMatch(date, time, location, matchName, team, enemy, matchStyle, ruleStyle);
        dbmanager.InsertNewRound();

        Debug.Log("Insert new match and round");
    }

    public void EndRound()
    {
        dbmanager.SetRoundScore(teamScore,enemyScore);
    }

    public void SetNewPlayerData(string team, ArrayList players)
    {
        if (team == "team")
        {
            teamPlayers = players;
        }
        else if (team == "enemy")
        {
            enemyPlayers = players;
        }
    }

    public void Undo()
    {
        dbmanager.RemoveLastBall();
    }


    public string encode()
    {
        string values = "";
        DateTime today = DateTime.Now;
        string deltaTime = "'" + today.TimeOfDay.Hours + ":" + today.TimeOfDay.Minutes + ":" + today.TimeOfDay.Seconds + "'";
        values = values + deltaTime + ",";
        values = values + start_X + ",";
        values = values + start_Y + ",";
        values = values + end_X + ",";
        values = values + end_Y + ",";
        values = values + attacker + ",";
        values = values + team_player + ",";
        values = values + enemy_player + ",";
        values = values + skill + ",";
        values = values + good + ",";
        values = values + score + ",";
        values = values + score_reason + ",";
        values = values + team_change + ",";
        values = values + team_switch + ",";
        values = values + team_position + ",";
        values = values + team_score + ",";
        values = values + enemy_score + ",";
        values = values + enemy_change + ",";
        values = values + enemy_switch + ",";
        values = values + enemy_position + ",";

        Debug.Log(values);
        return values;
    }

	public void updatePanel () {
        for (int i = 0; i < arrayPanel.Length; i++ )
        {
            arrayPanel[i].SetActive(false);
        }
        if (attacker == 1)
        {
            strike();
        }
        else if (attacker == 2)
        {
            defend();
        }
    }

    void strike() {
        Debug.Log("score:" + score + " attacker:" + attacker + "skill:"+skill);
        switch (skill)
        {
            case 0:
                if (score == 1)
                {
                    ((GameObject)arrayPanel[0]).SetActive(true);
                }
                else if (score == 2)
                {
                    score_reason = 8;
                }
                break;
            case 1:
                if (score == 1)
                {
                    ((GameObject)arrayPanel[2]).SetActive(true);
                }
                else if (score == 2)
                {
                    ((GameObject)arrayPanel[3]).SetActive(true);
                }
                break;
            case 2:
                if (score == 1)
                {
                    score_reason = 6;
                }
                else if (score == 2)
                {
                score_reason = 14;
                }
                break;
                
        }
    }

    void defend()
    {
        Debug.Log("score:" + score + " attacker:" + attacker);
        switch (skill)
        {
            case 0:
                if (score == 1)
                {
                    score_reason = 5;
                }
                else if(score == 2)
                {
                    ((GameObject)arrayPanel[1]).SetActive(true);
                }
                break;
            case 1:
                if (score == 1)
                {
                    ((GameObject)arrayPanel[4]).SetActive(true);
                }
                else if (score == 2)
                {
                    ((GameObject)arrayPanel[5]).SetActive(true);
                }
                break;
            case 2:
                if (score == 1)
                {
                    score_reason = 6;
                }
                else if (score == 2)
                {
                    score_reason = 14;
                }
                break;
        }
    }
}

