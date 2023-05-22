using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3_Basepil : Item
{
    // Start is called before the first frame update
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
        base.consume();
        Debug.Log("consume");

    }
}

