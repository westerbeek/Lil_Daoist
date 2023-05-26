using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4_DewDrop_Renewal: Combatcard
{
    public override void Use(int user)
    {
        CManager = GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>();
        
        //dealdamage to other player
        Debug.Log(name + " Draws 2 cards");
        if (user == 0)
        {
            CManager.playerstats.health += 15f;
        }
        else
        {
            CManager.enemystats.health += 15f;


        }
    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
