using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubblenotification : MonoBehaviour
{
    public UImanager UIhub;
    public GameObject popup;
    public Image icon1;
    public Image icon2;

    public GameObject adventurepopup;
    public Image adventureicon1;
    public Image adventureicon2;

    public Sprite[] sprit;
    public string notificationtype;
    // Start is called before the first frame update
    void Start()
    {
        notificationtype = "";
        UIhub = GameObject.Find("UIhub").GetComponent<UImanager>();
        if (popup == null)
        {
            //Debug.Log("popup");
            icon2 = GameObject.Find("bubbleicon.1").GetComponent<Image>();
            icon1 = GameObject.Find("bubbleicon").GetComponent<Image>();
            popup = GameObject.Find("bubble1");

        }
    }

    void Update()
    {
        if(popup == null)
        {
            //Debug.Log("popup");
            icon2 = GameObject.Find("bubbleicon.1").GetComponent<Image>();
            icon1 = GameObject.Find("bubbleicon").GetComponent<Image>();
            popup = GameObject.Find("bubble1");

        }
        if(adventurepopup == null && UIhub.adventurecam.activeSelf == true)
        {
            adventureicon2 = GameObject.Find("adventbubbleicon.1").GetComponent<Image>();
            adventureicon1 = GameObject.Find("adventbubbleicon").GetComponent<Image>();
            adventurepopup = GameObject.Find("adventbubble1");

        }
        if (notificationtype == "")
        {
            popup.SetActive(false);
            if (adventurepopup != null)
            {
                adventurepopup.SetActive(false);
            }
        }
        else
        {
            popup.SetActive(true);
            if (adventurepopup != null)
            {
                adventurepopup.SetActive(true);
            }

        }
        if (notificationtype == "skills")
        {
            icon1.sprite = sprit[1];
            icon2.sprite = sprit[0];

            adventureicon1.sprite = sprit[1];
            adventureicon2.sprite = sprit[0];

        }
        if (notificationtype == "inv")
        {
            icon1.sprite = sprit[2];
            icon2.sprite = sprit[0];

            adventureicon1.sprite = sprit[2];
            adventureicon2.sprite = sprit[0];
        }
        if (notificationtype == "adventure")
        {
            icon1.sprite = sprit[3];
            icon2.sprite = sprit[0];

            adventureicon1.sprite = sprit[3];
            adventureicon2.sprite = sprit[0];
        }

    }

    // Update is called once per frame
    public void click()
    {
        if (notificationtype == "skills")
        {
            UIhub.playerskillzcanvas();
            notificationtype = "";

        }
        if (notificationtype == "inv")
        {
            UIhub.Playerinv();
            notificationtype = "";

        }
        if (notificationtype == "adventurecomplete")
        {
            UIhub.adventuringcanvas.SetActive(true);
            UIhub.adventurecam.SetActive(true);

            GameObject.Find("adventuremodescripts").GetComponent<adventuremode>().adventurecomplete();

            notificationtype = "";

        }


        //TODO


        adventurepopup.SetActive(false);
        popup.SetActive(false);

    }
}
