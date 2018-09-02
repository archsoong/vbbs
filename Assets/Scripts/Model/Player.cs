public class Player {

    public int serve_score;
    public int serve_fail;
    public int serve_good;

    public int attack_score;
    public int attack_fail;
    public int attack_good;

    public int block_score;
    public int block_fail;

    public int duel_fail;
    public int defend_fail;
    public int enemy_fail;
    public int team_fail;

    public int number;

    public Player()
    {
        serve_score = 0;
        serve_fail = 0;
        serve_good = 0;

        attack_score = 0;
        attack_fail = 0;
        attack_good = 0;

        block_score = 0;
        block_fail = 0;
        duel_fail = 0;

        defend_fail = 0;
        enemy_fail = 0;
        team_fail = 0;
    }

    public float[] getPlayerData(int type)
    {
        float[] data = new float[4];

        if (type == 0)
        {
            data[0] = serve_score;
            data[1] = serve_fail;
            data[2] = serve_good;
            data[3] = CountTotalServe();
        }
        else if (type == 1) {
            data[0] = attack_score;
            data[1] = attack_fail;
            data[2] = attack_good;
            data[3] = CountTotalAttack();
        }

        return data;
    }

    public int CountTotalServe()
    {
        return serve_score + serve_fail;
    }

    public int CountTotalAttack()
    {
        return attack_score + attack_fail;
    }

    public int CountTotalScore()
    {
        return CountTotalServe() + CountTotalAttack();
    }

    public int CountTotalFail()
    {
        return attack_fail + block_fail + defend_fail + serve_fail + team_fail + duel_fail;
    }

    public int CountTotal(int type) {
        if (type == 0) { return CountTotalServe(); }
        else if (type == 1) { return CountTotalAttack(); }
        else if (type == 2) { return CountTotalFail(); }
        else { return CountTotalScore(); }
    }
}
