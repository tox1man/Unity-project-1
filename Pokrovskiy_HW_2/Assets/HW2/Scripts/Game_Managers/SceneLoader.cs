using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(scene);
    }
    public static Scene[] GetLoadedScenes()
    {
        Scene[] allScenes = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            allScenes[i] = SceneManager.GetSceneAt(i);
        }
        return allScenes;
    }
}
