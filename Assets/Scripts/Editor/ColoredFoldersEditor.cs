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
            if(selectionRect.x > 15)
            {
                if(selectionRect.height > 20)
                {
                    // Second column, big scale
                    EditorGUI.DrawRect(selectionRect, Color.blue);
                }
                else
                {
                    // First column
                    EditorGUI.DrawRect(selectionRect, Color.red);
                }
            }
            else
            {
                // Second column, small scale
                EditorGUI.DrawRect(selectionRect, Color.blue);
            }



            /*
            if(Selection.activeObject == null)
            {
                return;
            }

            string activeObjectGuid = AssetDatabase.
                GUIDFromAssetPath(AssetDatabase.GetAssetPath(Selection.activeObject)).ToString();

            if(activeObjectGuid == guid )
            {
                Debug.Log("Rect : " + selectionRect);
            }
            */

            // EditorGUI.DrawRect(selectionRect, Color.red);
        }

    }
}

#endif