using System;
using UnityEngine;
using UnityEngine.UI;

public class MatchRecord : MonoBehaviour {

    public int ID;

    public void Init(int ID, string date, string name, string team, string enemy)
    {
        this.ID = ID;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = date;
        transform.GetChild(1).gameObject.GetComponent<Text>().text = name;
        transform.GetChild(2).gameObject.GetComponent<Text>().text = team;
        transform.GetChild(3).gameObject.GetComponent<Text>().text = enemy;
    }

    public void OnClickMatchRecord()
    {
        GameObject core = GameObject.FindGameObjectWithTag("Core");
        core.GetComponent<MatchStatisticController>().SetMatchStatisticByMatchID(ID);
    }
}