using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Deck : MonoBehaviour
{
    public Combatcard[] decksaved;
    public List<Combatcard> deckinuse;

    public Item[] possibleloot;
    public int[] maxamounts;
    public List<int> amounts;
    public float[] lootodds;
    public float[] rolls;
    public List<Item> finalloot;
    // Start is called before the first frame update
    void Start()
    {
        if (possibleloot.Length != null) {
            for (int i = 0; i < possibleloot.Length; i++)
            {
                rolls[i] = Random.Range(0, 100);
                if(rolls[i] <= lootodds[i])
                {
                    finalloot.Add(possibleloot[i]);
                    if(maxamounts[i] > 1)
                    {
                        amounts.Add(Random.Range(1, maxamounts[i]));
                    }
                    else
                    {
                        amounts.Add(1);
                    }
                }
            }
           
                    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
