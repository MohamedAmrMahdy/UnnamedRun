using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRequester : MonoBehaviour {
	public enum Request{obstacle,item};
	[Header("Settings")]
	public Request requestType;
	GameManager gameManager;
	SpawnableManager spawnManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		spawnManager = GameObject.Find("SpawnableManager").GetComponent<SpawnableManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			if(requestType == Request.obstacle){
				spawnManager.SpawnObstacle(this.gameObject);
				gameManager.AddStage();
			}else if(requestType == Request.item){
				spawnManager.SpawnItem(this.gameObject);
			}
		}
	}
}
