using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string taskID;
    public string taskName;
    public string description;
    public bool isFinish;
    public List<TaskConditions> taskConditions = new List<TaskConditions>();
    public TaskRewards[] taskRewards = new TaskRewards[2];
    public Task(string _taskID, string _taskName, string _description, List<TaskConditions> _taskConditions, TaskRewards[] _taskRewards)
    {
        taskID = _taskID;
        taskName = _taskName;
        description = _description;
        taskRewards = _taskRewards;
        taskConditions = _taskConditions;
    }
}

