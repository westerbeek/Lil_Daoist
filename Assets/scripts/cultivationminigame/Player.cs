using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : stats
{
    [SerializeField] private bool Newgame;
    public bool newgame { get => Newgame; set => Newgame = value; }

    [SerializeField] private bool Seenintro;
    public bool seenintro { get => Seenintro; set => Seenintro = value; }

    [SerializeField] private bool Olddatafound;
    public bool olddatafound { get => Olddatafound; set => Olddatafound = value; }

    [SerializeField] private GameObject Weightobj;
    public GameObject weightobj { get => Weightobj; set => Weightobj = value; }

    [SerializeField] private string[] Titles;
    public string[] titles { get => Titles; set => Titles = value; }

    [SerializeField] private string[] Paths;
    public string[] paths { get => Paths; set => Paths = value; }

    [SerializeField] private int Amountplayermodels;
    public int amountplayermodels { get => Amountplayermodels; set => Amountplayermodels = value; }

    [SerializeField] private Animator[] Playeranimation;
    public Animator[] playeranimation { get => Playeranimation; set => Playeranimation = value; }

    [SerializeField] private GameObject Bookanimation;
    public GameObject bookanimation { get => Bookanimation; set => Bookanimation = value; }

    [SerializeField] private float Booktimer;
    public float booktimer { get => Booktimer; set => Booktimer = value; }

    [SerializeField] private float Maxbooktimer;
    public float maxbooktimer { get => Maxbooktimer; set => Maxbooktimer = value; }

    [SerializeField] private float Bookrecharge;
    public float bookrecharge { get => Bookrecharge; set => Bookrecharge = value; }

    [SerializeField] private Vector2 Oldplayercoords;
    public Vector2 oldplayercoords { get => Oldplayercoords; set => Oldplayercoords = value; }

    [SerializeField] private Vector2 Currentplayercoords;
    public Vector2 currentplayercoords { get => Currentplayercoords; set => Currentplayercoords = value; }

    [SerializeField] private Vector2 Heading2;
    public Vector2 heading2 { get => Heading2; set => Heading2 = value; }
    // Start is called before the first frame update
    public GameObject objplayermain;
    void Start()
    {
        
        maxbooktimer = 15;
        bookrecharge = maxbooktimer;
        booktimer = maxbooktimer;
        scripthub = GameObject.Find("ScriptHub");
        objplayermain = GameObject.Find("players");
        GameObject[] objplayers = GameObject.FindGameObjectsWithTag("Player");
        playeranimation = new Animator[objplayers.Length];

        for (int i = 0; i < objplayers.Length; i++)
        {
            playeranimation[i] = objplayers[i].GetComponent<Animator>();
        }
        bookanimation = GameObject.Find("book");
        weightobj = GameObject.Find("weightstick");
        weightobj.SetActive(false);
        titles = new string[10];
        paths = new string[10];

        //stats
        maxhealth = 100;
        health = maxhealth;
        maxenergy = 100;
        energy = maxenergy;
        physicalattack = 1;
        physicaldefence = 1;
        mentalattack = 1;
        mentaldefence = 1;

        //minpassiveinspirationxp = 0.01f;

        scripthub = GameObject.Find("ScriptHub");
        maxinspirationxp = 100;//todo
        //float tmp = dexterity / 100;
        adventuringspeed = .35f + (dexterity / 100);
    }

    // Update is called once per frame
    void Update()
    {
        //animation
        bookanimation.transform.position = new Vector3(bookanimation.transform.position.x, 500, bookanimation.transform.position.z);//1.24285

        if (scripthub.GetComponent<Cultivation>().Cultivate == true)
        {
            if (scripthub.GetComponent<Cultivation>().Realm == 0)
            {

                 //objplayermain.transform.rotation = Quaternion.Euler(objplayermain.transform.rotation.eulerAngles.x, 0f, objplayermain.transform.rotation.eulerAngles.z);

                for (int i = 0; i < playeranimation.Length; i++)
                {
                    playeranimation[i].SetBool("train", true);
                    if (playeranimation[i].GetCurrentAnimatorStateInfo(0).IsName("zoomup"))
                    {
                        if (playeranimation[i].GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
                        {
                            weightobj.SetActive(true);
                        }
                    }
                }
                
                if (scripthub.GetComponent<Cultivation>().Subrealm == 1)
                {
                    bookanimation.transform.position = new Vector3(-76.9899979f, 0.418670416f, -40.9927521f);//1.24285

                    weightobj.SetActive(false);
                    for (int i = 0; i < playeranimation.Length; i++)
                    {
                        playeranimation[i].SetBool("read", true);
                       // objplayermain.transform.rotation = Quaternion.Euler(objplayermain.transform.rotation.eulerAngles.x, -90f, objplayermain.transform.rotation.eulerAngles.z);
                    }
                    booktimer -= Time.deltaTime;
                    if (booktimer <= 0)
                    {
                        bookanimation.GetComponent<Animator>().SetBool("turnpage", true);
                        bookrecharge -= Time.deltaTime;
                        if(bookrecharge <= 0)
                        {
                            booktimer = maxbooktimer;
                            bookrecharge = maxbooktimer;
                        }
                    }
                    else
                    {
                        bookanimation.GetComponent<Animator>().SetBool("turnpage", false);

                    }

                }
                else
                {
                    bookanimation.transform.position = new Vector3(bookanimation.transform.position.x, 5000, bookanimation.transform.position.z);//1.24285

                }


            }
                if (scripthub.GetComponent<Cultivation>().Realm == 1)
                {
                for (int i = 0; i < playeranimation.Length; i++)
                {
                    playeranimation[i].SetBool("cultivate", true);
                    playeranimation[i].SetBool("train", false);
                    playeranimation[i].SetBool("read", false);
                }
                weightobj.SetActive(false);


            }
        }
        else
        {
            for (int i = 0; i < playeranimation.Length; i++)
            {
                playeranimation[i].SetBool("cultivate", false);
                playeranimation[i].SetBool("train", false);
                playeranimation[i].SetBool("read", false);
            }
            weightobj.SetActive(false);


        }

        if (scripthub.GetComponent<Cultivation>().Realm == 1)
        {
            minpassiveqi = 0.01f;
        }
        passiveqi = scripthub.GetComponent<skills>().skillqibonus + talent + minpassiveqi;
        skillstatboosts();

        passiveinspirationxp = minpassiveinspirationxp;//TODO
        inspirationxp += passiveinspirationxp;
        if (inspirationxp >= maxinspirationxp)
        {
            inspirationxp = 0;
            upgragepoints += 1;
            maxinspirationxp += maxinspirationxp / 15;
        }
        scripthub.GetComponent<Cultivation>().Giftxp(passiveqi, false);
        //animationoff
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
