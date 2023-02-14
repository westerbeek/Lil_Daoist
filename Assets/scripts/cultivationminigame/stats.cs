using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour
{
    public string playername;
    public string playerID;
    public float health;
    public float maxhealth;

    public float fortitude;
    public float strength;
    public float dexterity;
    public float inteligence;
    public float karma;
    public float luck;

    public float physicalattack;
    public float physicaldefence;
    public float mentalattack;
    public float mentaldefence;
    public float specialattack;
    public float specialdefence;

    public float fireattack;
    public float firedefence;
    public float waterattack;
    public float waterdefence;
    public float woodattack;
    public float wooddefence;
    public float earthattack;
    public float earthdefence;
    public float metalattack;
    public float metaldefence;

    //skills

    public float talent;
    private float minpassiveqi;
    public float passiveqi;//default = 0.01;


    public int upgragepoints;//inspiration
    public float inspirationxp;
    public float maxinspirationxp;
    public float passiveinspirationxp;
    public float minpassiveinspirationxp;

    public GameObject scripthub;

    // mortals journey

    //qi gathering
    public int Qisensing;
    public int Qiabsorbtion;
    public int Qirefinement;

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 100;
        health = maxhealth;
        physicalattack = 1;
        physicaldefence = 1;
        mentalattack = 1;
        mentaldefence = 1;
        //minpassiveinspirationxp = 0.01f;
        playername = "Song Shuhang";//testname
        scripthub = GameObject.Find("ScriptHub");
        maxinspirationxp = 100;//todo
    }

    // Update is called once per frame
    void Update()
    {
        if(scripthub.GetComponent<Cultivation>().Realm == 1)
        {
            minpassiveqi = 0.01f;
        }
        passiveqi = scripthub.GetComponent<skills>().skillqibonus + talent +minpassiveqi;
        skillstatboosts();

        passiveinspirationxp = minpassiveinspirationxp;//TODO
        inspirationxp += passiveinspirationxp;
        if(inspirationxp >= maxinspirationxp)
        {
            inspirationxp = 0;
            upgragepoints += 1;
            maxinspirationxp += maxinspirationxp / 15;
        }
        scripthub.GetComponent<Cultivation>().Xp += passiveqi;
    }
    public void skillstatboosts()
    {
        skills skillz = scripthub.GetComponent<skills>();
        maxhealth = 100 + fortitude * 10;
        physicalattack = 1 + skillz.skillslvl[4];
        physicaldefence = 1 + skillz.skillslvl[5];
        mentalattack = 1 + skillz.skillslvl[6];
        mentaldefence = 1 + skillz.skillslvl[6];
        //specialattack = 1 + skillz.skillslvl[4];
        //specialdefence = 1 + skillz.skillslvl[4];
        /*
        public float fireattack;
        public float firedefence;
        public float waterattack;
        public float waterdefence;
        public float woodattack;
        public float wooddefence;
        public float earthattack;
        public float earthdefence;
        public float metalattack;
        public float metaldefence;

        public float karma;
        public float luck;*/
    }


}
