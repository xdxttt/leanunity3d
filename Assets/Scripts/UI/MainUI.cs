

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

		if(GameCamera.Inst.selectGameObj){
			bShowNavBar =false;
			GUI.BeginGroup(new Rect(Screen.width / 2 -200, Screen.height - 100, 400, 100));
			if(GUI.Button(new Rect(20,20,100,40), "upgrade"))
				GameCamera.Inst.selectGameObj = null;
			if(GUI.Button(new Rect(140,20,100,40), "move"))
				GameCamera.Inst.selectGameObj = null;
			if(GUI.Button(new Rect(260,20,100,40), "close"))
				GameCamera.Inst.selectGameObj = null;
			GUI.EndGroup();

		}else{
			bShowNavBar =true;
		}
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
