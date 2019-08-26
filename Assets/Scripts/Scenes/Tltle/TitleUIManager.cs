using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    public CanvasGroup Gruop;

    // Start is called before the first frame update
    void Start()
    {
        // 获取CanvasGroup组件
        Gruop = GetComponent<CanvasGroup>();
        canvasHide();
        // 重复调用imageShow方法，从第0秒开始，每0.01秒调用一次
        InvokeRepeating("canvasShow", 0.5f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 隐藏UI
    void canvasHide() {
        Gruop.alpha = 0;
    }

    // UI渐出效果
    void canvasShow () {
        if(Gruop.alpha < 1) {
            Gruop.alpha += 0.02f;
        }
    }

    // UI渐隐效果
    void canvasDisappear () {
        if(Gruop.alpha > 0) {
            Gruop.alpha -= 0.02f;
        }
    }
}
