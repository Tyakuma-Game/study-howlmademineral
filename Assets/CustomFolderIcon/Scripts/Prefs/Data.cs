using UnityEngine;
using System.Collections.Generic;

namespace Tabsil.Mineral
{
    /// <summary>
    /// �ݒ�f�[�^�N���X
    /// </summary>
    [System.Serializable]
    public class Data
    {
        /// <summary>
        /// �L�[�ƒl�̃y�A��ێ�����N���X
        /// </summary>
        [System.Serializable]
        public class KeyValuePair
        {
            public string key;
            public string value;
        }

        [SerializeField] List<KeyValuePair> keyValuePairs = new List<KeyValuePair>();   // �V���A���C�Y�p�̃L�[�ƒl�̃y�A���X�g
        Dictionary<string, string> dictionary = new Dictionary<string, string>();       // ���ۂ̃f�[�^�f�[�^���쎫��

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public Data()
        {
            // �L�[�ƒl�̃y�A���玫���\�z
            foreach (var pair in keyValuePairs)
                dictionary[pair.key] = pair.value;
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ����镶����擾
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="defaultValue">�L�[�����݂��Ȃ��ꍇ�̃f�t�H���g�l</param>
        /// <returns>�Ή����镶����A�܂��̓f�t�H���g�l</returns>
        public string GetString(string key, string defaultValue)
        {
            if (dictionary.TryGetValue(key, out string value))
                return value;

            return defaultValue;
        }

        /// <summary>
        /// �w�肵���L�[�ƕ������ݒ�
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="value">�ݒ肷�镶����</param>
        public void SetString(string key, string value)
        {
            dictionary[key] = value;

            // �V���A���C�Y�p�̃��X�g�X�V
            var existingPair = keyValuePairs.Find(pair => pair.key == key);
            if (existingPair != null)
                existingPair.value = value;
            else
                keyValuePairs.Add(new KeyValuePair { key = key, value = value });
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ�����f�[�^�폜
        /// </summary>
        /// <param name="key">�L�[</param>
        public void DeleteKey(string key)
        {
            dictionary.Remove(key);
            keyValuePairs.RemoveAll(pair => pair.key == key);
        }
    }
}