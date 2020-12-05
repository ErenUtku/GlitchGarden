using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    Scene scene;
    int CurrentSceneIndex;
    float wait = 3.5f;
    void Start()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (CurrentSceneIndex == 0)
        {
            StartCoroutine(LoadCoroutine());
        }
    }
    IEnumerator LoadCoroutine()
    {
        yield return new WaitForSeconds(wait);
        LoadNextScene();
        
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }
}
