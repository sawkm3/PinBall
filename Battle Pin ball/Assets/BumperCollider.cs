using UnityEngine;
using System.Collections;

public class BumperCollider : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "Ball(Clone)") {
			Rigidbody rb = collider.GetComponent<Rigidbody>();

			// 三角形バンパの上面に衝突したとき，ボールに上方向の力を与える
			rb.AddForce(-transform.right * 3000);
		}
	}
}
