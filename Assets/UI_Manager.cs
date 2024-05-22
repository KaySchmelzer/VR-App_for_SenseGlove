using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Manager : MonoBehaviour
{
    public Transform camera_view;
    public float distance = 2;
    public GameObject menu;
    public InputActionProperty OpenMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OpenMenuButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            menu.transform.position = camera_view.position + new Vector3(camera_view.forward.x, 0, camera_view.forward.z).normalized * distance;
        }

        menu.transform.LookAt(new Vector3(camera_view.position.x, menu.transform.position.y, camera_view.position.z));
        menu.transform.forward *= -1;

    }
}
