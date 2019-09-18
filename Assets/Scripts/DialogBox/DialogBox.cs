﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    // 角色的四面图
    public Sprite characterLeft;
    public Sprite characterRight;
    public Sprite characterUp;
    public Sprite characterDown; 

    // 主角靠近NPC的时候头顶生成的小物件，表示可以对话
    // public Sprite iconOfNPCCanSpeak;

    // 可以对话的标志
    bool flagOfCanSpeak;
    // 可以对话的最远距离
    public float distanceOfCanSpeak = 1.2f;
    // 对话框正在打开的标志
    public bool flagOfDialogBox;
    
    // 角色的朝向
    public bool left;
    public bool right;
    public bool up;
    public bool down; 

    // Start is called before the first frame update
    void Start() {
        flagOfCanSpeak = false;
        flagOfDialogBox = false;
    }

    // Update is called once per frame
    void Update(){
        checkPosition();
        OpenDialogBox();
    }

    // 计算NPC与主角的距离从而判断主角是否能和此npc对话
    void checkPosition() {
        // 获取主角的信息
        GameObject Player = GameObject.FindWithTag("Player");
        if(System.Math.Abs(Player.transform.position.x - transform.position.x) < distanceOfCanSpeak && System.Math.Abs(Player.transform.position.y - transform.position.y) < distanceOfCanSpeak) {
            Color a = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
            a.a = 1;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = a;
            flagOfCanSpeak = true;
        }
        else {
            Color a = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
            a.a = 0;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = a;
            flagOfCanSpeak = false;
        }
    }

    // 打开对话框
    void OpenDialogBox() {
        // 判断条件：到达可以说话的距离而且按下了键盘的E键而且对话框并没有打开
        if(flagOfCanSpeak && Input.GetKey(KeyCode.E) && !flagOfDialogBox) {
            flagOfDialogBox = true;
            // 获取主角的信息
            GameObject Player = GameObject.FindWithTag("Player");
            // 根据主角的朝向判断NPC的朝向
            if(Player.GetComponent<label>().right == true) {
                left = true;
                GetComponent<SpriteRenderer>().sprite = characterLeft;
            }
            else if(Player.GetComponent<label>().left == true) {
                right = true;
                GetComponent<SpriteRenderer>().sprite = characterRight;
            }
            else if(Player.GetComponent<label>().up == true) {
                down = true;
                GetComponent<SpriteRenderer>().sprite = characterDown;
            }
            else if(Player.GetComponent<label>().down == true) {
                up = true;
                GetComponent<SpriteRenderer>().sprite = characterUp;
            }

            // 从这里调用对话框函数
            Debug.Log("DialogBox!");

            flagOfDialogBox = false;
        }
    }
}