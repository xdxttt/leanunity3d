using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {
	public static Quest Instance = null;
	public bool bShow = false;

	void Awake()
	{
		Instance = this;
	}
	public void OnGUI() {
		if(bShow){
			if(GUI.Button(new Rect(Screen.width -100 - 80, 40, 100, 40), "Close")){
				bShow = false;
				MainUI.Instance.bShowNavBar = true;
			}

			GUI.BeginGroup(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 600));
			GUI.Box(new Rect(0, 0, 800, 600), "This box is now centered! - here you would put your main menu");
			GUI.EndGroup();
		}
	}
}
