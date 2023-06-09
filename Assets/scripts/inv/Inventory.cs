using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using TMPro;

public class Inventory : MonoBehaviour
{
    // UI variables
    public ItemDatabase itemdatabase;
    public Equipment equip;
    public GameObject inventorySlotPrefab;
    public Transform inventoryPanel;
    public Item[] items;
    public Image[] slotimages;
    public GameObject[] slots;
    public GameObject slotobj;
    public int amountinvslots;
    public int inv;
    public int maxunlockinv;

    public Vector2 mousepos;
    public bool drag;
    public float dragtimer = 0.5f;
    public GameObject dragobj;
    public GameObject ingamedrag;
    public int loc1;
    public int pentered;
    public bool buttondown;

    //equipment
    public Item[] equipment;
    /* 0Head,
       1Clothes,
       2pants,
       3Feet,
       4Gloves,
       5Chest,
     * 6EarL,
       7EarR,
       8Cloak,
     * 9WeaponL
     * 10WeaponR,
       11RingL,
       12RingR,
       13Necklace,
       14Belt,
       15BraceletL,
       16BraceletR,
    */
    public Image[] equipmentslotimages;
    public GameObject[] equipslots;

    public GameObject Iteminfo;

    private void Start()
    {
        Iteminfo.SetActive(false);
        items = new Item[amountinvslots];
        equipment = new Item[17];
        for (int i = 0; i < amountinvslots; i++)
        {
            GameObject item = Instantiate(inventorySlotPrefab);
            item.transform.SetParent(GameObject.Find("inventoryitems").transform);
            items[i] = item.GetComponent<Item>();
        }
        for (int i = 0; i < equipment.Length; i++)
        {
            GameObject equip = Instantiate(inventorySlotPrefab);
            equip.transform.SetParent(GameObject.Find("Equippeditems").transform);
            equipment[i] = equip.GetComponent<Item>();
            equipment[i].gameObject.name = equipslots[i].name+"Item_Equiped";
        }
        if (slots[slots.Length - 1] != null)// adds the item pickup and let go functions to the itemslots
        {
            for (int i = 0; i < slots.Length; i++)
            {
                int index = i; // Create a local copy of i
                EventTrigger.Entry pdown = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerDown
                };
                EventTrigger.Entry pup = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerUp
                };
                EventTrigger.Entry penter = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerEnter
                };
                EventTrigger.Entry pexit = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerExit
                };

                pdown.callback.AddListener(eventData => { itembuttonDown(index); });
                pup.callback.AddListener(eventData => { itembuttonUp(index); });
                penter.callback.AddListener(eventData => { itembuttonEnter(index); });
                pexit.callback.AddListener(eventData => { itembuttonExit(index); });
                slots[i].GetComponent<EventTrigger>().triggers.Add(pdown);
                slots[i].GetComponent<EventTrigger>().triggers.Add(pup);
                slots[i].GetComponent<EventTrigger>().triggers.Add(penter);
                slots[i].GetComponent<EventTrigger>().triggers.Add(pexit);
            }

        }

       if (equipslots[equipslots.Length - 1] != null)// adds the item pickup and let go functions to the itemslots
        {
            for (int i = 0; i < equipslots.Length; i++)
            {
                int n = 100;
                int index = i + n; // Create a local copy of i
                EventTrigger.Entry pdown = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerDown
                };
                EventTrigger.Entry pup = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerUp
                };
                EventTrigger.Entry penter = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerEnter
                };
                EventTrigger.Entry pexit = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerExit
                };

                pdown.callback.AddListener(eventData => { itembuttonDown(index); });
                pup.callback.AddListener(eventData => { itembuttonUp(index); });
                penter.callback.AddListener(eventData => { itembuttonEnter(index); });
                pexit.callback.AddListener(eventData => { itembuttonExit(index); });
                equipslots[i].GetComponent<EventTrigger>().triggers.Add(pdown);
                equipslots[i].GetComponent<EventTrigger>().triggers.Add(pup);
                equipslots[i].GetComponent<EventTrigger>().triggers.Add(penter);
                equipslots[i].GetComponent<EventTrigger>().triggers.Add(pexit);
            }

        }
    } 
    public void spawnamountitemslots()
    {
        //TODO
    }
    public void offiteminfo()
    {

        Iteminfo.SetActive(false);
        Debug.Log("close item info");


    }
    public void Iteminspect(int loc)
    {
        
        Iteminfo.SetActive(true);
        Item tmp = new Item();
        if (loc < 99)
        {
            if (items[loc].id != 0)
            {
                tmp = items[loc];
            }
        }
        else
        {
            if (equipment[loc - 100].id != 0)
            {
                tmp = equipment[loc - 100];

            }
        }

        GameObject.Find("ItemIcon").GetComponent<Image>().sprite = tmp.icon;
        GameObject.Find("Itemnametxt").GetComponent<TMP_Text>().text = tmp.name;
        GameObject.Find("Qualitytxt").GetComponent<TMP_Text>().text = tmp.Quality.ToString();
        GameObject.Find("Raritytxt").GetComponent<TMP_Text>().text = tmp.rarity.ToString();
        if (tmp.maxamount < 9999)
        {
            GameObject.Find("Amounttxt").GetComponent<TMP_Text>().text = tmp.amount.ToString() + " / " + tmp.maxamount.ToString();
        }
        else
        {
            GameObject.Find("Amounttxt").GetComponent<TMP_Text>().text = tmp.amount.ToString();

        }
        GameObject.Find("Type1txt").GetComponent<TMP_Text>().text = tmp.type.ToString();
        GameObject.Find("Type2txt").GetComponent<TMP_Text>().text = tmp.subtype1.ToString();
        GameObject.Find("Type3txt").GetComponent<TMP_Text>().text = tmp.subtype2.ToString();
        GameObject.Find("Type4txt").GetComponent<TMP_Text>().text = tmp.subtype3.ToString();
        GameObject.Find("DescriptionTxt").GetComponent<TMP_Text>().text = tmp.description+"\n\n";
        tmp.Starting();
        GameObject.Find("StatitemTxt").GetComponent<TMP_Text>().text = tmp.stattext+"\n";
        GameObject.Find("SpecialsTxt").GetComponent<TMP_Text>().text = tmp.Specialfeatures;




        Debug.Log("show item info" + loc);

    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            buttondown = false;
        }
        if (buttondown == true)
        {
            mousepos = Input.mousePosition;

            dragtimer -= Time.deltaTime;

            if (dragtimer <= 0 && ingamedrag == null)
            {
                spawndrag(loc1);
                drag = true;
            }
          
           
        }
        else
        {
            if (ingamedrag != null)
            {
                Destroy(ingamedrag);
            }
            dragtimer = 0.5f;
        }
        if (ingamedrag != null)
        {
            ingamedrag.GetComponent<RectTransform>().position = mousepos;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Addrewards(2, "Spirit Stones", 23478, -1);
            //callItemfunction(5, "Slightly auspicious stick", "equip");
            //Addrewards(6, "Slightly Ominous stick", 1, 23);
        }
    }
    public void itembuttonEnter(int loc)
    {
        pentered = loc;
    }
    public void itembuttonExit(int loc)
    {
        pentered = -1;
    }
    public void itembuttonDown(int loc)
    {
        Debug.Log("down" + loc);
        if (loc < 99)
        {
            if (items[loc].id != 0)
            {
                loc1 = loc;
                buttondown = true;
            }
        }
        else
        {
            if (equipment[loc - 100].id != 0)
            {
                loc1 = loc;
                buttondown = true;
            }
        }
    }
    public void itembuttonUp(int loc)
    {
        Debug.Log("up" + pentered);

        if (drag == true)
        {

            if (pentered != -1 && loc != pentered)
            {
                if (loc < 99)
                {
                    if (pentered < 99)
                    {
                        swapItems(items[loc], items[pentered]);
                    }
                    else
                    {
                        Debug.Log("3");
                        if (checkequip(items[loc], pentered -100) == true)
                        {
                            if(equipment[pentered - 100].id != 0)
                            {
                                callItemfunction(equipment[pentered- 100], "unequip");

                            }
                            swapItems(items[loc], equipment[pentered - 100]);// from item to equip
                        }
                    }
                }
                else
                {
                    if (pentered < 99)
                    {
                        Debug.Log("1");
                        if (checkequip(items[pentered], loc - 100) == true)
                        {
                            callItemfunction(equipment[loc - 100],"unequip");
                            
                            swapItems(equipment[loc - 100], items[pentered]);//from equip to item
                        }
                    }
                    else
                    {
                        Debug.Log("2");
                        if (checkequip(equipment[loc - 100], pentered - 100) == true)
                        {
                            swapItems(equipment[loc - 100], equipment[pentered - 100]);//from equip to equip
                        }
                    }
                }
            }
            Destroy(ingamedrag);
            dragtimer = 0.5f;
            loc1 = -1;
            drag = false;



        }
        else
        {
            //openinspect
            if (loc < 99)
            {
                if (items[loc].id != 0)
                {
                    Iteminspect(loc);
                }
            }
            else
            {
                if (equipment[loc - 100].id != 0)
                {
                    Iteminspect(loc);
                }
            }

        }

    }
    
    public bool checkequip(Item item1, int num)
    {
        bool yes = false;
        if(item1.id == 0)
        {
            yes = true;
        }
        if (num == 0)
        {
            if(item1.type == Item.ItemType.Head || item1.subtype1 == Item.ItemType.Head || item1.subtype2 == Item.ItemType.Head || item1.subtype3 == Item.ItemType.Head)
            {
                yes = true;//head
            }
        }
        if (num == 1)
        {
            if (item1.type == Item.ItemType.Clothes || item1.subtype1 == Item.ItemType.Clothes || item1.subtype2 == Item.ItemType.Clothes || item1.subtype3 == Item.ItemType.Clothes)
            {
                yes = true;//clothes
            }
        }
        if (num == 2)
        {
            if (item1.type == Item.ItemType.pants || item1.subtype1 == Item.ItemType.pants || item1.subtype2 == Item.ItemType.pants || item1.subtype3 == Item.ItemType.pants)
            {
                yes = true;//pants
            }
        }
        if (num == 3)
        {
            if (item1.type == Item.ItemType.Feet || item1.subtype1 == Item.ItemType.Feet || item1.subtype2 == Item.ItemType.Feet || item1.subtype3 == Item.ItemType.Feet)
            {
                yes = true;//feet
            }
        }
        if (num == 4)
        {
            if (item1.type == Item.ItemType.Gloves|| item1.subtype1 == Item.ItemType.Gloves || item1.subtype2 == Item.ItemType.Gloves || item1.subtype3 == Item.ItemType.Gloves)
            {
                yes = true;//gloves
            }
        }
        if (num == 5)
        {
            if (item1.type == Item.ItemType.Chest || item1.subtype1 == Item.ItemType.Chest || item1.subtype2 == Item.ItemType.Chest || item1.subtype3 == Item.ItemType.Chest)
            {
                yes = true;//chestarmor
            }
        }
        if (num == 6 || num == 7)
        {
            if (item1.type == Item.ItemType.Ear || item1.subtype1 == Item.ItemType.Ear || item1.subtype2 == Item.ItemType.Ear || item1.subtype3 == Item.ItemType.Ear)
            {
                yes = true;//ear
            }
        }
        if (num == 8)
        {
            if (item1.type == Item.ItemType.Cape || item1.subtype1 == Item.ItemType.Cape || item1.subtype2 == Item.ItemType.Cape || item1.subtype3 == Item.ItemType.Cape)
            {
                yes = true;//cape
            }
        }
        if (num == 9 || num == 10)
        {
            if (item1.type == Item.ItemType.Weapon || item1.subtype1 == Item.ItemType.Weapon || item1.subtype2 == Item.ItemType.Weapon || item1.subtype3 == Item.ItemType.Weapon)
            {
                yes = true;//weapon
            }
        }
        if (num == 11 || num == 12)
        {
            if (item1.type == Item.ItemType.Ring || item1.subtype1 == Item.ItemType.Ring || item1.subtype2 == Item.ItemType.Ring || item1.subtype3 == Item.ItemType.Ring)
            {
                yes = true;//ring
            }
        }
        if (num == 13)
        {
            if (item1.type == Item.ItemType.Necklace || item1.subtype1 == Item.ItemType.Necklace || item1.subtype2 == Item.ItemType.Necklace || item1.subtype3 == Item.ItemType.Necklace)
            {
                yes = true;//necklace
            }
        }
        if (num == 14)
        {
            if (item1.type == Item.ItemType.Belt || item1.subtype1 == Item.ItemType.Belt || item1.subtype2 == Item.ItemType.Belt || item1.subtype3 == Item.ItemType.Belt)
            {
                yes = true;//belt
            }
        }
        if (num == 15 || num == 16)
        {
            if (item1.type == Item.ItemType.Bracelet || item1.subtype1 == Item.ItemType.Bracelet || item1.subtype2 == Item.ItemType.Bracelet || item1.subtype3 == Item.ItemType.Bracelet)
            {
                yes = true;//bracelet
            }
        }
        if(yes == true)
        {
            callItemfunction(item1,"equip");
        }
        return yes;
    }
    public void spawndrag(int loc)
    {
        
        if (dragtimer <= 0 && ingamedrag == null)
        {
            ingamedrag = Instantiate(dragobj);
            ingamedrag.transform.parent = GameObject.Find("dragparent").transform;
            ingamedrag.transform.localScale = dragobj.transform.localScale;
            ingamedrag.transform.Find("Itemdrag").transform.Find("ItemIcon").GetComponent<Image>().color = new Color(1,1,1,1);
            if (loc < 99)
            {
                ingamedrag.transform.Find("Itemdrag").transform.Find("ItemIcon").GetComponent<Image>().sprite = items[loc].icon;
              

            }
            else
            {

                ingamedrag.transform.Find("Itemdrag").transform.Find("ItemIcon").GetComponent<Image>().sprite = equipment[loc - 100].icon;
            }

            //Debug.Break();
            ///  ingamedrag.GetComponent<Item>();
        }
    }
    public void overideitem(Item item1, Item item2)
    {
        

        item1.name = item2.name;
        item1.id = item2.id;
        item1.stackable = item2.stackable;
        item1.rarity = item2.rarity;
        item1.description = item2.description;
        item1.stattext = item2.stattext;
        item1.Specialfeatures = item2.Specialfeatures;
        item1.type = item2.type;
        item1.subtype1 = item2.subtype1;
        item1.subtype2 = item2.subtype2;
        item1.subtype3 = item2.subtype3;
        item1.maxamount = item2.maxamount;
        item1.icon = item2.icon;
        item1.amount = item2.amount;
        item1.Quality = item2.Quality;

        item1.fortitude = item2.fortitude;
        item1.strength = item2.strength;
        item1.dexterity = item2.dexterity;
        item1.inteligence = item2.inteligence;
        item1.karma = item2.karma;
        item1.luck = item2.luck;
        item1.xpbonus = item2.xpbonus;

        item1.physicalattack = item2.physicalattack;
        item1.physicaldefence = item2.physicaldefence;
        item1.mentalattack = item2.mentalattack;
        item1.mentaldefence = item2.mentaldefence;
        item1.specialattack = item2.specialattack;
        item1.specialdefence = item2.specialdefence;

        item1.fireattack = item2.fireattack;
        item1.firedefence = item2.firedefence;
        item1.waterattack = item2.waterattack;
        item1.waterdefence = item2.waterdefence;
        item1.woodattack = item2.woodattack;
        item1.wooddefence = item2.wooddefence;
        item1.earthattack = item2.earthattack;
        item1.earthdefence = item2.earthdefence;
        item1.metalattack = item2.metalattack;
        item1.metaldefence = item2.metaldefence;
        invupdate();
}
    public void swapItems(Item item1, Item item2)
    {
        Item temp = new Item();
        overideitem(temp, item1);
        overideitem(item1, item2);
        overideitem(item2, temp);
        UpdateImage();
        invupdate();
    }

    public void removeitem(int itemloc)
    {
        if(items[itemloc].id != 0)
        {
            items[itemloc].amount -= 1;
        }
        if(items[itemloc].amount <= 0)
        {
            invupdate();
            UpdateImage();

        }
    }
    public void callItemfunction(Item item, string action)
    {

        for (int i = 0; i < itemdatabase.Itemlist.Length; i++)//goes through database
        {
            if (itemdatabase.Itemlist[i] != null)//
            {
                if (itemdatabase.Itemlist[i].id == item.id || itemdatabase.Itemlist[i].name == item.name)//if it finds the item its looking for it copies it into the newitem
                {
                    GameObject tmpitem = Instantiate(itemdatabase.Itemlist[i].gameObject);
                    if(action == "equip")
                    {
                        tmpitem.GetComponent<Item>().Equip();
                        Destroy(tmpitem);
                    }
                    if (action == "unequip")
                    {
                        tmpitem.GetComponent<Item>().unequip();
                        Destroy(tmpitem);
                    }
                    if (action == "ingredientuse")
                    {
                        tmpitem.GetComponent<Item>().ingredientuse();
                        Destroy(tmpitem);
                    }
                    if (action == "consume")
                    {
                        tmpitem.GetComponent<Item>().consume();
                        Destroy(tmpitem);
                    }
                    if (action == "materialuse")
                    {
                        tmpitem.GetComponent<Item>().materialuse();
                        Destroy(tmpitem);
                    }
                }
            }
        }

    }
    public void AddItem(int ID, string name, int amount, int quality)
    {
        Item newitem = new Item();// create new item
        //Debug.Log("AddItem: ID: " + ID + "  Name: " + name + "  Amount:  " + amount + "  Quality:  " + quality);
        bool itemfound = false;//sets variable itemfound to false
        if (itemdatabase == null)
        {
            return;
        }

        for (int i = 0; i < itemdatabase.Itemlist.Length; i++)//goes through database
        {
            if (itemdatabase.Itemlist[i] != null)//
            {
                if (itemdatabase.Itemlist[i].id == ID || itemdatabase.Itemlist[i].name == name)//if it finds the item its looking for it copies it into the newitem
                {
                    //newitem = itemdatabase.Itemlist[i];
                    overideitem(newitem, itemdatabase.Itemlist[i]);
                    newitem.amount = amount;
                    if (quality >= 1)
                    {
                        newitem.Quality = quality;
                    }//Debug.Log("Item found in database");

                    itemfound = true;
                }
            }
            else
            {
                Debug.LogError("Item not found");//stops game incase item doesnt exist
            }
        }
        
        if (itemfound == true)
        {
            bool checkinv = false;
            if (newitem.amount >= 1 && newitem.id != 0)
            {
                for (int i = 0; i < amountinvslots; i++)
                {
                    if (newitem.amount >= 1)
                    {
                        if (items[i].id != 0 && checkinv == false)//checks if the item location is not empty
                        {
                            if (items[i].id == newitem.id)//checks if the items in the slot are the same
                            {
                                if (items[i].stackable == true)//checks if item is stackable
                                {
                                    // Debug.Log("item stackable");
                                    if (items[i].amount != items[i].maxamount)//checks if the amount of the item is less than the max stack size
                                    {
                                        if (items[i].amount + newitem.amount <= items[i].maxamount)//checks if the combined amount is less than the max amount
                                        {
                                            items[i].amount += newitem.amount;
                                            newitem = new Item();
                                            checkinv = true;
                                            i = 0;
                                           // Debug.Log("amount added to inv");
                                        }
                                        else//adds the difference to the stack and then continues
                                        {
                                            int difference = items[i].maxamount;
                                            difference -= items[i].amount;
                                          //  Debug.Log("add difference to item");
                                            items[i].amount += difference;
                                            newitem.amount -= difference;
                                        }
                                    }
                                }
                                else
                                {
                                   // Debug.Log("Item not stackable");
                                    checkinv = true;
                                    i = 0;
                                }
                            }
                        }
                       // Debug.Log(i);
                        if (i == amountinvslots - 1 && checkinv == false)
                        {
                           
                            Debug.Log("I = max");
                            checkinv = true;
                            i = 0;
                        }
                        if (checkinv == true)
                        {
                            Debug.Log("checked inv = true");
                            if (items[i].id == 0)
                            {
                                if (newitem.amount >= 1)
                                {
                                    if (newitem.stackable == true)
                                    {
                                        Debug.Log("stackable true");
                                        if(newitem.amount <= newitem.maxamount){
                                            overideitem(items[i], newitem);
                                            break;
                                            Debug.Log("added item: " + newitem.name + "");
                                        }
                                        else
                                        {
                                            Item tmp = new Item();
                                            overideitem(tmp, newitem);

                                            tmp.amount = tmp.maxamount;
                                            overideitem(items[i], tmp);

                                            newitem.amount -= tmp.maxamount;
                                        }
                                    }
                                    if (newitem.stackable == false)
                                    {
                                        Debug.Log("stackable false");

                                        overideitem(items[i], newitem);
                                        newitem.amount -= 1;
                                    }

                                }
                            }
                        }
                    }

                }
            }
            invupdate();

            UpdateImage();
        }
        else
        {
            Debug.Log("Item not found2");

        }
    }
    public void invfix()
    {
        for (int i = 0; i < equipslots.Length; i++)
        {
            for (int b = 0; b < itemdatabase.Itemlist.Length; b++)//goes through database
            {
                Debug.Log("database fix");
                if (itemdatabase.Itemlist[b] != null)//
                {
                    if (itemdatabase.Itemlist[b].id == equipment[i].id)//if it finds the item its looking for it copies it into the newitem
                    {
                        Debug.Log("item found in database fix" + equipment[i].id);
                        //newitem = itemdatabase.Itemlist[i];
                        int tmpamount = equipment[i].amount;
                        int tmpquality = equipment[i].Quality;

                        overideitem(equipment[i], itemdatabase.Itemlist[b]);
                        equipment[i].amount = tmpamount;
                        equipment[i].Quality = tmpquality;
                        Debug.Log("save overide Equipment");
                        Debug.Log("222Equipment found in database fix222" + equipment[i].id);
                    }
                }
                else
                {
                    Debug.LogError("saved Equipment not found");//stops game incase item doesnt exist
                }
            }
        }
        
        for (int i = 0; i < amountinvslots; i++)
        {
            Debug.Log("inv fix");
            if (items[i].id != 0)
            {
                Debug.Log("inv fix222");

                for (int b = 0; b < itemdatabase.Itemlist.Length; b++)//goes through database
                {
                    Debug.Log("database fix");

                    if (itemdatabase.Itemlist[b] != null)//
                    {

                        if (itemdatabase.Itemlist[b].id == items[i].id)//if it finds the item its looking for it copies it into the newitem
                        {
                            Debug.Log("item found in database fix"+ items[i].id);
                            
                            //newitem = itemdatabase.Itemlist[i];
                            int tmpamount = items[i].amount;
                            int tmpquality = items[i].Quality;
                        
                            overideitem(items[i], itemdatabase.Itemlist[b]);
                            items[i].amount = tmpamount;
                            items[i].Quality = tmpquality;
                            Debug.Log("save overide item");
                            Debug.Log("222item found in database fix222"+ items[i].id);


                        }
                    }
                    else
                    {
                        Debug.LogError("saved Item not found");//stops game incase item doesnt exist
                    }
                }
            }
        }
        //invupdate();
        updateamount();
        UpdateImage();
    }
    public void invupdate()
    {
        for (int i = 0; i < amountinvslots; i++)
        {
            if (items[i].id != 0)
            {
                Debug.Log("inv update2");
                
                if (items[i].amount <= 0)
                {
                    Item tmp = new Item();
                    Debug.Log("inv update0");

                    overideitem(items[i], tmp);
                }

            }
        
        }
        
        updateamount();
        UpdateImage();
    }
  
    void updateamount()
    {
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (items[i].stackable == true) {
                slots[i].GetComponentInChildren<TMP_Text>().text = items[i].amount+"";
            }
            else
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = "";
                Debug.Log("update amount");

            }

        }
    }
    void UpdateImage()
    {
        for (int i = 0; i < slotimages.Length; i++)
        { 
                Debug.Log("set image");

            if (items[i].id != 0)
            {
                slotimages[i].sprite = items[i].icon;
                slotimages[i].enabled = true;
                Debug.Log("set image");

            }
            else
            {
                if (slotimages[i] != null)
                {
                    slotimages[i].sprite = null;
                    slotimages[i].enabled = false;
                }
            }
            if(items[i].rarity == 30)
            {
               // slotimages[i].GetComponentInParent<Image>().color = new Color();
            }
        }
        for(int i = 0; i < equipmentslotimages.Length; i++)
        {
            if (equipment[i].id != 0)
            {
                equipmentslotimages[i].sprite = equipment[i].icon;
                equipmentslotimages[i].enabled = true;
            }
            else
            {
                if (equipmentslotimages[i] != null)
                {
                    equipmentslotimages[i].sprite = null;
                    equipmentslotimages[i].enabled = false;
                }
            }
            Debug.Log("set equip");

        }
    }
}
