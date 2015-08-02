using UnityEngine;
using System.Collections;

public class CircleDumperCollision : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.name == "Ball(Clone)") {
			Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
			// ダンパに衝突したとき，ボールの速度方向に力を与える
			rb.AddForce(Vector3.Normalize(rb.velocity) * 1000);

		}
	}
}
