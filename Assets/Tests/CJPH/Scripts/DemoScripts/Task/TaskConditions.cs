using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskConditions
{
    public string conditionID;
    public int nowAmount;
    public int targetAmount;
    public bool isFinish = false;
    public TaskConditions(string _id, int _nowAmount, int _targetAmount)
    {
        conditionID = _id;
        nowAmount = _nowAmount;
        targetAmount = _targetAmount;
    }
}
