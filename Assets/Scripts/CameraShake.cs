using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	
	[Header("Settings")]
	public float EffectDuration = 0.1f;
	public float EffectMagnitude = 1f;
	

	[Header("Testing Controlers")]
	public bool ShakeCamera = false;
	
	void Start()
	{
		ShakeCamera = false;
	}
	void Update(){
		if (ShakeCamera){
			ShakeCamera = false;
			StartCoroutine(Shake());
		}
	}

	public IEnumerator Shake(){
		Vector3 originalPosition = transform.localPosition;
		float elapsed = 0.0f;

		while(elapsed < EffectDuration){
			float x = Random.Range(-1f, 1f) * EffectMagnitude;
			float y = Random.Range(-1f, 1f) * EffectMagnitude;

			transform.localPosition = new Vector3(originalPosition.x + x,originalPosition.y + y,originalPosition.z);
			elapsed += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = originalPosition;
	}
}
