using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IOLeaderBoardData : MonoBehaviour
{


    public static void SaveGame(string game, LeaderBoardData data)
    {
        string file = Application.persistentDataPath + "/" + game + "GameData.json";

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(file, json);
    }

    public static LeaderBoardData DataCharge(string game)
    {
        string file = Application.persistentDataPath + "/" + game + "GameData.json";
        if (File.Exists(file))
        {
            string content = File.ReadAllText(file);
            return JsonUtility.FromJson<LeaderBoardData>(content);
        }
        return null;
    }

    public void DeleteData(string game)
    {
        string file = Application.persistentDataPath + "/" + game + "/GameData.json";
        if (File.Exists(file))
        {
            File.Delete(file);
        }
        SceneManager.LoadScene("ChargeValues");

    }
}
