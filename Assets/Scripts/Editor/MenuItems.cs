using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace Tabsil.Mineral
{
    /// <summary>
    /// フォルダのアイコンと関連メニューを管理するクラス
    /// </summary>
    static class MenuItems
    {
        const int priority = 10000;

        /// <summary>
        /// "Red" フォルダアイコンを設定するメニュー項目
        /// </summary>
        [MenuItem("Assets/Mineral/Red", false, priority)]
        static void Red()
        {
            ColoredFoldersEditor.SetIconName("Red");
        }

        /// <summary>
        /// "Green" フォルダアイコンを設定するメニュー項目
        /// </summary>
        [MenuItem("Assets/Mineral/Green", false, priority)]
        static void Green()
        {
            ColoredFoldersEditor.SetIconName("Green");
        }

        /// <summary>
        /// "Blue" フォルダアイコンを設定するメニュー項目
        /// </summary>
        [MenuItem("Assets/Mineral/Blue", false, priority)]
        static void Blue()
        {
            ColoredFoldersEditor.SetIconName("Blue");
        }

        /// <summary>
        /// カスタムアイコンを選択するメニュー項目
        /// </summary>
        [MenuItem("Assets/Mineral/Custom Icon...", false, priority + 11)]
        static void Custom()
        {
            IconFoldersEditor.ChooseCustomIcon();
        }

        /// <summary>
        /// フォルダアイコンをリセットするメニュー項目
        /// </summary>
        [MenuItem("Assets/Mineral/Reset Icon", false, priority + 23)]
        static void ResetIcon()
        {
            ColoredFoldersEditor.ResetFolderTexture();
        }

        /// <summary>
        /// フォルダメニュー項目の有効性を検証するメソッド
        /// </summary>
        [MenuItem("Assets/Mineral/Red", true)]
        [MenuItem("Assets/Mineral/Green", true)]
        [MenuItem("Assets/Mineral/Blue", true)]
        [MenuItem("Assets/Mineral/Custom Icon...", true)]
        [MenuItem("Assets/Mineral/Reset Icon", true)]
        static bool ValidateFolder()
        {
            // 選択されたオブジェクトが存在しない場合、メニュー項目を無効にする
            if (Selection.activeObject == null)
            {
                return false;
            }

            // 選択されたオブジェクトのパス取得
            Object selectedObject = Selection.activeObject;
            string objectPath = AssetDatabase.GetAssetPath(selectedObject);

            // 選択されたオブジェクトがフォルダであるかどうかを検証し、結果を返す
            return AssetDatabase.IsValidFolder(objectPath);
        }
    }
}

#endif