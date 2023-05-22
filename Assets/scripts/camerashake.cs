using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    // Start is called before the first frame update
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;
    public Transform camTransform2;

    // How long the object should shake for.
    public float shakeDuration = 0f;
    public bool shake;
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.02f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        
        //camTransform = GameObject.Find("Main Camera").transform;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0 || shake == true)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
           // camTransform2.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
            //camTransform2.localPosition = originalPos;
        }
    }
}
