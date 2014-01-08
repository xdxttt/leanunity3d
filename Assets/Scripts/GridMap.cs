using UnityEngine;
using System.Collections;

public class GridMap : MonoBehaviour {
		void OnDrawGizmos() {
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(transform.position, 1);
			Debug.Log("Hello");
		}
	}
	