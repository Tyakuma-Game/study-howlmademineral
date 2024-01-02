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
            EditorGUI.DrawRect(selectionRect, Color.red);
        }

    }
}

#endif