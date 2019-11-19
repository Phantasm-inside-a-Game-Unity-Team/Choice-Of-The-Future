using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD_LifeMark : MonoBehaviour
{
    /*
     *专门给血量，即残机计量用的动态变化效果，每个都可以。
     */
    public Image LifeMark;
    public Image LifeMarkShadow;
    public PlayerHUD HUDControl;
    public float timer;
    private const float MAXTIMER=1f;
    //以上变量原理同PlayerHUD中的
    void Start()
    {
        
        timer = 0;
    }


    void Update()
    {
        //MarkShrink();
    }

}
