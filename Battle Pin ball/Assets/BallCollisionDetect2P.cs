using UnityEngine;
using System.Collections;

public class BallCollisionDetect2P : MonoBehaviour {

	public static bool detect = false;
	
	void OnTriggerStay(Collider collider)
	{
		if (collider.name == "Ball(Clone)")
			detect = true;
	}
	
	void OnTriggerExit(Collider collider)
	{
		if (collider.name == "Ball(Clone)")
			detect = false;
	}
}
