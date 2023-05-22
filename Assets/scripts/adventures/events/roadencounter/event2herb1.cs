using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event2herb1 : MonoBehaviour
{
    public adventureeventhub venturehub;
    public string adventuretype;


    public bool permanent;

    public string[] explanationtext;
    public int randomness;

    // Start is called before the first frame update
    void Start()
    {
        venturehub = GameObject.Find("adventuremodescripts").GetComponent<adventureeventhub>();
        explanationtext = new string[50];
        randomness = Mathf.FloorToInt(Random.Range(0f, 1000f));
        eventtext();
        Debug.Log("beggar event start");

    }
    void eventtext()
    {
        explanationtext[0] = "While walking along the road through the forest you stumble upon a small clearing where you see some naturally growing Nettles" +
            "\nWhile they arent anything special, they do still have some properties";//

        explanationtext[1] = "You picked the herb";//if steal stick

        explanationtext[2] = "You decide this isnt worth dirtying your hands for and continue on your way";//ask about the stick
        
        

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("beggar event1");
        if (venturehub.eventnum == 0)
        {
            if (venturehub.subeventnum == 0)
            {
                Debug.Log("beggar event2 add buttons");

                venturehub.changetext(explanationtext[0]);
                venturehub.createbutton(1, "Pick herbs");
                venturehub.createbutton(2, "Leave");
                venturehub.subeventnum = 1;
               
            }
            if (venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    venturehub.eventnum = 1;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
                if (venturehub.buttonbool[2] == true)
                {
                    venturehub.eventnum = 2;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
            }
        }
        if (venturehub.eventnum == 1)//stealstick
        {
            if (venturehub.subeventnum == 0)
            {
                venturehub.changetext(explanationtext[1]);
                venturehub.createbutton(1, "Leave");
                venturehub.subeventnum = 1;
            }
            if (venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    //stinging nettle
                    venturehub.rewardhub.Addrewards(8, "Stinging nettle", 1,3);
                    venturehub.rewardsgot = true;

                    venturehub.eventnum = 999;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
            }
        }
        if (venturehub.eventnum == 2)//ask about stick
        {
            if (venturehub.subeventnum == 0)
            {
                venturehub.changetext(explanationtext[2]);

                venturehub.createbutton(1, "Leave");
                venturehub.subeventnum = 1;
            }
            if (venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    //gift neutralstick
                    venturehub.eventnum = 999;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
            }
        }
        if (venturehub.eventnum == 3)//dont sleep in the road
        {
            if (venturehub.subeventnum == 0)
            {
                venturehub.changetext(explanationtext[3]);
                venturehub.createbutton(1, "Leave");
                venturehub.subeventnum = 1;
            }
            if (venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    venturehub.eventnum = 999;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
            }
        }

        if (venturehub.eventnum == 4)//ask if oke
        {
            if (venturehub.subeventnum == 0)
            {
                venturehub.changetext(explanationtext[4]);
                venturehub.createbutton(1, "Leave");
                venturehub.subeventnum = 1;
            }
            if (venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    venturehub.rewardhub.Addrewards(5, "Slightly auspicious stick", 1, 3);
                    venturehub.rewardsgot = true;


                    venturehub.eventnum = 999;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
            }
        }

        if (venturehub.eventnum == 20)
        {
            if (venturehub.subeventnum == 0)
            {
                venturehub.changetext(explanationtext[20]);
                venturehub.createbutton(1, "Leave");
                venturehub.subeventnum = 1;
            }
            if(venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    venturehub.eventnum = 999;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
            }
        }




        if (venturehub.eventnum == 999)
        {
            venturehub.endevent();
        }
    }
}
