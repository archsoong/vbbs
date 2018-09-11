using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStatisticController : MonoBehaviour {

    private DatabaseManager dbmanager;
    private CalcSystem calc;

    public GameObject matchList;

    public GameObject teamServeBar;
    public GameObject enemyServeBar;
    public GameObject teamAttackBar;
    public GameObject enemyAttackBar;
    public GameObject teamScoreTable;
    public GameObject enemyScoreTable;
    public GameObject teamPie;
    public GameObject enemyPie;
    public GameObject bottomPanel;

    private void Start()
    {
        dbmanager = GetComponent<DatabaseManager>();
        calc = GetComponent<CalcSystem>();
    }

    public void SetMatchStatisticByMatchID(int ID)
    {
        int roundID = dbmanager.GetRoundIDFromMatch(ID);
        calc.CalculateData(roundID);
        matchList.SetActive(false);
        OpenMatchStatisticUI();
    }

    public void OpenMatchStatisticUI()
    {
        teamServeBar.SetActive(true);
        enemyServeBar.SetActive(true);
        teamAttackBar.SetActive(true);
        enemyAttackBar.SetActive(true);
        teamScoreTable.SetActive(true);
        enemyScoreTable.SetActive(true);
        teamPie.SetActive(true);
        enemyPie.SetActive(true);
    }
}
