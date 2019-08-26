using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 此插件用于Loading画面中“少女祈祷中”字样的动态效果制作
public class NowLoadingManager : MonoBehaviour
{
    // 加载图片
    public Sprite loadingImage1;
    public Sprite loadingImage2;
    public Sprite loadingImage3;

    // 图片切换的速度（秒）
    public float speed = 0.3f;
    
    // 播放图片的顺序
    private int i = 0;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("LoadingImageChange", 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadingImageChange() {
        if(i % 3 == 0) {
            // 加载组件
            GetComponent<SpriteRenderer>().sprite = loadingImage1;
        }
        if(i % 3 == 1) {
            // 加载组件
            GetComponent<SpriteRenderer>().sprite = loadingImage2;
        }
        if(i % 3 == 2) {
            // 加载组件
            GetComponent<SpriteRenderer>().sprite = loadingImage3;
        }
        i++;
    }
}
