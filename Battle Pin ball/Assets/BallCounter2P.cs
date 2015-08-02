using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallCounter2P : MonoBehaviour {
	
	public static int count;
	public Text score;
	
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	void OnTriggerEnter(Collider collider)
	{
		// ボールがゴールに入ったらカウントを増やす
		if (collider.name == "Ball(Clone)") {
			count++;
			
			// テキストを更新
			score.text = "2P : " + count;
		}
	}
}
