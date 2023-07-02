using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;

public class UImanager : MonoBehaviour
{
    private GameObject scripthub;
    [SerializeField]
    public TextAsset skillinfotxtfile;
    [SerializeField]

    private string[] skillinfotxtstring;

    private GameObject maincam;

    [SerializeField]
    private TextAsset cultivationinfotxtfile;
    [SerializeField]
    private string[] cultivationinfotxt;

    private Image bgenclosure;
    private Animator bgenimator;
    private bool pulse;
    //bgenclosure
    private GameObject enclosurecanvasobj;

    //Maincanvass
    private GameObject maincanvasobj;
    private bool inforealmbool;
    private bool cultivatable;

    private Image cultbuttonimage;
    private Image cross;//of cultivation button
    private Text realmtxt;
    private Text realminfotxt;
    private Image mainBar;
    private GameObject cultbutton;
    private float realminfocontenty;
    private GameObject upinfo;
    private GameObject downinfo;
    private GameObject realminfoimage;
    private GameObject bottombar;

    private Image inspirationbar;
    private Text inspirationbartxt;

    //playerinfo
    private GameObject playerinfocanvas;
    private bool playerinfobool;
    private TMP_Text playername;
    private TMP_Text playerrealm;
    private TMP_Text playersubrealm;
    private TMP_Text playerqigeneration;
    private TMP_Text statstxt;

    //skillscreen
    private GameObject playerskillscanvas;
    private bool playerskillbool;
    private GameObject mortalsjourneyskillsmenu;
    private GameObject qigatheringskillsmenu;
    private Image inspirskillbar;
    private Text skillinspirlvl;
    private Text skillinspirpercentage;
    //skillinfowindow
    private GameObject skillinfoobj;
    private int sellectecskill;
    private Image skillicon;
    private Image skillxp;
    private Text skillxptxt;
    private Image buyfill;
    private Text skillnametxt;
    private Text skillinfotxt;
    private Text skillvltxt;
    private Text skillcosttxt;
    private float maxpurchasing;
    private float purchasing;
    private bool purchasingbool;

