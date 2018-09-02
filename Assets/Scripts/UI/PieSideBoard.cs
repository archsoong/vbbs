using UnityEngine.UI;
using UnityEngine;

public class PieSideBoard : MonoBehaviour
{

    public GameObject scorePanel;
    public GameObject failPanel;

    public void SetupPanel(Team team)
    {
        SetupScorePanel(team);
        SetupFailPanel(team);
    }

    private void SetupScorePanel(Team team)
    {
        Transform serve = scorePanel.transform.GetChild(1);
        Transform attack = scorePanel.transform.GetChild(2);
        Transform block = scorePanel.transform.GetChild(3);
        Transform fail = scorePanel.transform.GetChild(4);

        Text[] serves = serve.GetComponentsInChildren<Text>();
        Text[] attacks = attack.GetComponentsInChildren<Text>();
        Text[] blocks = block.GetComponentsInChildren<Text>();
        Text[] fails = fail.GetComponentsInChildren<Text>();

        serves[1].text = System.Math.Round((((float)team.t_serve_score) / team.countTotalScore() * 100.0f), 1) + "%";
        serves[2].text = team.t_serve_score.ToString();

        attacks[1].text = System.Math.Round((((float)team.t_attack_score) / team.countTotalScore() * 100.0f), 1) + "%";
        attacks[2].text = team.t_attack_score.ToString();

        blocks[1].text = System.Math.Round((((float)team.t_block_score) / team.countTotalScore() * 100.0f), 1) + "%";
        blocks[2].text = team.t_block_score.ToString();

        fails[1].text = System.Math.Round((((float)team.t_enemy_fail) / team.countTotalScore() * 100.0f), 1) + "%";
        fails[2].text = team.t_enemy_fail.ToString();
    }

    private void SetupFailPanel(Team team)
    {
        Transform serve = failPanel.transform.GetChild(1);
        Transform attack = failPanel.transform.GetChild(2);
        Transform block = failPanel.transform.GetChild(3);
        Transform defend = failPanel.transform.GetChild(4);
        Transform duel = failPanel.transform.GetChild(5);
        Transform fail = failPanel.transform.GetChild(6);

        Text[] serves = serve.GetComponentsInChildren<Text>();
        Text[] attacks = attack.GetComponentsInChildren<Text>();
        Text[] blocks = block.GetComponentsInChildren<Text>();
        Text[] defends = defend.GetComponentsInChildren<Text>();
        Text[] duels = duel.GetComponentsInChildren<Text>();
        Text[] fails = fail.GetComponentsInChildren<Text>();

        serves[1].text = System.Math.Round((((float)team.t_serve_fail) / team.countTotalFail() * 100.0f), 1) +"%";
        serves[2].text = team.t_serve_score.ToString();

        attacks[1].text = System.Math.Round((((float)team.t_attack_fail) / team.countTotalFail() * 100.0f), 1) +"%";
        attacks[2].text = team.t_attack_score.ToString();

        blocks[1].text = System.Math.Round((((float)team.t_block_fail) / team.countTotalFail() * 100.0f), 1) +"%";
        blocks[2].text = team.t_block_score.ToString();

        defends[1].text = System.Math.Round((((float)team.t_defend_fail) / team.countTotalFail() * 100.0f), 1) +"%";
        defends[2].text = team.t_defend_fail.ToString();

        duels[1].text = System.Math.Round((((float)team.t_duel_fail) / team.countTotalFail() * 100.0f), 1) +"%";
        duels[2].text = team.t_enemy_fail.ToString();

        fails[1].text = System.Math.Round((((float)team.t_team_fail) / team.countTotalFail() * 100.0f), 1) +"%";
        fails[2].text = team.t_enemy_fail.ToString();
    }
}