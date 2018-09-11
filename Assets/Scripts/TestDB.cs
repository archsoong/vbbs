using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDB : MonoBehaviour {

    DatabaseManager dbmanager;
    public Text matchText;

    public GameObject simpleText;
    public GameObject ballList;

    private void Start()
    {
        dbmanager = GetComponent<DatabaseManager>();
        ArrayList matchList = dbmanager.GetAllMatch();

        string matchNo = "";

        foreach (Match m in matchList)
        {
            matchNo += m.ID;
            matchNo += ", ";
        }

        matchText.text = matchNo;

        ArrayList balls = dbmanager.ReadDBDataFromRound(dbmanager.round_id);

        foreach (Ball b in balls)
        {
            GameObject g = Instantiate(simpleText, new Vector3(0, 0, 0), Quaternion.identity);
            
            string t = "attacker: " + b.attacker + " ,teamplayer: " + b.team_player + ",enemyplayer: " + b.enemy_player + ",skill: " + b.skill + ",good: " + b.good + ",score: " + b.score + ",reason: " + b.score_reason;

            g.GetComponent<Text>().text = t;
            g.transform.SetParent(ballList.transform);
            g.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void deleteMatch()
    {
        dbmanager.DeleteMatch();
    }
}
