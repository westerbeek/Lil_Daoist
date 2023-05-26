using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item5_SlightlyAuspiciousStick : Item
{
    // Start is called before the first frame update

    
    // Update is called once per frame
    public void Start()
    {
        Starting();

    }
    public override void Equip()
    {
        base.Equip();
        stats stat = GameObject.Find("ScriptHub").GetComponent<Player>();
        Debug.Log("equiping");

        stat.karma += karma;
        stat.woodattack += woodattack;
        stat.waterdefence += waterdefence;
        stat.luck += luck;
     

    }
    public override void unequip()
    {
        base.unequip();
        stats stat = GameObject.Find("ScriptHub").GetComponent<Player>();

        stat.karma -= karma;
        stat.woodattack -= woodattack;
        stat.waterdefence -= waterdefence;
        stat.luck -= luck;
        Debug.Log("Unequip");

    }

    public override void materialuse()
    {
        base.materialuse();

    }
    public override void ingredientuse()
    {
        base.ingredientuse();

    }
    public override void consume()
    {
        base.consume();

    }
}
