using UnityEngine;
using System.Collections;

public class HookRight2P : MonoBehaviour {
	
	HingeJoint hinge;
	JointSpring originSpring;
	JointSpring turnedSpring;
	
	// Use this for initialization
	void Start () {
		hinge = GetComponent<HingeJoint>();
		
		// オリジナルのヒンジの情報を得る
		originSpring = hinge.spring;
		
		// 打つ最中のヒンジの情報を作成
		turnedSpring = new JointSpring ();
		turnedSpring.spring = originSpring.spring;
		turnedSpring.damper = originSpring.damper;
		turnedSpring.targetPosition = -60;
	}
	
	// Update is called once per frame
	void Update () {
		bool turn = Input.GetKey(KeyCode.RightArrow);
		
		// 右キーが押されている間，右のフリッパーのヒンジの力を逆方向にする
		if (turn) {
			hinge.spring = turnedSpring;
			// 右キーが離されている間，右のフリッパーのヒンジの力を順方向にする
		} else {
			//hinge.spring = spring;
			hinge.spring = originSpring;
		}
	}
}
