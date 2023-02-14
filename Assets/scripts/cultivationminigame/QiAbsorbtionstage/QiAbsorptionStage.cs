using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QiAbsorptionStage : MonoBehaviour
{
    public GameObject scripthub;

    public GameObject[] rhunlocs;
    public GameObject[] rhuns;
    public Sprite[] rhunssprites;
    public GameObject absorbed;
    public GameObject required;

    public GameObject RhunRequest;
    public int xpgivenQiAbsorption;

    public List<int> nodouble = new List<int>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        rhuns = GameObject.FindGameObjectsWithTag("QiAbsorbminigameCollider");
        rhunlocs = new GameObject[4];
        rhunlocs[0] = GameObject.Find("rhunloc (1)");
        rhunlocs[1] = GameObject.Find("rhunloc (2)");
        rhunlocs[2] = GameObject.Find("rhunloc (3)");
        rhunlocs[3] = GameObject.Find("rhunloc (4)");
        scripthub = GameObject.Find("ScriptHub");

        nodouble.Add(999);
        nodouble.Add(999);
        nodouble.Add(999);
        nodouble.Add(999);
        xpgivenQiAbsorption = 50;
        resetminigame();
    }

    private void Update()
    {
        if (absorbed != null)
        {
            if (absorbed.GetComponent<Image>().sprite == required.GetComponent<Image>().sprite)
            {
                absorbed.GetComponent<Dragable>().drag = false;
                Complete();
            }
            if (absorbed != null && absorbed.GetComponent<Image>().sprite != required.GetComponent<Image>().sprite)
            {
                absorbed.GetComponent<Dragable>().drag = false;

                Mistake();
            }
        }
    }
    // Update is called once per frame
    public void Mistake()
    {
        //meridian damage
        scripthub.GetComponent<camerashake>().shakeDuration = 0.2f;
        resetminigame();
    }
    public void Complete()
    {
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenQiAbsorption);
        scripthub.GetComponent<Cultivation>().Giftinspiration(xpgivenQiAbsorption);

        //absorbed.SetActive(false);
        resetminigame();
    }
    public void resetminigame()
    {
        nodouble[0] = 999;
        nodouble[1] = 999;
        nodouble[2] = 999;
        nodouble[3] = 999;
//        Debug.Log(nodouble.Count);

        absorbed = null;
        required = rhuns[Random.RandomRange(0, rhuns.Length)];

        for(int i = 0; i < nodouble.Count;i++)
        {
            int newvalue= Random.RandomRange(0, rhuns.Length);
            if(nodouble.Contains(newvalue))
            {
                i--;
            }
            else
            {
                nodouble[i] = newvalue;
            }
            rhuns[i].GetComponent<Image>().sprite = rhunssprites[nodouble[i]];
            rhuns[i].transform.position = rhunlocs[i].transform.position;
            //rhuns[i].SetActive(true);
        }
        RhunRequest.GetComponent<Image>().sprite = required.GetComponent<Image>().sprite;


    }
}
