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
    [TextArea(15, 20)]
    public string stattext;
    [TextArea(15, 20)]
    public string Specialfeatures;
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

    public void Starting()
    {
        if (fortitude != 0)
        {
            string sign = fortitude > 0 ? "+" : "-";
            stattext += "Fortitude: " + sign + fortitude + "\n";
        }
        if (strength != 0)
        {
            string sign = strength > 0 ? "+" : "-";
            stattext += "Strength: " + sign + strength + "\n";
        }
        if (dexterity != 0)
        {
            string sign = dexterity > 0 ? "+" : "-";
            stattext += "Dexterity: " + sign + dexterity + "\n";
        }
        if (inteligence != 0)
        {
            string sign = inteligence > 0 ? "+" : "-";
            stattext += "Intelligence: " + sign + inteligence + "\n";
        }
        if (karma != 0)
        {
            string sign = karma > 0 ? "+" : "-";
            stattext += "Karma: " + sign + karma + "\n";
        }
        if (luck != 0)
        {
            string sign = luck > 0 ? "+" : "-";
            stattext += "Luck: " + sign + luck + "\n";
        }
        if (xpbonus != 0)
        {
            string sign = xpbonus > 0 ? "+" : "-";
            stattext += "XP Bonus: " + sign + xpbonus + "\n";
        }
        if (physicalattack != 0)
        {
            string sign = physicalattack > 0 ? "+" : "-";
            stattext += "Physical Attack: " + sign + physicalattack + "\n";
        }
        if (physicaldefence != 0)
        {
            string sign = physicaldefence > 0 ? "+" : "-";
            stattext += "Physical Defence: " + sign + physicaldefence + "\n";
        }
        if (mentalattack != 0)
        {
            string sign = mentalattack > 0 ? "+" : "-";
            stattext += "Mental Attack: " + sign + mentalattack + "\n";
        }
        if (mentaldefence != 0)
        {
            string sign = mentaldefence > 0 ? "+" : "-";
            stattext += "Mental Defence: " + sign + mentaldefence + "\n";
        }
        if (specialattack != 0)
        {
            string sign = specialattack > 0 ? "+" : "-";
            stattext += "Special Attack: " + sign + specialattack + "\n";
        }
        if (specialdefence != 0)
        {
            string sign = specialdefence > 0 ? "+" : "-";
            stattext += "Special Defence: " + sign + specialdefence + "\n";
        }
        if (fireattack != 0)
        {
            string sign = fireattack > 0 ? "+" : "-";
            stattext += "Fire Attack: " + sign + fireattack + "\n";
        }
        if (firedefence != 0)
        {
            string sign = firedefence > 0 ? "+" : "-";
            stattext += "Fire Defence: " + sign + firedefence + "\n";
        }
        if (waterattack != 0)
        {
            string sign = waterattack > 0 ? "+" : "-";
            stattext += "Water Attack: " + sign + waterattack + "\n";
        }
        if (waterdefence != 0)
        {
            string sign = waterdefence > 0 ? "+" : "-";
            stattext += "Water Defence: " + sign + waterdefence + "\n";
        }
        if (woodattack != 0)
        {
            string sign = woodattack > 0 ? "+" : "-";
            stattext += "Wood Attack: " + sign + woodattack + "\n";
        }
        if (wooddefence != 0)
        {
            string sign = wooddefence > 0 ? "+" : "-";
            stattext += "Wood Defence: " + sign + wooddefence + "\n";
        }
        if (earthattack != 0)
        {
            string sign = earthattack > 0 ? "+" : "-";
            stattext += "Earth Attack: " + sign + earthattack + "\n";
        }
        if (earthdefence != 0)
        {
            string sign = earthdefence > 0 ? "+" : "-";
            stattext += "Earth Defence: " + sign + earthdefence + "\n";
        }
        if (metalattack != 0)
        {
            string sign = metalattack > 0 ? "+" : "-";
            stattext += "Metal Attack: " + sign + metalattack + "\n";
        }
        if (metaldefence != 0)
        {
            string sign = metaldefence > 0 ? "+" : "-";
            stattext += "Metal Defence: " + sign + metaldefence + "\n";
        }
        Debug.Log("starting finished");
    }
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

