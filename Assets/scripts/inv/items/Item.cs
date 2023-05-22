using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public int id;
    [TextArea(15, 10)]
    public string name;
    public int Quality;
    public int rarity;
    public bool stackable;
    public int amount;
    public int maxamount;
    [TextArea(15, 20)]
    public string description;
    public Sprite icon;
    public ItemType type;
    public ItemType subtype1;
    public ItemType subtype2;
    public ItemType subtype3;

    //if equipment
    public float fortitude;
    public float strength;
    public float dexterity;
    public float inteligence;
    public float karma;
    public float luck;
    public float xpbonus;

    public float physicalattack;
    public float physicaldefence;
    public float mentalattack;
    public float mentaldefence;
    public float specialattack;
    public float specialdefence;

    public float fireattack;
    public float firedefence;
    public float waterattack;
    public float waterdefence;
    public float woodattack;
    public float wooddefence;
    public float earthattack;
    public float earthdefence;
    public float metalattack;
    public float metaldefence;


    public enum ItemType
    {
        Null,
        Medicine,
        Ingredient,
        Material,
        CraftingStations,
        Weapon,
        Armor,
        Head,
        Chest,
        pants,
        Clothes,
        Arm,
        Feet,
        Ring,
        Ear,
        Cape,
        Belt,
        Bracelet,
        Necklace,
        Gloves,


        Technique,
        Law,
        Lore,
        Maps,
        Consumable,
        Quest,
        Flavor,//knickknacks
        Trophy,
        Misc,
    }
    public virtual void Equip()
    {

    }
    public virtual void unequip()
    {

    }
    public virtual void materialuse()
    {

    }
    public virtual void ingredientuse()
    {

    }
    public virtual void consume()
    {

    }



    /*
    
    public Item(int id, string name, string description, ItemType type)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.type = type;
    }*/
}

