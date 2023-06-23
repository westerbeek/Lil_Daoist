using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class offlinecalc : MonoBehaviour
{
    private GameObject rewardedqi;

    private DateTime currentTime;
   
    private DateTime oldTime;
    public DateTime OldTime
    {
        get { return oldTime; }
        set { oldTime = value; }
    }


    [SerializeField]
    private float totalproduction;
    // Start is called before the first frame update
    void Start()
    {
        /*oldTime = DateTime.UtcNow;
        oldsecond = oldTime.Second;
        oldminute = oldTime.Minute;
        oldhour = oldTime.Hour;
        oldday = oldTime.Day;
        oldmonth = oldTime.Month;
        oldyear = oldTime.Year;
        */
        rewardedqi = GameObject.Find("Offlineproduction");
        rewardedqi.SetActive(false);
        TimeSpan difference = currentTime - oldTime;//todo 

        currentTime = DateTime.UtcNow;

        Debug.Log(currentTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.UtcNow;

        if (oldTime.Year == 0001)
        {
            oldTime = currentTime;

        }
    }
    public void acceptreward()
    {
        GameObject.Find("ScriptHub").GetComponent<Cultivation>().Giftxp(totalproduction, true);
        rewardedqi.SetActive(false);
    }
    public void checkproduction()
    {
        TimeSpan timeDifference = currentTime - oldTime;
        float passivenumbr = GameObject.Find("ScriptHub").GetComponent<Player>().passiveqi;
        Debug.Log("passive qi = "+ passivenumbr);
       // Debug.Break();
        //float diffinsecs = diff.TotalSeconds;


        float elapsedTimeInSeconds = (float)timeDifference.TotalSeconds;
        totalproduction = passivenumbr * elapsedTimeInSeconds;
        Debug.Log("time in sec" + elapsedTimeInSeconds);
        Debug.Log(("passive number :"+passivenumbr+ " times: " + elapsedTimeInSeconds+" euqals: "+(float)totalproduction));
        if(totalproduction >= 25)
        {
            rewardedqi.SetActive(true);
            string timeString = "";
            if (timeDifference.Days >= 365)
            {
                int years = timeDifference.Days / 365;
                timeString += years + " year" + (years > 1 ? "s" : "") + ", ";
                timeDifference = timeDifference.Subtract(new TimeSpan(years * 365, 0, 0, 0));
            }
            if (timeDifference.Days >= 30)
            {
                int months = timeDifference.Days / 30;
                timeString += months + " month" + (months > 1 ? "s" : "") + ", ";
                timeDifference = timeDifference.Subtract(new TimeSpan(months * 30, 0, 0, 0));
            }
            if (timeDifference.Days >= 7)
            {
                int weeks = timeDifference.Days / 7;
                timeString += weeks + " week" + (weeks > 1 ? "s" : "") + ", ";
                timeDifference = timeDifference.Subtract(new TimeSpan(weeks * 7, 0, 0, 0));
            }
            if (timeDifference.Days > 0)
            {
                timeString += timeDifference.Days + " day" + (timeDifference.Days > 1 ? "s" : "") + ", ";
            }
            if (timeDifference.Hours > 0)
            {
                timeString += timeDifference.Hours + " hour" + (timeDifference.Hours > 1 ? "s" : "") + ", ";
            }
            if (timeDifference.Minutes > 0)
            {
                timeString += timeDifference.Minutes + " minute" + (timeDifference.Minutes > 1 ? "s" : "") + ", ";
            }

            timeString += timeDifference.Seconds + " second" + (timeDifference.Seconds > 1 ? "s" : "");

            GameObject.Find("timeofflinetxt").GetComponent<TMP_Text>().text = timeString;


            GameObject.Find("amountearnedtxt").GetComponent<TMP_Text>().text = "" +totalproduction+" Qi   & "+ 0 + "  Inspiration"; //TODO INSPIRATION GAIN

        }
        else
        {
            rewardedqi.SetActive(false);

        }
    }
}
