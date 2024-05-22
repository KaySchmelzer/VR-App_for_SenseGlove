using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelection : MonoBehaviour
{

    public static bool HandschuhModus = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static bool WhatIsMode()
    {
        return HandschuhModus;
    }

    public static void ChangeMode()
    {
        if (!HandschuhModus)
        {
            HandschuhModus = true;
        }

        else
        {
            HandschuhModus = false;
        }
    }

}
