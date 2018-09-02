using UnityEngine;

public class PieChartMeshController : MonoBehaviour
{
    PieChartMesh mPieChart;

    public void InitPieChart(Team team, int number)
    {
        mPieChart = gameObject.AddComponent<PieChartMesh>();

        float[] datas = new float[number];

        if (number == 4)
        {
            datas[0] = team.t_serve_score;
            datas[1] = team.t_attack_score;
            datas[2] = team.t_block_score;
            datas[3] = team.t_enemy_fail;
        }
        else if (number == 6)
        {
            datas[0] = team.t_serve_fail;
            datas[1] = team.t_attack_fail;
            datas[2] = team.t_block_fail;
            datas[3] = team.t_team_fail;
            datas[4] = team.t_duel_fail;
            datas[5] = team.t_defend_fail;
        }

        if (mPieChart != null)
        {
            mPieChart.Init(datas, 100, 0, 100, null);
            mPieChart.Draw(datas);
        }
    }
}
