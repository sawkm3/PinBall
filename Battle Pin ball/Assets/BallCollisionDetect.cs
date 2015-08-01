using UnityEngine;
using System.Collections;

public class BallCollisionDetect : MonoBehaviour {

	public static bool detect = false;

	void OnTriggerEnter(Collider collider)
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
