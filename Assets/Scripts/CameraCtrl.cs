using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {

	public bool MoveAble = true;
	float ZoomSpeed = 30.0f; //镜头缩放速率
	float MovingSpeed = 1.0f; //镜头移动速率
	float RotateSpeed = 1.0f; //镜头旋转速率
	private float distance = 0.0f;//保存镜头和中心点的直线距离

	public static CameraCtrl Inst = null;
	public GameObject selectGameObj = null;
	void Awake()
	{
		Inst = this;
	}

	void Start () {
		distance = Mathf.Abs(transform.position.y/Mathf.Sin(transform.eulerAngles.x));
	}

	void Update () {
		if(!MoveAble){
			return;
		}
		Quaternion rotation;
		Vector3 position;
		if(Input.GetMouseButton(0))
		{
			float delta_x = Input.GetAxis("Mouse X") * MovingSpeed;
			float delta_y = Input.GetAxis("Mouse Y") * MovingSpeed;
			rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y,0 );
			transform.position =rotation * (new Vector3(-delta_x,0,-delta_y))+transform.position;
		}
		
		if(Input.GetAxis("Mouse ScrollWheel")>0.01||Input.GetAxis("Mouse ScrollWheel")<-0.01){   
			float delta_z = -Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
			transform.Translate(0,0,-delta_z);
			distance += delta_z;
		}
		
		if (Input.GetMouseButton(1)) {
			float delta_rotation_x = Input.GetAxis("Mouse X") * RotateSpeed;
			float delta_rotation_y = -Input.GetAxis("Mouse Y") * RotateSpeed;
			position =transform.rotation* (new Vector3(0,0,distance))+transform.position;
			transform.Rotate(0,delta_rotation_x,0,Space.World);
			transform.Rotate(delta_rotation_y,0,0);
			transform.position = transform.rotation* (new Vector3(0,0,-distance))+position;

		}
	}
}
