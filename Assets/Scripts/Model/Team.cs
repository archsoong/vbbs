using System.Collections;
using System.Linq;
using UnityEngine;

public class Team {

    public ArrayList players;

    public int t_serve_score;
    public int t_serve_fail;
    public int t_serve_good;

    public int t_attack_score;
    public int t_attack_fail;
    public int t_attack_good;

    public int t_block_score;
    public int t_block_fail;
    public int t_duel_fail;
    public int t_defend_fail;
    public int t_enemy_fail;
    public int t_team_fail;

    public Team()
    {
        players = new ArrayList();

        t_serve_score = 0;
        t_serve_fail = 0;
        t_serve_good = 0;

        t_attack_score = 0;
        t_attack_fail = 0;
        t_attack_good = 0;

        t_block_score = 0;
        t_block_fail = 0;
        t_duel_fail = 0;
        t_defend_fail = 0;
        t_enemy_fail = 0;
        t_team_fail = 0;
    }

    public int FindMaxPlayerData(int type)
    {
        int max = 1;

        for (int i = 0; i < players.Count; i++) {
            int total = ((Player)players[i]).CountTotal(type);
            if (total > max){
                max = total;
            }
        }
        return max;
    }

    public int countTotalScore()
    {
        return t_attack_score + t_block_score + t_serve_score + t_enemy_fail;
    }

    public int countTotalFail()
    {
        return t_attack_fail + t_block_fail + t_serve_fail + t_team_fail + t_defend_fail + t_duel_fail;
    }
}
