using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public Text tempDialogText;
    public Text SelectionA;
    public Text SelectionB;
    public Text SelectionC;
    public Text SelectionD;

    DialogTextIO ioManager;//读写器单例
    DialogPackage tempPackage;//当前语句包
    DialogText tempText;//当前包中的当前文本
    int tempIndex;//当前序号
    int indexLength;//长度
    void Start()
    {
        ioManager = GetComponent<DialogTextIO>();
        tempPackage = ioManager.dialogPackage;
        indexLength = tempPackage.dialogTextList.Capacity;
        tempIndex = 0;
        Debug.Log(indexLength+"aaaaaa");
        //自动载入一次
        tempDialogText.text = tempPackage.dialogTextList[tempIndex].Text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StateCheck()
    {

    }
    void LoadNext()//载入下一段文字
    {
        
    }
}
