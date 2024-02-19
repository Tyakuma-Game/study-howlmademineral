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
        const int MENU_PRIORITY = 10000;
        const string CUSTOM_ICON_MENU_PATH = "Assets/Custom Folder Icon/Custom Icon...";
        const string RESET_ICON_MENU_PATH = "Assets/Custom Folder Icon/Reset Icon";

        /// <summary>
        /// �J�X�^���A�C�R����I�����郁�j���[����
        /// </summary>
        [MenuItem(CUSTOM_ICON_MENU_PATH, false, MENU_PRIORITY)]
        static void SelectCustomIcon()
        {
            IconFoldersEditor.ChooseCustomIcon();
        }

        /// <summary>
        /// �t�H���_�A�C�R�������Z�b�g���郁�j���[����
        /// </summary>
        [MenuItem(RESET_ICON_MENU_PATH, false, MENU_PRIORITY + 1)]
        static void ResetFolderIcon()
        {
            ColoredFoldersEditor.ResetFolderTexture();
        }

        /// <summary>
        /// �t�H���_���j���[���ڂ̗L���������؂��郁�\�b�h
        /// </summary>
        [MenuItem(CUSTOM_ICON_MENU_PATH, true)]
        [MenuItem(RESET_ICON_MENU_PATH, true)]
        static bool IsFolderSelected()
        {
            // �I�����ꂽ�I�u�W�F�N�g�����݂��Ȃ��ꍇ�A���j���[���ڂ𖳌�
            if (Selection.activeObject == null)
                return false;

            // �I�����ꂽ�I�u�W�F�N�g�̃p�X�擾
            Object selectedObject = Selection.activeObject;
            string objectPath = AssetDatabase.GetAssetPath(selectedObject);

            // �I�����ꂽ�I�u�W�F�N�g���t�H���_�ł��邩�ǂ��������؂��A���ʂ�Ԃ�
            return AssetDatabase.IsValidFolder(objectPath);
        }
    }
}

#endif