using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	public Texture texture = null;
	public Vector2 scrollPosition = Vector2.zero;
	public bool bShowPanel = true;
	public Rect panel = new Rect(20,20,Screen.width, Screen.height);
	void OnGUI() {
		if(bShowPanel)
			panel = GUI.Window(0, panel, DrawPanel, "");
		else
		{
			if(GUI.Button(new Rect(20, 400, 100, 100), texture))
				bShowPanel = true;
			GUI.DrawTexture(new Rect(10, 10, 100, 100), texture, ScaleMode.ScaleToFit, true, 0);
			Rect pos = new Rect(10, 120, 100, 20);
			GUI.Label(pos, "User Name Here!");
			GUI.Label(new Rect(pos.x+100, 10, 100, 20), "Level 11");
		}

		if(loading)
		{ 
			GUI.Label(new Rect(100,30,200,30),"", progressbar_bj);
			GUI.Label(new Rect(100,30,progress*200,30),"", progressbar_qj);
			GUI.Label (new Rect (150,35, 200, 30),"Loading:    "+(progress*100).ToString()+"%");
		}
	}
	void DrawPanel(int windowID) {

		scrollPosition = GUI.BeginScrollView(new Rect(10, 100, panel.width -20, 220), scrollPosition, new Rect(0, 0, 10*120,200));
		for(int i = 0;i<10;i++)
		{
			if(GUI.Button(new Rect(0+i*120, 0, 100, 100), texture)){
				bShowPanel = false;
				progress = 0.0f;
			}
		}
		GUI.EndScrollView();

		if(GUI.Button(new Rect(500, 350, 100, 40), "Build"))
			bShowPanel = false;
	}

	public GUIStyle progressbar_bj;   //背景图
	public GUIStyle progressbar_qj;   //前景图
	float progress = 0;
	bool loading = true;
	
	public Texture img;
	public float Length=0;

	void Update () 
	{
		progress+= Time.deltaTime/10;
		if(progress>1.0f){
			progress = 1.0f;
		}
	}

}
