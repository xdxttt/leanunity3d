using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	public static GameCamera Inst = null;
	protected float m_distance = 10;
	protected Vector3 m_rot = new Vector3(-55,180,0);
	protected float m_moveSpeed = 30;
	protected float m_vx = 0;
	protected float m_vy = 0;
	protected Transform m_cameraPoint;
	public GameObject selectGameObj = null;
	void Awake()
	{
		Inst = this;
	}


	// Use this for initialization
	void Start () {
		m_cameraPoint = CameraPoint.Instance.transform;
		Follow();
	}
	void Update () {
		if(!MainUI.Instance.bShowPanel){
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
					Debug.Log("Raycast "+hit.collider.gameObject.name);
					selectGameObj = hit.collider.gameObject;
				}
			}
		}
			

	}
	void LateUpdate () {
		Follow();
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
			m_cameraPoint.Translate(-mx*m_moveSpeed*Time.deltaTime,0,-my*m_moveSpeed*Time.deltaTime);
	}



}
