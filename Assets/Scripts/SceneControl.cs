using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

    public void AddNewMatch()
    {
        SceneManager.LoadScene("NewMatch");
    }

    public void OpenTeamStatistic()
    {
        SceneManager.LoadScene("TeamStatistic");
    }

    public void OpenMatchStatistic()
    {
        SceneManager.LoadScene("MatchStatistic");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
