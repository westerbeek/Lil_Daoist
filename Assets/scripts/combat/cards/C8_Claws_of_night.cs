using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C8_Claws_of_night : Combatcard
{
    public override void Use(int user)
    {
        CManager = GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>();
        
        //dealdamage to other player
        Debug.Log(name + " Gains 25 energy");
        if (user == 0)
        {
            CManager.playerstats.health -= 15;//CManager.enemystats.physicalattack
        }
        else
        {
            CManager.enemystats.health -= 15;//CManager.playerstats.physicalattack



        }
    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
