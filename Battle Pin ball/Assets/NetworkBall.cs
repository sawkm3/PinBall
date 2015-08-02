using UnityEngine;
using System.Collections;

[RequireComponent (typeof(PhotonView))]

// http://kan-kikuchi.hatenablog.com/entry/photonBasic
public class NetworkBall : Photon.MonoBehaviour
{
	private Vector3 correctPlayerPos = Vector3.zero;
	private Quaternion correctPlayerRot = Quaternion.identity;
	private Rigidbody rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		//自分のキャラクター以外の時はLerpを使って滑らかに位置と角度を変更
		if (!photonView.isMine) {
			rb.isKinematic = true;
			transform.position = this.correctPlayerPos;
			transform.rotation = this.correctPlayerRot;
		}
	}
	
	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		//データを送る
		if (stream.isWriting) {
			//現在地と角度を送信
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} 
		//データを受け取る
		else {
			//現在地と角度を受信
			this.correctPlayerPos = (Vector3)stream.ReceiveNext ();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext ();
		}
	}
}