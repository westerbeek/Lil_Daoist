using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QiSensingStage : MonoBehaviour
{
    [SerializeField] private GameObject Mask;
    public GameObject mask { get => Mask; set => Mask = value; }

    [SerializeField] private GameObject Scripthub;
    public GameObject scripthub { get => Scripthub; set => Scripthub = value; }

    [SerializeField] private GameObject Qi2sense;
    public GameObject qi2sense { get => Qi2sense; set => Qi2sense = value; }

    [SerializeField] private Image Fill;
    public Image fill { get => Fill; set => Fill = value; }

    [SerializeField] private float Fillamount;
    public float fillamount { get => Fillamount; set => Fillamount = value; }

    [SerializeField] private float Maxfillamount;
    public float maxfillamount { get => Maxfillamount; set => Maxfillamount = value; }

    [SerializeField] private float Fillspeed;
    public float fillspeed { get => Fillspeed; set => Fillspeed = value; }

    [SerializeField] private bool Found;
    public bool found { get => Found; set => Found = value; }

    [SerializeField] private Sprite[] Rhuns;
    public Sprite[] rhuns { get => Rhuns; set => Rhuns = value; }

    [SerializeField] private float XpgivenQisensing;
    public float xpgivenQisensing { get => XpgivenQisensing; set => XpgivenQisensing = value; }

    // Start is called before the first frame update
    void Start()
    {
        found = false;
        mask = GameObject.Find("Sensingmask");
        qi2sense = GameObject.Find("rhun2sense");
        fill = GameObject.Find("qisensefillamount").GetComponent<Image>();
        scripthub = GameObject.Find("ScriptHub");

        fillamount = 0;
        maxfillamount = 1000;
        fillspeed = 50;

        xpgivenQisensing = 15;

        resetminigame();
    }

    // Update is called once per frame
  

    void Update()
    {
        if (fill != null)
        {
            fill.fillAmount = fillamount / maxfillamount;
        }
        if(found == true)
        {
            fillamount += fillspeed;
        }
        else
        {
            fillamount = 0;
        }
        if(fillamount >= maxfillamount && found == true)
        {
            Complete();
        }
    }
    public void Complete()
    {
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenQisensing,true);
        scripthub.GetComponent<Cultivation>().Giftinspiration(xpgivenQisensing);

        //absorbed.SetActive(false);
        resetminigame();
    }
    public void resetminigame()
    {
        Vector3 newpos = new Vector3(Random.RandomRange(-300, 300), Random.RandomRange(-400, 400),0);
        //Debug.Log(GameObject.Find("Qi_sensing").transform.position) ;
        qi2sense.GetComponent<UILock>().position = GameObject.Find("Qi_sensing").transform.position -newpos;

        qi2sense.GetComponent<Image>().sprite = rhuns[Random.RandomRange(0, Rhuns.Length)];
        fillamount = 0;
    }
}
