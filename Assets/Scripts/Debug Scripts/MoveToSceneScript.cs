using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToSceneScript : MonoBehaviour
{
    public string sceneName;
    public int sceneIndex;

    public void moveToScene()
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if(sceneIndex != 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Uh oh! You may have forgotten to assign the scene!");
        }
    }
}
