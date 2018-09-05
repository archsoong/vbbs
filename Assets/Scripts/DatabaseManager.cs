using UnityEngine;
using System.Data;
using System.Collections;
using UnityEditor;
using System.IO;

public class DatabaseManager : MonoBehaviour
{
    public int match_id;
    public int round_id;

    public ModelController model;
    private dbAccess db;

    // DB Location C:\Users\Arch\AppData\LocalLow\Volley\Statistic
    // $ sqlite3 Volley.db

    void Start()
    {
        // BuildDBSchema();
    }

    public void BuildDBSchema()
    {
        Debug.Log("Start constructing DB");

        db = GetComponent<dbAccess>();
        db.OpenDB("VBBS.db");

        // Create Table for Match
        string[] match = new string[] {
            "ID INTEGER PRIMARY KEY AUTOINCREMENT",
            "date TEXT",
            "time TEXT",
            "location TEXT",
            "matchName TEXT",
            "team TEXT",
            "enemy TEXT",
            "matchStyle INTEGER",
            "ruleStyle INTEGER",
        };

        db.CreateTableByQuery("matches", match);

        // Create Table for Round
        string[] round = new string[] {
            "ID INTEGER PRIMARY KEY AUTOINCREMENT",
            "team_score INTEGER",
            "enemy_score INTEGER",
            "match_ID INTEGER",
            "FOREIGN KEY(match_ID) REFERENCES matches(ID)"
        };

        db.CreateTableByQuery("rounds", round);

        // Create Table for Each Ball

        string[] ball = new string[] {
            "ID INTEGER PRIMARY KEY AUTOINCREMENT",
            "time NUMERIC",
            "start_X NUMERIC",
            "start_Y NUMERIC",
            "end_X NUMERIC",
            "end_Y NUMERIC",
            "attacker INTEGER",
            "team_player INTEGER",
            "enemy_player INTEGER",
            "skill INTEGER",
            "good INTEGER",
            "score INTEGER",
            "score_reason INTEGER",
            "team_change INTEGER",
            "team_switch INTEGER",
            "team_position INTEGER",
            "team_score INTEGER",
            "enemy_score INTEGER",
            "enemy_change INTEGER",
            "enemy_switch INTEGER",
            "enemy_position INTEGER",
            "round_ID INTEGER",
            "FOREIGN KEY(round_ID) REFERENCES rounds(ID)"
        };

        db.CreateTableByQuery("balls", ball);

        Debug.Log("Constructing Done");

        db.CloseDB();
    }

    private void ReadSampleData() {

        for (int i = 0; i < Data.datas.Length; i++)
        {
            string cols = "time, start_X, start_Y, end_X, end_Y, attacker, team_player, enemy_player, skill, good, score, score_reason, team_change, team_switch, team_position, team_score, enemy_score, enemy_change, enemy_switch, enemy_position, match_ID";
            db.InsertIntoSingle("balls", cols,Data.datas[i] + "," + match_id);
        }
        Debug.Log("Read Sample Data Successfull");
    }

    public void InsertNewMatch(string date, string time, string location, string matchName, string team, string enemy, int matchStyle, int ruleStyle)
    {
        dbAccess db = GetComponent<dbAccess>();
        db.OpenDB("VBBS.db");

        string attr = "date, time, location, team, enemy, matchStyle, ruleStyle";
        string values = "'"+ date + "','" + time + "','" + location + "','" + team + "','" + enemy + "'," + matchStyle + "," + ruleStyle;

        db.BasicQuery("INSERT INTO matches (" + attr + ") values (" + values + ")" );
        IDataReader reader = db.BasicQuery("SELECT last_insert_rowid();");

        if (reader.Read())
        {
            match_id = reader.GetInt32(0);
        }
    }

    public void InsertNewRound()
    {
        dbAccess db = GetComponent<dbAccess>();

        string attr = "team_score, enemy_score, match_ID";
        string values = "0,0," + match_id;

        db.BasicQuery("INSERT INTO rounds (" + attr + ") values (" + values + ")");
        IDataReader reader = db.BasicQuery("SELECT last_insert_rowid();");

        if (reader.Read())
        {
            round_id = reader.GetInt32(0);
        }
    }

    public void InsertNewBall()
    {
        Debug.Log("Start Inserting Ball");

        dbAccess db = GetComponent<dbAccess>();
        db.OpenDB("VBBS.db");

        string ball_attr = "time, start_X, start_Y, end_X, end_Y, attacker, team_player, enemy_player, skill, good, score, score_reason, team_change, team_switch, team_position, team_score, enemy_score, enemy_change, enemy_switch, enemy_position, match_ID";
        
        db.InsertIntoSingle("balls", ball_attr, model.encode() + round_id);
    }

    public ArrayList ReadDBData()
    {
        ArrayList balls = new ArrayList();
        Debug.Log("Start Reading Data");

        dbAccess db = GetComponent<dbAccess>();
        db.OpenDB("VBBS.db");

        IDataReader reader = db.BasicQuery("SELECT attacker, team_player, enemy_player,	skill, good, score,	score_reason FROM balls");

        while (reader.Read())
        {
            Ball b = new Ball(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
            balls.Add(b);
        }

        Debug.Log("Total Ball Count: " + balls.Count);

        return balls;
    }

    public ArrayList ReadDBDataFromRound()
    {
        ArrayList balls = new ArrayList();
        Debug.Log("Reading Data by round_id");

        dbAccess db = GetComponent<dbAccess>();
        db.OpenDB("VBBS.db");

        // SELECT * FROM ball where match_id = 1
        // "ID, time, start_X, start_Y, end_X, end_Y, attacker, team_player, enemy_player, skill, good, score, score_reason, team_change, team_switch, team_position, team_score, enemy_score, enemy_change, enemy_switch, enemy_position, match_ID"
        IDataReader reader = db.BasicQuery("SELECT attacker, team_player, enemy_player,	skill, good, score,	score_reason FROM balls where match_id =" + match_id);

        // string path = "Assets/Resources/test.txt";

        // Write some text to the test.txt file
        // StreamWriter writer = new StreamWriter(path, true);

        while (reader.Read())
        {
            Ball b = new Ball(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6));
            
            // string l = "attacker: " + b.attacker + " ,teamplayer: " + b.team_player + ",enemyplayer: " + b.enemy_player
            // + ",skill: " + b.skill + ",good: " + b.good + ",score: " + b.score + ",reason: " + b.score_reason;

            // writer.WriteLine(l);

            balls.Add(b);
        }
        // writer.Close();

        Debug.Log("Total Ball Count: " + balls.Count);
        return balls;
    }


}