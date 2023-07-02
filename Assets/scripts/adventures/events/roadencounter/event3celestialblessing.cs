using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event3celestialblessing : MonoBehaviour
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
        Debug.Log("beggar event start");

    }
    void eventtext()
    {
        explanationtext[0] = "While meditating in a secluded spot, you feel an ethereal presence surrounding you. \nThe celestial energies converge upon your cultivation, \n\ninfusing you with a profound blessing.";

        explanationtext[1] = "You accept the Celestial Blessing.\nYour body tingles with newfound energy as you feel your cultivation potential soar.";
        explanationtext[2] = "You decline the Celestial Blessing.\nThough the opportunity slips away, you continue your cultivation journey undeterred.";




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
                venturehub.createbutton(1, "Accept the Celestial Blessing");
                venturehub.createbutton(2, "Decline");
                venturehub.subeventnum = 1;

            }
            if (venturehub.subeventnum == 1)
            {
                if (venturehub.buttonbool[1] == true)
                {
                    venturehub.eventnum = 1;
                    venturehub.subeventnum = 0;
                    GameObject.Find("ScriptHub").GetComponent<Player>().passiveqi += GameObject.Find("ScriptHub").GetComponent<Player>().passiveqi / 10;
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
                Debug.Log("beggar event2 add buttons");

                venturehub.changetext(explanationtext[1]);
                venturehub.createbutton(1, "Next");
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
