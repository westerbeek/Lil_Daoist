using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkymantrigger : MonoBehaviour
{
    GameObject adventure;
    // Start is called before the first frame update
    void Start()
    {
        adventure = GameObject.Find("adventurepaths");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag == "path")
        {
            adventure.GetComponent<adventuring>().nextpath = true;
        }
    }
}
