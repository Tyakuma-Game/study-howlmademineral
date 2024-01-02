using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    [System.Serializable]
    public class Data
    {
        [SerializeField]
        List<string> keys;

        [SerializeField]
        List<string> values;

        public Data()
        {
            keys = new List<string>();
            values = new List<string>();
        }

        public string GetString(string key, string defultValue)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i] == key)
                {
                    return values[i];
                }
            }

            return defultValue;
        }

        public void SetString(string key, string value)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i] == key)
                {
                    values[i] = value;
                    return;
                }
            }

            // The key doesn't exist, let's add it
            keys.Add(key);
            values.Add(value);
        }

        public void DeleteKey(string key)
        {
            int indexToRemove = -1;

            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i] == key)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if( indexToRemove < 0)
            {
                return;
            }

            keys.RemoveAt(indexToRemove);
            values.RemoveAt(indexToRemove);
        }
    }


    [InitializeOnLoad]
    public static class MineralPrefs
    {
        const string dataPath = "Assets/data.txt";
        static Data dataObject;

        static MineralPrefs()
        {
            LoadData();
        }

        static void LoadData()
        {
            if(!File.Exists(dataPath))
            {
                // Create the data file
                FileStream fs = new FileStream(dataPath, FileMode.Create);

                Data dataObject = new Data();

                string data = JsonUtility.ToJson(dataObject);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);

                fs.Write(dataBytes);
                fs.Close();
            }
            else
            {
                string data = File.ReadAllText(dataPath);

                if(data.Length <= 0 )
                {
                    return;
                }

                dataObject = JsonUtility.FromJson<Data>(data);
            }
        }

        static void SaveData()
        {
            string data = JsonUtility.ToJson(dataObject, true);
            File.WriteAllText(dataPath, data);
        }


        public static string GetString(string key, string defultValue)
        {
            return dataObject.GetString(key, defultValue);
        }

        public static void SetString(string key,string value)
        {
            dataObject.SetString(key, value);
            SaveData();
        }

        public static void DeleteKey(string key)
        {
            dataObject.DeleteKey(key);
            SaveData();
        }
    }
}

#endif