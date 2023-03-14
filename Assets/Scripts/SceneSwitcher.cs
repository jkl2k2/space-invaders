using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string menuNameScene;
    public string gameSceneName;
    public string creditsSceneName;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        GetComponent<AudioSource>().Play();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
    }

    public void LoadCreditsScene()
    {
        StartCoroutine(LoadCreditsSceneDelayed());
    }
    
    IEnumerator LoadCreditsSceneDelayed()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(creditsSceneName, LoadSceneMode.Single);
        StartCoroutine(LoadMenuFromCreditsDelayed());
    }

    IEnumerator LoadMenuFromCreditsDelayed()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(menuNameScene, LoadSceneMode.Single);
    }
}
