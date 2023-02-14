using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QiSensingStage : MonoBehaviour
{
    public GameObject mask;
    public GameObject scripthub;
    public GameObject qi2sense;
    public Image fill;
    public float fillamount;
    public float maxfillamount;
    public float fillspeed;
    public bool found;

    public Sprite[] rhuns;

    public float xpgivenQisensing;
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
        scripthub.GetComponent<Cultivation>().Giftxp(xpgivenQisensing);
        scripthub.GetComponent<Cultivation>().Giftinspiration(xpgivenQisensing);

        //absorbed.SetActive(false);
        resetminigame();
    }
    public void resetminigame()
    {
        Vector3 newpos = new Vector3(Random.RandomRange(-300, 300), Random.RandomRange(-400, 400),0);
        //Debug.Log(GameObject.Find("Qi_sensing").transform.position) ;
        qi2sense.GetComponent<UILock>().position = GameObject.Find("Qi_sensing").transform.position -newpos;

        qi2sense.GetComponent<Image>().sprite = rhuns[Random.RandomRange(0, rhuns.Length)];
        fillamount = 0;
    }
}
