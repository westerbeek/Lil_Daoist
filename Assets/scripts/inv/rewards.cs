using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class rewards : MonoBehaviour
{
    public bool revealanim;
    public GameObject revealcanvas;

    public Inventory inv;
    public GameObject reveal;
    public Image revealanimimage;
    public GameObject itemdiscardscreen;
    public ItemDatabase itemdatabase;
    public GameObject inventorySlotPrefab;

    public GameObject revealprefab;
    public GameObject ingamerevealprefab;

    public GameObject[] slots;
    public Item[] itemsinreveal;
    public Image[] itemicons;
    public int revealint;
    // Start is called before the first frame update
    void Start()
    {
        
        itemsinreveal = new Item[21];

        for (int i = 0; i < 20; i++)
        {
            GameObject item = Instantiate(inventorySlotPrefab);
            item.transform.SetParent(GameObject.Find("RevealItems").transform);
            itemsinreveal[i] = item.GetComponent<Item>();
        }
           // Addrewards(2, "Spirit Stones", 23478, -1);
           // Addrewards(1, "Test", 35, -1);

    }
    public void switchbutton(int i)
    {
       if(i < 10)
        {
            swapItems(itemsinreveal[i], itemsinreveal[i + 10]);
        }
       if(i >= 10)
        {
            swapItems(itemsinreveal[i], itemsinreveal[i - 10]);
        }
    }
    public void swapItems(Item item1, Item item2)
    {
        Item temp = new Item();
        overideitem(temp, item1);
        overideitem(item1, item2);
        overideitem(item2, temp);
        UpdateImage();
        rewardsupdate();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
           if(reveal.activeSelf == true)
            {
                if (itemsinreveal[revealint +1].id == 0)
                {
                    reveal.SetActive(false);
                    itemdiscardscreen.SetActive(true);
                    Destroy(ingamerevealprefab);
                    revealint = 0;

                }
                else
                {
                    revealint++;
                    showrewards(revealint);
                }
            }
            else
            {

            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            showrewards(revealint);
            //Addrewards(1, "Test", 7, -1);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Addrewards(2, "Spirit Stones", 23478, -1);
            Addrewards(5, "Slightly auspicious stick", 1, 27);
            Addrewards(6, "Slightly Ominous stick", 1, 23);
        }

       
    }
    public void showrewards(int i)
    {
        revealcanvas.SetActive(true);
        reveal.SetActive(true);
        itemdiscardscreen.SetActive(false);


        if (ingamerevealprefab == null)
        {
            ingamerevealprefab = Instantiate(revealprefab); 
            ingamerevealprefab.transform.SetParent(GameObject.Find("bgenclosurereveal").transform);
            ingamerevealprefab.GetComponent<RectTransform>().localPosition = new Vector2();
            ingamerevealprefab.transform.Find("revealingitemicon").GetComponent<Image>().sprite = itemsinreveal[i].icon;
        }
        else
        {
            Destroy(ingamerevealprefab);
            ingamerevealprefab = Instantiate(revealprefab);     
            ingamerevealprefab.transform.SetParent(GameObject.Find("bgenclosurereveal").transform);
            ingamerevealprefab.GetComponent<RectTransform>().localPosition = new Vector2();
            ingamerevealprefab.transform.Find("revealingitemicon").GetComponent<Image>().sprite = itemsinreveal[i].icon;
        }
                
    }
    public void overideitem(Item item1, Item item2)
    {


        item1.name = item2.name;
        item1.id = item2.id;
        item1.stackable = item2.stackable;
        item1.rarity = item2.rarity;
        item1.description = item2.description;
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

    }
    public void Addrewards(int ID, string name, int amount, int quality)
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
                for (int i = 0; i < 10; i++)
                {
                    if (newitem.amount >= 1)
                    {

                        if (itemsinreveal[i].id != 0 && checkinv == false)//checks if the item location is not empty
                        {
                            if (itemsinreveal[i].id == newitem.id)//checks if the itemsinreveal in the slot are the same
                            {
                                if (itemsinreveal[i].stackable == true)//checks if item is stackable
                                {
                                    // Debug.Log("item stackable");
                                    if (itemsinreveal[i].amount != itemsinreveal[i].maxamount)//checks if the amount of the item is less than the max stack size
                                    {
                                        if (itemsinreveal[i].amount + newitem.amount <= itemsinreveal[i].maxamount)//checks if the combined amount is less than the max amount
                                        {
                                            itemsinreveal[i].amount += newitem.amount;
                                            newitem = new Item();
                                            checkinv = true;
                                            i = 0;
                                            // Debug.Log("amount added to inv");
                                        }
                                        else//adds the difference to the stack and then continues
                                        {
                                            int difference = itemsinreveal[i].maxamount;
                                            difference -= itemsinreveal[i].amount;
                                            //  Debug.Log("add difference to item");
                                            itemsinreveal[i].amount += difference;
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
                        if (i == 10 - 1 && checkinv == false)
                        {

                            Debug.Log("I = max");
                            checkinv = true;
                            i = 0;
                        }
                        if (checkinv == true)
                        {
                            Debug.Log("checked inv = true");
                            if (itemsinreveal[i].id == 0)
                            {
                                if (newitem.amount >= 1)
                                {
                                    if (newitem.stackable == true)
                                    {
                                        Debug.Log("stackable true");
                                        if (newitem.amount <= newitem.maxamount)
                                        {
                                            overideitem(itemsinreveal[i], newitem);
                                            break;
                                            Debug.Log("added item: " + newitem.name + "");
                                        }
                                        else
                                        {
                                            Item tmp = new Item();
                                            overideitem(tmp, newitem);

                                            tmp.amount = tmp.maxamount;
                                            overideitem(itemsinreveal[i], tmp);

                                            newitem.amount -= tmp.maxamount;
                                        }
                                    }
                                    if (newitem.stackable == false)
                                    {
                                        Debug.Log("stackable false");

                                        overideitem(itemsinreveal[i], newitem);
                                        newitem.amount -= 1;
                                    }

                                }
                            }
                        }
                    }

                }
            }
           rewardsupdate();

           UpdateImage();
        }
        else
        {
            Debug.Log("Item not found2");

        }
    }
    
    public void rewardsupdate()
    {
        for (int i = 0; i < 10; i++)
        {
            if (itemsinreveal[i].id != 0)
            {
                if (itemsinreveal[i].amount <= 0)
                {
                    itemsinreveal[i] = new Item();
                }
            }
        }
        UpdateImage();
    }
    void updateamount()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (itemsinreveal[i].stackable == true)
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = itemsinreveal[i].amount + "";
            }
            else
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = "";

            }

        }
    }
    void UpdateImage()
    {
        for (int i = 0; i < itemicons.Length -1; i++)
        {
            if (itemsinreveal[i].id != 0)
            {
                itemicons[i].sprite = itemsinreveal[i].icon;
                itemicons[i].enabled = true;
            }
            else
            {
                if (itemicons[i] != null)
                {
                    itemicons[i].sprite = null;
                    itemicons[i].enabled = false;
                }
            }
            if (itemsinreveal[i].rarity == 30)
            {
                //slotimages[i].GetComponentInParent<Image>().color = new Color();
            }
        }
    }
    
    public void addrewards2inv()
    {
        for (int i = 0; i < 10; i++)
        {
            //AddItem(1, "Test", 7, -1);
            inv.AddItem(itemsinreveal[i].id, itemsinreveal[i].name, itemsinreveal[i].amount, itemsinreveal[i].Quality);
            reveal.SetActive(false);
            itemdiscardscreen.SetActive(false);
            inv.overideitem(itemsinreveal[i],new Item());
            revealcanvas.SetActive(false);

        }

    }

}