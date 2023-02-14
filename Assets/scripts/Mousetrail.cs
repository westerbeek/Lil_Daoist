using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousetrail : MonoBehaviour
{
    public GameObject trail;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        trail = GameObject.Find("mousTrail");
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        trail.transform.position = camera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        if (Input.GetMouseButton(0)){
            trail.SetActive(true);
        }
        else{
            trail.SetActive(false);
        }
    }

}
