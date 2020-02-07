using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapTestSceneManager : SingletonTemplate<TilemapTestSceneManager>
{
    public GameObject playerPrefeb;
    public GameObject player;
    public Vector3 playerInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneStart()
    {
        if (player == null)
        {
            if (playerPrefeb == null)
            {
                playerPrefeb = Resources.Load("Reimu") as GameObject;

            }
            player = Instantiate<GameObject>(playerPrefeb, playerInitialPosition, Quaternion.identity);
        }
        else
        {
            player.transform.position = playerInitialPosition;
        }
    }
}
