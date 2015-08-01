using UnityEngine;
using System.Collections;

public class Launch : MonoBehaviour {

	int count;
	public Transform ball;
	Vector3 ballPos = new Vector3(-3.0f, 1.0f, 0.0f);
	Vector3 v = new Vector3(-3.545306f, 0.625132f, 0.0f);
	Vector3 pos;

	// Use this for initialization
	void Start () {
		count = 0;
		pos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		Rigidbody rigidbody = GetComponent<Rigidbody>();

		if (Input.GetKey(KeyCode.Space))
		{
			if (count < 40)
			{
				// ボール生成
				if (count == 0 && !BallCollisionDetect.detect) Instantiate(ball, transform.position + ballPos, transform.rotation);

				count += 2;
				rigidbody.transform.position = pos + new Vector3(count * 0.09848f, count * -0.017364f, 0.0f);
			}
		}
		else
		{
			if (count > 0)
			{
				count -= 10;

				if (count < 0) count = 0;

				rigidbody.velocity = count * v;
				rigidbody.transform.position = pos + new Vector3(count * 0.09848f, count * -0.017364f, 0.0f);
			}
			else
			{
				rigidbody.transform.position = pos;
				rigidbody.velocity = Vector3.zero;
			}
		}
		//transform.position = new Vector3(centerX + count * 0.1f, transform.position.y, transform.position.z);
	}
}
