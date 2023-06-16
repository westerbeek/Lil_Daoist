using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item16_Sturdy_Boots : Item
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

        stat.dexterity += dexterity;
        stat.physicaldefence += physicaldefence;

        Debug.Log("equip");

    }
    public override void unequip()
    {
        base.unequip();
        stats stat = GameObject.Find("ScriptHub").GetComponent<Player>();
        stat.dexterity -= dexterity;
        stat.physicaldefence -= physicaldefence;


        Debug.Log("unequipuse");

    }

    public override void materialuse()
    {
        base.materialuse();
        Debug.Log("Materialuse");

    }
    public override void ingredientuse()
    {
        base.ingredientuse();
        Debug.Log("Ingredientuse");


    }
    public override void consume()
    {
        //stats stat = GameObject.Find("ScriptHub").GetComponent<Player>();
        //stat.health += 5;
        base.consume();
        Debug.Log("consume");

    }
}