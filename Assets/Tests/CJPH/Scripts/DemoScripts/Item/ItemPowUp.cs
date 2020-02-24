using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowUp : AItem
{
    public override void ItemEffect(GameObject player)
    {
        player.GetComponent<PlayerControl>().pPoint += effectPoint;
        AudioSource.PlayClipAtPoint(itemSE, transform.position);
    }
}
