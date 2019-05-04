using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableManager : MonoBehaviour {
	[Header("Settings")]
	public float nextSpawnMargin;
	public float nextSpawnCaracterMargin;
	[Header("GameObject References")]
	public Obstacle[] obstacles;
	public CollectableItem[] collectableItems;
	[Header("Testing Controlers")]
	public float lastSpawnPos;
	public float lastSpawnHeight;
	[System.Serializable]
	public class Obstacle {
		public GameObject ObstaclePrefab;
		public float obstacleHeight;
	}

	[System.Serializable]
	public class CollectableItem {
		public GameObject collectableItemPrefab;
		public float collectableItemHeight;
	}
	// Use this for initialization
	void Start () {
		nextSpawnMargin = 15; 
		lastSpawnPos = 0;
		requestObstacle(lastSpawnPos+15,3);
		requestItem(lastSpawnPos+nextSpawnMargin+nextSpawnCaracterMargin);
		requestObstacle(lastSpawnPos+nextSpawnMargin+nextSpawnCaracterMargin,3);
		requestItem(lastSpawnPos+nextSpawnMargin+nextSpawnCaracterMargin);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void requestObstacle(float yPos,int maxRand = -1){
		int randNumForPref = Random.Range(0,maxRand == -1?GetComponentInParent<SpawnableManager>().obstacles.Length : maxRand);
		GameObject newObstacle = Instantiate(
			obstacles[randNumForPref].ObstaclePrefab
			,new Vector3(0,yPos,0)
			,Quaternion.identity);
		newObstacle.transform.SetParent(GameObject.Find("SpawnableManager").transform);
		lastSpawnHeight = obstacles[randNumForPref].obstacleHeight;
		lastSpawnPos = yPos;
	}

	public void SpawnObstacle (GameObject sender){
		int randNumForPref = Random.Range(0,GetComponentInParent<SpawnableManager>().obstacles.Length);
		float spawnYPos = 
			lastSpawnPos + 
			lastSpawnHeight / 2 + 
			nextSpawnMargin +
			nextSpawnCaracterMargin +
			obstacles[randNumForPref].obstacleHeight / 2 ;
		GameObject newObstacle = Instantiate(
			obstacles[randNumForPref].ObstaclePrefab
			,new Vector3(0,spawnYPos,0)
			,Quaternion.identity);
		newObstacle.transform.SetParent(GameObject.Find("SpawnableManager").transform);
		Destroy(sender.gameObject);
		lastSpawnHeight = obstacles[randNumForPref].obstacleHeight;
		lastSpawnPos = spawnYPos;
	}
	public void requestItem(float yPos){
		int randNumForPref = Random.Range(0,GetComponentInParent<SpawnableManager>().collectableItems.Length);
		GameObject newItem = Instantiate(
			collectableItems[randNumForPref].collectableItemPrefab
			,new Vector3(0,yPos,0)
			,Quaternion.identity);
		newItem.transform.SetParent(GameObject.Find("SpawnableManager").transform);
		lastSpawnHeight = collectableItems[randNumForPref].collectableItemHeight;
		lastSpawnPos = yPos;
	}
	public void SpawnItem (GameObject sender){
		int randNumForPref = Random.Range(0,GetComponentInParent<SpawnableManager>().collectableItems.Length);
		float spawnYPos = lastSpawnPos + 
			lastSpawnHeight / 2 + 
			nextSpawnMargin +
			nextSpawnCaracterMargin +
			collectableItems[randNumForPref].collectableItemHeight / 2 ;
		GameObject newItem = Instantiate(
			collectableItems[randNumForPref].collectableItemPrefab
			,new Vector3(0,spawnYPos,0)
			,Quaternion.identity);
		newItem.transform.SetParent(GameObject.Find("SpawnableManager").transform);
		Destroy(sender.gameObject);
		lastSpawnHeight = collectableItems[randNumForPref].collectableItemHeight;
		lastSpawnPos = spawnYPos;
	}
}
