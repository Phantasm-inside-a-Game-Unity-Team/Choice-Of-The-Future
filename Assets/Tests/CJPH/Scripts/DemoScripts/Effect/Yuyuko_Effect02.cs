using UnityEngine;
using System.Collections;

public class Yuyuko_Effect02 : MonoBehaviour
{
    public int existFrame;
    private int startFrame;
    // Use this for initialization
    void Start()
    {
        startFrame = DemoSceneManager.Instance.frameSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if ((DemoSceneManager.Instance.frameSinceLevelLoad - startFrame) > existFrame)
        {
            Destroy(gameObject);
        }
    }
}
