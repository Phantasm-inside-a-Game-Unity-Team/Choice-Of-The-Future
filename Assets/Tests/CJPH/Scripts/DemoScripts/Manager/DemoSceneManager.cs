using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSceneManager : SingletonTemplate<DemoSceneManager>
{
    public GameObject mainPlayer;       //主角色实例
    public GameObject subPlayer;
    public List<GameObject> enemies;
    public GameObject boss;
    public Vector3 rebirthPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
