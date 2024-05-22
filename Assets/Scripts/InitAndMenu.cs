using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitAndMenu : MonoBehaviour
{

    public GameObject HeadsetRig;
    public GameObject HandschuhRig;
    public GameObject HandschuhSetup;


    // Start is called before the first frame update
    void Start()
    {
        if (!ModeSelection.WhatIsMode())
        {
            HeadsetRig.SetActive(true);
            HandschuhRig.SetActive(false);
            HandschuhSetup.SetActive(false);
        }
        else
        {
            HeadsetRig.SetActive(false);
            HandschuhRig.SetActive(true);
            HandschuhSetup.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButton()
    {
        Debug.Log("test");
        ModeSelection.ChangeMode();
        SceneManager.LoadScene("SampleScene");
    }

}
