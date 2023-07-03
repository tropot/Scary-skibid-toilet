using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class SaveManager : MonoBehaviour
{
    public List<Item> toSave;
    public int numberToSave;
    private string saveFilePath;
    private void Start()
    {
        saveFilePath = Application.persistentDataPath + "/save.dat";
    }

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(saveFilePath);
        

        SaveData saveData = new SaveData();
        saveData.money = numberToSave;
        saveData.inventory = toSave;

        formatter.Serialize(file, saveData);
        file.Close();

    }

    public List<Item> LoadGame()
    {
        saveFilePath = Application.persistentDataPath + "/save.dat";
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(saveFilePath, FileMode.Open);

            SaveData saveData = (SaveData)formatter.Deserialize(file);
            file.Close();

            numberToSave = saveData.money;
            Debug.Log(saveData.inventory[0]);
            return saveData.inventory;
        }
       else
        {
            Debug.Log("No save file found.");
            return null;
        }
    }
}

[System.Serializable]
public class SaveData
{
    public int money;
    public List<Item> inventory;

}