using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cultivation : MonoBehaviour
{
    public GameObject scripthub;

    [SerializeField]private int realm;
    public int Realm{ get { return realm; }set { realm = value; }}
    [SerializeField]private string realmname;
    public string Realmname { get { return realmname; } set { realmname = value; } }
    [SerializeField] private int subrealm;
    public int Subrealm { get { return subrealm; } set { subrealm = value; } }
    [SerializeField] private string subrealmname;
    public string Subrealmname { get { return subrealmname; } set { subrealmname = value; } }
    [SerializeField] private int maxsubrealm;
    public int Maxsubrealm { get { return maxsubrealm; } set { maxsubrealm = value; } }
    [SerializeField] private float xp;
    public float Xp { get { return xp; } set { xp = value; } }
    [SerializeField] private float xpbonus;
    public float Xpbonus { get { return xpbonus; } set { xpbonus = value; } }
    [SerializeField] private float maxxp;
    public float Maxxp { get { return maxxp; } set { maxxp = value; } }

    [SerializeField] private bool cultivate;
    public bool Cultivate {get { return cultivate; } set { cultivate = value; }
    }


    [SerializeField] private GameObject[] cultgames;
    public GameObject[] Cultgames { get { return cultgames; } set { cultgames = value; } }
    [SerializeField] private int cultgamenumber;
    public int Cultgamenumber { get { return cultgamenumber; } set { cultgamenumber = value; } }
    [SerializeField] private Image screenoutline;
    public Image Screenoutline { get { return screenoutline; } set { screenoutline = value; } }


    [SerializeField] private bool breakthroughable;
    public bool Breakthroughable { get { return breakthroughable; } set { breakthroughable = value; } }
    // Start is called before the first frame update
    void Start()
    {
        scripthub = GameObject.Find("ScriptHub");
        //cultivate = false;
        
        maxxp = 9899;
    }

    // Update is called once per frame
    void Update()
    {
        
       

        if (realm == 0)
        {
            mortalstrainingfunction();
        }
        if (realm == 1)
        {
            Qigatheringfunction();
        }
        cultivatingfunction();
       
    }
    void cultivatingfunction()
    {
        if (xp > maxxp)//level up
        {

            subrealm++;
            breakthroughable = true;
            xp = 0;
        }
        if (subrealm > maxsubrealm)//realm up
        {
            breakthroughable = true;

            realm++;
            subrealm = 0;
        }


        if (cultivate == true)//if cultivating
        {
            for (int i = 0; i < cultgames.Length; i++)//looks through all minigames
            {
                if (i != cultgamenumber)
                {
                    cultgames[i].SetActive(false);//if i is not  the activated number disable
                }
                cultgames[cultgamenumber].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < cultgames.Length; i++)
            {
                cultgames[i].SetActive(false);//if cultivating is off then all games need to be disabled
            }
        }
    }
    void mortalstrainingfunction()
    {
        realmname = "Mortal training:\n";
        maxsubrealm = 3;

        if (subrealm == 0)//0
        {
            subrealmname = "Body preperation";//bodyprep
                                              //paths[0] = "Qi condensation";
            cultgamenumber = 3;

            maxxp = 15;
        }
        if (subrealm == 1)//0
        {
            subrealmname = "Mind preperation";//mindprep
                                              //paths[0] = "Qi condensation";
            cultgamenumber = 4;

            maxxp = 20;
        }
    }

    void Qigatheringfunction()
    {
        realmname = "Qi Gathering:\n";
        maxsubrealm = 5;

        if (subrealm == 0)//0
        {
            subrealmname = "Qi sensing";//QiSensing
                                        //paths[0] = "Qi condensation";
            cultgamenumber = 2;

            maxxp = 1000;
        }
        if (subrealm == 1)
        {
            subrealmname = "Qi condensation";//QiSensing
                                             //subrealmname = "finished build";//qicondensation
                                            //paths[0] = "Qi condensation";
            cultgamenumber = 0;

            maxxp = 1000;

        }
        if (subrealm == 2)//2
        {
            subrealmname = "Qi refinement";
            //paths[0] = "Qi condensation";
            cultgamenumber = 0;

            maxxp = 1000;
        }
        if (subrealm == 3)
        {
            subrealmname = "Qi absorbtion";
            //paths[0] = "Qi condensation";
            cultgamenumber = 1;

            maxxp = 1000;
        }
        if (subrealm == 4)
        {
            subrealmname = "Finished Build";
            //paths[0] = "Qi condensation";
            cultgamenumber = 1;

            maxxp = 1000;
        }
    }
    public void breakthroughsuccess()
    {
        skills skillunlock = scripthub.GetComponent<skills>();

        if (breakthroughable == true)
        {
            if(realm == 1)
            {
                if (subrealm == 0)
                {
                    skillunlock.skillslvl[0] = 1;

                    skillunlock.skillslvl[1] = 1;
                }
                if (subrealm == 1)
                {
                    skillunlock.skillslvl[2] = 1;

                }
                if (subrealm == 2)
                {
                    skillunlock.skillslvl[3] = 1;

                }
                if (subrealm == 3)
                {
                    skillunlock.skillslvl[4] = 1;
                }
            }
        }
    }
    public void realmbreakthrough()
    {

    }
   
 
    public void Giftxp(float gift)//granting xp
    {
        GameObject ui = GameObject.Find("UIhub");

        xp += gift;
        ui.GetComponent<UImanager>().bgreward();            
       
    }
    public void Giftinspiration(float gift)
    {
        GameObject ui = GameObject.Find("UIhub");

        scripthub.GetComponent<stats>().inspirationxp += gift;
        //ui.GetComponent<UImanager>().bgreward();

    }
}
