using UnityEngine;
using System.Collections;

public class GridMap : MonoBehaviour {

	void Start () {
	}
	void OnDrawGizmos()
	{
		if(GameCamera.Inst)
		{
			Debug.Log("OnDrawGizmos ");

			if(GameCamera.Inst.selectGameObj){
				Gizmos.color = Color.blue;
				float height = 1;
				for(int i = 0;i<200;i++){
					Gizmos.DrawLine(new Vector3(i,height,0),new Vector3(i,height,200));
				}
				for(int i = 0;i<200;i++){
					Gizmos.DrawLine(new Vector3(0,height,i),new Vector3(200,height,i));
				}
			}
		}
	}

}
