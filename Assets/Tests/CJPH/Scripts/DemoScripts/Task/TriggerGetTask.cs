﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGetTask : MonoBehaviour
{
    public string taskID;
    private bool isPlayerIn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerIn)
        {
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log("Submit");
                DemoTaskManager.Instance.AcceptTask(taskID);
                TaskEvent.Instance.AddEventListen(Reacceptable, (int)TaskEventType.OnFinishEvent);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            isPlayerIn = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            isPlayerIn = false;
        }
    }

    public void Reacceptable(TaskArgs e)
    {
        TaskArgs args = new TaskArgs();
        args.taskID = taskID;
        DemoTaskManager.Instance.RefreshTask(args);
    }
}