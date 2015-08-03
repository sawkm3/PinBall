using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text time;

	private int counter;

	private static readonly int seconds = 60;

	private static readonly int gameTime = 120 * seconds;
	private static readonly int ready = 4 * seconds;

	private static bool flag;

	// Use this for initialization
	void Start () {
		counter = -ready;
	}
	
	// Update is called once per frame
	void Update () {
	
		counter++;

		if (0 < counter && counter < gameTime) {
			flag = true;

			time.text = "" + ((gameTime - counter) / seconds);
			time.color = Color.white;
		} else {
			flag = false;

			if (counter <= 0) {
				time.text = "" + ((-counter) / seconds);
				time.color = Color.red;
			}
		}
	}

	public static bool IsGameTime() {
		return flag;
	}
}
