using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {

	public Transform[] buildings;
	public Vector3 scrollViewPos =  Vector2.zero;
	public bool bShow = false;
	public static Build Instance = null;
	void Awake()
	{
		Instance = this;
	}
	void OnGUI() {
		if(bShow){
			MainUI.Instance.bShowNavBar = false;
			GUI.Window(0, new Rect(40,40,Screen.width-80, Screen.height-80), DrawPanelBase, "");
		}
	}
	public void DrawPanelBase(int windowID){
		if(GUI.Button(new Rect(Screen.width -100 - 80, 40, 100, 40), "Close")){
			bShow = false;
			MainUI.Instance.bShowNavBar = true;
		}
		DrawPanel(windowID);
		GUI.DragWindow (new Rect (0,0,10000,10000));
	}
	public void DrawPanel(int windowID) {

		scrollViewPos = GUI.BeginScrollView(new Rect(60, 40, Screen.width - 180, Screen.height-240 ) ,scrollViewPos, new Rect(30, 40, buildings.Length*120,Screen.height-260));
		for(int i = 0;i<buildings.Length;i++)
		{
			Rect pos = new Rect(30+i*120,60, 100, 200);
			if(GUI.Button(pos, "")){
				bShow = false;
				MainUI.Instance.bShowNavBar = true;

				Instantiate(buildings[i],CameraPoint.Instance.transform.position, Quaternion.identity);
			}
			pos = new Rect(30+i*120,60, 100, 100);
			if(GUI.Button(pos, "")){

			}
			pos.y+=160;
			GUI.Label(pos, "Building Name Here!");
		}
		GUI.EndScrollView();
	}
}
