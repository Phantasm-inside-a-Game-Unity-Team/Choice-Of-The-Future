using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class UIManager : SingletonTemplate<UIManager>
{
    public int score;
    public int playerHP;
    public int hitCount;
    public Text hitCountText;
    public Text scoreText;
    public GameObject buttonGameOver;
    public GameObject buttonLevelClear;

    // Use this for initialization
    void Start()
    {
        DemoSceneManager.Instance.GameOverEvent += UIgameOver;
        DemoSceneManager.Instance.LevelClearEvent += UIlevelClear;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UIgameOver(object sender,EventArgs e)
    {
        buttonGameOver.SetActive(true);
    }
    public void UIlevelClear(object sender, EventArgs e)
    {
        buttonLevelClear.SetActive(true);
    }
}
