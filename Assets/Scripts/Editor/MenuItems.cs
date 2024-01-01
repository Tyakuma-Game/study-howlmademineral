using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    static class MenuItems
    {
        [MenuItem("Assets/Mineral/Blue")]
        static void Blue()
        {
            Debug.Log("Coloring the folder blue");
        }
    }
}

#endif