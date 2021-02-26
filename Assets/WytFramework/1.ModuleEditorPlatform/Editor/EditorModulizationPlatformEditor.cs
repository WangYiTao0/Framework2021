using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace WytFramework
{
    public class EditorModulizationPlatformEditor : EditorWindow
    {
        /// <summary>
        /// Editor Module
        /// </summary>
        static ModuleContainer<IEditorPlatformModule> mModuleContainer = new ModuleContainer<IEditorPlatformModule>();

        /// <summary>
        /// Open Window
        /// </summary>
        [MenuItem("WytFramework/0.EditorModulizationPlatform")]
        public static void Open()
        {
            var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();

            editorPlatform.position = new Rect(Screen.width / 2, Screen.height * 2 / 3, 600, 500);
            editorPlatform.Show();

            // clear the modules
            mModuleContainer.Modules.Clear();

            mModuleContainer.Scan("Assembly-CSharp-Editor");

            editorPlatform.Show();
        }

        private void OnGUI()
        {
            //Render
            foreach(var editorPlatformModule in mModuleContainer.Modules)
            {
                editorPlatformModule.OnGUI();
            }
        }
    }
}
