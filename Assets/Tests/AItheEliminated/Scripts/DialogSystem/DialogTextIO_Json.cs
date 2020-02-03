using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class DialogTextIO_Json : MonoBehaviour
{
    //单条语句信息在此读取
    public string text;
    public int textID;
    public int nextTextID;
    public bool ifBranch;
    public string mark;
    public List<string> selections;
    public List<int> selectionIDs;
    void Start()
    {
        StreamReader streamreader = new StreamReader(Application.dataPath + "/Tests/AItheEliminated/Resources/Texts/DialogPackages_Json.json");//读取数据，转换成数据流
        JsonData data = JsonMapper.ToObject(streamreader);
        Debug.Log(data["DialogPackages"][0]["DialogPackage_Test"][0]["PackageID"]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
