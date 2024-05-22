using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_with_shape : MonoBehaviour
{

    public GameObject shape; //jeweilige shape
    public GameObject teleport; //da wo die shapes hinkommen

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Shape")
        {
            Debug.Log("shape entered succesfully");
            //shape.transform.position = new Vector3(0, 0, 0);
            shape.transform.position = teleport.transform.position;
            RotationCube.RotationSelectionInit(); //Funktion im anderen Skript
        }


    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        //if (mode%4 == 1)
        //{
        //    cube.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f), RotationSpeed * Time.deltaTime);

        //    Debug.Log(cube.transform.rotation);
        //    if(cube.transform.rotation == Quaternion.Euler(90, 0, 0))
        //    {
        //        cube.transform.rotation = Quaternion.Euler(90, 0, 0); //Abweichungen ausgleichen
        //        mode += 2;
        //    }
        //}

        //if (mode%4 == 3)
        //{
        //    cube.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f), RotationSpeed * Time.deltaTime);

        //    Debug.Log(cube.transform.rotation);
        //    if (cube.transform.rotation == Quaternion.Euler(90, 90, 0))
        //    {
        //        cube.transform.rotation = Quaternion.Euler(90, 90, 0); //Abweichungen ausgleichen
        //        mode += 2;
        //    }
        //}

        
       
    }
}
