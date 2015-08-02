using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	void OnTriggerStay(Collider collider)
	{
		if (collider.name == "Ball(Clone)") {
			Rigidbody rb = collider.GetComponent<Rigidbody>();

			// 坂を登っている場合のみ作動
			if (0 < rb.velocity.y)
			{
				// 三角形バンパの上面に衝突したとき，ボールに上方向の力を与える
				rb.AddForce(-transform.right * 200);
			}
		}
	}
}
