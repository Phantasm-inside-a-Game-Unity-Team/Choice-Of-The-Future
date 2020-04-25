using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABuff
{
    public BuffType buffType;
    public abstract void OnBuffAdd();
    public abstract void OnBuffUpdate();
    public abstract void OnBuffRemove();
}
