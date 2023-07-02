using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event4BanditCultivator : MonoBehaviour
{
    private adventureeventhub venturehub;
    private string adventuretype;


    private bool permanent;

    private string[] explanationtext;
    private int randomness;

    // Start is called before the first frame update
    void Start()
    {
        venturehub = GameObject.Find("adventuremodescripts").GetComponent<adventureeventhub>();
        explanationtext = new string[50];
        randomness = Mathf.FloorToInt(Random.Range(0f, 1000f));
        eventtext();
        Debug.Log("Bandit Cultivator event start");
    }

    void eventtext()
    {
        explanationtext[0] = "While traveling through the mountains, \nyou come across a lone cultivator dressed in tattered robes. \nThe air around them reeks of hostility and menace." +
            "\nThe bandit cultivator demands that you hand over all your valuable possessions or face their wrath.";
        explanationtext[1] = "You refuse to give in to the bandit cultivator's demands, " +
            "\nready to defend yourself.";
        explanationtext[2] = "You comply with the bandit cultivator's demands, " +
            "\nhoping to avoid a confrontation.\n" +
            "He quickly goes through your pockets but doesnt find anything that interests him\nYou see him quickly vanish in the distance";
    }
    //TODO change this event later
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
                venturehub.createbutton(1, "Stand your ground");
                venturehub.createbutton(2, "Hand over valuables");
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
        if (venturehub.eventnum == 1)
        {
            if (venturehub.subeventnum == 0)
            {

                venturehub.changetext(explanationtext[1]);
                venturehub.createbutton(1, "Fight");
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
        if (venturehub.eventnum == 2)
        {
            if (venturehub.subeventnum == 0)
            {
                Debug.Log("beggar event2 add buttons");

                venturehub.changetext(explanationtext[2]);
                venturehub.createbutton(1, "Next");
                venturehub.subeventnum = 1;

            }
            if (venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    venturehub.destroybuttons();

                    venturehub.eventnum = 998;
                    venturehub.subeventnum = 0;
                }
            }
        }



        if (venturehub.eventnum == 998)
        {
            venturehub.endevent();
        }
        if (venturehub.eventnum == 999)
        {
            GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>().activatecombat();
            venturehub.endevent();
        }
    }

}