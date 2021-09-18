using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	[SerializeField]
	private float maximoX, minimoX, maximoY, minimoY;

	private Transform target;

	void Start () {
		target = GameObject.Find("CameraTarget").GetComponent<Transform>();
	}

	void FixedUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (target.position.x, minimoX, maximoX), Mathf.Clamp (target.position.y, minimoY, maximoY), transform.position.z);
	}
}
