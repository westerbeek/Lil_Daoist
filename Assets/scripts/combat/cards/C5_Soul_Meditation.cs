using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_Soul_Meditation : Combatcard
{
    public override void Use(int user)
    {
        CManager = GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>();
        
        //dealdamage to other player
        Debug.Log(name + " Gains 25 energy");
        if (user == 0)
        {
            CManager.playerstats.energy += 25f;
        }
        else
        {
            CManager.enemystats.energy += 25f;


        }
    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
