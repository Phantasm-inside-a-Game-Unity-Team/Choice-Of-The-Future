using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleImageManager : MonoBehaviour
{
    public GameObject TitleImage;

    public GameObject TitleUI;

    public string changeSceneName;

    public string loadingScene;

    SpriteRenderer TitleImageRenderer;

    // Start is called before the first frame update
    void Start () {
        ImageHide();
        // 重复调用ImageShow方法，从第0秒开始，每0.01秒调用一次
        InvokeRepeating("ImageShow", 0, 0.01f);
    }

    // Update is called once per frame
    void Update () 
    {
        EnterToNewScene();
    }

    // 将图片隐藏掉
    void ImageHide () {
        TitleImageRenderer = TitleImage.GetComponent<SpriteRenderer>();
        Color a = TitleImageRenderer.color;
        a.a = 0;
        TitleImage.GetComponent<SpriteRenderer>().color = a;
    }

    // 图像渐出效果
    void ImageShow () {
        Color a = TitleImageRenderer.color;
        // 注意这里a.a是一个介于0~1之间的数
        if(a.a < 1) {
            a.a += 0.02f;
        }
        TitleImage.GetComponent<SpriteRenderer>().color = a;
    }

    // 图像渐隐效果
    void ImageDisappear () {
        Color a = TitleImageRenderer.color;
        // 注意这里a.a是一个介于0~1之间的数
        if(a.a >= 0) {
            // 这里减去0.04f的原因是要抵消掉ImageShow的效果
            a.a = a.a - 0.04f;
        }
        TitleImage.GetComponent<SpriteRenderer>().color = a;

        if(a.a <= 0){
            SceneManager.LoadScene(loadingScene);
            Globle.changeSceneName  = changeSceneName;
        }
    }

    // 切换场景
    void EnterToNewScene () {
        // 如果按下回车键
        if(Input.GetKeyDown(KeyCode.Return)){
            Destroy(TitleUI);
            InvokeRepeating("ImageDisappear", 0, 0.01f);
        }
    }
}
