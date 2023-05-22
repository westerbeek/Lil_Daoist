using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event1beggar1 : MonoBehaviour
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
        explanationtext[0] = "You come across a strange man sitting by the road," +
            "\nHe seems to be sleeping, and from the look of his clothes, quite poor,and while you cant see his face clearly seems to be elderly." +
            "\nPossibly a beggar." +
            "\nTo his left is a fancy walking stick that you can feel some engergy coming from.";//base

        explanationtext[1] = "The beggar looks at you with disdain, grabs your hand and whispers something to you in an unknown language and fades away as if he was never there at all\n" +
            "You look down to see that to your surprise the stick is still there!";//if steal stick

        explanationtext[2] = "The old beggar looks up at you, grumbles something you cant quite make out and dissapears,\n" +
            "fades away in front of your eyes.";//ask about the stick
        
        explanationtext[3] = "You tell the beggar he shouldn't sleep in the road,\n The beggar scoffs at your word and fades away as if he were never there.";//tell him he shouldnt be sleeping in the road
       
        explanationtext[4] = "You ask the beggar if he is oke, he says something in a language you don't quite understand." +
            "\nBut you can sense that he's content, gets up and gives you his walking stick with a slight smile." +
            "\nYou accept the walking stick, quickly inspect it but only get a good feeling from it." +
            "\nWhen you look up again you can't see the beggar anywhere and you go on your way.";// ask him if he is oke
        explanationtext[5] = "";
        explanationtext[20] = "You decide to just leave the beggar be and head on your way, slowly but surely leaving him behind you.";
        Debug.Log("beggar event make text");

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
                venturehub.createbutton(1, "Steal the stick");
                venturehub.createbutton(2, "Ask him about the stick");
                venturehub.createbutton(3, "Tell him he shouldnt be sleeping in the road");
                venturehub.createbutton(4, "Ask him if he is oke");
                venturehub.createbutton(20, "Leave the man alone");
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
                if (venturehub.buttonbool[3] == true)
                {
                    venturehub.eventnum = 3;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
                if (venturehub.buttonbool[4] == true)
                {
                    venturehub.eventnum = 4;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
                if (venturehub.buttonbool[5] == true)
                {
                    venturehub.eventnum = 5;
                    venturehub.subeventnum = 0;
                    venturehub.destroybuttons();
                }
                if (venturehub.buttonbool[20] == true)
                {
                    venturehub.eventnum = 20;
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
                    //gift bad stick
                    venturehub.rewardhub.Addrewards(6, "Slightly ominous stick", 1,3);
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
                    venturehub.rewardhub.Addrewards(7, "Slightly special stick", 1, 3);
                    venturehub.rewardsgot = true;
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
