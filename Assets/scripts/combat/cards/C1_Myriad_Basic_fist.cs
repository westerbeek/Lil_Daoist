using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1_Myriad_Basic_fist : Combatcard
{
    public override void Use(int user)
    {
        //dealdamage to other player
        Debug.Log(name + " deal 5 damage");


    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
