using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager I;

    public Color teamColor;


    [System.Serializable]
    class SaveData
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColor = teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/userdata.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/userdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColor = data.teamColor;
        }
    }


    private void Awake()
    {
        if(I != null)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
}
