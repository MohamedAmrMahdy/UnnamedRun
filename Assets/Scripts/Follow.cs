using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
	[Header("GameObject References")]
	public GameObject target;
	[Header("Settings")]
	public Vector2 offset;
	public bool followX;
	public bool followY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 pos = transform.position;
		if (followX){
		pos.x = target.transform.position.x-offset.x;
		}
		if (followY){
		pos.y = target.transform.position.y-offset.y;
		}
		transform.position = pos;

	}
}
