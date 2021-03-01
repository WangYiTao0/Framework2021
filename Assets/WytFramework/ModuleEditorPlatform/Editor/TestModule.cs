using UnityEngine;

namespace WytFramework
{
    public class TestModule : IEditorPlatformModule
    {
        public void OnGUI()
        {
            GUILayout.Label("New Module", new GUIStyle() { fontSize = 30 }); 
        }
    }
}
