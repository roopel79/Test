using UnityEngine;

public class PlayerPrefsExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string path = string.Empty;

        //path = $"{Application.persistentDataPath}/Unity/{Application.companyName}/{Application.productName}/prefs";

        Debug.Log("playerPrefs path : " + Application.persistentDataPath);

        SaveData("PlayerName", "UnityPlayer");
        SaveData("HighScore", 12345);

        string playerName  = LoadData("PlayerName", "DefaultName");

        Debug.Log($"Player Name: {playerName}");
    }

    public void SaveData(string key, object value)
    {
        if(value is int)
        {
            PlayerPrefs.SetInt(key, (int)value);
        }
        else if(value is float)
        {
            PlayerPrefs.SetFloat(key, (float)value);
        }
        else if(value is string)
        {
            PlayerPrefs.SetString(key, (string)value);
        }
        else
        {
            Debug.LogError("�������� �ʴ� ������ Ÿ���Դϴ�.");
            return;
        }

        PlayerPrefs.Save();
        Debug.Log($"Data saved: {key} = {value}");
    }

    public int LoadData(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public string LoadData(string key, string defaultValue)
    {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public float LoadData(string key, float defaultValue)
    {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    // Ư�� Ű�� �ش��ϴ� �����͸� �����ϴ� �Լ�
    public void DeleteData(string key)
    {
        if(PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
            Debug.Log($"Data deleted: {key}");
        }
        else
        {
            Debug.Log($"No data found for key: {key}");
        }

    }

    // ��� �����͸� �����ϴ� �Լ�
    public void ResetAllData()
    {
        PlayerPrefs.DeleteAll();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
