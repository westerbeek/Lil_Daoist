using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateNotice : MonoBehaviour
{
    [SerializeField]
    private bool showupdate;
    private GameObject updatenoticeobj;
    // Start is called before the first frame update
    void Start()
    {
        updatenoticeobj = GameObject.Find("UpdateNotice");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clicknotice() {
        updatenoticeobj.SetActive(false);
    }
}
