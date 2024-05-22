using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCube : MonoBehaviour
{

    public GameObject cube; //cube
    public GameObject ZahnradVorne;
    public GameObject ZahnradHinten;
    public GameObject ZahnradRechts;
    public GameObject ZahnradLinks;
    private int links = 0;
    private int rechts = 0;

    private float time = 0f;
    private Quaternion startRotation;
    private Quaternion startRotationZahnradVorne;
    private Quaternion startRotationZahnradHinten;
    private Quaternion startRotationZahnradRechts;
    private Quaternion startRotationZahnradLinks;

    private static bool init = false;

    // Start is called before the first frame update
    void Start()
    {

        cube.transform.rotation = Quaternion.Euler(0, 0, 0);
        startRotation = cube.transform.rotation;
        startRotationZahnradVorne = ZahnradVorne.transform.rotation;
        startRotationZahnradHinten = ZahnradHinten.transform.rotation;
        startRotationZahnradLinks = ZahnradLinks.transform.rotation;
        startRotationZahnradRechts = ZahnradRechts.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {

        if (init)
        {
            init = false;
            RotationSelection();
        }


        if (links == 1)
        {
            cube.transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(90, 0, 0) * startRotation, time);
            ZahnradRechts.transform.rotation = Quaternion.Slerp(startRotationZahnradRechts, Quaternion.Euler(90, 0, 0) * startRotationZahnradRechts, time);
            ZahnradLinks.transform.rotation = Quaternion.Slerp(startRotationZahnradLinks, Quaternion.Euler(90, 0, 0) * startRotationZahnradLinks, time);
            time = time + Time.deltaTime;
            Debug.Log("hallo");
            if (time >= 3) { links = 2; } //damit es nicht durchgehend läuft
        }

        if (rechts == 1)
        {
            cube.transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, 0, 90) * startRotation, time);
            ZahnradVorne.transform.rotation = Quaternion.Slerp(startRotationZahnradVorne, Quaternion.Euler(0, 0, 90) * startRotationZahnradVorne, time);
            ZahnradHinten.transform.rotation = Quaternion.Slerp(startRotationZahnradHinten, Quaternion.Euler(0, 0, 90) * startRotationZahnradHinten, time);
            time = time + Time.deltaTime;
            Debug.Log("bye");
            if (time >= 3) { rechts = 0; }
        }

    }

    public void RotationSelection()
    {
        time = 0;
        startRotation = cube.transform.rotation;
        startRotationZahnradVorne = ZahnradVorne.transform.rotation;
        startRotationZahnradHinten = ZahnradHinten.transform.rotation;
        startRotationZahnradLinks = ZahnradLinks.transform.rotation;
        startRotationZahnradRechts = ZahnradRechts.transform.rotation;

        if (links == 0)
        {
            links = 1;
        }
        else
        {
            rechts = 1;
            links = 0;
        }
    }

    public static void RotationSelectionInit()
    {
        init = true;
    }
}
