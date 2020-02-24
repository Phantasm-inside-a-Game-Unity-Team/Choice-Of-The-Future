using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AItem : MonoBehaviour
{
    public int effectPoint;
    public AudioClip itemSE;
    public abstract void ItemEffect(GameObject player);
}
