using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchList : MonoBehaviour {

    public GameObject matchRecordPrefab;

    public GameObject matchPanel;

    public DatabaseManager dbmanager;
    public ArrayList matchRecords;

    private void Start()
    {
        ArrayList matches = dbmanager.GetAllMatch();
        matchRecords = new ArrayList();
        foreach (Match m in matches)
        {
            AddMatchRecord(m.ID, m.date, m.name, m.team, m.enemy);
        }
    }

    public void AddMatchRecord(int ID, string date, string name, string team, string enemy)
    {
        GameObject matchRecord = Instantiate(matchRecordPrefab, new Vector3(0,0,0), Quaternion.identity);
        matchRecord.GetComponent<MatchRecord>().Init(ID, date, name, team, enemy);
        matchRecord.transform.SetParent(matchPanel.transform);
        matchRecord.transform.localScale = new Vector3(1,1,1);
        matchRecords.Add(matchRecord);
    }
}
