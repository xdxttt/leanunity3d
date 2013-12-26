﻿using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	public static GameCamera Inst = null;
	protected float m_distance = 160;
	protected Vector3 m_rot = new Vector3(-55,180,0);
	protected float m_moveSpeed = 60;
	protected float m_vx = 0;
	protected float m_vy = 0;

	protected Transform m_transform;
	protected Transform m_cameraPoint;

	void Awake()
	{
		Inst = this;
		m_transform = this.transform;
	}


	// Use this for initialization
	void Start () {
		m_cameraPoint = CameraPoint.Instance.transform;
		Follow();
	}
	void Update () {
		bool press = Input.GetMouseButton(0);
		float mx = Input.GetAxis("Mouse X");
		float my = Input.GetAxis("Mouse Y");
		this.Control(press,mx,my);
	}
	// Update is called once per frame
	void LateUpdate () {
		Follow();
	}

	void Follow(){
		m_transform.position = m_cameraPoint.position;
		m_transform.eulerAngles = m_rot;
		m_transform.Translate(0,0,m_distance);

		this.m_transform.LookAt(m_cameraPoint);

	}

	public void Control(bool mouse,float mx,float my)
	{
		if(!mouse)
			return;

		m_cameraPoint.Translate(-mx*m_moveSpeed*Time.deltaTime,0,-my*m_moveSpeed*Time.deltaTime);
	}



}
