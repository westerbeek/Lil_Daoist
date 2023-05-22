using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item4_Aloe_Vera : Item
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void Start()
    {

    }
    public override void Equip()
    {
        base.Equip();
        Debug.Log("equip");

    }
    public override void unequip()
    {
        base.unequip();
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
        stats stat = GameObject.Find("ScriptHub").GetComponent<Player>();
        stat.health += 10;
        base.consume();
        Debug.Log("consume");

    }
}

