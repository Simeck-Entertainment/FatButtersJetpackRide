using UnityEngine;

public class FramerateManager : MonoBehaviour
{
    public const int TargetFramerate = 60;
    private static FramerateManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        gameObject.transform.parent = null;
        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = TargetFramerate;
        Debug.Log($"Frame rate set to {TargetFramerate} FPS");
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
