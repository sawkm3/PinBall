using UnityEngine;
using System.Collections;

public class Launch : MonoBehaviour {

	int count;
	public string ballString;

	private PhotonView photonView;

//	Vector3 ballPos = new Vector3(-3.0f, 1.0f, 0.0f);
	Vector3 ballPos = new Vector3(-4.0f, 1.2f, 0.0f);
	Vector3 v = new Vector3(-3.545306f, 0.625132f, 0.0f);
	Vector3 pos;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		count = 0;
		pos = transform.position;

		rb = GetComponent<Rigidbody>();
		photonView = PhotonView.Get(this);
	}

	// Update is called once per frame
	void Update () {

		if (photonView.isMine) {

			// スペースキーを入力中は，発射台が下がる
			if (Input.GetKey (KeyCode.Space)) {
				if (count < 40) {
					// スペースキーを入力直後にボールを生成
					if (count == 0 && !BallCollisionDetect.detect)
						PhotonNetwork.Instantiate (ballString, transform.position + ballPos, transform.rotation, 0);

					count += 1;
					// countを進めた後の位置を計算
					// 台が10度傾いているため，少しだけY方向に移動させなければならない
					rb.transform.position = pos + new Vector3 (count * 0.09848f, count * -0.017364f, 0.0f);
				}
			} else {
				// スペースキーが離れているとき，発射台は元の位置に戻る
				if (count > 0) {
					count -= 5;

					if (count < 0)
						count = 0;

					// countを進めた後の位置と速度を計算
					// 台が10度傾いているため，少しだけY方向に移動させなければならない
					rb.velocity = count * v;
					rb.transform.position = pos + new Vector3 (count * 0.09848f, count * -0.017364f, 0.0f);
				}
				// countが0のとき何もしない
				else {
					rb.transform.position = pos;
					rb.velocity = Vector3.zero;
				}
			}
			//transform.position = new Vector3(centerX + count * 0.1f, transform.position.y, transform.position.z);
		}
	}
}
