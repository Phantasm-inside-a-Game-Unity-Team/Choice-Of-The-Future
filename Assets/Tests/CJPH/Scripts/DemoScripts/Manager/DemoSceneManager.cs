using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DemoSceneManager : SingletonTemplate<DemoSceneManager>
{
    public List<GameObject> player;
    public List<GameObject> enemies;
    public Points points;
    public List<int> spawnTime;
    public List<GameObject> spawnEnemy;
    private int spawnIndex = 0;

    public GameObject playersObj;
    public GameObject enemiesObj;
    public GameObject playerBullentsObj;
    public GameObject enemyBullentsObj;
    public GameObject itemsObj;

    public float areaBorderX;
    public float areaBorderY;

    private int frameZero;
    public int frameSinceLevelLoad { get { return Time.frameCount - frameZero; } }

    public event EventHandler GameOverEvent;
    public event EventHandler LevelClearEvent;

    void Awake()
    {
        Time.timeScale = 1;
        //player = (GameObject)Instantiate(Resources.Load("Prefabs/Player_Yuyuko"));
        for (int i = 0; i < player.Count; i++)
        {
            player[i] = Instantiate(player[i]);
            player[i].transform.parent = playersObj.transform;
        }
    }
    void Start()
    {
        frameZero = Time.frameCount;
    }
    void Update()
    {
        if (player.Count == 0)
        {
            Invoke("GameOver", 1f);
        }
        EnemySpawn();
        if (spawnIndex >= spawnTime.Count && enemies.Count == 0)
        {
            Invoke("LevelClear", 1f);
        }
    }

    void EnemySpawn()
    {
        if (spawnIndex < spawnTime.Count && frameSinceLevelLoad > spawnTime[spawnIndex])
        {
            Point spawnPoint = points.GetNextPoint(true);
            if (spawnPoint != null)
            {
                GameObject enemy = (GameObject)Instantiate(spawnEnemy[spawnIndex], spawnPoint.position, spawnPoint.rotation);
                enemy.transform.parent = enemiesObj.transform;
                enemies.Add(enemy);
            }
            spawnIndex++;
        }
    }

    public float GetAreaBorderX()
    {
        return areaBorderX;
    }
    public float GetAreaBorderY()
    {
        return areaBorderY;
    }
    void GameOver()
    {
        if (GameOverEvent != null)
            GameOverEvent(this, EventArgs.Empty);
    }
    void LevelClear()
    {
        if (LevelClearEvent != null)
            LevelClearEvent(this, EventArgs.Empty);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Profeb Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
