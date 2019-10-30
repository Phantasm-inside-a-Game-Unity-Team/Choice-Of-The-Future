using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // 摄像机是否跟随主角
    public bool ifCameraFollowPlayer = true;
    // 主角
    GameObject player;

    // Start is called before the first frame update
    void Start() {
        // 寻找Tag名为“Player”的游戏对象（即主角）
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        FollowPlayer();
    }

    void FollowPlayer () {
        if(ifCameraFollowPlayer) {
            transform.position = player.transform.position - Vector3.forward * 10f;
        }
    }
}
