using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 此插件用于Loading画面中灵梦走路的效果制作
public class CharacterMovingManager : MonoBehaviour
{
    // 加载图片
    public Sprite loadingImage1;
    public Sprite loadingImage2;
    public Sprite loadingImage3;

    // 图片切换的速度（秒）
    public float speed = 0.2f;

    // 播放图片的顺序
    private int i = 0;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("CharacterImageChange", 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CharacterImageChange() {
        if(i % 4 == 0  || i % 4 ==2) {
            // 加载组件
            GetComponent<SpriteRenderer>().sprite = loadingImage1;
        }
        if(i % 4 == 1) {
            // 加载组件
            GetComponent<SpriteRenderer>().sprite = loadingImage2;
        }
        if(i % 4 == 3) {
            // 加载组件
            GetComponent<SpriteRenderer>().sprite = loadingImage3;
        }
        i++;
    }
}
