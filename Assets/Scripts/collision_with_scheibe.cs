using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_with_scheibe : MonoBehaviour
{

    public GameObject Pfeil;
    public GameObject brokenScheibe;
    public GameObject brokenTorus;
    public GameObject Licht;
    private Rigidbody scheibe;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Scheibe")
        {

            //Pfeil stecken lassen
            //Rigidbody UwU = Pfeil.GetComponent<Rigidbody>();
            //Destroy(UwU);
            
            scheibe = other.GetComponent<Rigidbody>();
            Instantiate(brokenScheibe, other.transform.position, other.transform.rotation);
            scheibe.AddExplosionForce(10f, Vector3.zero, 0f);
            Destroy(other.gameObject);
            Debug.Log("scheibe getroffen");

        }

        if (other.gameObject.tag == "Torus")
        {

            scheibe = other.GetComponent<Rigidbody>();
            Instantiate(brokenTorus, other.transform.position, other.transform.rotation);
            scheibe.AddExplosionForce(10f, Vector3.zero, 0f);
            Destroy(other.gameObject);
            Licht.SetActive(false);
            Debug.Log("Torus getroffen");

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
        
    }
}
