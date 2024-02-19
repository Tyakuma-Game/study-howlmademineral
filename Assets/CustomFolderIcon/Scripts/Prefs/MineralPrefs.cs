using UnityEngine;
using System.IO;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    /// <summary>
    /// �G�f�B�^���Ŏg�p����ݒ�f�[�^�Ǘ��N���X
    /// </summary>
    [InitializeOnLoad]
    public static class MineralPrefs
    {
        const string DATA_ASSET_NAME = "CustomFolderData";
        static string dataPath;
        static Data dataObject;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static MineralPrefs()
        {
            dataPath = GetAssetPath(DATA_ASSET_NAME);
            LoadData();
        }

        /// <summary>
        /// �w�肳�ꂽ�A�Z�b�g���Ɋ�Â��ăp�X�擾
        /// </summary>
        /// <param name="assetName">�A�Z�b�g��</param>
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
        /// �f�[�^��ǂݍ���
        /// �E�t�@�C�������݂��Ȃ��ꍇ�͐V�K�쐬
        /// </summary>
        static void LoadData()
        {
            try
            {
                if (!File.Exists(dataPath))
                {
                    dataObject = new Data();
                    SaveData();
                }
                else
                {
                    string data = File.ReadAllText(dataPath);
                    dataObject = JsonUtility.FromJson<Data>(data);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("�f�[�^�̓ǂݍ��݂Ɏ��s���܂���: " + e.Message);
            }
        }

        /// <summary>
        /// �f�[�^�ۑ�
        /// </summary>
        static void SaveData()
        {
            try
            {
                string data = JsonUtility.ToJson(dataObject, true);
                File.WriteAllText(dataPath, data);
            }
            catch (System.Exception e)
            {
                Debug.LogError("�f�[�^�̕ۑ��Ɏ��s���܂���: " + e.Message);
            }
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ����镶����擾
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="defaultValue">�L�[�����݂��Ȃ��ꍇ�̃f�t�H���g�l</param>
        /// <returns>�L�[�ɑΉ����镶����A�܂��̓f�t�H���g�l</returns>
        public static string GetString(string key, string defaultValue)
        {
            return dataObject.GetString(key, defaultValue);
        }

        /// <summary>
        /// �w�肵���L�[�ƕ�����ݒ�
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="value">�ݒ肷�镶����</param>
        public static void SetString(string key, string value)
        {
            dataObject.SetString(key, value);
            SaveData();
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ����镶������폜
        /// </summary>
        /// <param name="key">�L�[</param>
        public static void DeleteKey(string key)
        {
            dataObject.DeleteKey(key);
            SaveData();
        }
    }
}

#endif