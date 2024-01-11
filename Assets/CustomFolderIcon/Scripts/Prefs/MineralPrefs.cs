using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    // folderIconData
    /// <summary>
    /// �t�H���_�[�̐ݒ���Ǘ�����N���X
    /// </summary>
    [InitializeOnLoad]
    public static class MineralPrefs
    {
        static string dataPath;
        static Data dataObject;

        static MineralPrefs()
        {
            dataPath = GetAssetPath("CustomFolderData");
            LoadData();
        }

        /// <summary>
        /// �A�Z�b�g�̃p�X���擾���郁�\�b�h
        /// </summary>
        /// <param name="assetName">�A�Z�b�g�̖��O</param>
        /// <returns>�A�Z�b�g�̃p�X</returns>
        static string GetAssetPath(string assetName)
        {
            string[] assetPaths = AssetDatabase.FindAssets(assetName);
            if (assetPaths.Length > 0)
            {
                string assetGUID = assetPaths[0];
                return AssetDatabase.GUIDToAssetPath(assetGUID);
            }
            else
            {
                Debug.LogError("�A�Z�b�g��������܂���: " + assetName);
                return null;
            }
        }

        /// <summary>
        /// �f�[�^�̓ǂݍ���
        /// </summary>
        static void LoadData()
        {
            if(!File.Exists(dataPath))
            {
                // �f�[�^�t�@�C�����쐬
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

        /// <summary>
        /// �f�[�^�ۑ�
        /// </summary
        static void SaveData()
        {
            string data = JsonUtility.ToJson(dataObject, true);
            File.WriteAllText(dataPath, data);
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ����镶������擾
        /// </summary>
        /// <param name="key">�擾����l�̃L�[</param>
        /// <param name="defultValue">���݂��Ȃ������ۂɕԂ��l</param>
        /// <returns>�L�[�ɑΉ�����l</returns>
        public static string GetString(string key, string defultValue)
        {
            return dataObject.GetString(key, defultValue);
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ����镶�����ݒ�
        /// </summary>
        /// <param name="key">�ۑ�����L�[</param>
        /// <param name="value">�ۑ�����l</param>
        public static void SetString(string key,string value)
        {
            dataObject.SetString(key, value);
            SaveData();
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ�����f�[�^�̍폜
        /// </summary>
        /// <param name="key">�폜����L�[</param>
        public static void DeleteKey(string key)
        {
            dataObject.DeleteKey(key);
            SaveData();
        }
    }
}

#endif