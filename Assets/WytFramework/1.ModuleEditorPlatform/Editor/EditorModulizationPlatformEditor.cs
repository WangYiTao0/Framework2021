using UnityEditor;
using UnityEngine;

namespace WytFramework
{
    public class EditorModulizationPlatformEditor : EditorWindow
    {
        /// <summary>
        /// Open Window
        /// </summary>
        [MenuItem("WytFramework/0.EditorModulizationPlatform")]
        public static void Open()
        {
            var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();

            editorPlatform.position = new Rect(Screen.width / 2, Screen.height * 2 / 3, 600, 500);
            editorPlatform.Show();
        }
    }
}
