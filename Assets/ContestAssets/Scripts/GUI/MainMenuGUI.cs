using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	private Vector2 screenCenter;
	public int boxHeight = 60;
	public int boxWidth = 200;
	
	// Use this for initialization
	void Start () {
		screenCenter.x = Screen.width / 2;
		screenCenter.y = Screen.height / 2;
	}
	
	void OnGUI() {
		if(GUI.Button(new Rect(screenCenter.x - (boxWidth / 2), screenCenter.y - (boxHeight / 2), boxHeight, boxWidth), "Headlong, into the breach")) {
			Application.LoadLevel("MainHangar");
		}
	}
	
}
