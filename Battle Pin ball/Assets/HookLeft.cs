using UnityEngine;
using System.Collections;

public class HookLeft : MonoBehaviour {

//	Rigidbody rb;
	HingeJoint hinge;
	JointSpring originSpring;
	JointSpring turnedSpring;

	private PhotonView photonView;

	// Use this for initialization
	void Start () {
//		rb = GetComponent<Rigidbody>();
		hinge = GetComponent<HingeJoint>();

		// オリジナルのヒンジの情報を得る
		originSpring = hinge.spring;

		// 打つ最中のヒンジの情報を作成
		turnedSpring = new JointSpring ();
		turnedSpring.spring = originSpring.spring;
		turnedSpring.damper = originSpring.damper;
		turnedSpring.targetPosition = 60;

		photonView = PhotonView.Get(this);
	}
	
	// Update is called once per frame
	void Update () {

		if (photonView.isMine) {

			bool turn = Input.GetKey(KeyCode.LeftArrow);

			// 左キーが押されている間，左のフリッパーのヒンジの力を逆方向にする
			if (turn) {
				//rb.AddTorque (transform.up * turn * 10000000);
				//hinge.spring = new JointSpring();
				hinge.spring = turnedSpring;
			// 左キーが離されている間，左のフリッパーのヒンジの力を順方向にする
			} else {
				//hinge.spring = spring;
				hinge.spring = originSpring;
			}
		}
	}
}
