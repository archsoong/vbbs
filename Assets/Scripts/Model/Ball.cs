public class Ball {

    public int attacker;
    public int team_player;
    public int enemy_player;
    public int skill;
    public int good;
    public int score;
    public int score_reason;

    public Ball(int attacker, int team_player, int enemy_player, int skill, int good, int score, int score_reason) {
        this.attacker = attacker;
        this.team_player = team_player;
        this.enemy_player = enemy_player;
        this.skill = skill;
        this.good = good;
        this.score = score;
        this.score_reason = score_reason;
    }
}
