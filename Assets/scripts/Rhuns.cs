using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rhuns : MonoBehaviour
{
    public Transform[] buttons;
    public GameObject rhungame;
    // Start is called before the first frame update
    private void Start()
    {
        rhungame = GameObject.Find("Qigatheringstagegamehub");
    }

    // Update is called once per frame
    void Update()
    {
      buttons = this.gameObject.GetComponentsInChildren<Transform>(); 

        
        if(buttons.Length == 1)
        {
           Finish();
        }
    }
    void Finish()
    {
        rhungame.GetComponent<QiRefiningStage>().rhuncomplete(this.gameObject.name);
        Destroy(this.gameObject);
    }
    public void onpointer(GameObject name)
    {
        if (Input.GetMouseButton(0)||  Input.touchCount > 0)
        {
            Destroy(name);
        }
    }
}