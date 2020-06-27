using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMSNotifiler : SingletonTemplate<SMSNotifiler>
{
    private void Start()
    {
        TaskEvent.Instance.AddEventListen(GetPrintInfo, (int)TaskEventType.OnGetEvent);
        TaskEvent.Instance.AddEventListen(finishPrintInfo, (int)TaskEventType.OnFinishEvent);
        TaskEvent.Instance.AddEventListen(rewardPrintInfo, (int)TaskEventType.OnRewardEvent);
        TaskEvent.Instance.AddEventListen(cancelPrintInfo, (int)TaskEventType.OnCancelEvent);
        TaskEvent.Instance.AddEventListen(cheackPrintInfo, (int)TaskEventType.OnCheackEvent);
    }
    public void GetPrintInfo(TaskArgs e)
    {
        print("接受任务" + e.taskID);
    }

    public void finishPrintInfo(TaskArgs e)
    {
        print("完成任务" + e.taskID);
    }

    public void rewardPrintInfo(TaskArgs e)
    {
        print("奖励物品" + e.conditionID + "数量" + e.amount);
    }

    public void cancelPrintInfo(TaskArgs e)
    {
        print("取消任务" + e.taskID);
    }
    public void cheackPrintInfo(TaskArgs e)
    {
        print(string.Format("任务是{0},{1}完成了{2}", e.taskID, e.conditionID, e.amount));
    }
}
