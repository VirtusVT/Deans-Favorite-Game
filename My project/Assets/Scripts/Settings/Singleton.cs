using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (Instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                obj.hideFlags = HideFlags.HideAndDontSave;
                _instance = obj.AddComponent<T>();
            }
            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance == this) _instance = null;
    }
}
/*
public class SingletonPersitent<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (Instance == null)
            {
                Scene activeScene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Managers"));
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                obj.hideFlags = HideFlags.HideAndDontSave;
                _instance = obj.AddComponent<T>();
                SceneManager.SetActiveScene(activeScene);
            }
            return _instance;
        }
    }

    private void OnDestroy()
    {
        if (_instance == this) _instance = null;
    }
}*/
