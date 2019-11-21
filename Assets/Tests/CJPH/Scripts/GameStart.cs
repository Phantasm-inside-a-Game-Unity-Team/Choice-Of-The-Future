//游戏入口，开始时启动第一个场景

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Scene01");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
