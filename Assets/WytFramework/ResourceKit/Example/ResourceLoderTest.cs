using UnityEngine;
using UnityEngine.SceneManagement;
using WytFramework.ResourceKit;

public class ResourceLoderTest : MonoBehaviour
{
    private ResLoader _resLoader = new ResLoader();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _resLoader.Load<Texture2D>("amazon");
            _resLoader.Load<AudioClip>("Simple Swish 1");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _resLoader.UnloadAllAssets();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnDestroy()
    {
        _resLoader = null;
    }
}
