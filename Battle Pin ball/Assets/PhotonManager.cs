using UnityEngine;
using System.Collections;
// http://blog.photoncloud.jp/getting-started-pun-01/
public class PhotonManager : Photon.MonoBehaviour
{
	public Camera camera1;
	public Camera camera2;
	public string hook0Name;
	public GameObject hook0;
	public string hook1Name;
	public GameObject hook1;
	public string hook2Name;
	public GameObject hook2;
	public string hook3Name;
	public GameObject hook3;

	public string launch0Name;
	public GameObject launch0;
	public string launch1Name;
	public GameObject launch1;
	
	void Start()
	{
		// Photonへの接続を行う
		PhotonNetwork.ConnectUsingSettings("0.1");
		
		// PhotonNetworkの更新回数のセット
		PhotonNetwork.sendRate = 60;
	}
	
	/// <summary>
	/// ロビーに接続すると呼ばれるメソッド
	/// </summary>
	void OnJoinedLobby()
	{
		// ランダムでルームに入室する
		PhotonNetwork.JoinRandomRoom();
	}
	
	/// <summary>
	/// ランダムで部屋に入室できなかった場合呼ばれるメソッド
	/// </summary>
	void OnPhotonRandomJoinFailed()
	{
		// ルームを作成、部屋名は今回はnullに設定
		PhotonNetwork.CreateRoom(null);
	}
	
	/// <summary>
	/// ルームに入室成功した場合呼ばれるメソッド
	/// </summary>
	void OnJoinedRoom()
	{
		int playerNum = PhotonNetwork.room.playerCount % 2;
		if (playerNum == 1) {
			PhotonNetwork.Instantiate (hook0Name, hook0.transform.position, hook0.transform.rotation, 0);
			PhotonNetwork.Instantiate (hook1Name, hook1.transform.position, hook1.transform.rotation, 0);
			PhotonNetwork.Instantiate (launch0Name, launch0.transform.position, launch0.transform.rotation, 0);

			camera1.enabled = true;
			camera2.enabled = false;
		} else {
			PhotonNetwork.Instantiate (hook2Name, hook2.transform.position, hook2.transform.rotation, 0);
			PhotonNetwork.Instantiate (hook3Name, hook3.transform.position, hook3.transform.rotation, 0);
			PhotonNetwork.Instantiate (launch1Name, launch1.transform.position, launch1.transform.rotation, 0);

			camera1.enabled = false;
			camera2.enabled = true;
		}
	}
	
	/// <summary>
	/// UnityのGameウィンドウに表示させる
	/// </summary>
	void OnGUI()
	{
		// Photonのステータスをラベルで表示させています
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
}