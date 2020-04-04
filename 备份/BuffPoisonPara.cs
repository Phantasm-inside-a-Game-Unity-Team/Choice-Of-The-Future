using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuffPoisonPara : ABuffParameter
{
    public float buffTime;
    public float minusHP;
    public float effectGapTime;

    public BuffPoisonPara(List<float> buffParaList)
    {
        if (buffParaList.Count == 3)
        {
            buffTime = buffParaList[0];
            minusHP = buffParaList[1];
            effectGapTime = buffParaList[2];
        }
        else
        {
            buffTime = 3;
            minusHP = 0.5f;
            effectGapTime = 1;
        }
    }
    public override List<float> GetParameterList()
    {
        List<float> para = new List<float>();
        para.Add(buffTime);
        para.Add(minusHP);
        para.Add(effectGapTime);
        return para;
    }
}
