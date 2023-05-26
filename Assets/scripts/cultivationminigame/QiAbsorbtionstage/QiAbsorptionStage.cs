using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QiAbsorptionStage : MonoBehaviour
{
    [SerializeField] private GameObject Scripthub;
    public GameObject scripthub { get => Scripthub; set => Scripthub = value; }

    [SerializeField] private GameObject[] Rhunlocs;
    public GameObject[] rhunlocs { get => Rhunlocs; set => Rhunlocs = value; }

    [SerializeField] private GameObject[] Rhuns;
    public GameObject[] rhuns { get => Rhuns; set => Rhuns = value; }

    [SerializeField] private Sprite[] Rhunssprites;
    public Sprite[] rhunssprites { get => Rhunssprites; set => Rhunssprites = value; }

    [SerializeField] private GameObject Absorbed;
    public GameObject absorbed { get => Absorbed; set => Absorbed = value; }

    [SerializeField] private GameObject Required;
    public GameObject required { get => Required; set => Required = value; }

    [SerializeField] private GameObject RhunRequest;
    public GameObject rhunRequest { get => RhunRequest; set => RhunRequest = value; }

    [SerializeField] private int XpgivenQiAbsorption;
    public int xpgivenQiAbsorption { get => XpgivenQiAbsorption; set => XpgivenQiAbsorption = value; }

    [SerializeField] private List<int> Nodouble = new List<int>();
    public List<int> nodouble { get => Nodouble; set => Nodouble = value; }


    // Start is called before the first frame update
    void Start()
    {
        Rhuns = GameObject.FindGameObjectsWithTag("QiAbsorbminigameCollider");
        Rhunlocs = new GameObject[4];
        Rhunlocs[0] = GameObject.Find("rhunloc (1)");
        Rhunlocs[1] = GameObject.Find("rhunloc (2)");
        Rhunlocs[2] = GameObject.Find("rhunloc (3)");
        Rhunlocs[3] = GameObject.Find("rhunloc (4)");
        Scripthub = GameObject.Find("ScriptHub");

        Nodouble.Add(999);
        Nodouble.Add(999);
        Nodouble.Add(999);
        Nodouble.Add(999);
        XpgivenQiAbsorption = 50;
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
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenQiAbsorption,true);
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
        required = Rhuns[Random.RandomRange(0, Rhuns.Length)];

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
