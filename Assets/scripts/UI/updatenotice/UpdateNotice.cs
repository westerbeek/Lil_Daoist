using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateNotice : MonoBehaviour
{
    [SerializeField]
    private bool showupdate;
    private GameObject updatenoticeobj;
    private bool finishedbuild;
    // Start is called before the first frame update
    void Start()
    {
        updatenoticeobj = GameObject.Find("UpdateNotice");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ScriptHub").GetComponent<Cultivation>().Subrealmname == "Finished Build" && finishedbuild == false)
        {
            updatenoticeobj.SetActive(true);
            GameObject.Find("concepttxt").GetComponent<TMP_Text>().text = "Congratulations!\n\n" +
                "You have reached the end of the content, " +
                "\nyou can keep going infinitely if you'd like or try to gather as many items as you can, but currently there are no more realms or sub realms to explore.\n\n\n" +
                "Thank you for playing!";
            finishedbuild = true;

        }
    }
    public void clicknotice() {
        updatenoticeobj.SetActive(false);
    }
}
