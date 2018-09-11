using UnityEngine;
using UnityEngine.UI;

public class PlayerBoard : MonoBehaviour {

    public GameObject player_result_prefab;
    public GameObject panel;

    private const float RIGHT_MAX = 20;
    private const float RIGHT_MIN = 420;
    private const float RIGHT = RIGHT_MIN - RIGHT_MAX;
    private const float LEFT = 15;
    
    public int total { set; get; }

    public void GeneratePlayerResult( Player player, Team team, int type )  // Type 0 Serve, Type 1 Attack
    {
        if (player.number == 0 || player.CountTotal(type) == 0) { return; }

        GameObject player_result = Instantiate(player_result_prefab, new Vector3(0, 0, 0), Quaternion.identity);

        player_result.transform.SetParent(panel.transform);
        player_result.transform.localScale = new Vector3(1, 1, 1);

        // Set player number
        player_result.transform.GetChild(0).GetComponentInChildren<Text>().text = player.number.ToString();

        Transform bar_UI  = player_result.transform.GetChild(1);

        GameObject getBar = bar_UI.GetChild(0).gameObject;
        GameObject lossBar = bar_UI.GetChild(1).gameObject;
        GameObject totalBar = bar_UI.GetChild(2).gameObject;
        GameObject goodBar = bar_UI.GetChild(3).gameObject;

        // Get Color Bar Portion
        float portion = RIGHT / team.FindMaxPlayerData(type);
        float[] data = player.getPlayerData(type);

        float getBarSize = data[0] * portion;
        float lossBarSize = data[1] * portion;
        float goodBarSize = data[2] * portion;
        float totalBarSize = data[3] * portion;
        

        /*
            rectTransform.offsetMin.x     // Left
            rectTransform.offsetMin.y    // Bottom
            rectTransform.OffsetMax.x    // Right
            rectTransform.offestMax.y    // Top
         */

        float get_y = getBar.GetComponent<RectTransform>().offsetMax.y;
        float loss_y = lossBar.GetComponent<RectTransform>().offsetMax.y;
        float total_y = totalBar.GetComponent<RectTransform>().offsetMax.y;
        float good_y = goodBar.GetComponent<RectTransform>().offsetMax.y;

        getBar.GetComponent<RectTransform>().offsetMax = new Vector2( -(RIGHT_MIN - getBarSize), get_y);    // Must be negative
        lossBar.GetComponent<RectTransform>().offsetMax = new Vector2( -(RIGHT_MIN - lossBarSize), loss_y);
        totalBar.GetComponent<RectTransform>().offsetMax = new Vector2(-(RIGHT_MIN - totalBarSize), total_y);
        goodBar.GetComponent<RectTransform>().offsetMax = new Vector2(-(RIGHT_MIN - goodBarSize), good_y);

        // Set player serve score, fail, good, total
        Transform score_UI = player_result.transform.GetChild(2);
        Text[] texts = score_UI.GetComponentsInChildren<Text>();

        // Get, Loss, Good, Total
        texts[0].text = data[0].ToString();
        texts[1].text = data[1].ToString();
        texts[2].text = data[2].ToString();
        texts[3].text = data[3].ToString();
    }
}