    //adventure canvas
    private GameObject adventuremodeobj;
    private GameObject AdventureCanvas;
    public GameObject adventurecanvas
    {
        get { return AdventureCanvas; }
        set { AdventureCanvas = value; }
    }
    private bool AdventureBool;
    public bool adventurebool
    {
        get { return AdventureBool; }
        set { AdventureBool = value; }
    }
    private GameObject adventureactivate;
    private GameObject AdventureCam;
    [SerializeField]public GameObject adventurecam
    {
        get { return AdventureCam; }
        set { AdventureCam = value; }
    }
    private GameObject AdventuringCanvas;
    public GameObject adventuringcanvas
    {
        get { return AdventuringCanvas; }
        set { AdventuringCanvas = value; }
    }
    private Text Progressionbartxt;
    private GameObject AdventureChoices;
    public GameObject Adventurechoices
    {
        get { return AdventureChoices; }
        set { AdventureChoices = value; }
    }
    private bool ChoicesEnable;
    public bool choicesenable
    {
        get { return ChoicesEnable; }
        set { ChoicesEnable = value; }
    }
    private adventureeventhub adeventhub;
    private string EventType;
    public string eventtype
    {
        get { return EventType; }
        set { EventType = value; }
    }
    //inv
    private GameObject inventorycanvas;
    private Inventory inv;
    private Equipment equip;
    private bool invbool;
    //rewardscreen
    private GameObject rewardcanvas;
    private rewards rewardscript;
    // Start is called before the first frame update
    void Awake()
    {
        scripthub = GameObject.Find("ScriptHub");
        maincam = GameObject.Find("Main Camera");
        //cultivationinfotxtfile = Resources.Load<TextAsset>("text/Cultivationranksinfo");
       // skillinfotxtfile = Resources.Load<TextAsset>("text/skillinfotext");
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
        cultbuttonimage = GameObject.Find("CultivationbuttonTemp").GetComponent<Image>(); ;

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
            playername = GameObject.Find("Playernametxt").GetComponent<TMP_Text>();
            playerrealm = GameObject.Find("Playerrealmtxt").GetComponent<TMP_Text>();
            playersubrealm = GameObject.Find("Playersubrealmtxt").GetComponent<TMP_Text>();
            playerqigeneration = GameObject.Find("passiveQigentxt").GetComponent<TMP_Text>();//
            statstxt = GameObject.Find("Playerstatstxt").GetComponent<TMP_Text>();
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
        adventuremodeobj = GameObject.Find("adventuremodescripts");

        adventurecanvas = GameObject.Find("Adventurecanvas");
        AdventureCam = GameObject.Find("adventurecam");
        adventureactivate = GameObject.Find("adventurepaths");
        adventuringcanvas = GameObject.Find("Adventuringwalkcanvas");
        Adventurechoices = GameObject.Find("choices");
        ChoicesEnable = false;
        adeventhub = GameObject.Find("adventuremodescripts").GetComponent<adventureeventhub>();
        adeventhub.UIhub = this;
        if (adventurecanvas != null)
        {
            adventurebool = false;
            adventurecanvas.SetActive(false);
            adventurecam.SetActive(false);
            adventuringcanvas.SetActive(false);
            adventureactivate.SetActive(false);
            Adventurechoices.SetActive(false);
            
        }
        //Inventory
        inv = this.gameObject.GetComponent<Inventory>();
        inv.Iteminfo = GameObject.Find("Iteminfo");

        inv.equipmentslotimages = new Image[17];
        inv.equipslots = new GameObject[17];
        for (int i = 1; i <= inv.equipmentslotimages.Length; i++)
        {
            string n = "EquipIcon" + i + "";
            //Debug.Log(n);
            inv.equipmentslotimages[i - 1] = GameObject.Find(n).GetComponent<Image>();
            inv.equipslots[i - 1] = inv.equipmentslotimages[i - 1].transform.parent.gameObject;
            // inv.slots[i - 1] = GameObject.Find(n).transform.parent.gameObject;
        }
        
         inventorycanvas = GameObject.Find("invequip");
        if (inv != null)
        {
            inv.slotimages = new Image[20];
            inv.slots = new GameObject[20];
            inv.itemdatabase = GameObject.Find("ItemDatabaseObj").GetComponent<ItemDatabase>();

            for (int i = 1; i <= inv.slotimages.Length; i++)
            {
                string n = "Invicon" + i + "";
                //Debug.Log(n);
                inv.slotimages[i-1] = GameObject.Find(n).GetComponent<Image>();
                inv.slots[i - 1] = GameObject.Find(n).transform.parent.gameObject;
            }
            if (inventorycanvas != null)
            {
                inventorycanvas.SetActive(false);
            }
        }
        //Rewards
        if (rewardcanvas == null)
        {
            rewardcanvas = GameObject.Find("Rewardscanvas");
            rewardscript = this.GetComponent<rewards>();
            rewardscript.revealcanvas = GameObject.Find("Rewardscanvas");

            rewardscript.itemdatabase = GameObject.Find("ItemDatabaseObj").GetComponent<ItemDatabase>();
            rewardscript.inv = this.gameObject.GetComponent<Inventory>();
            rewardscript.reveal = GameObject.Find("Revealanimscreen");
            rewardscript.itemicons = new Image[21];
            rewardscript.slots = new GameObject[21];
            rewardscript.itemsinreveal = new Item[21];
            rewardscript.itemdiscardscreen = GameObject.Find("rewards");
            for (int i = 1; i <= 10; i++)
            {
                string n = "Revealslots" + i + "";
                string p = "revealicon" + i + "";
                int f = i - 1;
                //Debug.Log(n);
                rewardscript.slots[f] = GameObject.Find(n);
                rewardscript.itemicons[f] = GameObject.Find(n).transform.Find(p).GetComponent<Image>();
                int index = f;
                rewardscript.slots[index].GetComponent<Button>().onClick.AddListener(() => rewardscript.switchbutton(index));
                //inv.slots[i - 1] = GameObject.Find(n).transform.parent.gameObject;
            }
            for (int i = 11; i <= 20; i++)
            {
                int D = i - 10;
                string n = "DisgardSlot" + D + "";
                string p = "Disgardicon" + D + "";
                //Debug.Log(n);
                rewardscript.slots[i - 1] = GameObject.Find(n);

                rewardscript.itemicons[i - 1] = GameObject.Find(n).transform.Find(p).GetComponent<Image>();
                int index = D;
                rewardscript.slots[index].GetComponent<Button>().onClick.AddListener(() => rewardscript.switchbutton(index));
                //inv.slots[i - 1] = GameObject.Find(n).transform.parent.gameObject;
            }
            rewardscript.reveal.SetActive(false);
            rewardcanvas.SetActive(false);
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
        skillinfotxtstring = temptxt2.Split(new[] { "~~~" }, StringSplitOptions.RemoveEmptyEntries);
        skillz.skillsinfo = skillinfotxtstring;


    }
    // Update is called once per frame
    private void Update()
    {
        maincanvas();
        skillpointupdate();

        if(adventureactivate.activeSelf == true)
        {
            cultivatable = false;
        }
        else
        {
            cultivatable = true;
        }
        if(purchasingbool == true)
        {
            skillinfopurchase();
        }
    }
    public void maincanvas()
    {
        float xp = scripthub.GetComponent<Cultivation>().Xp;
        float maxxp = scripthub.GetComponent<Cultivation>().Maxxp;
        float inspirxp = scripthub.GetComponent<Player>().inspirationxp;
        float maxinspirxp = scripthub.GetComponent<Player>().maxinspirationxp;
        inspirationbar.fillAmount = inspirxp / maxinspirxp;
        mainBar.fillAmount = xp / maxxp;

        if (inforealmbool == false && realmtxt != null)
        {
            realmtxt.text = scripthub.GetComponent<Cultivation>().Subrealmname;
            realminfotxt.enabled = false;

        }
        xp = Mathf.Round(xp * 10.0f) * 0.01f;
        maxxp = Mathf.Round(maxxp * 10.0f) * 0.01f;

        inspirationbartxt.text = ""+ inspirxp / maxinspirxp * 100 + "%      "+ Math.Round(scripthub.GetComponent<Player>().inspirationxp) + " / "+ Math.Round(scripthub.GetComponent<Player>().maxinspirationxp) +"";
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
   
        float inspirxp = scripthub.GetComponent<Player>().inspirationxp;
        float maxinspirxp = scripthub.GetComponent<Player>().maxinspirationxp;
        float inspirationpoints = scripthub.GetComponent<Player>().upgragepoints;
        skillinspirpercentage.text = "" + inspirxp / maxinspirxp * 100 + "%      " + Math.Round(scripthub.GetComponent<Player>().inspirationxp) + " / " + Math.Round(scripthub.GetComponent<Player>().maxinspirationxp) + "";
        inspirskillbar.fillAmount = inspirxp / maxinspirxp;


        skillinspirlvl.text = "" + inspirationpoints + "";
    }
    public void playerskillzcanvas()
    {
        playerskillbool = !playerskillbool;
        enclosurecanvasobj.SetActive(!playerskillbool);

        playerskillscanvas.SetActive(playerskillbool);
        maincanvasobj.SetActive(!playerskillbool);

        float inspirxp = scripthub.GetComponent<Player>().inspirationxp;
        float maxinspirxp = scripthub.GetComponent<Player>().maxinspirationxp;
        float inspirationpoints = scripthub.GetComponent<Player>().upgragepoints;
        skillinspirpercentage.text = "" + inspirxp / maxinspirxp * 100 + "%      " + Math.Round(scripthub.GetComponent<Player>().inspirationxp) + " / " + Math.Round(scripthub.GetComponent<Player>().maxinspirationxp) + "";
        inspirskillbar.fillAmount = inspirxp / maxinspirxp;

        
        skillinspirlvl.text = ""+inspirationpoints+"";
       
    }
    public void skillinfofunction(GameObject skill, int num)
    {
      
        sellectecskill = num;
        maxpurchasing = 3;
        skills skillz = scripthub.GetComponent<skills>();
        skillinfoobj.SetActive(true);
        skillicon = GameObject.Find("skillinfoiconimage").GetComponent<Image>();
        skillxp = GameObject.Find("skillinfoiconbgxp").GetComponent<Image>();
        skillxptxt = GameObject.Find("skillinfoxp").GetComponent<Text>();
        buyfill = GameObject.Find("skillbuyfill").GetComponent<Image>();
        skillnametxt = GameObject.Find("skillinfoname").GetComponent<Text>();
        skillinfotxt = GameObject.Find("skillinfotext").GetComponent<Text>();
        skillvltxt = GameObject.Find("skilllvltxt").GetComponent<Text>();
        skillcosttxt = GameObject.Find("skillcosttxt").GetComponent<Text>();
        //skillicon.sprite = ;inspirskillbar.fillAmount = inspirxp / maxinspirxp;
        skillxp.fillAmount = skillz.skillsxp[sellectecskill] / skillz.skillsmaxxp[sellectecskill];
        skillxptxt.text = "" + skillz.skillsxp[sellectecskill] / skillz.skillsmaxxp[sellectecskill] * 100 + "%";
        buyfill.fillAmount = 0;
        skillnametxt.text = ""+skillz.skillsname[sellectecskill];
        skillinfotxt.text = ""+skillz.skillsinfo[sellectecskill];
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
      
        if (scripthub.GetComponent<Player>().upgragepoints >= skillz.skillspointcost[sellectecskill])
        {
            purchasing += Time.deltaTime;
            buyfill.fillAmount = purchasing / maxpurchasing;
            if (purchasing >= maxpurchasing)
            {
                scripthub.GetComponent<Player>().upgragepoints -= skillz.skillspointcost[sellectecskill];
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
            playername.text = "\nName: "+ scripthub.GetComponent<Player>().playername;
            GameObject.Find("Playerhealthtxt").GetComponent<TMP_Text>().text = "Health:" + scripthub.GetComponent<Player>().health + " / " + scripthub.GetComponent<Player>().maxhealth;
            GameObject.Find("Playerenergytxt").GetComponent<TMP_Text>().text = "Energy:" + scripthub.GetComponent<Player>().health + " / " + scripthub.GetComponent<Player>().maxhealth;
            playerrealm.text = "Realm: " + scripthub.GetComponent<Cultivation>().Realmname;
            playersubrealm.text = "Subreal: " + scripthub.GetComponent<Cultivation>().Subrealmname;
            playerqigeneration.text = "Passive Qi Generation: " + scripthub.GetComponent<Player>().passiveqi.ToString() + "per tick";
            //statstxt.text = "physical attack: "+ scripthub.GetComponent<Player>().physicalattack.ToString() + "\nPhysical defence: "+ scripthub.GetComponent<Player>().physicaldefence.ToString() + "\nmental attack: " + scripthub.GetComponent<Player>().mentalattack.ToString() + "\nmental defence: " + scripthub.GetComponent<Player>().mentaldefence.ToString() + "\n";
            statstxt.text = "physical attack: " + scripthub.GetComponent<Player>().physicalattack.ToString() + "   Physical defence: " + scripthub.GetComponent<Player>().physicaldefence.ToString() + "\n" +
        "mental attack: " + scripthub.GetComponent<Player>().mentalattack.ToString() + "   mental defence: " + scripthub.GetComponent<Player>().mentaldefence.ToString() + "\n" +
        "special attack: " + scripthub.GetComponent<Player>().specialattack.ToString() + "   special defence: " + scripthub.GetComponent<Player>().specialdefence.ToString() + "\n\n" +
        "fire attack: " + scripthub.GetComponent<Player>().fireattack.ToString() + "   fire defence: " + scripthub.GetComponent<Player>().firedefence.ToString() + "\n" +
        "water attack: " + scripthub.GetComponent<Player>().waterattack.ToString() + "   water defence: " + scripthub.GetComponent<Player>().waterdefence.ToString() + "\n" +
        "wood attack: " + scripthub.GetComponent<Player>().woodattack.ToString() + "   wood defence: " + scripthub.GetComponent<Player>().wooddefence.ToString() + "\n" +
        "earth attack: " + scripthub.GetComponent<Player>().earthattack.ToString() + "   earth defence: " + scripthub.GetComponent<Player>().earthdefence.ToString() + "\n" +
        "metal attack: " + scripthub.GetComponent<Player>().metalattack.ToString() + "   metal defence: " + scripthub.GetComponent<Player>().metaldefence.ToString() + "\n\n" +
        "perception: " + scripthub.GetComponent<Player>().perception.ToString() + "   speed: " + scripthub.GetComponent<Player>().speed.ToString() + "\n" +
        "base damage: " + scripthub.GetComponent<Player>().basedamage.ToString() + "   stealth: " + scripthub.GetComponent<Player>().stealth.ToString() + "\n\n" +
        "cultivation knowledge: " + scripthub.GetComponent<Player>().cultivationknowledge.ToString() + "   herbology knowledge: " + scripthub.GetComponent<Player>().herbologyknowledge.ToString() + "\n" +
        "talisman knowledge: " + scripthub.GetComponent<Player>().talismanknowledge.ToString() + "   rhun knowledge: " + scripthub.GetComponent<Player>().rhunknowledge.ToString() + "\n" +
        "alchemy knowledge: " + scripthub.GetComponent<Player>().alchemyknowledge.ToString() + "   crafting knowledge: " + scripthub.GetComponent<Player>().craftingknowledge.ToString() + "\n" +
        "talent: " + scripthub.GetComponent<Player>().talent.ToString();
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
    public void addventurestart(int b)
    {
        //TODO
        //adventurebool = !adventurebool;
        adventuremodeobj.GetComponent<adventuremode>().activated = true;

        adventureactivate.SetActive(true);
        maincam.SetActive(false);
        adventurecam.SetActive(true);
        enclosurecanvasobj.SetActive(!adventurebool);
         adventurecanvas.SetActive(false);
        adventuringcanvas.SetActive(true);
        maincanvasobj.SetActive(false);

        Debug.Log("adventure number:  " + b);
        adventuremodeobj.GetComponent<adventuremode>().gotowards(b);
        // maincanvasobj.SetActive(!adventurebool);

    }
    public void addventurestop()
    {
        //TODO
        //adventurebool = !adventurebool;
        adventureactivate.SetActive(false);
        maincam.SetActive(true);
        adventurecam.SetActive(false);
        enclosurecanvasobj.SetActive(true);
        adventurecanvas.SetActive(false);
        adventuringcanvas.SetActive(false);
        maincanvasobj.SetActive(true);
        adventurebool = false;
        adventuremodeobj.GetComponent<adventuremode>().setdestination = false;
        adventuremodeobj.GetComponent<adventuremode>().sellectedadventure = 0;
        adventuremodeobj.GetComponent<adventuremode>().activated = false;
       Debug.Log("stooop adventuring");
        // maincanvasobj.SetActive(!adventurebool);

    }
    public void Playerinv()
    {
        invbool = inventorycanvas.activeSelf;
        enclosurecanvasobj.SetActive(invbool);
        maincanvasobj.SetActive(invbool);

        inventorycanvas.SetActive(!invbool);
       

    }
    public void cultivationbutton()
    {
        Debug.Log("cultivate");
        if (cultivatable == true)
        {
            Debug.Log("cultivating");

            scripthub.GetComponent<Cultivation>().Cultivate = !scripthub.GetComponent<Cultivation>().Cultivate;
            cross.gameObject.SetActive(scripthub.GetComponent<Cultivation>().Cultivate);
        }
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
                if (scripthub.GetComponent<Cultivation>().Subrealm == 0)
                {
                    realminfotxt.text = cultivationinfotxt[0];

                }
                if (scripthub.GetComponent<Cultivation>().Subrealm == 1)
                {
                    realminfotxt.text = cultivationinfotxt[1];

                }
                realminfotxt.enabled = true;
                // content.GetComponent<RectTransform>().SetHeight(realmtxt.gameObject.GetComponent<RectTransform>().GetHeight() * 25.1f);
            }
            if (scripthub.GetComponent<Cultivation>().Realm == 1)
            {
                realmtxt.text = "" + scripthub.GetComponent<Cultivation>().Realmname+ "" + scripthub.GetComponent<Cultivation>().Subrealmname + "";
                if (scripthub.GetComponent<Cultivation>().Subrealm == 0)
                {
                    realminfotxt.text = cultivationinfotxt[3];

                }
                if (scripthub.GetComponent<Cultivation>().Subrealm == 1)
                {
                    realminfotxt.text = cultivationinfotxt[4];

                }
                if (scripthub.GetComponent<Cultivation>().Subrealm == 2)
                {
                    realminfotxt.text = cultivationinfotxt[5];

                }
                if (scripthub.GetComponent<Cultivation>().Subrealm == 3)
                {
                    realminfotxt.text = cultivationinfotxt[6];
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
