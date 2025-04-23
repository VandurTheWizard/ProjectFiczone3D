using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoardGestions : MonoBehaviour
{
    private static string leaderBoardScene = "LeaderBoard";
    private static string gameName = "";
    private static LeaderBoardData leaderBoardData;
    private static int point = 0;

    public TextMeshProUGUI[] names;
    public TextMeshProUGUI[] points;

    public GameObject panelName;
    public GameObject panelLeaderBoard;

    private void Start()
    {
        if (!leaderBoardData.isNewValue(point))
        { 
            activateLeaderBoard();
        }
    }


    public void activateLeaderBoard()
    {
        panelName.SetActive(false);
        panelLeaderBoard.SetActive(true);

        for (int x = 0; x < points.Length; x++)
        {
            if (leaderBoardData.haveMorePlayers(x))
            {
                names[x].text = leaderBoardData.names[x];
                points[x].text = leaderBoardData.represetationOfPoint(x);
            }
        }
    }

    public static void activateLeaderBoardNotTime(string gameName, int point)
    {
        activate(gameName, point, false);
    }

    public static void activateLeaderBoardTime(string gameName, int point)
    {
        activate(gameName, point, true);
    }



    private static void activate(string gameName, int point, bool isTime)
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        Cursor.visible = true;
        leaderBoardData = IOLeaderBoardData.DataCharge(gameName);
        if (leaderBoardData == null)
        {
            leaderBoardData = new LeaderBoardData(isTime);
        }
        LeaderBoardGestions.gameName = gameName;
        LeaderBoardGestions.point = point;
        SceneManager.LoadScene(leaderBoardScene);
    }

    public void introductionOfButton(TMP_InputField field)
    {
        string playerName = field.text.Trim();

        if (!string.IsNullOrEmpty(playerName))
        {
            leaderBoardData.addNewValue(point, playerName);
            IOLeaderBoardData.SaveGame(gameName,leaderBoardData);
            activateLeaderBoard();
        }
    }
}
