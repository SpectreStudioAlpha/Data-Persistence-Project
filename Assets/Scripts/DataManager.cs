// DataManager.cs
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public string BestPlayerName;
    public int BestScore;

    private string savePath;

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName;
        public int BestScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        savePath = Application.persistentDataPath + "/savefile.json";
        LoadScore();
    }

    public void SaveScore(int score)
    {
        if (score > BestScore)
        {
            BestScore = score;
            BestPlayerName = PlayerName;

            SaveData data = new SaveData
            {
                BestPlayerName = BestPlayerName,
                BestScore = BestScore
            };

            File.WriteAllText(savePath, JsonUtility.ToJson(data));
        }
    }

    public void LoadScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestScore = data.BestScore;
            BestPlayerName = data.BestPlayerName;
        }
    }
}
