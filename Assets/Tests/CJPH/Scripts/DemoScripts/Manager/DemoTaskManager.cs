using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DemoTaskManager : SingletonTemplate<DemoTaskManager>
{
    private Dictionary<string, Task> taskAllDic = new Dictionary<string, Task>();
    private Dictionary<string, Task> currentTaskDic = new Dictionary<string, Task>();
    private List<string> removeTaskList = new List<string>();
    public TextAsset mTextAsset;

    private void Awake()
    {
        taskAllDic = JsonConvert.DeserializeObject<Dictionary<string, Task>>(mTextAsset.text);
        // taskAllDic = UnityEngine.JsonUtility.FromJson <Dictionary<string, Task>> (mTextAsset.text);
        //foreach (var item in taskAllDic)
        //{
        //    string tempName = item.Value.taskName;
        //    Debug.Log(tempName);
        //}
    }

    /// <summary>
    /// 通过taskID获取Task
    /// </summary>
    /// <param name="args"></param>
    public Task GetTaskByID(string ID)
    {
        Task value;
        if (taskAllDic.TryGetValue(ID, out value))
        {
            return value;
        }
        else
        {
            Debug.LogError("任务字典中没有此项");
            return null;
        }
    }
    /// <summary>
    /// 接取任务
    /// </summary>
    /// <param name="args"></param>
    public void AcceptTask(string taskID)
    {
        if (currentTaskDic.ContainsKey(taskID))
        {
            print(string.Format("{0},任务已经接受过", taskID));
            return;
        }
        else
        {
            Task t = GetTaskByID(taskID);
            if (t == null) return;
            if (t.isFinish)
            {
                print(string.Format("{0},任务已经完成了", taskID));
                return;
            }
            currentTaskDic.Add(taskID, t);
            TaskArgs args = new TaskArgs();
            args.taskID = taskID;
            TaskEvent.Instance.InvokeEvent((int)TaskEventType.OnGetEvent, args);
        }
    }
    /// <summary>
    /// 更新任务进度
    /// </summary>
    /// <param name="args"></param>
    public void CheckTask(TaskArgs args)
    {
        foreach (var item in currentTaskDic)
        {
            UpdateCondition(item, args);
            CheckFinishTask(item, args);
        }
        foreach (var taskID in removeTaskList)
        {
            Debug.Log(taskID);
            currentTaskDic.Remove(taskID);
        }
        removeTaskList.Clear();
    }
    //更新数据
    private void UpdateCondition(KeyValuePair<string, Task> item, TaskArgs args)
    {
        TaskConditions tc;
        for (int i = 0; i < item.Value.taskConditions.Count; i++)
        {
            tc = item.Value.taskConditions[i];
            if (tc.conditionID == args.conditionID)
            {
                if (tc.isFinish == true) return;
                tc.nowAmount += args.amount;
                if (tc.nowAmount < 0) tc.nowAmount = 0;
                if (tc.nowAmount >= tc.targetAmount)
                {
                    tc.isFinish = true;
                }
                else tc.isFinish = false;
                args.taskID = item.Value.taskID;
                args.amount = tc.nowAmount;
                //更新UI数据
                TaskEvent.Instance.InvokeEvent((int)TaskEventType.OnCheackEvent, args);
            }
        }
    }
    private void CheckFinishTask(KeyValuePair<string, Task> item, TaskArgs args)
    {
        TaskConditions tc;
        for (int i = 0; i < item.Value.taskConditions.Count; i++)
        {
            tc = item.Value.taskConditions[i];
            if (!tc.isFinish) return;//只要是没有完成就返回
        }
        item.Value.isFinish = true;
        FinishTask(args);
    }
    private void FinishTask(TaskArgs args)
    {
        //调用任务完成事件
        Debug.Log("wancheng");
        TaskEvent.Instance.InvokeEvent((int)TaskEventType.OnFinishEvent, args);
        removeTaskList.Add(args.taskID);
    }
    /// <summary>
    /// 获取任务奖励
    /// </summary>
    /// <param name="args"></param>
    public void GetReward(TaskArgs args)
    {
        if (currentTaskDic.ContainsKey(args.taskID))//当任务存在
        {
            Task t = currentTaskDic[args.taskID];
            for (int i = 0; i < t.taskRewards.Length; i++)
            {
                TaskArgs a = new TaskArgs();
                a.conditionID = t.taskRewards[i].taskRewardID;
                a.amount = t.taskRewards[i].amount;
                a.taskID = args.taskID;
                TaskEvent.Instance.InvokeEvent((int)TaskEventType.OnRewardEvent, args);
                currentTaskDic.Remove(args.taskID);
            }
        }
    }
    public void CancelTask(TaskArgs args)
    {
        if (currentTaskDic.ContainsKey(args.taskID))
        {
            TaskEvent.Instance.InvokeEvent((int)TaskEventType.OnCancelEvent, args);
            currentTaskDic.Remove(args.taskID);
        }
    }

    public void RefreshTask(TaskArgs args)
    {
        Debug.Log("Refresh");
        Task value;
        if (taskAllDic.TryGetValue(args.taskID, out value))
        {
            value.isFinish = false;
            for (int i = 0; i < value.taskConditions.Count; i++)
            {
                value.taskConditions[i].nowAmount = 0;
                value.taskConditions[i].isFinish = false;
            }
        }
    }
}
