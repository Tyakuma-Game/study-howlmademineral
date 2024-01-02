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
        static ColoredFoldersEditor()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        static void OnGUI(string guid, Rect selectionRect)
        {
            Rect folderRect;
            Color backgroundColor = new Color(.2f, .2f, .2f);


            if (selectionRect.x < 15)
            {
                // Second Column, small scale
                folderRect = new Rect(selectionRect.x + 3, selectionRect.y, selectionRect.height, selectionRect.height);
            }
            else if(selectionRect.x >= 15 && selectionRect.height < 30)
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
            EditorGUI.DrawRect(folderRect, backgroundColor);

            Texture2D folderTexture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Icons/Blue.png");

            GUI.DrawTexture(folderRect, folderTexture);

            // EditorGUI.DrawRect(selectionRect, Color.red);
        }

    }
}

#endif