using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	
	public Texture btn = null;
	public Texture building = null;
	public Texture close = null;
	public bool bShowPanel = false;
	public Vector3 scrollViewPos =  Vector2.zero;
	public static MainUI Instance = null;
	public Transform[] buildings;
	public Transform testbuilding;

	void Awake()
	{
		Instance = this;
	}
	void OnGUI() {
		if(bShowPanel)
			DrawBuildPanel();
		else
			DrawMain();
	}
	
	void DrawMain(){
		if(GUI.Button(new Rect(20, Screen.height-20-100, 100, 100), btn))
			bShowPanel = true;
		GUI.DrawTexture(new Rect(10, 10, 100, 100), btn, ScaleMode.ScaleToFit, true, 0);
		Rect pos = new Rect(10, 120, 100, 20);
		GUI.Label(pos, "User Name Here!");
		GUI.Label(new Rect(pos.x+100, 10, 100, 20), "Level 11");

		if(GameCamera.Inst.selectGameObj){
			if(GUI.Button(new Rect(Screen.width/2,Screen.height -160,100,40), close))
				GameCamera.Inst.selectGameObj = null;
		}
	}
	void DrawBuildPanel(){
		Rect panel = new Rect(20,20,Screen.width-40, Screen.height-40);
		panel = GUI.Window(0, panel, DrawPanel, "");
	}
	void DrawPanel(int windowID) {
		if(GUI.Button(new Rect(Screen.width -160,10,100,40), close))
			bShowPanel = false;
		
		scrollViewPos = GUI.BeginScrollView(new Rect(30, 30, Screen.width -100, Screen.height-100) ,scrollViewPos, new Rect(30, 30, buildings.Length*120,200));
		for(int i = 0;i<buildings.Length;i++)
		{
			Rect pos = new Rect(30+i*120, 60, 100, 200);
			//GUI.Box(pos, "This is a title");
			if(GUI.Button(pos, "")){
				bShowPanel = false;
				Instantiate(buildings[i],CameraPoint.Instance.transform.position, Quaternion.identity);
			}
			pos = new Rect(30+i*120, 60, 100, 100);
			GUI.DrawTexture(pos,building);
			pos.y+=160;
			GUI.Label(pos, "Building Name Here!");
		}
		GUI.EndScrollView();
	}
	
}
