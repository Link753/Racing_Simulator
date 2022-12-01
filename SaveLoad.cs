using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad
{
    // Start is called before the first frame update
    public static void Save(Values player)
    {
        BinaryFormatter format = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Save.race";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        format.Serialize(stream, data);
        stream.Close();
    }

    // Update is called once per frame
    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/Save.race";
        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = format.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file missing or corrupted");
            return null;
        }
    }
}
