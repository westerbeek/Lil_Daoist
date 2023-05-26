using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3_Lotus_Insight : Combatcard
{
    public override void Use(int user)
    {
        CManager = GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>();
        
        //dealdamage to other player
        Debug.Log(name + " Draws 2 cards");
        if (user == 0)
        {
            CManager.drawcards(user, 2);
        }
        else
        {
            CManager.drawcards(user, 2);

        }
    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
