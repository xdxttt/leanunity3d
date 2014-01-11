using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

	bool bSelected = false;
	bool bShowPanel = false;
	float fPressed = 0f;
	float MovingSpeed = 1.0f; //镜头移动速率
	float npcHeight;
	public Texture2D blood_red;
	public Texture2D blood_black;

	void Start () {
		float size_y = collider.bounds.size.y;
		//得到模型缩放比例
		float scal_y = transform.localScale.y;
		//它们的乘积就是高度
		npcHeight = (size_y *scal_y) ;
	}
	
	// Update is called once per frame
	void Update () {
		if(bSelected){
			fPressed+= Time.deltaTime;
		}
		if(bSelected&&fPressed>2.0f){
			CameraCtrl.Inst.MoveAble = false;
		}
	}
	
	void OnGUI()
	{
		if(bShowPanel){
			if(GUI.Button(new Rect(Screen.width/2-120,Screen.height - 120,100,40), "Remove")){
				bShowPanel = false;
				bSelected = false;
				CameraCtrl.Inst.MoveAble = true;
				MainUI.Instance.bShowNavBar = true;

			}

			if(GUI.Button(new Rect(Screen.width/2,Screen.height - 120,100,40), "Upgrade")){
				bShowPanel = false;
				bSelected = false;
				CameraCtrl.Inst.MoveAble = true;
				MainUI.Instance.bShowNavBar = true;

			}

			if(GUI.Button(new Rect(Screen.width/2+120,Screen.height - 120,100,40), "Close")){
				bShowPanel = false;
				bSelected = false;
				CameraCtrl.Inst.MoveAble = true;
				MainUI.Instance.bShowNavBar = true;
			}
		}

		if(bSelected&&fPressed>0.5f&&fPressed<2.0f){
			Vector3 worldPosition = new Vector3 (transform.position.x , transform.position.y + npcHeight,transform.position.z);
			Vector2 position =  Camera.main.WorldToScreenPoint (worldPosition);
			position = new Vector2 (position.x, Screen.height - position.y);
			Vector2 bloodSize = GUI.skin.label.CalcSize (new GUIContent(blood_red));
			
			float blood_width = blood_red.width * fPressed/2.0f;
			GUI.DrawTexture(new Rect(position.x - (bloodSize.x/2),position.y - bloodSize.y ,bloodSize.x,bloodSize.y),blood_black);
			GUI.DrawTexture(new Rect(position.x - (bloodSize.x/2),position.y - bloodSize.y ,blood_width,bloodSize.y),blood_red);
			
			Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent(name));
			GUI.color  = Color.yellow;
			GUI.Label(new Rect(position.x - (nameSize.x/2),position.y - nameSize.y - bloodSize.y ,nameSize.x,nameSize.y), name);
		}
	}
	void OnMouseEnter()
	{

	}

	void OnMouseDown()
	{
		if(bShowPanel){

		}else{
			bSelected = true;
		}
	}
	void OnMouseDrag() {
		if(bSelected&&fPressed>2.0f){
			renderer.material.color = Color.red;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray,out hit))
			{
				transform.position = hit.point+new Vector3(0,1,0);
			}
		}
	}
	void OnMouseUp() {
		if(bSelected&&fPressed>2.0f){
			CameraCtrl.Inst.MoveAble = true;
		}else{
			bShowPanel = true;
			MainUI.Instance.bShowNavBar = false;
			CameraCtrl.Inst.MoveAble = false;
		}
		fPressed = 0;
		bSelected = false;
		renderer.material.color = Color.white;

	}
	void OnMouseExit()
	{
	
	}

}



	
