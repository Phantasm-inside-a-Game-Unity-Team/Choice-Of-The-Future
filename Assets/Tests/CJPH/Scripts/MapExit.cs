//场景切换触发，使用碰撞体Trigger
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapExit : MonoBehaviour
{
    public string sceneName;                //跳转的场景名称
    public Vector3 playerInitialPosition;   //跳转后场景中角色的位置
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //角色碰到碰撞体后加载新场景
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DontDestroyOnLoad(other);
            SceneManager.LoadScene(sceneName);
            MySceneManager.Instance.playerInitialPosition = playerInitialPosition;
        }
    }
}
