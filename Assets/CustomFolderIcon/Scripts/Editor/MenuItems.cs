using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    /// <summary>
    /// �t�H���_�̃A�C�R���Ɗ֘A���j���[���Ǘ�����N���X
    /// </summary>
    static class MenuItems
    {
        const int priority = 10000;

        /// <summary>
        /// �J�X�^���A�C�R����I�����郁�j���[����
        /// </summary>
        [MenuItem("Assets/Custom Folder Icon/Custom Icon...", false, priority + 11)]
        static void Custom()
        {
            IconFoldersEditor.ChooseCustomIcon();
        }

        /// <summary>
        /// �t�H���_�A�C�R�������Z�b�g���郁�j���[����
        /// </summary>
        [MenuItem("Assets/Custom Folder Icon/Reset Icon", false, priority + 23)]
        static void ResetIcon()
        {
            ColoredFoldersEditor.ResetFolderTexture();
        }

        /// <summary>
        /// �t�H���_���j���[���ڂ̗L���������؂��郁�\�b�h
        /// </summary>
        [MenuItem("Assets/Custom Folder Icon/Custom Icon...", true)]
        [MenuItem("Assets/Custom Folder Icon/Reset Icon", true)]
        static bool ValidateFolder()
        {
            // �I�����ꂽ�I�u�W�F�N�g�����݂��Ȃ��ꍇ�A���j���[���ڂ𖳌��ɂ���
            if (Selection.activeObject == null)
            {
                return false;
            }

            // �I�����ꂽ�I�u�W�F�N�g�̃p�X�擾
            Object selectedObject = Selection.activeObject;
            string objectPath = AssetDatabase.GetAssetPath(selectedObject);

            // �I�����ꂽ�I�u�W�F�N�g���t�H���_�ł��邩�ǂ��������؂��A���ʂ�Ԃ�
            return AssetDatabase.IsValidFolder(objectPath);
        }
    }
}

#endif