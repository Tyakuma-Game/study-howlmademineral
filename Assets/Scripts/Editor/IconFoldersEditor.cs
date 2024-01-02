using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    [InitializeOnLoad]
    static class IconFoldersEditor
    {
        static string selectedFolderGuid;
        static int controlID;

        static IconFoldersEditor()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        static void OnGUI(string guid, Rect selectionRect)
        {
            if(guid != selectedFolderGuid)
            {
                return;
            }

            if(Event.current.commandName == "ObjectSelectorUpdated" && EditorGUIUtility.GetObjectPickerControlID() == controlID)
            {
                UnityEngine.Object selectedObject = EditorGUIUtility.GetObjectPickerObject();

                string folderTextureGuid = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(selectedObject)).ToSafeString();
                EditorPrefs.SetString(selectedFolderGuid, folderTextureGuid);
            }
        }

        public static void ChooseCustomIcon()
        {
            selectedFolderGuid = Selection.assetGUIDs[0];

            controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "", controlID);
        }
    }
}

#endif