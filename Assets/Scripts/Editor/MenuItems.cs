using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    static class MenuItems
    {
        const int priority = 10000;

        [MenuItem("Assets/Mineral/Red", false, priority)]
        static void Red()
        {
            ColoredFoldersEditor.SetIconName("Red");
        }

        [MenuItem("Assets/Mineral/Green", false, priority)]
        static void Green()
        {
            ColoredFoldersEditor.SetIconName("Green");
        }

        [MenuItem("Assets/Mineral/Blue", false, priority)]
        static void Blue()
        {
            ColoredFoldersEditor.SetIconName("Blue");
        }

        [MenuItem("Assets/Mineral/Custom Icon...", false, priority + 11)]
        static void Custom()
        {
            Debug.Log("Coloring a custom icon...");
        }

        [MenuItem("Assets/Mineral/Reset Icon", false, priority + 23)]
        static void ResetIcon()
        {
            Debug.Log("Reset the folder icon");
        }

        [MenuItem("Assets/Mineral/Red", true)]
        [MenuItem("Assets/Mineral/Green", true)]
        [MenuItem("Assets/Mineral/Blue", true)]
        [MenuItem("Assets/Mineral/Custom Icon...", true)]
        [MenuItem("Assets/Mineral/Reset Icon", true)]
        static bool ValidateFolder()
        {
            if(Selection.activeObject == null)
            {
                return false;
            }

            Object selectedObject = Selection.activeObject;

            string objectPath = AssetDatabase.GetAssetPath(selectedObject);
            return AssetDatabase.IsValidFolder(objectPath);
        }
    }
}

#endif