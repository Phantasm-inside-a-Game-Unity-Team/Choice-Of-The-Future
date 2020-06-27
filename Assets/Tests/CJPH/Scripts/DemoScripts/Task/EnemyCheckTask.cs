using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckTask : MonoBehaviour
{
    public string conditionID;
    void OnDestroy()
    {
        TaskArgs e = new TaskArgs();
        e.conditionID = conditionID;
        e.amount = 1;
        DemoTaskManager.Instance.CheckTask(e);
    }
}
