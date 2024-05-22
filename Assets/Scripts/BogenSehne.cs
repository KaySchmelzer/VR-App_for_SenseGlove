using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BogenSehne : MonoBehaviour
{

    public GameObject SehnenMitte;
    public GameObject ColliderSehne;
    public GameObject ColliderBogen;
    public GameObject Sehne1;
    public GameObject Sehne2;
    public GameObject TiltRestriction;
    public GameObject Abstand;
    public GameObject Pfeil;
    public GameObject AktuellerPfeil;
    public GameObject Sehne1_default;
    public GameObject Sehne2_default;
    public GameObject Pfeil_default;
    private bool BogenSpannen = false;
    private bool SehneReset = false;
    private bool PfeilGeschossen = false;

    float DefaultDistanz = 0f;
    Vector3 SpannungsAbstandSehne1;
    Vector3 SpannungsAbstandSehne2;
    Vector3 DefaultSehne1position;
    Vector3 DefaultSehne2position;
    Vector3 DefaultPfeilposition;
    private Transform DefaultPfeilTransform;
    float VerhaeltnisAbstand; //Verhaeltnis wie weit die Sehne gespannt wurde

    // Start is called before the first frame update
    void Start()
    {
        DefaultDistanz = Vector3.Distance(ColliderBogen.transform.position, ColliderSehne.transform.position);
        DefaultSehne1position = Sehne1.transform.position;
        DefaultSehne2position = Sehne2.transform.position;
        DefaultPfeilposition = Pfeil.transform.position;
        DefaultPfeilTransform = Pfeil.transform;
        SpannungsAbstandSehne1 = new Vector3(Abstand.transform.position.x, Sehne1.transform.position.y, Abstand.transform.position.z) - Sehne1.transform.position;
        SpannungsAbstandSehne2 = new Vector3(Abstand.transform.position.x, Sehne2.transform.position.y, Abstand.transform.position.z) - Sehne2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

       

        //TiltRestriction.transform.rotation = new Quaternion(0, ColliderBogen.transform.rotation.y, 0,1);

        

        if (!BogenSpannen)
        {
            ColliderSehne.transform.position = SehnenMitte.transform.position;
            ColliderSehne.transform.rotation = SehnenMitte.transform.rotation;

            //Sehne1.transform.rotation = new Quaternion(0, 0, 0, 1);
            //Sehne2.transform.rotation = new Quaternion(0, 0, 0, 1);

            Sehne1.transform.rotation = Sehne1_default.transform.rotation;
            Sehne2.transform.rotation = Sehne2_default.transform.rotation;
            Sehne1.transform.position = Sehne1_default.transform.position;
            Sehne2.transform.position = Sehne2_default.transform.position;

        }

        else
        {
            if (DefaultDistanz - Vector3.Distance(ColliderBogen.transform.position, ColliderSehne.transform.position) < 0/*(Math.Abs(ColliderBogen.transform.position.x - SehnenMitte.transform.position.x) + Math.Abs(ColliderBogen.transform.position.z - SehnenMitte.transform.position.z) > 0*/)
            {
                // Sehne1.transform.position = new Vector3(ColliderSehne.transform.position.x, Sehne1.transform.position.y, ColliderSehne.transform.position.z);
                // Sehne2.transform.position = new Vector3(ColliderSehne.transform.position.x, Sehne2.transform.position.y, ColliderSehne.transform.position.z);
                
                //Traveln
                //Sehne1.transform.position = Vector3.MoveTowards(Sehne1.transform.position, Abstand.transform.position, 0.01f);d

                VerhaeltnisAbstand = (Vector3.Distance(ColliderBogen.transform.position, ColliderSehne.transform.position) - DefaultDistanz) / DefaultDistanz;

                SpannungsAbstandSehne1 = new Vector3(Abstand.transform.position.x, Sehne1_default.transform.position.y, Abstand.transform.position.z) - Sehne1_default.transform.position;
                SpannungsAbstandSehne2 = new Vector3(Abstand.transform.position.x, Sehne2_default.transform.position.y, Abstand.transform.position.z) - Sehne2_default.transform.position;

                if (VerhaeltnisAbstand > 1) { VerhaeltnisAbstand = 1; }

                //Sehne1.transform.position = DefaultSehne1position + SpannungsAbstandSehne1 * VerhaeltnisAbstand;
                //Sehne2.transform.position = DefaultSehne2position + SpannungsAbstandSehne2 * VerhaeltnisAbstand;

                Sehne1.transform.position = Sehne1_default.transform.position + SpannungsAbstandSehne1 * VerhaeltnisAbstand;
                Sehne2.transform.position = Sehne2_default.transform.position + SpannungsAbstandSehne1 * VerhaeltnisAbstand;

                //Pfeil.transform.position = DefaultPfeilposition + (new Vector3(SehnenMitte.transform.position.x, SehnenMitte.transform.position.y, SehnenMitte.transform.position.z) - DefaultPfeilposition) * VerhaeltnisAbstand;//wie darueber
                Pfeil.transform.position = Pfeil_default.transform.position + (new Vector3(SehnenMitte.transform.position.x, SehnenMitte.transform.position.y, SehnenMitte.transform.position.z) - Pfeil_default.transform.position) * VerhaeltnisAbstand;

                //Sehne1.transform.rotation = new Quaternion(0, 0, 0.3f*(Vector3.Distance(ColliderBogen.transform.position, ColliderSehne.transform.position)/DefaultDistanz), 1);
                //Sehne2.transform.rotation = new Quaternion(0, 0, -0.3f * (Vector3.Distance(ColliderBogen.transform.position, ColliderSehne.transform.position) / DefaultDistanz), 1);

                //Sehne1.transform.rotation = Quaternion.LookRotation(((SehnenMitte.transform.position + (Abstand.transform.position - SehnenMitte.transform.position) * VerhaeltnisAbstand) - DefaultSehne2position).normalized); 
                //Sehne2.transform.rotation = Quaternion.LookRotation(Abstand.transform.position - DefaultSehne1position, Vector3.up);

                //Sehne1.transform.rotation = Quaternion.LookRotation(((SehnenMitte.transform.position + (DefaultSehne1position - SehnenMitte.transform.position) * VerhaeltnisAbstand) - ColliderBogen.transform.position).normalized);
                //Sehne2.transform.rotation = Quaternion.LookRotation(((SehnenMitte.transform.position + (DefaultSehne2position - SehnenMitte.transform.position) * VerhaeltnisAbstand) - ColliderBogen.transform.position).normalized);

                Sehne1.transform.rotation = Quaternion.LookRotation(((SehnenMitte.transform.position + (Sehne1_default.transform.position - SehnenMitte.transform.position) * VerhaeltnisAbstand) - ColliderBogen.transform.position).normalized);
                Sehne2.transform.rotation = Quaternion.LookRotation(((SehnenMitte.transform.position + (Sehne2_default.transform.position - SehnenMitte.transform.position) * VerhaeltnisAbstand) - ColliderBogen.transform.position).normalized);
            }
        }

        if (SehneReset)
        {
            Sehne1.transform.position = new Vector3(ColliderSehne.transform.position.x, Sehne1.transform.position.y, ColliderSehne.transform.position.z);
            Sehne2.transform.position = new Vector3(ColliderSehne.transform.position.x, Sehne2.transform.position.y, ColliderSehne.transform.position.z);
            Pfeil.transform.position = ColliderBogen.transform.position;
            SehneReset = false;
        }

    }


    public void BogenSollGespanntWerden(bool x)
    {

        if (!x)
        {
            ReleasePfeil();
        }

        BogenSpannen = x;
        SehneReset = true;
        DefaultSehne1position = Sehne1.transform.position;
        DefaultSehne2position = Sehne2.transform.position;
        DefaultPfeilposition = Pfeil.transform.position;
        DefaultPfeilTransform = Pfeil.transform;
        SpannungsAbstandSehne1 = new Vector3(Abstand.transform.position.x, DefaultSehne1position.y, Abstand.transform.position.z) - DefaultSehne1position;
        SpannungsAbstandSehne2 = new Vector3(Abstand.transform.position.x, DefaultSehne2position.y, Abstand.transform.position.z) - DefaultSehne2position;

    }

    void ReleasePfeil()
    {

        float shootSpeed = 100f * VerhaeltnisAbstand;
        AktuellerPfeil = Instantiate(Pfeil, DefaultPfeilTransform.position, DefaultPfeilTransform.rotation);
        AktuellerPfeil.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f); //anpassen an groesse des pfeils im bogen
        Rigidbody PfeilRigidbody = AktuellerPfeil.AddComponent<Rigidbody>();
        PfeilRigidbody.velocity = (ColliderBogen.transform.position - SehnenMitte.transform.position) * shootSpeed; //Richtung mal Geschwindigkeit

    }

}



//Probleme beim script gehabt: statisch gedacht und statisch Vektoren berechnet(immer eine default position am anfange bestimmt als sie durchgehend zu bestimmen) anstatt sie immer jeden Frame dynamisch neu zu berechnen