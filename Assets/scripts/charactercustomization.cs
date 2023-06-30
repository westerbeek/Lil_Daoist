using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charactercustomization : MonoBehaviour
{

    public string charactername;

    public GameObject scripthub;

    public int amountoutfits;
    public GameObject[] heads;
    public Material[] faces;
    public GameObject[] Body;
    public GameObject[] armsL;
    public GameObject[] armsR;
    public GameObject[] legL;
    public GameObject[] legR;


    public GameObject[] aheads;
    public Material[] afaces;
    public GameObject[] aBody;
    public GameObject[] aarmsL;
    public GameObject[] aarmsR;
    public GameObject[] alegL;
    public GameObject[] alegR;

    public GameObject[] cheads;
    public Material[] cfaces;
    public GameObject[] cBody;
    public GameObject[] carmsL;
    public GameObject[] carmsR;
    public GameObject[] clegL;
    public GameObject[] clegR;

    public int headint;
    public int faceint;
    public int bodyint;
    public int armint;
    public int legsint;

    // Start is called before the first frame update
    void Start()
    {
        updatemodel();
        GameObject.Find("Newgame").SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        scripthub = GameObject.Find("ScriptHub");

    }
    void updatemodel()
    {
        for (int i = 0; i < amountoutfits; i++)
        {
            heads[i].SetActive(false);
            aheads[i].SetActive(false);
            //cheads[i].SetActive(false);
            heads[headint].SetActive(true);
            aheads[headint].SetActive(true);
            Body[i].SetActive(false);
            aBody[i].SetActive(false);

            Body[bodyint].SetActive(true);
            aBody[bodyint].SetActive(true);

            armsL[i].SetActive(false);
            armsR[i].SetActive(false);
            aarmsL[i].SetActive(false);
            aarmsR[i].SetActive(false);

            armsL[armint].SetActive(true);
            armsR[armint].SetActive(true);
            aarmsL[armint].SetActive(true);
            aarmsR[armint].SetActive(true);

            legL[i].SetActive(false);
            legR[i].SetActive(false);
            alegL[i].SetActive(false);
            alegR[i].SetActive(false);

            legL[legsint].SetActive(true);
            legR[legsint].SetActive(true);
            alegL[legsint].SetActive(true);
            alegR[legsint].SetActive(true);
        }
    }
    public void headbutton(int i)
    {
        headint += i;
        if(headint >= amountoutfits)
        {
            headint = 0;
        }
        if(headint < 0)
        {
            headint = amountoutfits - 1;
        }
        updatemodel();

    }
    public void facebutton(int i)
    {
       faceint += i;
        if (faceint >= amountoutfits)
        {
            faceint = 0;
        }
        if (faceint < 0)
        {
            faceint = amountoutfits - 1;
        }
        updatemodel();

    }
    public void bodybutton(int i)
    {
        bodyint += i;
        if (bodyint >= amountoutfits)
        {
            bodyint = 0;
        }
        if (bodyint < 0)
        {
            bodyint = amountoutfits - 1;
        }
        updatemodel();

    }
    public void armbutton(int i)
    {
        armint += i;
        if (armint >= amountoutfits)
        {
            armint = 0;
        }
        if (armint < 0)
        {
            armint = amountoutfits - 1;
        }
        updatemodel();

    }
    public void legsbutton(int i)
    {
        legsint += i;
        if (legsint >= amountoutfits)
        {
            legsint = 0;
        }
        if (legsint < 0)
        {
            legsint = amountoutfits-1;
        }
        updatemodel();

    }
}
