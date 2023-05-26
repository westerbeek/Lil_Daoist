using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C2_Great_Buddha_Blockade : Combatcard
{
    public override void Use(int user)
    {
        //dealdamage to other player
        

    }

    // Update is called once per frame
    public override void Disgard(int user)
    {
        Debug.Log(name + " disgarded");

    }
}
