using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_Bite : Combatcard
{
    public override void Use(int user)
    {
        CManager = GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>();
        
        //dealdamage to other player
        Debug.Log(name + " Gains 25 energy");
        if (user == 0)
        {
            CManager.playerstats.health -= 10;//CManager.enemystats.physicalattack
        }
        else
        {
            CManager.enemystats.health -= 10;//CManager.playerstats.physicalattack



        }
    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
