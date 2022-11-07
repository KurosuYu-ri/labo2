using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript: MonoBehaviour
{
    public Image LoadBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelAsync());
        LoadBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadLevelAsync()
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");

        while(!asyncOperation.isDone)
        {
            LoadBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
