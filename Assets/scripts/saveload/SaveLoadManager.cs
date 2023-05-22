using System.Collections;
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
    
    public int cultivation = 5;
    public string lore = "i am being saved";
    public float funny = 4.20f;

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
        if(SceneManager.GetActiveScene().name == "game")
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveData();
        }
    }
    private void SaveData()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("playername", scripthub.GetComponent<Player>().playername);
        data.Add("seenintro", scripthub.GetComponent<Player>().seenintro);
        data.Add("cultivation", cultivation);
        data.Add("lore", lore);
        data.Add("funny", funny);

        BinarySaveLoadSystem.Save(filePath, data);
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
            cultivation = (int)data["cultivation"];
            lore = (string)data["lore"];
            funny = (float)data["funny"];
        }
    }
    public void destroysave()
    {
        BinarySaveLoadSystem.DestroySave(filePath);
    }
}