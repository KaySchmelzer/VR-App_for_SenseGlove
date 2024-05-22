using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;


public class Teleport : MonoBehaviour
{
	public GameObject Player;
	public SG.SG_TrackedHand LeftHand;
	public SG.SG_TrackedHand RightHand;
	public GameObject zeigeFinger;
	[SerializeField] LineRenderer RayLine;
	public float RaycastLength = 10;



	// gameobject to transform when gesture made

	// finger presets for thumbsUp gesture
	public static float[] FingerUpThresholds = new float[5] { 0.7f, 0.1f, 0.7f, 0.7f, 0.7f };
	public static float[] RightFingerThumpsUpThresholds = new float[5] { 0.2f, 0.7f, 0.7f, 0.7f, 0.7f };
	public static float FingerPassThreshold = 0.2f;

	protected bool[] confirmGest = new bool[5];
	protected bool[] confirmGestRight = new bool[5];
	private bool checkTeleport = true;


    // Start is called before the first frame update
    void Start()
    {
		/*
        if (Physics.Raycast(transform.position, transform.forward, out hit))
		{ 
			if (hit.collider.gameObject.tag == "Tagged") 
			{ 
				Debug.DrawRay(transform.position, transform.forward, Color.green);
				print("Hit");
			} 
		}
		*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = zeigeFinger.transform.up;
        RaycastHit Hit;

		if (CheckConfirm(true, LeftHand, ref this.confirmGest))
        {
            //print("Zeigefinger links check.");
            if (Physics.Raycast(zeigeFinger.transform.position, fwd, out Hit))
			{
				RayLine.enabled = true;
				RayLine.SetPosition(0, zeigeFinger.transform.position);
                RayLine.SetPosition(1, Hit.point);
                Debug.DrawRay(zeigeFinger.transform.position, transform.forward, Color.green);
				//print("Raycast check.");
				if (Hit.collider.gameObject.tag == "Boden")
				{
					//print("Tag check.");
					if (CheckConfirmRight(true, RightHand, ref this.confirmGestRight))
					{

						//print("Daumen hoch rechts check.");
						if (checkTeleport) TeleportPlayer(Hit);
					}
					else checkTeleport = true;
                }
            }
        }
		else RayLine.enabled = false;
    }

	public static bool CheckConfirm(bool shouldCheck, SG.SG_TrackedHand hand, ref bool[] gest)
	{
		if (shouldCheck)
		{
			float[] normalizedFlexion;
			if (hand != null && hand.GetNormalizedFlexion(out normalizedFlexion))
			{
				bool allGood = true;
				//Debug.Log(SG.Util.SG_Util.ToString(normalizedFlexion));
				for (int f = 0; f < normalizedFlexion.Length && f < gest.Length && f < FingerUpThresholds.Length; f++)
				{
					if (gest[f]) //finger is currently making a gesture
					{
						if (f == 0) { gest[f] = normalizedFlexion[f] < FingerUpThresholds[f] + FingerPassThreshold; }
						else { gest[f] = normalizedFlexion[f] > FingerUpThresholds[f] - FingerPassThreshold; }
					}
					else //finger is not yet in the right spot
					{
						if (f == 0) { gest[f] = normalizedFlexion[f] < FingerUpThresholds[f]; }
						else { gest[f] = normalizedFlexion[f] > FingerUpThresholds[f]; }
					}
					if (!gest[f]) { allGood = false; }
				}
				return allGood;
			}
			return false;
		}
		return true;
	}

	public static bool CheckConfirmRight(bool shouldCheck, SG.SG_TrackedHand hand, ref bool[] gest)
	{
		if (shouldCheck)
		{
			float[] normalizedFlexion;
			if (hand != null && hand.GetNormalizedFlexion(out normalizedFlexion))
			{
				bool allGood = true;
				//Debug.Log(SG.Util.SG_Util.ToString(normalizedFlexion));
				for (int f = 0; f < normalizedFlexion.Length && f < gest.Length && f < RightFingerThumpsUpThresholds.Length; f++)
				{
					if (gest[f]) //finger is currently making a gesture
					{
						if (f == 0) { gest[f] = normalizedFlexion[f] < RightFingerThumpsUpThresholds[f] + FingerPassThreshold; }
						else { gest[f] = normalizedFlexion[f] > RightFingerThumpsUpThresholds[f] - FingerPassThreshold; }
					}
					else //finger is not yet in the right spot
					{
						if (f == 0) { gest[f] = normalizedFlexion[f] < RightFingerThumpsUpThresholds[f]; }
						else { gest[f] = normalizedFlexion[f] > RightFingerThumpsUpThresholds[f]; }
					}
					if (!gest[f]) { allGood = false; }
				}
				return allGood;
			}
			return false;
		}
		return true;
	}

	private void TeleportPlayer(RaycastHit _hit)
    {
		//print("hit-coordinates: x= " + _hit.point.x + ", y= " + _hit.point.y + ", z= " + _hit.point.z);
		//Player.transform.position.Set(_hit.point.x, 0f, _hit.point.z);
        Player.transform.position = new Vector3(_hit.point.x, 0f, _hit.point.z);
        checkTeleport = false;
	}
}
