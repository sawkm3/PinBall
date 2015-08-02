using UnityEngine;
using System.Collections;

// ボールが発射台の中にあったらフラグを立てて，新しい球を出せなくする
public class BallCollisionDetect : MonoBehaviour {

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
