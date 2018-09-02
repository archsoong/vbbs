using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour {

    public GameObject player_record_prefab;

    private const float RECORD_HEIGHT = 150;

    private int record;
    private float width;

    private int serve;
    private int attack;
    private int block;
    private int duel;
    private int defend;
    private int fail;
    private int total;

    void Start ()
    {
        record = 0;
        width = GetComponent<RectTransform>().position.x;

        serve = 0;
        attack = 0;
        block = 0;
        duel = 0;
        defend = 0;
        fail = 0;
        total = 0;
    }

    public void GeneratePlayerRecord(Player player)
    {
        if (player.number == 0) { return; }

        GameObject player_record = Instantiate(player_record_prefab, new Vector3(0, 0, 0), Quaternion.identity);

        player_record.transform.SetParent(this.transform);
        player_record.transform.localScale = new Vector3(1, 1, 1);
        
        Text tno = player_record.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text tserve = player_record.transform.GetChild(1).gameObject.GetComponent<Text>();
        Text tattack = player_record.transform.GetChild(2).gameObject.GetComponent<Text>();
        Text tblock = player_record.transform.GetChild(3).gameObject.gameObject.GetComponent<Text>();
        Text tduel = player_record.transform.GetChild(4).gameObject.gameObject.GetComponent<Text>();
        Text tdefend = player_record.transform.GetChild(5).gameObject.gameObject.GetComponent<Text>();
        Text tfail = player_record.transform.GetChild(6).gameObject.gameObject.GetComponent<Text>();
        Text ttotal = player_record.transform.GetChild(7).gameObject.gameObject.GetComponent<Text>();

        tno.text = player.number.ToString();
        tserve.text = player.serve_fail == 0 ? "" : player.serve_fail.ToString();
        tattack.text = player.attack_fail == 0 ? "" : player.attack_fail.ToString();
        tblock.text = player.block_fail == 0 ? "" : player.block_fail.ToString();
        tdefend.text = player.defend_fail == 0 ? "" : player.defend_fail.ToString();
        tduel.text = player.duel_fail == 0 ? "" : player.duel_fail.ToString();
        tfail.text = player.team_fail == 0 ? "" : player.team_fail.ToString();
        ttotal.text = player.CountTotal(2).ToString();

        serve += player.serve_fail;
        attack += player.attack_fail;
        block += player.block_fail;
        defend += player.defend_fail;
        duel += player.duel_fail;
        fail += player.team_fail;
        total += player.CountTotal(2);
    }

    public void GenerateTeamRecord()
    {
        GameObject player_record = Instantiate(player_record_prefab, new Vector3(0, 0, 0), Quaternion.identity);

        player_record.transform.SetParent(this.transform);
        player_record.transform.localScale = new Vector3(1, 1, 1);
        player_record.transform.SetAsFirstSibling();

        Text tno = player_record.transform.GetChild(0).gameObject.GetComponent<Text>();
        Text tserve = player_record.transform.GetChild(1).gameObject.GetComponent<Text>();
        Text tattack = player_record.transform.GetChild(2).gameObject.GetComponent<Text>();
        Text tblock = player_record.transform.GetChild(3).gameObject.gameObject.GetComponent<Text>();
        Text tduel = player_record.transform.GetChild(4).gameObject.gameObject.GetComponent<Text>();
        Text tdefend = player_record.transform.GetChild(5).gameObject.gameObject.GetComponent<Text>();
        Text tfail = player_record.transform.GetChild(6).gameObject.gameObject.GetComponent<Text>();
        Text ttotal = player_record.transform.GetChild(7).gameObject.gameObject.GetComponent<Text>();

        tno.text = "ALL";
        tserve.text = serve.ToString();
        tattack.text = attack.ToString();
        tblock.text = block.ToString();
        tdefend.text = defend.ToString();
        tduel.text = duel.ToString();
        tfail.text = fail.ToString();
        ttotal.text = total.ToString();
    }

    public void reSizeUI()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, RECORD_HEIGHT * record);
        rt.position = new Vector3(0, -(RECORD_HEIGHT * record / 2), 0);
    }
}
