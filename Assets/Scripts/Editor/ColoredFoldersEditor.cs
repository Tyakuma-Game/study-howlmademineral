using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    [InitializeOnLoad]
    static class ColoredFoldersEditor
    {
        static string iconName;

        static ColoredFoldersEditor()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        static void OnGUI(string guid, Rect selectionRect)
        {
            Color backgroundColor;
            Rect folderRect = GetFolderRect(selectionRect, out backgroundColor);

            string iconGuid = EditorPrefs.GetString(guid, "");

            if (iconGuid == "")
                return;

            /*
            if(Selection.activeObject == null)
            {
                return;
            }
            
            string activeObjectGuid = AssetDatabase.
                GUIDFromAssetPath(AssetDatabase.GetAssetPath(Selection.activeObject)).ToString();

            if(activeObjectGuid != guid )
            {
                return;
            }
            */

            EditorGUI.DrawRect(folderRect, backgroundColor);

            string folderTexturePath = AssetDatabase.GUIDToAssetPath(iconGuid);
            Texture2D folderTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(folderTexturePath);

            GUI.DrawTexture(folderRect, folderTexture);

            // EditorGUI.DrawRect(selectionRect, Color.red);
        }

        static Rect GetFolderRect(Rect selectionRect, out Color backgroundColor)
        {
            Rect folderRect;
            backgroundColor = new Color(.2f, .2f, .2f);

            if (selectionRect.x < 15)
            {
                // Second Column, small scale
                folderRect = new Rect(selectionRect.x + 3, selectionRect.y, selectionRect.height, selectionRect.height);
            }
            else if (selectionRect.x >= 15 && selectionRect.height < 30)
            {
                // First column
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.height, selectionRect.height);
                backgroundColor = new Color(0.22f, 0.22f, 0.22f);
            }
            else
            {
                // Second column, big scale
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width, selectionRect.width);
            }

            return folderRect;
        }

        public static void SetIconName(string m_iconName)
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            string iconPath = "Assets/Icons/" + m_iconName + ".png";
            string iconGuid = AssetDatabase.GUIDFromAssetPath(iconPath).ToSafeString();

            EditorPrefs.SetString(folderGuid, iconGuid);
            // iconName = m_iconName;
        }

        public static void ResetFolderTexture()
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            EditorPrefs.DeleteKey(folderGuid);
        }
    }
}

#endif