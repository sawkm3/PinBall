using UnityEngine;
using System.Collections;

public class MarkerManager2 : MonoBehaviour {
	
	public Transform marker;
	
	// マーカー番号（Unity側から受け取る）
	public int number;
	
	// マテリアル
	public Material onLumpMaterial;
	public Material offLumpMaterial;
	
	public Renderer renderer;
	
	// 必殺技モードのときの重力加速度
	private static readonly Vector3 myGravity = new Vector3 (0.25881f, -0.96592f, 0.0f);
	// 通常の重力加速度
	private Vector3 gravity;
	
	private static bool[] markerFlag = new bool[7];
	
	private int count;
	
	// Use this for initialization
	void Start () {
		gravity = Physics.gravity;
		count = -1;
		//renderer = marker.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		count--;
		
		// 必殺技発動中
		if (0 < count) {
			Physics.gravity = myGravity * (98.1f);
		} else if (count == 0) {
			Physics.gravity = gravity;
		}
		
		// マーカーの色を変更
		renderer.material = (markerFlag[number] ? onLumpMaterial : offLumpMaterial);
		
		// マーカーが全部ONになったら，マーカーのランプをすべてオフにし，
		// 重力加速度を一定時間変更（必殺技モード）
		// MarkerManager1は7つインスタンスがあるが，
		// 最初にUpdateに入ったMarkerManeger1が動作し，
		// markerFlagを初期化するためカウンタが動作するインスタンスは1つ
		foreach (var item in markerFlag) {
			if (!item) return;
		}
		
		// リセット
		for (int i = 0; i < markerFlag.Length; i++) {
			markerFlag[i] = false;
		}
		
		// 必殺技発動
		count = 7 * 60;
	}
	
	void OnTriggerEnter(Collider collider)
	{
		// ボールがマーカーの上を通ったら，ランプをトグルする
		if (collider.name == "Ball(Clone)") {
			markerFlag[number] = true;
		}
	}
}
