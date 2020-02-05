using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDrop : MonoBehaviour
{
    public List<GameObject> item;
    [Range(0, 1)]
    public float dropRate;

    public void RandomItemDrop()
    {
        if (Random.value <= dropRate)
        {
            GameObject droppedItem = (GameObject)Instantiate(item[Random.Range(0,item.Count)], transform.position, transform.rotation);
            droppedItem.transform.parent = DemoSceneManager.Instance.itemsObj.transform;
        }
    }
}
