using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class DialogTextIO : MonoBehaviour
{
    /*此处用于接收来自于游戏触发的开始对话的指示
     * 开始对话的消息包括引用的对话包信息，如编号，应当另外在某个表格文件里面写上编号和包名的参照
     * 根据这些信息读取对话包。（当然，游戏当中的气泡对话信息另算，应该直接每次调用单个气泡语句就行。）
     * 
     * 本脚本的对象应当是单例（Singleton）
     */
    public bool ifDialogOn;
    public DialogPackage dialogPackage=new DialogPackage();

    void Awake()
    {
        //GetNextText();
        dialogPackage=getSerializedPackageByName("VeryFirstDialogPackage");
        Debug.Log(dialogPackage.packageName);
        Debug.Log(dialogPackage.dialogTextList[0].Text);
    }

    void Update()
    {
        
    }
    public DialogPackage getDialogPackageByName(string packageName)
    {
        return getSerializedPackageByName(packageName);
    }
    //测试连接功能用函数
    public string GetNextText()
    {
        XmlDocument DialogXML = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load("Texts/DialogPackages");
        DialogXML.LoadXml(textAsset.text);
        XmlNodeList elemList = DialogXML.GetElementsByTagName("DialogText");
        foreach (XmlElement element in elemList)
        {
            Debug.Log(element.GetAttribute("TextSequenceID")+""+ element.InnerText);
        }
        return null;
    }
    //获取包内容,序列化好麻烦啊
    public DialogPackage getSerializedPackageByName(string packageName)
    {
        XmlDocument DialogXML = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load("Texts/DialogPackages");
        DialogXML.LoadXml(textAsset.text);
        XmlNodeList packageList = DialogXML.GetElementsByTagName("DialogPackage");
        XmlNodeList elemList = DialogXML.GetElementsByTagName("DialogText");

        DialogPackage tempDialogPackage = new DialogPackage();
        //以上这一段是通用的获取整个xml元素列表的代码，下面应当接着使用遍历来获取或修改其中信息
        foreach (XmlNode package in packageList)
        {
            //得到包的标签就开始读取该标签内部的东西
            if (package.Attributes["packageName"].Value == packageName)
            {
                tempDialogPackage.packageID= int.Parse(package.Attributes["packageID"].Value);
                tempDialogPackage.packageName = packageName;
                foreach (XmlNode element in package.ChildNodes)
                {
                        //把每一个DialogText读取到Package里面
                    if (element.Name == "DialogText")
                    {
                        DialogText tempText=new DialogText();
                        //读取文本,ID,Tag以及选项
                        tempText.ID = int.Parse(element.Attributes["TextSequenceID"].Value);
                        tempText.Text = element.InnerText;
                        tempText.TextTag = element.Attributes["TextTag"].Value;
                        //若有分支则继续读取支线内容
                        if (element.Attributes["TextTag"].Value == "BranchText")
                        {
                            foreach (XmlNode selection in element.ChildNodes)
                            {
                                if (selection.Name == "DialogTextQuest")
                                {
                                    tempText.Text = selection.FirstChild.InnerText;
                                }
                                if (selection.Name == "DialogTextSelection")
                                {
                                    tempText.Selections.Add(selection.InnerText);
                                }
                            }
                        }
                        //将读取到的本段对话加入生成的对话包里
                        tempDialogPackage.dialogTextList.Add(tempText);
                    } 
                }
            }
        }
        //返回完整的对话包
        return tempDialogPackage;
    }
    public void getSerializedPackageByID(int packageID)
    {
        XmlDocument DialogXML = new XmlDocument();
        TextAsset textAsset = (TextAsset)Resources.Load("Texts/DialogPackages");
        DialogXML.LoadXml(textAsset.text);
        XmlNodeList elemList = DialogXML.GetElementsByTagName("DialogText");
        //

    }
}
