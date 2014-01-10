

using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	public static MainUI Instance = null;
	public bool bShowNavBar = true;
	void Awake()
	{
		Instance = this;
	}
	void OnGUI() {
		DrawNavBar();

		GUI.Label(new Rect(120, 10, 100, 20), "User Name");
		GUI.Label(new Rect(220, 10, 100, 20), "Level 11");

		GUI.Box(new Rect(Screen.width -120, 5, 100, 30),new GUIContent(""));
		GUI.Label(new Rect(Screen.width -120, 10, 100, 20), "100/1000");

		GUI.Box(new Rect(Screen.width -120, 35, 100, 30),new GUIContent(""));
		GUI.Label(new Rect(Screen.width -120, 40, 100, 20), "100/1000");

	}

	void DrawNavBar(){
		if(GUI.Button(new Rect(20,10,100,100), "Icon")){
			
		}
		if(bShowNavBar){

			if(GUI.Button(new Rect(Screen.width-120,Screen.height - 120,100,100), "Build"))
				Build.Instance.bShow = true;
			
			if(GUI.Button(new Rect(Screen.width-240,Screen.height - 120,100,100), "Quest"))
				Quest.Instance.bShow = true;

		}
	}
}
