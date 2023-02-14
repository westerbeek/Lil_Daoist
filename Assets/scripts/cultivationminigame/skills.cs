using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skills : MonoBehaviour
{
    public GameObject[] skillsobj;
    public GameObject mortalsjourney;
    public GameObject qimanipulation;

    public int amountskills;
    public string[] skillsname;
    public string[] skillsinfo;
    //public float[] skills;
    public int[] skillslvl;
    public Text[] skillslvltxt;
    public float[] skillsxp;
    public float[] skillsmaxxp;
    public int[] skillspointcost;

    public float skillqibonus;
    public int skillweb;
    // Start is called before the first frame update
    void Start()
    {
        amountskills = 10;
        skillsobj = GameObject.FindGameObjectsWithTag("skillscreenskills");
        skillsname = new string[amountskills];
        skillsinfo = new string[amountskills];
        skillsmaxxp = new float[amountskills];
        skillslvl = new int[amountskills];
        skillspointcost = new int[amountskills];
        skillspointcost[0] = 1;
        skillspointcost[1] = 1;
        skillspointcost[2] = 1;
        skillspointcost[3] = 1;
        skillspointcost[4] = 1;
        skillspointcost[5] = 1;
        skillspointcost[6] = 1;
        skillspointcost[7] = 1;
        skillspointcost[8] = 1;
        skillspointcost[9] = 1;//TODO

        skillsxp = new float[amountskills];
        skillsmaxxp = new float[amountskills];
        skillsmaxxp[0] = 100;
        skillsmaxxp[1] = 100;
        skillsmaxxp[2] = 100;
        skillsmaxxp[3] = 100;
        skillsmaxxp[4] = 100;
        skillsmaxxp[5] = 100;
        skillsmaxxp[6] = 100;
        skillsmaxxp[7] = 100;
        skillsmaxxp[8] = 100;
        skillsmaxxp[9] = 100;

        skillsname[1] = "Qi Sensing";
        skillsname[2] = "Qi Refining";
        skillsname[3] = "Qi Absorption";
        skillsname[4] = "Strength";
        skillsname[5] = "Intelligence";
        skillsname[6] = "Perception";
        skillsname[7] = "Qi sensing";
        skillsname[8] = "Qi sensing";
        skillsname[8] = "Qi sensing";
    }
    void Update()
    {
       skillqibonus = skillslvl[1] + skillslvl[2] + skillslvl[3] / 100;//gets added to cultivation passive qibase
        for (int i = 0; i < skillslvltxt.Length; i++)
        {
            if (i != 0)
            {
                skillslvltxt[i].text = "lvl: " + skillslvl[i];
            }
        }
    }

    // Update is called once per frame
    public void skillz(GameObject nameofskill)
    {
        
       stats statobj = GameObject.Find("ScriptHub").GetComponent<stats>();
       UImanager UI = GameObject.Find("UIhub").GetComponent<UImanager>();
        string skillname = nameofskill.name;
        if(skillname == "Cultivationskill")//0
        {
            if(skillweb == 0)
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
