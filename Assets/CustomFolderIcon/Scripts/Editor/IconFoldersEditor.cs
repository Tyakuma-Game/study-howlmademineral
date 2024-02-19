using UnityEngine;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    /// <summary>
    /// �A�C�R���t�H���_�[�G�f�B�^�[�N���X
    /// </summary>
    [InitializeOnLoad]
    static class IconFoldersEditor
    {
        static string selectedFolderGuid;
        static int controlID;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        static IconFoldersEditor()
        {
            // �v���W�F�N�g�E�B���h�E�̃A�C�e���`�掞�ɃR�[���o�b�N��o�^
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        // <summary>
        /// �v���W�F�N�g�E�B���h�E�̃A�C�e��GUI��`��
        /// </summary>
        /// <param name="guid">�A�C�e����GUID</param>
        /// <param name="selectionRect">�I��͈͂̋�`</param>
        static void OnGUI(string guid, Rect selectionRect)
        {
            // �I�����ꂽ�t�H���_��GUID�ƈ�v���Ȃ��ꍇ�͉������Ȃ�
            if (guid != selectedFolderGuid)
                return;

            // �I�u�W�F�N�g�I�����X�V���ꂽ�ꍇ�A�I�����ꂽ�I�u�W�F�N�g��GUID���擾���ĕۑ�
            if (Event.current.commandName == "ObjectSelectorUpdated" && EditorGUIUtility.GetObjectPickerControlID() == controlID)
            {
                Object selectedObject = EditorGUIUtility.GetObjectPickerObject();

                string folderTextureGuid = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(selectedObject)).ToSafeString();
                MineralPrefs.SetString(selectedFolderGuid, folderTextureGuid);
            }
        }

        /// <summary>
        /// �J�X�^���A�C�R����I��
        /// </summary>
        public static void ChooseCustomIcon()
        {
            // �I�����ꂽ�t�H���_��GUID���擾
            selectedFolderGuid = Selection.assetGUIDs[0];

            // �I�u�W�F�N�g�s�b�J�[��\�����邽�߂̃R���g���[��ID���擾���A�I�u�W�F�N�g�s�b�J�[��\��
            controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "", controlID);
        }
    }
}

#endif