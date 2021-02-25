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
        static List<IEditorPlatformModule> mMoudles = new List<IEditorPlatformModule>();

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
            mMoudles.Clear();
            // 1. Get all the assmeblies in Current Project (dll)
            var assmeblies = AppDomain.CurrentDomain.GetAssemblies();
            // 2. Get Current Editor Environment (dll)
            var editorAssembly = assmeblies.First(assmebly => assmebly.FullName.StartsWith("Assembly-CSharp-Editor"));
            // 3. Get IEditorPlatformModule Type
            var moduleTyoe = typeof(IEditorPlatformModule);

            mMoudles = editorAssembly.
                // Get all Type in Editor Environment
                GetTypes()
                // Remove abstract type,  Unimplement the IEditorPlatformModeule Type
                .Where(type => moduleTyoe.IsAssignableFrom(type) && !type.IsAbstract)
                // Get Constructor to Create instance
                .Select(type => type.GetConstructors().First().Invoke(null))
                // Cast to IEditorPlatformModule Type
                .Cast<IEditorPlatformModule>()
                // Cast List<IEditorPlatformModule>
                .ToList();

            editorPlatform.Show();
        }

        private void OnGUI()
        {
            //Render
            foreach(var editorPlatformModule in mMoudles)
            {
                editorPlatformModule.OnGUI();
            }
        }
    }
}
