using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Paddle paddle;
	bool start = false;
	AudioSource tik;
	public static int life = 4;
	
	public GUISkin tekstSkin;
	

	// Use this for initialization
	void Start () {
		
		paddle = GameObject.FindObjectOfType<Paddle> ();
		tik = GetComponent<AudioSource> ();
		life++;
	}

	// Update is called once per frame
	void Update () {
		if (!start) {
			transform.position = new Vector2 (paddle.transform.position.x, paddle.transform.position.y + 0.7f);
		}
		if (Input.GetMouseButtonDown (0) && !start) {
			start = true;
			Vector2 snelheid = new Vector2 (transform.position.x, 20f);
			GetComponent<Rigidbody2D> ().velocity = snelheid;
		}
		if (Input.GetMouseButtonDown (1) && start == true) {
			life--;
			start = false;
		}
		
	}

	void OnCollisionEnter2D (Collision2D ball) {
		tik.Play ();
		if (ball.transform.name == "floor") {
			life--;
			start = false;
		}
	}

	void OnGUI()
	{
		GUI.skin = tekstSkin;
		GUI.Label(new Rect(10,10,300,100), "levens: " + life);
	}
}