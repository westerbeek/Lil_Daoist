using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class adventureeventhub : MonoBehaviour
{

    public UImanager UIhub;
    public rewards rewardhub;
    public Inventory inv;

    public bool eventactivated;
    public TMP_Text eventext;
    public bool[] buttonbool;
    public GameObject buttonprefab;
    public GameObject[] buttonsobjs;
    public Transform buttonloc;
    public GameObject[] events;
    public GameObject currentevent;
    public int eventID;
    public int amountevents;
    public int eventnum;
    public int subeventnum;
    public bool rewardsgot;
    public bool once;

    // Start is called before the first frame update
    void Start()
    {
        buttonbool = new bool[21];
        buttonsobjs = new GameObject[21];
        once = false;
        UIhub = GameObject.Find("UIhub").GetComponent<UImanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rewardhub == null)
        {
            rewardhub = GameObject.Find("UIhub").GetComponent<rewards>();
        }
        eventactivated = UIhub.choicesenable;

        if (inv == null)
        {
            inv = GameObject.Find("UIhub").GetComponent<Inventory>();
        }
        if (eventactivated == true)
        {
            UIhub.Adventurechoices.SetActive(true);
            
            buttonloc = GameObject.Find("Contentbuttonloc").transform;
            if(eventext == null)
            {
                eventext = GameObject.Find("eventtext").GetComponent<TMP_Text>();
            }

            if (currentevent != null)
            {
                if (currentevent != events[eventID] && once == false)
                {                  
                    
                        Destroy(currentevent);
                    Debug.Log("destroy current event");
                        setadventure();
                    once = true;

                }
            }
            if(currentevent == null && once == false)
            {
               
                setadventure();
                once = true;
            }
        }
    }
    public void setadventure()
    {
        Debug.Log("set adventure");

        if (UIhub.eventtype == "Basic")
        {
            eventID = Mathf.FloorToInt(Random.Range(0f, events.Length));//TODO make this random based on map area
            currentevent = Instantiate(events[eventID]);
            currentevent.transform.parent = GameObject.Find("Eventdatabase").transform;
        }
    }
    public void createbutton(int i,string Txt)
    {
       buttonsobjs[i] = Instantiate(buttonprefab);
       buttonsobjs[i].transform.parent = buttonloc;
       buttonsobjs[i].GetComponent<RectTransform>().localScale = new Vector3(0.573622048f, 0.488438308f, 0.488438249f);
       buttonsobjs[i].GetComponentInChildren<TMP_Text>().text = Txt;
       int index = i;
       buttonsobjs[i].GetComponent<Button>().onClick.AddListener(() => buttonpressed(index));
        
    }
    public void endevent()
    {
        eventnum = 0;
        eventID = 0;
        subeventnum = 0;
        eventext.text = "";
        once = false;
        Destroy(currentevent);
        UIhub.choicesenable = false;
        if(rewardsgot == true)
        {
            rewardhub.showrewards(rewardhub.revealint);
        }
        UIhub.Adventurechoices.SetActive(false);
        UIhub.addventurestop();
        rewardsgot = false;

    }
    public void destroybuttons()
    {
        for(int i = 0; i < buttonsobjs.Length; i++)
        {
            if(buttonsobjs[i] != null)
            {
                Destroy(buttonsobjs[i]);
                buttonbool[i] = false;
            }
        }
    }
    
    public void buttonpressed(int i)
    {
        Debug.Log("Butten pressed "+i);
        buttonbool[i] = true;
    }

    public void changetext (string Txt)
    {
        eventext.text = "";
        eventext.text = Txt;
    }
}
