using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	[Header("GameObject References")]
	public GameObject PlayerObj;
	[Header("Settings")]
	public float yOffset;
	public float smoothSpeed;
	void FixedUpdate () {
		FollowPlayerObj();
	}
	void FollowPlayerObj(){
		float desiredPosition = PlayerObj.transform.position.y + yOffset;
		if (PlayerObj.GetComponent<Player>().isDead || PlayerObj.transform.position.y - transform.position.y > -yOffset){
			Vector3 smoothPosition = Vector3.Lerp(transform.position, new Vector3(0,desiredPosition,-10), smoothSpeed*Time.deltaTime);
			transform.position = smoothPosition;
			}
	}
}
