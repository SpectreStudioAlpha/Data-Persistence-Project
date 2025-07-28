// DataPersistenceManager.cs
using UnityEngine;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;
    public string playerName;
    public string highScorePlayer;
    public int highScore;

    private string savePath;

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
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayer;
        public int highScore;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SaveHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            highScorePlayer = playerName;

            SaveData data = new SaveData()
            {
                highScorePlayer = highScorePlayer,
                highScore = highScore
            };

            File.WriteAllText(savePath, JsonUtility.ToJson(data));
        }
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScorePlayer = data.highScorePlayer;
        }
    }
}
