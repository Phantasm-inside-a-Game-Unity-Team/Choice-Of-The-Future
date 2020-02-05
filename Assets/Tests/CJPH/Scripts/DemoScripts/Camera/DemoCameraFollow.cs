using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DemoCameraFollow : MonoBehaviour
{
    public float speed;

    private List<GameObject> player;
    private GameObject aimedPlayer;
    private float screenBorderX;
    private float screenBorderY;

    // Use this for initialization
    void Start()
    {
        player = DemoSceneManager.Instance.player;
        if (player.Count != 0)
        {
            aimedPlayer = player[0];
        }
        screenBorderX = DemoSceneManager.Instance.areaBorderX;
        screenBorderY = DemoSceneManager.Instance.areaBorderY;
    }

    // Update is called once per frame
    void Update()
    {
        if (aimedPlayer == null)
            return;
        float interpolation = speed * Time.deltaTime;
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, aimedPlayer.transform.position.x, interpolation);
        position.y = Mathf.Lerp(transform.position.y, aimedPlayer.transform.position.y, interpolation);
        float orthographicSize = GetComponent<Camera>().orthographicSize;//orthographicSize代表相机(或者称为游戏视窗)竖直方向一半的范围大小,且不随屏幕分辨率变化(水平方向会变)
        var cameraHalfWidth = orthographicSize * ((float)Screen.width / Screen.height);//的到视窗水平方向一半的大小
        position.x = Mathf.Clamp(position.x, -screenBorderX + cameraHalfWidth, screenBorderX - cameraHalfWidth);//限定x值
        position.y = Mathf.Clamp(position.y, -screenBorderY + orthographicSize, screenBorderY - orthographicSize);//限定y值
        transform.position = position;
    }
}
