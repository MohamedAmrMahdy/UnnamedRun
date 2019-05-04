using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
	[Header("Script References")]
	public SpawnableManager spawnManager;
	[Header("GameObject References")]
	public GameObject mainCamera;
	public GameObject GameOverPanel;
	[Header("GUI Reference")]
	public TextMeshProUGUI currentScoreText;

	public TextMeshProUGUI currentStageText;
	public TextMeshProUGUI currentFruitsText;

	public TextMeshProUGUI highestStageScoreText;

	[Header("Testing Controlers")]
	public int currentScore;
	public int currentStage;
	public int currentFruits;


	void Start () {
		currentScore = 0;
		SetScore();
		currentStage = 0;
		SetStage();
		currentFruits = PlayerPrefs.GetInt("Fruits", 0);
		SetFruits();
		highestStageScoreText.text = "Stage "+ PlayerPrefs.GetInt("Stage", 0).ToString() + " - Score " + PlayerPrefs.GetInt("Score", 0).ToString();
	}
	
	void Update () {
		if (currentStage == 5){
			spawnManager.nextSpawnMargin = 12;
			mainCamera.GetComponent<Animator>().SetTrigger("0T60");
		}else if (currentStage == 10){
			spawnManager.nextSpawnMargin = 9;
			mainCamera.GetComponent<Animator>().ResetTrigger("0T60");
			mainCamera.GetComponent<Animator>().SetTrigger("60T0");
		}else if (currentStage == 15){
			mainCamera.GetComponent<Animator>().SetTrigger("0T-60");
		}else if (currentStage == 20){
			spawnManager.nextSpawnMargin = 8;
			mainCamera.GetComponent<Animator>().ResetTrigger("0T-60");
			mainCamera.GetComponent<Animator>().SetTrigger("-60T0");
		}else if (currentStage == 25){
			mainCamera.GetComponent<Animator>().SetTrigger("0T90");
		}else if (currentStage == 30){
			spawnManager.nextSpawnMargin = 7;
			mainCamera.GetComponent<Animator>().ResetTrigger("0T90");
		}else if (currentStage == 40){
			spawnManager.nextSpawnMargin = 6;
		}else if (currentStage == 50){
			spawnManager.nextSpawnMargin = 5;
		}else if (currentStage == 60){
			spawnManager.nextSpawnMargin = 4;
		}else if (currentStage == 70){
			spawnManager.nextSpawnMargin = 3;
		}else if (currentStage == 80){
			spawnManager.nextSpawnMargin = 2;
		}else if (currentStage == 90){
			spawnManager.nextSpawnMargin = 1;
		}else if (currentStage == 100){
			spawnManager.nextSpawnMargin = 0;
		}
		
	}

	public void CallGameOver(){
		StartCoroutine(GameOver());
		
	}

	IEnumerator GameOver(){
		yield return new WaitForSeconds(0.5f);
		GameOverPanel.SetActive(true);
		yield break;
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void AddScore(){
		currentScore ++;
		SetScore();
	}

	public void AddStage(){
		currentStage ++;
		SetStage();
	}
	
	public void AddFruits(){
		currentFruits ++;
		SetFruits();
	}
	void SetStage(){
		if (PlayerPrefs.GetInt("Stage", 0) < currentStage){
			PlayerPrefs.SetInt("Stage", currentStage);
		}
		currentStageText.text = currentStage.ToString();
	}
	void SetFruits(){
		PlayerPrefs.SetInt("Fruits", currentFruits);
		currentFruitsText.text = currentFruits.ToString();
	}
	void SetScore(){
		if (PlayerPrefs.GetInt("Score", 0) < currentScore){
			PlayerPrefs.SetInt("Score", currentScore);
		}
		currentScoreText.text = currentScore.ToString();
	}
}
