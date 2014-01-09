using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {


	
	float ZoomSpeed = 30.0f;//镜头缩放速率
	float MovingSpeed = 1.0f;//镜头移动速率
	float RotateSpeed = 1.0f;  //镜头旋转速率
	private var distance = 0.0f;//保存镜头和中心点的直线距离

	public static GameCamera Inst = null;
	public GameObject selectGameObj = null;
	void Awake()
	{
		Inst = this;
	}

	void Start () {
		distance = Mathf.Abs(transform.position.y/Mathf.Sin(transform.eulerAngles.x));
	}




	void Update () {
		if(!Build.Instance.bShow){
			bool press = Input.GetMouseButton(0);
			float mx = Input.GetAxis("Mouse X");
			float my = Input.GetAxis("Mouse Y");
			this.Control(press,mx,my);

			if (press&&selectGameObj==null)
			{
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit = new RaycastHit();
				if (Physics.Raycast(ray,out hit))
				{
					selectGameObj = hit.collider.gameObject;
				}
			}
		}
	}
	void LateUpdate () {
		//Follow();
	}

	void Follow(){
		this.transform.position = m_cameraPoint.position;
		this.transform.eulerAngles = m_rot;
		this.transform.Translate(0,0,m_distance);
		this.transform.LookAt(m_cameraPoint);
	}

	public void Control(bool mouse,float mx,float my)
	{
		if(!mouse)
			return;
		if(selectGameObj)
			selectGameObj.transform.Translate(mx*m_moveSpeed*Time.deltaTime,0,my*m_moveSpeed*Time.deltaTime);
		else
			this.transform.Translate(-mx*m_moveSpeed*Time.deltaTime,0, -my*m_moveSpeed*Time.deltaTime);
	}



}
