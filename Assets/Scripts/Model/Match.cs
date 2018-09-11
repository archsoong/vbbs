public class Match
{
    public int ID;
    public string name;
    public string date;
    public string team;
    public string enemy;

    public Match(int ID, string date, string name, string team, string enemy)
    {
        this.ID = ID;
        this.name = name;
        this.date = date;
        this.team = team;
        this.enemy = enemy;
    }
}
