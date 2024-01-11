using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabsil.Mineral
{
    /// <summary>
    /// �ݒ�f�[�^�Ǘ��N���X
    /// </summary>
    [System.Serializable]
    public class Data
    {
        [SerializeField]
        List<string> keys;

        [SerializeField]
        List<string> values;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public Data()
        {
            keys = new List<string>();
            values = new List<string>();
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ����镶����擾
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="defultValue">���݂��Ȃ������ۂɕԂ����f�t�H���g�̒l</param>
        /// <returns></returns>
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

        /// <summary>
        /// �w�肵���L�[�ɑΉ����镶�����ݒ�
        /// </summary>
        /// <param name="key">�L�[</param>
        /// <param name="value">���݂��Ȃ������ۂɕԂ����f�t�H���g�̒l</param>
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

            // �L�[�����݂��Ȃ��ꍇ�́A�V�����ǉ�
            keys.Add(key);
            values.Add(value);
        }

        /// <summary>
        /// �w�肵���L�[�ɑΉ�����f�[�^���폜
        /// </summary>
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

            if (indexToRemove < 0)
            {
                return;
            }

            keys.RemoveAt(indexToRemove);
            values.RemoveAt(indexToRemove);
        }
    }
}