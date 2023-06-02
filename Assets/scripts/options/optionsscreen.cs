using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsscreen : MonoBehaviour
{
    private GameObject optionscreenobj;
    // Start is called before the first frame update
    void Start()
    {
        optionscreenobj = GameObject.Find("OptionCanvas");
        optionscreenobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void optionscreenON()
    {
        optionscreenobj.SetActive(true);
    }
    public void optionscreenOF()
    {
        optionscreenobj.SetActive(false);
    }
}
