using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTest : MonoBehaviour
{
    private SMSNotifiler mSMSNotifiler;
    private DemoTaskManager mTaskManager;
    void Start()
    {
        if (mSMSNotifiler == null)
            mSMSNotifiler = SMSNotifiler.Instance;

        if (mTaskManager == null)
            mTaskManager = DemoTaskManager.Instance;
    }
    private void OnGUI()
    {
        if (GUILayout.Button("接受任务Task1"))
        {
            mTaskManager.AcceptTask("T001");
        }
        if (GUILayout.Button("接受任务Task2"))
        {
            mTaskManager.AcceptTask("T002");
        }
        if (GUILayout.Button("接受任务T003"))
        {
            mTaskManager.AcceptTask("T003");
        }
        if (GUILayout.Button("打怪Enemy1"))
        {
            TaskArgs e = new TaskArgs();
            e.conditionID = "Enemy1";
            e.amount = 1;
            mTaskManager.CheckTask(e);
        }
        if (GUILayout.Button("打怪Enemy2"))
        {
            TaskArgs e = new TaskArgs();
            e.conditionID = "Enemy2";
            e.amount = 1;
            mTaskManager.CheckTask(e);
        }
    }
}