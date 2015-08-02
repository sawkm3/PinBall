using UnityEngine;
using System.Collections;

// 使っていない
public class ValveCollision : MonoBehaviour {

	public static bool detect = false;

	void OnCollisionEnter(Collision collision)
	{
		Rigidbody colliderRigidbody = collision.collider.GetComponent<Rigidbody>();
		Rigidbody rigidbody = GetComponent<Rigidbody>();

		if (collision.collider.name == "Ball(Clone)")
		{
			if (colliderRigidbody.velocity.y < 0.0f)
			{
				rigidbody.mass = 10000f;

				detect = true;
			}
		}
	}
	
	void OnCollisionExit(Collision collision)
	{
		Rigidbody rigidbody = GetComponent<Rigidbody>();

		if (collision.collider.name == "Ball(Clone)")
		{
			rigidbody.mass = 0.1f;
			detect = false;
		}
	}
}
