using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[Header("GameObject References")]
	public GameObject deadEffectObj;
	public GameObject itemEffectObj;
	public GameManager gameManager;
	[Header("Audio Settings")]
	public AudioClip cutSFX;
	public AudioClip hitSFX;

	[Header("Testing Controlers")]
	public bool isDead = false;
	Rigidbody2D rb;
	float angle = 0;
	int xSpeed = 3;
	int ySpeed = 100;
	float hueValue;
	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		hueValue = Random.Range(0,10) / 10.0f;
		SetBackgroundColor();
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (isDead) return;
		MovePlayer();
		GetInput();
		if (rb.velocity.y>1){
			GetComponent<Animator>().SetBool("Fast", true);
		}else{
			GetComponent<Animator>().SetBool("Fast", false);
		}
	}

	void MovePlayer ()
	{
		Vector2 pos = transform.position;
		pos.x = Mathf.Sin(angle)*3;
		transform.position = pos;
		angle += Time.deltaTime * xSpeed;
	}

	void GetInput(){
		rb.AddForce(new Vector2 (0,20));
		if (Input.GetMouseButton(0) && rb.velocity.y < 15){
			rb.AddForce(new Vector2 (0,ySpeed));
		}else{
			if(rb.velocity.y > 0){
				rb.AddForce(new Vector2 (0,-ySpeed));
			}else{
				rb.velocity = new Vector2(rb.velocity.x,0);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Obstacle"){
			GetComponent<AudioSource>().clip = hitSFX;
			GetComponent<AudioSource>().Play();
			other.GetComponent<Collider2D>().enabled = false;
			Dead();
		} else if (other.gameObject.tag == "Item"){
			GetItem(other);
			GetComponent<AudioSource>().clip = cutSFX;
			GetComponent<AudioSource>().Play();
		}
	}
	void GetItem(Collider2D other){
		SetBackgroundColor();
		Destroy(Instantiate(itemEffectObj,other.gameObject.transform.position,Quaternion.identity),1f);
		Destroy(other.gameObject.transform.parent.gameObject);
		gameManager.AddScore();
		gameManager.AddFruits();
	}
	public void Play(){
		isDead = false;
		rb.isKinematic = false;
		this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
	}
	void Dead(){
		isDead = true;
		StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());
		Destroy(Instantiate(deadEffectObj,transform.position,Quaternion.identity),1f);
		StopPlayer();
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameManager.CallGameOver();
	}

	void StopPlayer(){
		rb.velocity = new Vector2(0,0);
		rb.isKinematic = true;
	}

	void SetBackgroundColor(){
		Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
		hueValue +=0.1f;
		if(hueValue >= 1){
			hueValue = 0;
		}
	}
}
