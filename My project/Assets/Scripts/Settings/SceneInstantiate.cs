using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInstantiate : MonoBehaviour
{
    [SerializeField] private Object persistentScene;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(persistentScene.name, LoadSceneMode.Additive);
    }

    //Test-Function in Inspector per Right Click on this Script
    [ContextMenu("ChangeScene")]
    public void NextScene()
    {
        SceneManager.UnloadSceneAsync("FirstScene");
        SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
    }
}
