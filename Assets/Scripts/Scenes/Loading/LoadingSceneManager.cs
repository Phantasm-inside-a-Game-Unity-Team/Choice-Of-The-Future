using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Invoke("ChangeScene", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene () {
        // 开启协程
        StartCoroutine(ChangeSceneAsync());
    }

    IEnumerator ChangeSceneAsync () {
        AsyncOperation asyne = SceneManager.LoadSceneAsync(Globle.changeSceneName);
        yield return null;
    }
}
