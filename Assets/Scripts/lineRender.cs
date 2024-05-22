using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRender : MonoBehaviour
{

    public LineRenderer line;
    public GameObject Punkt1;
    public GameObject Punkt2;
    public GameObject Punkt3;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, Punkt1.transform.position);
        line.SetPosition(1, Punkt2.transform.position);
        line.SetPosition(2, Punkt3.transform.position);
    }
}
