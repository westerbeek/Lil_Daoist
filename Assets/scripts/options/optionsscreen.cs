using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsscreen : MonoBehaviour
{
    public GameObject saveload;
    private GameObject optionscreenobj;
    private GameObject areyousure;
    private bool deletesave;
    // Start is called before the first frame update
    void Start()
    {
        optionscreenobj = GameObject.Find("OptionCanvas");
        areyousure = GameObject.Find("confirmdenyOptions");
        saveload = GameObject.Find("saveload");
        areyousure.SetActive(false);

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

    
    public void Destroysave1()
    {
        areyousure.SetActive(true);
        GameObject.Find("ConfirmOptions").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ConfirmOptions").GetComponent<Button>().onClick.AddListener(Destroysaveconfirm);
    }
    public void Destroysaveconfirm()
    {
        GameObject.Find("ConfirmOptions").GetComponent<Button>().onClick.RemoveAllListeners();

        areyousure.SetActive(false);
        saveload.GetComponent<SaveLoadManager>().destroysave();

    }

    public void DENY()
    {
        areyousure.SetActive(false);
        GameObject.Find("ConfirmOptions").GetComponent<Button>().onClick.RemoveAllListeners();


    }
}
