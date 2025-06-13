using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string currentBestPlayer;
    public int currentBestScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveInformation()
    {
        SaveData data = new SaveData();

        data.bestPlayer = currentBestPlayer;
        data.bestScore = currentBestScore; 

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentBestPlayer = data.bestPlayer;
            currentBestScore = data.bestScore; 
        }
    }


}
