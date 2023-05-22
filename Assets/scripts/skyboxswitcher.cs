using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxswitcher : MonoBehaviour
{
    public Material[] skybox;
    public Material currentsky;
    public int intcurrentskybox;
    // Start is called before the first frame update
    void Start()
    {
       
        currentsky = skybox[intcurrentskybox];
        RenderSettings.skybox = currentsky;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            intcurrentskybox++;
            if (intcurrentskybox >= skybox.Length)
            {
                intcurrentskybox = 0;
            }
            changeskybox(intcurrentskybox);
        }
    }
    public void changeskybox(int i)
    {
        intcurrentskybox = i;
        currentsky = skybox[i];
        RenderSettings.skybox = currentsky;
    }
}
