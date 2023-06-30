using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skills : MonoBehaviour
{
    [SerializeField] private GameObject[] Skillsobj;
    public GameObject[] skillsobj { get => Skillsobj; set => Skillsobj = value; }

    [SerializeField] private GameObject Mortalsjourney;
    public GameObject mortalsjourney { get => Mortalsjourney; set => Mortalsjourney = value; }

    [SerializeField] private GameObject Qimanipulation;
    public GameObject qimanipulation { get => Qimanipulation; set => Qimanipulation = value; }

    [SerializeField] private int Amountskills;
    public int amountskills { get => Amountskills; set => Amountskills = value; }

    [SerializeField] private string[] Skillsname;
    public string[] skillsname { get => Skillsname; set => Skillsname = value; }

    [SerializeField] private string[] Skillsinfo;
    public string[] skillsinfo { get => Skillsinfo; set => Skillsinfo = value; }

    //[SerializeField] private float[] Skills;
    //public float[] skills { get => Skills; set => Skills = value; }

    [SerializeField] private int[] Skillslvl;
    public int[] skillslvl { get => Skillslvl; set => Skillslvl = value; }

    [SerializeField] private Text[] Skillslvltxt;
    public Text[] skillslvltxt { get => Skillslvltxt; set => Skillslvltxt = value; }

    [SerializeField] private float[] Skillsxp;
    public float[] skillsxp { get => Skillsxp; set => Skillsxp = value; }

    [SerializeField] private float[] Skillsmaxxp;
    public float[] skillsmaxxp { get => Skillsmaxxp; set => Skillsmaxxp = value; }

    [SerializeField] private int[] Skillspointcost;
    public int[] skillspointcost { get => Skillspointcost; set => Skillspointcost = value; }

    [SerializeField] private float Skillqibonus;
    public float skillqibonus { get => Skillqibonus; set => Skillqibonus = value; }

    [SerializeField] private int Skillweb;
    public int skillweb { get => Skillweb; set => Skillweb = value; }
    // Start is called before the first frame update
    void Start()
    {
        Amountskills = 10;
        Skillsobj = GameObject.FindGameObjectsWithTag("skillscreenskills");
        Skillsname = new string[Amountskills];
        //Skillsinfo = new string[Amountskills];
        Skillsmaxxp = new float[Amountskills];
        Skillslvl = new int[Amountskills];
        Skillspointcost = new int[Amountskills];
        Skillspointcost[0] = 1;
        Skillspointcost[1] = 1;
        Skillspointcost[2] = 1;
        Skillspointcost[3] = 1;
        Skillspointcost[4] = 1;
        Skillspointcost[5] = 1;
        Skillspointcost[6] = 1;
        Skillspointcost[7] = 1;
        Skillspointcost[8] = 1;
        Skillspointcost[9] = 1;//TODO

        Skillsxp = new float[Amountskills];
        Skillsmaxxp = new float[Amountskills];
        Skillsmaxxp[0] = 100;
        Skillsmaxxp[1] = 100;
        Skillsmaxxp[2] = 100;
        Skillsmaxxp[3] = 100;
        Skillsmaxxp[4] = 100;
        Skillsmaxxp[5] = 100;
        Skillsmaxxp[6] = 100;
        Skillsmaxxp[7] = 100;
        Skillsmaxxp[8] = 100;
        Skillsmaxxp[9] = 100;

        Skillsname[1] = "Qi Sensing";
        Skillsname[2] = "Qi Refining";
        Skillsname[3] = "Qi Absorption";
        Skillsname[4] = "Strength";
        Skillsname[5] = "Intelligence";
        Skillsname[6] = "Perception";
        Skillsname[7] = "Qi sensing";
        Skillsname[8] = "Qi sensing";
        Skillsname[8] = "Qi sensing";
    }
    void Update()
    {
       Skillqibonus = Skillslvl[1] + Skillslvl[2] + Skillslvl[3] / 100;//gets added to cultivation passive qibase
        for (int i = 0; i < Skillslvltxt.Length; i++)
        {
            if (i != 0)
            {
                Skillslvltxt[i].text = "lvl: " + Skillslvl[i];
            }
        }
    }

    // Update is called once per frame
    public void skillz(GameObject nameofskill)
    {
        
       stats statobj = GameObject.Find("ScriptHub").GetComponent<Player>();
       UImanager UI = GameObject.Find("UIhub").GetComponent<UImanager>();
        string skillname = nameofskill.name;
        if(skillname == "Cultivationskill")//0
        {
            if(Skillweb == 0)
            {

            }
        }
        if (skillname == "QiSensingskill")//1
        {
            UI.skillinfofunction(nameofskill, 1);
        }
        if (skillname == "QiRefiningskill")//2
        {
            UI.skillinfofunction(nameofskill, 2);
        }
        if (skillname == "QiAbsorptionskill")//3
        {
            UI.skillinfofunction(nameofskill, 3);
        }
        if (skillname == "strengthskill")//4
        {
            UI.skillinfofunction(nameofskill, 4);
        }
        
        if (skillname == "intelligenceskill")//5
        {
            UI.skillinfofunction(nameofskill, 5);
        }
        if (skillname == "perceptionskill")//6
        {
            UI.skillinfofunction(nameofskill, 6);
        }
    }
}
