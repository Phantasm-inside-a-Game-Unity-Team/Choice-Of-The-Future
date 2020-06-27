using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskEventType
{
    OnGetEvent = 0,
    OnCheackEvent = 1,
    OnFinishEvent = 2,
    OnRewardEvent = 3,
    OnCancelEvent = 4
}
public class TaskEvent
{
    public delegate void TaskDelegate(TaskArgs args);
    private List<TaskDelegate> taskDelegateList;
    private List<TaskDelegate> mAddListener;
    private event TaskDelegate OnGetEvent;      //接受任务时,更新任务到任务面板等操作
    private event TaskDelegate OnCheckEvent;    //更新任务信息
    private event TaskDelegate OnFinishEvent;   //完成任务时,提示完成任务等操作
    private event TaskDelegate OnRewardEvent;   //得到奖励时,显示获取的物品等操作
    private event TaskDelegate OnCancelEvent;   //取消任务时,显示提示信息等操作
    private static TaskEvent mInstance;
    public TaskEvent()
    {
        taskDelegateList = new List<TaskDelegate>();
        taskDelegateList.Add(OnGetEvent);
        taskDelegateList.Add(OnCheckEvent);
        taskDelegateList.Add(OnFinishEvent);
        taskDelegateList.Add(OnRewardEvent);
        taskDelegateList.Add(OnCancelEvent);

    }
    public static TaskEvent Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = new TaskEvent();
            return mInstance;
        }

    }
    public bool isCheckNull(int index)
    {
        return taskDelegateList[index] == null ? true : false;
    }
    //添加事件
    public void AddEventListen(TaskDelegate temp, int index)
    {
        if (taskDelegateList[index] != null) return;
        taskDelegateList[index] += temp;
    }
    //回调事件
    public void InvokeEvent(int index, TaskArgs args)
    {
        if (index > taskDelegateList.Count - 1)
        {
            Debug.Log("链表索引越界");
            return;
        }
        if (!isCheckNull(index))
            taskDelegateList[index](args);
    }
    //清空所有的监听事件
    public void ClearListTransfer()
    {
        int i = 0;
        IEnumerator listEnumerartor = taskDelegateList.GetEnumerator();
        while (listEnumerartor.MoveNext())
        {
            TaskDelegate mes = (TaskDelegate)listEnumerartor.Current;
            mes -= mAddListener[i];
            i++;
        }
        taskDelegateList.Clear();
    }


}