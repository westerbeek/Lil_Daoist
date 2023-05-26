using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1_Myriad_Basic_fist : Combatcard
{
    public override void Use(int user)
    {
        CManager = GameObject.Find("Combatmanagerobj").GetComponent<combatmanager>();
        
        //dealdamage to other player
        Debug.Log(name + " deal 5 damage");
        if (user == 0)
        {
            CManager.enemystats.health -= 5 + CManager.playerstats.physicalattack;
        }
        else
        {
            CManager.playerstats.health -= 5;
        }
    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
