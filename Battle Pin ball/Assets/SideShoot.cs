using UnityEngine;
using System.Collections;

public class SideShoot : MonoBehaviour {

	public Transform shoot;
	Rigidbody shootrb;
	int count;

	// Use this for initialization
	void Start () {
		// -1で初期化
		count = -1;

		shootrb = shoot.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// カウンタが0のとき，球を発射（シリンダに力を与える）
		if (count-- == 0) {
			shootrb.AddForce (-transform.right * 80000);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		// ボールが左右の穴に入ったらカウンタを初期化
		if (collider.name == "Ball(Clone)") {
			count = 60;
		}
	}
}
