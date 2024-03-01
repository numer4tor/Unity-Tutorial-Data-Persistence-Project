using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class LoadGameRank : MonoBehaviour
{
    public TMP_Text bestPlayerName;

    // static variables for holding the best player data
    private static int bestScore;
    private static string bestPlayer;

    private void Awake()
    {
        LoadRank();
    }

    private void SetBestPlayer()
    {
        if (bestPlayer == null && bestScore == 0)
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"Best Score - {bestPlayer}: {bestScore}";
        }
    }

    public void LoadRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(Application.persistentDataPath);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    class SaveData{
        public int bestScore;
        public string bestPlayer;
    }
}
