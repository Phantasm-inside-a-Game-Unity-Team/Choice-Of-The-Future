using UnityEngine;
using System.Collections;

public class Yuyuko_Effect01 : MonoBehaviour
{
    public Animator ani;
    AnimatorStateInfo stateInfo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}