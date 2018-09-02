using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcSystem : MonoBehaviour {

    public DatabaseManager dbm;

    public PlayerBoard team_serve_pb;
    public PlayerBoard enemy_serve_pb;
    public PlayerBoard team_attack_pb;
    public PlayerBoard enemy_attack_pb;

    public ScoreTable team_score_tbl;
    public ScoreTable enemy_score_tbl;

    public PieChartMeshController teamScore;
    public PieChartMeshController teamFail;
    public PieChartMeshController enemyScore;
    public PieChartMeshController enemyFail;

    public PieSideBoard teamPieSideBoard;
    public PieSideBoard enemyPieSideBoard;

    public Team team;
    public Team enemy;

    void Start()
    {
        CalculateData(); // Testing use
    }

    public void CalculateData()
    {
        ArrayList balls = dbm.ReadDBDataFromMatch(1);

        team = new Team();
        enemy = new Team();

        foreach (Ball b in balls)
        {
            AddBall(b);
        }

        // PrintScore();

        team_serve_pb.total = team.t_serve_score;
        enemy_serve_pb.total = enemy.t_serve_score;
        team_attack_pb.total = team.t_attack_score;
        enemy_attack_pb.total = enemy.t_attack_score;

        // Player Board
        foreach (Player p in team.players)
        {
            team_serve_pb.GeneratePlayerResult(p, team, 0);
            team_attack_pb.GeneratePlayerResult(p, team, 1);

            team_score_tbl.GeneratePlayerRecord(p);  // Score Table
        }

        team_score_tbl.GenerateTeamRecord();        // Score Table
        teamScore.InitPieChart(team, 4);            // Pie for Score
        teamFail.InitPieChart(team, 6);             // Pie for Fail
        teamPieSideBoard.SetupPanel(team);

        // Player Board
        foreach (Player e in enemy.players)
        {
            enemy_serve_pb.GeneratePlayerResult(e, enemy, 0);
            enemy_attack_pb.GeneratePlayerResult(e, enemy, 1);
            enemy_score_tbl.GeneratePlayerRecord(e);  // Score Table
        }

        enemy_score_tbl.GenerateTeamRecord();       // Score Table
        enemyScore.InitPieChart(enemy, 4);          // Pie for Score
        enemyFail.InitPieChart(enemy, 6);           // Pie for Fail
        enemyPieSideBoard.SetupPanel(team);

    }

    public void AddBall(Ball b)
    {

        Player p = GetPlayer(team, b.team_player);
        Player e = GetPlayer(enemy, b.enemy_player);

        switch (b.score_reason)
        {
            case 0:
                break;
            case 1: // �o�y�o��
                p.serve_score++;
                e.duel_fail++;
                team.t_serve_score++;
                enemy.t_duel_fail++;
                break;
            case 2:
                p.attack_score++;
                e.defend_fail++;
                team.t_attack_score++;
                enemy.t_defend_fail++;
                break;
            case 3:
                p.block_score++;
                e.attack_fail++;
                team.t_block_score++;
                enemy.t_attack_fail++;
                break;
            case 4:
                p.enemy_fail++;
                team.t_enemy_fail++;
                e.attack_fail++;
                enemy.t_attack_fail++;
                break;
            case 5:
                p.enemy_fail++;
                team.t_enemy_fail++;
                e.serve_fail++;
                team.t_serve_fail++;
                break;
            case 6:
                p.enemy_fail++;
                team.t_enemy_fail++;
                e.team_fail++;
                enemy.t_team_fail++;
                break;
            case 7:
                p.attack_score++;
                team.t_attack_score++;
                e.block_fail++;
                enemy.t_block_fail++;
                break;
            case 8:
                p.serve_fail++;
                team.t_serve_fail++;
                e.enemy_fail++;
                enemy.t_enemy_fail++;
                break;
            case 9:
                p.attack_fail++;
                team.t_attack_fail++;
                e.enemy_fail++;
                enemy.t_enemy_fail++;
                break;
            case 10:
                p.attack_fail++;
                team.t_attack_fail++;
                e.block_score++;
                enemy.t_block_score++;
                break;
            case 11:
                p.block_fail++;
                team.t_block_fail++;
                e.attack_score++;
                enemy.t_attack_score++;
                break;
            case 12:
                p.defend_fail++;
                team.t_defend_fail++;
                e.attack_score++;
                enemy.t_attack_score++;
                break;
            case 13:
                p.duel_fail++;
                team.t_duel_fail++;
                e.serve_score++;
                enemy.t_serve_score++;
                break;
            case 14:
                p.team_fail++;
                team.t_team_fail++;
                p.enemy_fail++;
                enemy.t_enemy_fail++;
                break;
        }
    }

    public Player GetPlayer(Team team, int player_no)
    {
        foreach(Player p in team.players) {
            if (p.number == player_no) {
                return p;
            }
        }

        Player new_p = new Player();
        new_p.number = player_no;

        team.players.Add(new_p);

        return new_p;
    }

    public void PrintScore()
    {
        Debug.Log("attack_score " + team.t_attack_score + " serve_score " + team.t_serve_score + " block_score " + team.t_block_score + " block_fail " + team.t_block_fail + " duel_fail " + team.t_duel_fail + " defend_fail " + team.t_defend_fail + " enemy_fail " + team.t_enemy_fail + " team_fail " + team.t_team_fail);

        int i = 1;
        foreach (Player p in team.players)
        {
            Debug.Log(i + " attack_score " + p.attack_score + " serve_score " + p.serve_score + " block_score " + p.block_score + " block_fail " + p.block_fail + " duel_fail " + p.duel_fail + " defend_fail " + p.defend_fail + " enemy_fail " + p.enemy_fail + " team_fail " + p.team_fail);
            i++;
        }

        Debug.Log("attack_score " + enemy.t_attack_score + " serve_score " + enemy.t_serve_score + " block_score " + enemy.t_block_score + " block_fail " + enemy.t_block_fail + " duel_fail " + enemy.t_duel_fail + " defend_fail " + enemy.t_defend_fail + " enemy_fail " + enemy.t_enemy_fail + " team_fail " + enemy.t_team_fail);

        foreach (Player p in enemy.players)
        {
            Debug.Log(i + " attack_score " + p.attack_score + " serve_score " + p.serve_score + " block_score " + p.block_score + " block_fail " + p.block_fail + " duel_fail " + p.duel_fail + " defend_fail " + p.defend_fail + " enemy_fail " + p.enemy_fail + " team_fail " + p.team_fail);
            i++;
        }
    }

}
