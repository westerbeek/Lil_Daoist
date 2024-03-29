using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public bool DontLoadDataAtStart;
    public GameObject scripthub;
    public GameObject UIhub;
    

    //inv
    public bool once;

    private string filePath;

    private bool savedatafound;


    private void Awake()
    {
        once = false;
        filePath = Application.persistentDataPath + "/savedata.dat";
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            savedatafound = true;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
    public void Update()
    {
        if(DateTime.UtcNow.Millisecond % 5000 == 0)
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadData();
        }
        if (SceneManager.GetActiveScene().name == "game")
        {
            if(once == false)
            {
                scripthub = GameObject.Find("ScriptHub");
                UIhub = GameObject.Find("UIhub");
                if (File.Exists(filePath))
                {
                    if (DontLoadDataAtStart == false)
                    {
                        LoadData();


                        Debug.Log("loading data");
                    }
                }
                else
                {
                    scripthub.GetComponent<Player>().newgame = true;
                }
                once = true;
            }
        }
    }
    private void SaveData()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();




        //default = 0.01;
     
        data.Add("chead", GameObject.Find("charcustomization").GetComponent<charactercustomization>().headint);
        data.Add("cface", GameObject.Find("charcustomization").GetComponent<charactercustomization>().faceint);
        data.Add("cbody", GameObject.Find("charcustomization").GetComponent<charactercustomization>().bodyint);
        data.Add("carms", GameObject.Find("charcustomization").GetComponent<charactercustomization>().armint);
        data.Add("clegs", GameObject.Find("charcustomization").GetComponent<charactercustomization>().legsint);


        data.Add("playername", scripthub.GetComponent<Player>().playername);
        data.Add("playerid", scripthub.GetComponent<Player>().playerID);
        data.Add("phealth", scripthub.GetComponent<Player>().health);
        data.Add("pmaxhealth", scripthub.GetComponent<Player>().maxhealth);
        data.Add("penergy", scripthub.GetComponent<Player>().energy);
        data.Add("pmaxenergy", scripthub.GetComponent<Player>().maxenergy);
        data.Add("pfortitude", scripthub.GetComponent<Player>().fortitude);
        data.Add("pstrength", scripthub.GetComponent<Player>().strength);
        data.Add("pdexterity", scripthub.GetComponent<Player>().dexterity);
        data.Add("pintelligence", scripthub.GetComponent<Player>().inteligence);
        data.Add("pkarma", scripthub.GetComponent<Player>().karma);
        data.Add("pluck", scripthub.GetComponent<Player>().luck);
        data.Add("pphysicalattack", scripthub.GetComponent<Player>().physicalattack);
        data.Add("pphysicaldefence", scripthub.GetComponent<Player>().physicaldefence);
        data.Add("pmentalattack", scripthub.GetComponent<Player>().mentalattack);
        data.Add("pmentaldefence", scripthub.GetComponent<Player>().mentaldefence);
        data.Add("pspecialattack", scripthub.GetComponent<Player>().specialattack);
        data.Add("pspecialdefence", scripthub.GetComponent<Player>().specialattack);
        
        data.Add("pfireattack", scripthub.GetComponent<Player>().fireattack);
        data.Add("pfiredefence", scripthub.GetComponent<Player>().firedefence);
        data.Add("pwaterattack", scripthub.GetComponent<Player>().waterattack);
        data.Add("pwaterdefence", scripthub.GetComponent<Player>().waterdefence);
        data.Add("pwoodattack", scripthub.GetComponent<Player>().woodattack);
        data.Add("pwooddefence", scripthub.GetComponent<Player>().wooddefence);
        data.Add("pearthattack", scripthub.GetComponent<Player>().earthattack);
        data.Add("pearthdefence", scripthub.GetComponent<Player>().earthdefence);
        data.Add("pmetalattack", scripthub.GetComponent<Player>().metalattack);
        data.Add("pmetaldefence", scripthub.GetComponent<Player>().metaldefence);

         data.Add("pperception", scripthub.GetComponent<Player>().perception);
        data.Add("pspeed", scripthub.GetComponent<Player>().speed);
        data.Add("pbasedamage", scripthub.GetComponent<Player>().basedamage);
        data.Add("pstealth", scripthub.GetComponent<Player>().stealth);

        data.Add("pcultivationknowledge", scripthub.GetComponent<Player>().cultivationknowledge);
        data.Add("pherbologyknowledge", scripthub.GetComponent<Player>().herbologyknowledge);
        data.Add("ptalismanknowledge", scripthub.GetComponent<Player>().talismanknowledge);
        data.Add("prhunknowledge", scripthub.GetComponent<Player>().rhunknowledge);
        data.Add("palchemyknowledge", scripthub.GetComponent<Player>().alchemyknowledge);
        data.Add("pcraftingknowledge", scripthub.GetComponent<Player>().craftingknowledge);
        
        data.Add("ptalent", scripthub.GetComponent<Player>().talent);
        data.Add("pminpassiveqi", scripthub.GetComponent<Player>().minpassiveqi);
        data.Add("ppassiveqi", scripthub.GetComponent<Player>().passiveqi);

        data.Add("pupgragepoints", scripthub.GetComponent<Player>().upgragepoints);
        data.Add("pinspirationxp", scripthub.GetComponent<Player>().inspirationxp);
        data.Add("pmaxinspirationxp", scripthub.GetComponent<Player>().maxinspirationxp);
        data.Add("ppassiveinspirationxp", scripthub.GetComponent<Player>().passiveinspirationxp);
        data.Add("pminpassiveinspirationxp", scripthub.GetComponent<Player>().minpassiveinspirationxp);

        data.Add("seenintro", scripthub.GetComponent<Player>().seenintro);


        for (int i = 0; i < UIhub.GetComponent<Inventory>().items.Length; i++)
        {
            data.Add("Itemid" + i + "", UIhub.GetComponent<Inventory>().items[i].id);
            data.Add("Itemquality" + i + "", UIhub.GetComponent<Inventory>().items[i].Quality);
            data.Add("Itemamount" + i + "", UIhub.GetComponent<Inventory>().items[i].amount);
        }
        for (int i = 0; i < UIhub.GetComponent<Inventory>().equipment.Length; i++)
        {
            data.Add("Equipid" + i + "", UIhub.GetComponent<Inventory>().equipment[i].id);
            data.Add("Equipquality" + i + "", UIhub.GetComponent<Inventory>().equipment[i].Quality);
            data.Add("Equipamount" + i + "", UIhub.GetComponent<Inventory>().equipment[i].amount);
        }


        data.Add("realm", scripthub.GetComponent<Cultivation>().Realm);
        data.Add("xp", scripthub.GetComponent<Cultivation>().Xp);
        data.Add("subrealm", scripthub.GetComponent<Cultivation>().Subrealm);
       
        //offline production
        data.Add("oldtime", scripthub.GetComponent<offlinecalc>().OldTime);


        BinarySaveLoadSystem.Save(filePath, data);
        Debug.Log("Data Saved");
    }

    private void LoadData()
    {
        if (File.Exists(filePath))
        {
            Dictionary<string, object> data = BinarySaveLoadSystem.Load(filePath);
            if (data.ContainsKey("playername"))
            {
                scripthub.GetComponent<Player>().playername = (string)data["playername"];
            }
            if (data.ContainsKey("seenintro"))
            {
                scripthub.GetComponent<Player>().seenintro = (bool)data["seenintro"];
            }

            GameObject charCustomization = GameObject.Find("charcustomization");
            charactercustomization customizationScript = charCustomization.GetComponent<charactercustomization>();

            customizationScript.headint = (int)data["chead"];
            customizationScript.faceint = (int)data["cface"];
            customizationScript.bodyint = (int)data["cbody"];
            customizationScript.armint = (int)data["carms"];
            customizationScript.legsint = (int)data["clegs"];

            customizationScript.updatemodel();

            scripthub.GetComponent<Player>().playerID = (string)data["playerid"];
            scripthub.GetComponent<Player>().health = (float)data["phealth"];
            scripthub.GetComponent<Player>().maxhealth = (float)data["pmaxhealth"];
            scripthub.GetComponent<Player>().energy = (float)data["penergy"];
            scripthub.GetComponent<Player>().maxenergy = (float)data["pmaxenergy"];
            scripthub.GetComponent<Player>().fortitude = (float)data["pfortitude"];
            scripthub.GetComponent<Player>().strength = (float)data["pstrength"];
            scripthub.GetComponent<Player>().dexterity = (float)data["pdexterity"];
            scripthub.GetComponent<Player>().inteligence = (float)data["pintelligence"];
            scripthub.GetComponent<Player>().karma = (float)data["pkarma"];
            scripthub.GetComponent<Player>().luck = (float)data["pluck"];
            scripthub.GetComponent<Player>().physicalattack = (float)data["pphysicalattack"];
            scripthub.GetComponent<Player>().physicaldefence = (float)data["pphysicaldefence"];
            scripthub.GetComponent<Player>().mentalattack = (float)data["pmentalattack"];
            scripthub.GetComponent<Player>().mentaldefence = (float)data["pmentaldefence"];
            scripthub.GetComponent<Player>().specialattack = (float)data["pspecialattack"];
            scripthub.GetComponent<Player>().specialdefence = (float)data["pspecialdefence"];
            scripthub.GetComponent<Player>().fireattack = (float)data["pfireattack"];
            scripthub.GetComponent<Player>().firedefence = (float)data["pfiredefence"];
            scripthub.GetComponent<Player>().waterattack = (float)data["pwaterattack"];
            scripthub.GetComponent<Player>().waterdefence = (float)data["pwaterdefence"];
            scripthub.GetComponent<Player>().woodattack = (float)data["pwoodattack"];
            scripthub.GetComponent<Player>().wooddefence = (float)data["pwooddefence"];
            scripthub.GetComponent<Player>().earthattack = (float)data["pearthattack"];
            scripthub.GetComponent<Player>().earthdefence = (float)data["pearthdefence"];
            scripthub.GetComponent<Player>().metalattack = (float)data["pmetalattack"];
            scripthub.GetComponent<Player>().metaldefence = (float)data["pmetaldefence"];
            scripthub.GetComponent<Player>().perception = (float)data["pperception"];
            scripthub.GetComponent<Player>().speed = (float)data["pspeed"];
            scripthub.GetComponent<Player>().basedamage = (float)data["pbasedamage"];
            scripthub.GetComponent<Player>().stealth = (float)data["pstealth"];
            scripthub.GetComponent<Player>().cultivationknowledge = (float)data["pcultivationknowledge"];
            scripthub.GetComponent<Player>().herbologyknowledge = (float)data["pherbologyknowledge"];
            scripthub.GetComponent<Player>().talismanknowledge = (float)data["ptalismanknowledge"];
            scripthub.GetComponent<Player>().rhunknowledge = (float)data["prhunknowledge"];
            scripthub.GetComponent<Player>().alchemyknowledge = (float)data["palchemyknowledge"];
            scripthub.GetComponent<Player>().craftingknowledge = (float)data["pcraftingknowledge"];
            scripthub.GetComponent<Player>().talent = (float)data["ptalent"];
            scripthub.GetComponent<Player>().minpassiveqi = (float)data["pminpassiveqi"];
            scripthub.GetComponent<Player>().passiveqi = (float)data["ppassiveqi"];
            scripthub.GetComponent<Player>().upgragepoints = (int)data["pupgragepoints"];
            scripthub.GetComponent<Player>().inspirationxp = (float)data["pinspirationxp"];
            scripthub.GetComponent<Player>().maxinspirationxp = (float)data["pmaxinspirationxp"];
            scripthub.GetComponent<Player>().passiveinspirationxp = (float)data["ppassiveinspirationxp"];
            scripthub.GetComponent<Player>().minpassiveinspirationxp = (float)data["pminpassiveinspirationxp"];
            scripthub.GetComponent<Player>().seenintro = (bool)data["seenintro"];

            for (int i = 0; i < UIhub.GetComponent<Inventory>().items.Length; i++)
            {
                UIhub.GetComponent<Inventory>().items[i].id = (int)data["Itemid"+i+""];
                UIhub.GetComponent<Inventory>().items[i].Quality = (int)data["Itemquality"+i+""];
                UIhub.GetComponent<Inventory>().items[i].amount = (int)data["Itemamount"+i+""];
            }
            for (int i = 0; i < UIhub.GetComponent<Inventory>().equipment.Length; i++)
            {
                UIhub.GetComponent<Inventory>().equipment[i].id = (int)data["Equipid" + i + ""];
                UIhub.GetComponent<Inventory>().equipment[i].Quality = (int)data["Equipquality" + i + ""];
                UIhub.GetComponent<Inventory>().equipment[i].amount = (int)data["Equipamount" + i + ""];
            }
            
            UIhub.GetComponent<Inventory>().invfix();
            scripthub.GetComponent<Cultivation>().Realm = (int)data["realm"];
            scripthub.GetComponent<Cultivation>().Subrealm = (int)data["subrealm"];
            scripthub.GetComponent<Cultivation>().Xp = (float)data["xp"];


            scripthub.GetComponent<offlinecalc>().OldTime = (DateTime)data["oldtime"];
            Debug.Log("old time: " + scripthub.GetComponent<offlinecalc>().OldTime);
            scripthub.GetComponent<offlinecalc>().checkproduction();
        }
    }
    public void destroysave()
    {
        BinarySaveLoadSystem.DestroySave(filePath);
        Destroy(GameObject.Find("SteamManagerer"));
        SceneManager.LoadScene("pregame");
        Debug.Log("Save Successfully destroyed");
    }
}