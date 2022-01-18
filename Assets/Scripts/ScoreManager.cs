using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;

    public string PlayerName;

    public int BestScoreNumber;

    public string BestScoreText;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScores();
    }

    [System.Serializable]
    class SaveData {
        public string PlayerName;

        public int BestScoreNumber;

        public string BestScoreText;
    }

    public void SaveScores() {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestScoreNumber = BestScoreNumber;
        data.BestScoreText = BestScoreText;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/scores.json", json);
    }

    public void LoadScores() {
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            BestScoreNumber = data.BestScoreNumber;
            BestScoreText = data.BestScoreText;
        }
    }
}
