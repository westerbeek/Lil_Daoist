using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventuring : MonoBehaviour
{
    // Start is called before the first frame update
 
    
    public GameObject[] pathsprefabs;
    public GameObject spawnlocation;
    public GameObject path;
    public GameObject[] initialspawns;
    public bool nextpath;
    public int randomnumber;
    public GameObject questionmark;
    public GameObject exclamationnmark;
    public bool active;
    public float speed;

    public GameObject choicemenu;
    public float timetillarival;
    void Start()
    {
        active = true;
        nextpath = false;
        path = GameObject.Find("pathall");
        spawnlocation = GameObject.Find("pathspawn");
        speed = 0.05f;
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        rotatepaths();
    }
    void generate()
    {
        for(int i = 0; i < initialspawns.Length; i++)
        {
           GameObject temp =  Instantiate(pathsprefabs[Random.Range(0, pathsprefabs.Length)], initialspawns[i].transform);
         
        }
    }

    void rotatepaths()
    {

        if(nextpath == true)
        {
            GameObject newpth = Instantiate(pathsprefabs[Random.Range(0, pathsprefabs.Length)], spawnlocation.transform);
            newpth.transform.parent = path.transform;
            nextpath = false;
        }
        path.transform.position = new Vector3(path.transform.position.x, path.transform.position.y, path.transform.position.z + speed);

    }
}
