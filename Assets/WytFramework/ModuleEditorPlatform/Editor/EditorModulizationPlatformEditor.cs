using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using WytFramework.ServiceLocator;

namespace WytFramework
{
    public class EditorModulizationPlatformEditor : EditorWindow
    {
        /// <summary>
        /// 用来缓存模块的容器
        /// </summary>
        private ModuleContainer mModuleContainer = null;

        /// <summary>
        /// Open Window
        /// </summary>
        [MenuItem("WytFramework/0.EditorModulizationPlatform")]
        public static void Open()
        {
            var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();

            editorPlatform.position = new Rect(Screen.width / 2, Screen.height * 2 / 3, 600, 500);
            editorPlatform.Show();

            // 组装 Container
            var cache = new EditorPlatformModuleCache();
            var factory = new EditorPlatformModuleFactory();

            editorPlatform.mModuleContainer = new ModuleContainer(cache, factory);

            editorPlatform.Show();
        }

        private void OnGUI()
        {
            // 获取全部模块
            var modules = mModuleContainer.GetModules<IEditorPlatformModule>();

            //Render
            foreach(var editorPlatformModule in modules)
            {
                editorPlatformModule.OnGUI();
            }
        }
    }
}
