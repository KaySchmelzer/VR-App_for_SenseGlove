using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BogenRotationOnGrab : MonoBehaviour
{

    public GameObject BogenStamm;
    Quaternion DefaultStammRotation;
    int counter = 3000;


    // Start is called before the first frame update
    void Start()
    {
        DefaultStammRotation = BogenStamm.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        counter--;
        if(counter >= 0)
        {
            BogenStamm.transform.rotation = DefaultStammRotation;
        }
    }

    public void BogenGotGrabbed(bool x)
    {
        if (x)
        {
            BogenStamm.transform.rotation = DefaultStammRotation;
            Debug.Log("grab");
        }
        else
        {
            DefaultStammRotation = BogenStamm.transform.rotation;
            Debug.Log("no grab");
        }
    }

}
