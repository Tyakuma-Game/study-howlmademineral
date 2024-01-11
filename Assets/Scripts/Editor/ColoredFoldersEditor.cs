using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    /// <summary>
    /// �t�H���_�̐F�t���ƃA�C�R���ݒ���s���G�f�B�^�̊g���N���X
    /// </summary>
    [InitializeOnLoad]
    static class ColoredFoldersEditor
    {
        static string iconName;

        static ColoredFoldersEditor()
        {
            // �G�f�B�^�̃v���W�F�N�g�E�B���h�E�A�C�e���̕`�掞�Ƀ��\�b�h���Ăяo��
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        /// <summary>
        /// �v���W�F�N�g�E�B���h�E�Ńt�H���_�̐F�t���ƃA�C�R���̕`��
        /// </summary>
        /// <param name="guid">�A�Z�b�g��GUID</param>
        /// <param name="selectionRect">�I��̈��Rect</param>
        static void OnGUI(string guid, Rect selectionRect)
        {
            Color backgroundColor;
            Rect folderRect = GetFolderRect(selectionRect, out backgroundColor);

            string iconGuid = MineralPrefs.GetString(guid, "");

            // �����ݒ肳��Ă��Ȃ��@OR�@None���ݒ肳��Ă���
            if (iconGuid == "" || iconGuid == "00000000000000000000000000000000")
                return;

            // �t�H���_�̔w�i�F��`��
            EditorGUI.DrawRect(folderRect, backgroundColor);

            // �t�H���_�ɐݒ肳�ꂽ�A�C�R����`��
            string folderTexturePath = AssetDatabase.GUIDToAssetPath(iconGuid);
            Texture2D folderTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(folderTexturePath);
            GUI.DrawTexture(folderRect, folderTexture);
        }

        /// <summary>
        /// �t�H���_��Rect���擾
        /// </summary>
        /// <param name="selectionRect">�I��̈��Rect</param>
        /// <param name="backgroundColor">�w�i�F</param>
        /// <returns>�t�H���_��Rect</returns>
        static Rect GetFolderRect(Rect selectionRect, out Color backgroundColor)
        {
            Rect folderRect;
            backgroundColor = new Color(.2f, .2f, .2f);

            if (selectionRect.x < 15)
            {
                // ����A�������X�P�[��
                folderRect = new Rect(selectionRect.x + 3, selectionRect.y, selectionRect.height, selectionRect.height);
            }
            else if (selectionRect.x >= 15 && selectionRect.height < 30)
            {
                // ����
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.height, selectionRect.height);
                backgroundColor = new Color(0.22f, 0.22f, 0.22f);
            }
            else
            {
                // ����A�傫���X�P�[��
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width, selectionRect.width);
            }

            return folderRect;
        }

        /// <summary>
        /// �t�H���_�̃A�C�R���ݒ�����Z�b�g
        /// </summary>
        public static void ResetFolderTexture()
        {
            // �A�N�e�B�u�ȃI�u�W�F�N�g�̃t�H���_�p�X��GUID���擾
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            // �t�H���_�̃A�C�R���ݒ���폜
            MineralPrefs.DeleteKey(folderGuid);
        }
    }
}

#endif