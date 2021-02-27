using UnityEngine;

namespace WytFramework
{
    public class ModuleContainerModule : IEditorPlatformModule
    {
        public void OnGUI()
        {
            GUILayout.Label("这里是 ModuleCotnainerModule", new GUIStyle()
            {
                fontSize = 20,
                fontStyle = FontStyle.Bold
            }); ;

            GUILayout.Label("1. 并指定接口类型");
            GUILayout.Label("public interface IModule {}");
            GUILayout.Label("2. 创建 ModuleContainer 实例");
            GUILayout.Label("var container = new ModuleContainer<IModule>();");
            GUILayout.Label("3. 在指定 Assembly 中搜索");
            GUILayout.Label("container.Scan(\"Assembly-CSharp-Editor\");");
            GUILayout.Label("4. 获取 Modules");
            GUILayout.Label("var modules = container.Modules;");
        }
    }
}
