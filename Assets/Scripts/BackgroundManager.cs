using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {
	[Header("GameObject References")]
	public GameObject spawnableBackground;
	[Header("Settings")]
	public float backgroundHeight;
	public int maxBackgroundCount;	
	public int maxMarginHeightToDelete;	
	[Header("Extra")]
	public GameObject playerObj;
	void Update () {
		if(CountBackgrounds(this.gameObject) < maxBackgroundCount){
			SpawnBackgrounds();
		}
		if((this.transform.GetChild(0).transform.position.y+backgroundHeight - playerObj.transform.position.y+maxMarginHeightToDelete) <= maxBackgroundCount){
			Destroy(this.transform.GetChild(0).gameObject);
		}
	}
	int CountBackgrounds(GameObject b){
		int counter = 0;
		foreach(Transform background in b.transform){
			counter++;
		}
		return counter;
	}
	void SpawnBackgrounds(){
		Instantiate(spawnableBackground,new Vector3(0,this.transform.GetChild(CountBackgrounds(this.gameObject)-2).transform.position.y+backgroundHeight,0),Quaternion.identity,this.transform);
	}
}
