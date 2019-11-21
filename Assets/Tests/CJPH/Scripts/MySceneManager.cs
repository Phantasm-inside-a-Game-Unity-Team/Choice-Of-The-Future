//管理场景内角色的实例化和初始位置

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : SingletonTemplate<MySceneManager>
{
    public GameObject playerPrefeb;         //玩家角色预设体
    public GameObject player;               //玩家角色
    public Vector3 playerInitialPosition;   //场景加载后角色初始位置
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //初始化方法，新场景加载后由SceneInit类调用
    public void SceneStart()
    {
        if (player == null)
        {
            if (playerPrefeb == null)   //正常从InitialScene进入的话不需要这段，如果直接启动Scene01或Scene02的话，会新建MySceneManager类而无playerPrefeb的引用，所以需要再加载。
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
