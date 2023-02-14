using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UImanager : MonoBehaviour
{
    public GameObject scripthub;
    public TextAsset skillinfotxtfile;
    public GameObject maincam;

    public TextAsset cultivationinfotxtfile;
    public string[] cultivationinfotxt;

    public Image bgenclosure;
    public Animator bgenimator;
    public bool pulse;
    //bgenclosure
    public GameObject enclosurecanvasobj;
    //Maincanvass
    public GameObject maincanvasobj;
    public bool inforealmbool;
    public Image cross;//of cultivation button
    public Text realmtxt;
    public Text realminfotxt;
    public Image mainBar;
    public GameObject cultbutton;
    private float realminfocontenty;
    public GameObject upinfo;
    public GameObject downinfo;
    private GameObject realminfoimage;
    GameObject bottombar;

    public Image inspirationbar;
    public Text inspirationbartxt;

    //playerinfo
    public GameObject playerinfocanvas;
    public bool playerinfobool;
    public Text playername;
    public Text playerrealm;
    public Text playersubrealm;
    public Text playerqigeneration;
    public Text statstxt;


    //skillscreen
    public GameObject playerskillscanvas;
    public bool playerskillbool;
    public GameObject mortalsjourneyskillsmenu;
    public GameObject qigatheringskillsmenu;
    public Image inspirskillbar;
    public Text skillinspirlvl;
    public Text skillinspirpercentage;
    //skillinfowindow
    public GameObject skillinfoobj;
    public int sellectecskill;
    public Image skillicon;
    public Image skillxp;
    public Text skillxptxt;
    public Image buyfill;
    public Text skillnametxt;
    public Text skillinfotxt;
    public Text skillvltxt;
    public Text skillcosttxt;
    public float maxpurchasing;
    public float purchasing;
    public bool purchasingbool;

    //adventure canvas
    public GameObject adventurecanvas;
    public bool adventurebool;
    public GameObject adventureactivate;
    public GameObject adventurecam;
    public GameObject adventuringcanvas;
    public Text Progressionbartxt;

    // Start is called before the first frame update
    void Start()
    {
        scripthub = GameObject.Find("ScriptHub");
        maincam = GameObject.Find("Main Camera");
        splitText(cultivationinfotxtfile);
        skillinfosplitText(skillinfotxtfile);

        //enclosure
        enclosurecanvasobj = GameObject.Find("enclosure");
        bgenclosure = GameObject.Find("bgenclosure").GetComponent<Image>();
        bgenimator = GameObject.Find("bgenclosure").GetComponent<Animator>();
        string bgcolor1 = bgenclosure.color.ToString();
        //maincanvas
        maincanvasobj = GameObject.Find("Maincanvas");
        mainBar = GameObject.Find("progression").GetComponent<Image>();
        cross = GameObject.Find("cultivationcross").GetComponent<Image>();
        cross.gameObject.SetActive(false);
        Progressionbartxt = GameObject.Find("progressiontxt").GetComponent<Text>();
        realmtxt = GameObject.Find("realmname").GetComponent<Text>();
        realminfotxt = GameObject.Find("realminfo").GetComponent<Text>();
        cultbutton = GameObject.Find("CultivationbuttonTemp");

        upinfo = GameObject.Find("Upinforlm");
        downinfo = GameObject.Find("Downinforlm");
        realminfoimage = GameObject.Find("Realminfobackgroundimage");

        downinfo.SetActive(true);
        upinfo.SetActive(false);
        realminfoimage.SetActive(false);
        bottombar = GameObject.Find("button_background");

        realminfotxt.text = "";

        inspirationbar = GameObject.Find("rsgprogression").GetComponent<Image>();
        inspirationbartxt = GameObject.Find("rsgprogressiontxt").GetComponent<Text>();

        //playerinfo
        playerinfocanvas = GameObject.Find("Playerinfocanvas");
        if (playerinfocanvas != null)
        {
            playername = GameObject.Find("Playernametxt").GetComponent<Text>();
            playerrealm = GameObject.Find("Playerrealmtxt").GetComponent<Text>();
            playersubrealm = GameObject.Find("Playersubrealmtxt").GetComponent<Text>();
            playerqigeneration = GameObject.Find("passiveQigentxt").GetComponent<Text>();//
            statstxt = GameObject.Find("Playerstatstxt").GetComponent<Text>();
            playerinfobool = false;
            playerinfocanvas.SetActive(false);
        }
        //skillinfo
        skillinfoobj = GameObject.Find("skillinfo");
        sellectecskill = 0;
        skillicon = GameObject.Find("skillinfoiconimage").GetComponent<Image>();
        skillxp = GameObject.Find("skillinfoiconbgxp").GetComponent<Image>();
        skillxptxt = GameObject.Find("skillinfoxp").GetComponent<Text>();
        buyfill = GameObject.Find("skillbuyfill").GetComponent<Image>();
        skillnametxt = GameObject.Find("skillinfoname").GetComponent<Text>();
        skillinfotxt = GameObject.Find("skillinfotext").GetComponent<Text>();
        skillvltxt = GameObject.Find("skilllvltxt").GetComponent<Text>();
        skillcosttxt = GameObject.Find("skillcosttxt").GetComponent<Text>();
        purchasingbool = false;
        skillinfoobj.SetActive(false);
        //skills
        inspirskillbar = GameObject.Find("skillrsgprogression").GetComponent<Image>();
        skillinspirlvl = GameObject.Find("lvlrsgprogressiontxt").GetComponent<Text>();
        skillinspirpercentage = GameObject.Find("skillrsgprogressiontxt").GetComponent<Text>();
        playerskillscanvas = GameObject.Find("PlayerSkillzcanvas");
        if(playerskillscanvas != null)
        {
            mortalsjourneyskillsmenu = GameObject.Find("mortalstrainingskillbg");
            qigatheringskillsmenu = GameObject.Find("Qigatheringskillbg");
            mortalsjourneyskillsmenu.SetActive(true);
            qigatheringskillsmenu.SetActive(false);
            playerskillbool = false;
            playerskillscanvas.SetActive(false);
        }
  

    //adventure
        adventurecanvas = GameObject.Find("Adventurecanvas");
        adventurecam = GameObject.Find("adventurecam");
        adventureactivate = GameObject.Find("adventurepaths");
        adventuringcanvas = GameObject.Find("Adventuringwalkcanvas");
        if(adventurecanvas != null)
        {
            adventurebool = false;
            adventurecanvas.SetActive(false);
            adventurecam.SetActive(false);
            adventuringcanvas.SetActive(false);
            adventureactivate.SetActive(false);
        }

    }
    public void splitText(TextAsset file)
    {
        string temptxt;
        temptxt = file.text.ToString();
        cultivationinfotxt = temptxt.Split(new[] { "~~~" }, StringSplitOptions.RemoveEmptyEntries);
        //Debug.Log(cultivationinfotxt[1]);
    }
    public void skillinfosplitText(TextAsset file)
    {
        skills skillz = scripthub.GetComponent<skills>();

        string temptxt2;
        temptxt2 = file.text.ToString();
        skillz.skillsinfo = temptxt2.Split(new[] { "~~~" }, StringSplitOptions.RemoveEmptyEntries);
        


    }
    // Update is called once per frame
    private void Update()
    {
        maincanvas();
        skillpointupdate();
        if(purchasingbool == true)
        {
            skillinfopurchase();
        }
    }
    public void maincanvas()
    {
        float xp = scripthub.GetComponent<Cultivation>().Xp;
        float maxxp = scripthub.GetComponent<Cultivation>().Maxxp;
        float inspirxp = scripthub.GetComponent<stats>().inspirationxp;
        float maxinspirxp = scripthub.GetComponent<stats>().maxinspirationxp;
        inspirationbar.fillAmount = inspirxp / maxinspirxp;
        mainBar.fillAmount = xp / maxxp;

        if (inforealmbool == false && realmtxt != null)
        {
            realmtxt.text = scripthub.GetComponent<Cultivation>().Subrealmname;
            realminfotxt.enabled = false;

        }
        xp = Mathf.Round(xp * 10.0f) * 0.01f;
        maxxp = Mathf.Round(maxxp * 10.0f) * 0.01f;

        inspirationbartxt.text = ""+ inspirxp / maxinspirxp * 100 + "%      "+ Math.Round(scripthub.GetComponent<stats>().inspirationxp) + " / "+ Math.Round(scripthub.GetComponent<stats>().maxinspirationxp) +"";
        Progressionbartxt.text = ""+ xp / maxxp * 100 + "%      "+ Math.Round(scripthub.GetComponent<Cultivation>().Xp, 2) + " / "+ Math.Round(scripthub.GetComponent<Cultivation>().Maxxp, 2) +"";
        //Progressionbartxt.text = ""+ xp / maxxp * 100 + "%      "+ Math.Round(scripthub.GetComponent<Cultivation>().Xp, 2) + " / "+ Math.Round(scripthub.GetComponent<Cultivation>().Maxxp, 2) +"";
    }
    public void bgreward()
    {
        bgenimator.SetBool("reward", true);
        StartCoroutine(bgrewardend());
    }
     public IEnumerator bgrewardend()
    {
        yield return new WaitForEndOfFrame();
        bgenimator.SetBool("reward", false);

    }
    public void skillpointupdate()
    {
        float inspirxp = scripthub.GetComponent<stats>().inspirationxp;
        float maxinspirxp = scripthub.GetComponent<stats>().maxinspirationxp;
        float inspirationpoints = scripthub.GetComponent<stats>().upgragepoints;
        skillinspirpercentage.text = "" + inspirxp / maxinspirxp * 100 + "%      " + Math.Round(scripthub.GetComponent<stats>().inspirationxp) + " / " + Math.Round(scripthub.GetComponent<stats>().maxinspirationxp) + "";
        inspirskillbar.fillAmount = inspirxp / maxinspirxp;


        skillinspirlvl.text = "" + inspirationpoints + "";
    }
    public void playerskillzcanvas()
    {
        playerskillbool = !playerskillbool;
        enclosurecanvasobj.SetActive(!playerskillbool);

        playerskillscanvas.SetActive(playerskillbool);
        maincanvasobj.SetActive(!playerskillbool);

        float inspirxp = scripthub.GetComponent<stats>().inspirationxp;
        float maxinspirxp = scripthub.GetComponent<stats>().maxinspirationxp;
        float inspirationpoints = scripthub.GetComponent<stats>().upgragepoints;
        skillinspirpercentage.text = "" + inspirxp / maxinspirxp * 100 + "%      " + Math.Round(scripthub.GetComponent<stats>().inspirationxp) + " / " + Math.Round(scripthub.GetComponent<stats>().maxinspirationxp) + "";
        inspirskillbar.fillAmount = inspirxp / maxinspirxp;

        
        skillinspirlvl.text = ""+inspirationpoints+"";
       
    }
    public void skillinfofunction(GameObject skill, int num)
    {
        sellectecskill = num;
        maxpurchasing = 3;
        skills skillz = scripthub.GetComponent<skills>();
        skillinfoobj.SetActive(true);

        //skillicon.sprite = ;inspirskillbar.fillAmount = inspirxp / maxinspirxp;
        skillxp.fillAmount = skillz.skillsxp[sellectecskill] / skillz.skillsmaxxp[sellectecskill];
        skillxptxt.text = "" + skillz.skillsxp[sellectecskill] / skillz.skillsmaxxp[sellectecskill] * 100 + "%";
        buyfill.fillAmount = 0;
        skillnametxt.text = skillz.skillsname[sellectecskill];
        skillinfotxt.text = skillz.skillsinfo[sellectecskill];
        skillvltxt.text = ""+skillz.skillslvl[sellectecskill] +"";
        skillcosttxt.text = "" + skillz.skillspointcost[sellectecskill] + "";
        purchasing = 0;
    }
    public void skillinfoclose()
    {
        skillinfoobj.SetActive(false);

    }
    public void activatepurchase()
    {
        purchasingbool = true;
    }
    public void skillinfopurchase()
    {
        skills skillz = scripthub.GetComponent<skills>();
      
        if (scripthub.GetComponent<stats>().upgragepoints >= skillz.skillspointcost[sellectecskill])
        {
            purchasing += Time.deltaTime;
            buyfill.fillAmount = purchasing / maxpurchasing;
            if (purchasing >= maxpurchasing)
            {
                scripthub.GetComponent<stats>().upgragepoints -= skillz.skillspointcost[sellectecskill];
                skillz.skillslvl[sellectecskill]++;
                skillvltxt.text = "" + skillz.skillslvl[sellectecskill] + "";

                purchasing = 0;
            }
        }
        Debug.Log("purchasing");
    }
    public void letgopurchaseskill()
    {
        purchasing = 0;

        purchasingbool = false;
    }

    public void playerinfo()
    {
        playerinfobool = !playerinfobool;
        playerinfocanvas.SetActive(playerinfobool);
        maincanvasobj.SetActive(!playerinfobool);

        if (playerinfobool == true)
        {
            playername.text = "Health:"+ scripthub.GetComponent<stats>().health+" / "+ scripthub.GetComponent<stats>().maxhealth+ "\nName: "+ scripthub.GetComponent<stats>().playername;
            playerrealm.text = "Realm: " + scripthub.GetComponent<Cultivation>().Realmname;
            playersubrealm.text = "Subreal: " + scripthub.GetComponent<Cultivation>().Subrealmname;
            playerqigeneration.text = "Passive Qi Generation: " + scripthub.GetComponent<stats>().passiveqi.ToString() + "per tick";
            statstxt.text = "physical attack: "+ scripthub.GetComponent<stats>().physicalattack.ToString() + "\nPhysical defence: "+ scripthub.GetComponent<stats>().physicaldefence.ToString() + "\nmental attack: " + scripthub.GetComponent<stats>().mentalattack.ToString() + "\nmental defence: " + scripthub.GetComponent<stats>().mentaldefence.ToString() + "\n";
        }
    }
    public void addventurecanvasfuction()
    {
        adventurebool = !adventurebool;
        enclosurecanvasobj.SetActive(!adventurebool);
        adventurecanvas.SetActive(adventurebool);
        maincanvasobj.SetActive(!adventurebool);
        maincam.SetActive(true);
        adventurecam.SetActive(false);
        adventuringcanvas.SetActive(false);

    }
    public void addventurestart()
    {
        //TODO
        //adventurebool = !adventurebool;
        adventureactivate.SetActive(true);
        maincam.SetActive(false);
        adventurecam.SetActive(true);
        enclosurecanvasobj.SetActive(!adventurebool);
         adventurecanvas.SetActive(false);
        adventuringcanvas.SetActive(true);
      // maincanvasobj.SetActive(!adventurebool);

    }
    public void cultivationbutton()
    {

        scripthub.GetComponent<Cultivation>().Cultivate = !scripthub.GetComponent<Cultivation>().Cultivate;
        cross.gameObject.SetActive(scripthub.GetComponent<Cultivation>().Cultivate);

    }
    public void realminfo()
    {
        realminfoimage.SetActive(true);

        GameObject content = GameObject.Find("contentRealminfo");
        GameObject scrollnfo = GameObject.Find("scrollInforealm");
        //content.GetComponent<RectTransform>().SetHeight(100);

        inforealmbool = !inforealmbool;
        if (inforealmbool == true)
        {
            downinfo.SetActive(false);
            upinfo.SetActive(true);
            bottombar.SetActive(false);
            scrollnfo.GetComponent<ScrollRect>().enabled = true;

            //realminfocontenty = content.transform.position.y;


            cultbutton.SetActive(false);

            if (scripthub.GetComponent<Cultivation>().Realm == 0)
            {
                realmtxt.text = "" + scripthub.GetComponent<Cultivation>().Realmname+ "" + scripthub.GetComponent<Cultivation>().Subrealmname + "";
                realminfotxt.text = cultivationinfotxt[1];
                realminfotxt.enabled = true;
                // content.GetComponent<RectTransform>().SetHeight(realmtxt.gameObject.GetComponent<RectTransform>().GetHeight() * 25.1f);
            }
            if (scripthub.GetComponent<Cultivation>().Realm == 1)
            {
                realmtxt.text = "" + scripthub.GetComponent<Cultivation>().Realmname+ "" + scripthub.GetComponent<Cultivation>().Subrealmname + "";
                if (scripthub.GetComponent<Cultivation>().Subrealm == 0)
                {
                    realminfotxt.text = cultivationinfotxt[1];

                }
                if (scripthub.GetComponent<Cultivation>().Subrealm == 1)
                {
                    realminfotxt.text = "\n\n\nQi condensation realm is the realm that condenses the Qi from the air\n\nCurrently in the Qi sensing realm\n\nThis is obvious a bit of filler text and real lore will be written at a later time\n\nThis is mostly to see how much text can fit on here while still being readable on phones\n\nya di da di do\n\nDa be die, Da be die\nI'm blue\n\nWith much love\n\n~West\n\n\n\n";

                }
                if (scripthub.GetComponent<Cultivation>().Subrealm == 2)
                {
                    realminfotxt.text = "\n\n\nQi refinement realm is the realm that refines the Qi\n\nCurrently in the Qi sensing realm\n\nThis is obvious a bit of filler text and real lore will be written at a later time\n\nThis is mostly to see how much text can fit on here while still being readable on phones\n\nya di da di do\n\nDa be die, Da be die\nI'm blue\n\nWith much love\n\n~West\n\n\n\n";

                }
                if (scripthub.GetComponent<Cultivation>().Subrealm == 3)
                {
                    realminfotxt.text = "\n\n\nQi gathering realm is the realm that gathers the Qi\n\nCurrently in the Qi absorbtion realm\n\nThis is obvious a bit of filler text and real lore will be written at a later time\n\nThis is mostly to see how much text can fit on here while still being readable on phones\n\nya di da di do\n\nDa be die, Da be die\nI'm blue\n\nWith much love\n\n~West\n\n\n\n";
                }
                realminfotxt.enabled = true;

                /*int count = realminfotxt.text.Split('\n').Length - 1;
                int count2 = realminfotxt.text.Length - realminfotxt.text.Split('\n').Length - 1;
                int count3 = count - count2;
                int count4 = count3;
                int count5 = count4* -1;
                int count6 = count5 + count2;
                Debug.Log(count5);
                for (int i = 0; i < count5; i++)
                {
                    content.GetComponent<RectTransform>().SetHeight(content.GetComponent<RectTransform>().GetHeight() + 10);
                    
                    Debug.Log(count5 + 25);
                }*/
            }
            if (scripthub.GetComponent<Cultivation>().Realm == 2)
            {
                realmtxt.text = "" + scripthub.GetComponent<Cultivation>().Realmname+ "" + scripthub.GetComponent<Cultivation>().Subrealmname + "";
                //   content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 2184.791F);
                realminfotxt.enabled = true;
            }
        }
        else
        {

            realmtxt.text = "" + scripthub.GetComponent<Cultivation>().Realmname+ "" + scripthub.GetComponent<Cultivation>().Subrealmname + "";
            realminfotxt.enabled = false;
            cultbutton.SetActive(true);
            realminfotxt.text = "";
            bottombar.SetActive(true);

            downinfo.SetActive(true);
            upinfo.SetActive(false);
            realminfoimage.SetActive(false);
            //content.transform.position = new Vector2(content.transform.position.x, realminfocontenty);
        }

    }

    public void rightUI()
    {
        Animator right = GameObject.Find("buttonbackgroundR").GetComponent<Animator>();
        if (right.GetBool("start") == true)
        {
            right.SetBool("menu", !right.GetBool("menu"));
        }
        else
        {
            right.SetBool("start", true);
        }
    }
    public void leftUI()
    {
        Animator left = GameObject.Find("buttonbackgroundL").GetComponent<Animator>();
        if (left.GetBool("start") == true)
        {
            left.SetBool("menu", !left.GetBool("menu"));

        }
        else
        {
            left.SetBool("start", true);
        }
    }

    public void skillsmortaljourney()
    {
        mortalsjourneyskillsmenu.SetActive(true);
        qigatheringskillsmenu.SetActive(false);
    }
    public void skillsqigathering()
    {
        if (scripthub.GetComponent<Cultivation>().Realm >= 1)
        {
            mortalsjourneyskillsmenu.SetActive(false);
            qigatheringskillsmenu.SetActive(true);
        }
    }
    public void skillsfoundationbuilding()//TODO
    {
        if (scripthub.GetComponent<Cultivation>().Realm >= 2)
        {
            mortalsjourneyskillsmenu.SetActive(false);
            qigatheringskillsmenu.SetActive(true);
        }
    }
}
