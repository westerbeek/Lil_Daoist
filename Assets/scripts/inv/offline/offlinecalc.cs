using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class offlinecalc : MonoBehaviour
{
    public float passivenumbr;
    public int currentsecond;
    public int currentminute;
    public int currenthour;
    public int currentday;
    public int currentmonth;
    public int currentyear;

    public int oldsecond;
    public int oldminute;
    public int oldhour;
    public int oldday;
    public int oldmonth;
    public int oldyear;

    public DateTime currentTime;
    public DateTime oldTime;
    // Start is called before the first frame update
    void Start()
    {
        oldTime = DateTime.UtcNow;
        oldTime = DateTime.Today.AddMonths(-6);
        oldsecond = oldTime.Second;
        oldminute = oldTime.Minute;
        oldhour = oldTime.Hour;
        oldday = oldTime.Day;
        oldmonth = oldTime.Month;
        oldyear = oldTime.Year;

        TimeSpan difference = currentTime - oldTime;//todo 



    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.UtcNow;
        currentsecond = currentTime.Second;
        currentminute = currentTime.Minute;
        currenthour = currentTime.Hour;
        currentday = currentTime.Day;
        currentmonth = currentTime.Month;
        currentyear = currentTime.Year;
        if (Input.GetKeyDown(KeyCode.F))
        {
            TimeSpan diff = currentTime - oldTime;
            double diffinseconds = (currentTime - oldTime).TotalSeconds;
            //float diffinsecs = diff.TotalSeconds;
            passivenumbr = 1 * MathF.Floor((float)diffinseconds);
            Debug.Log(MathF.Floor((float)diffinseconds));
        }
    }
}
