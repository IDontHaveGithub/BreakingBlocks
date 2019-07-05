using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	int sprite;
	public int HP;
	public static int brickCount;
	public Sprite[] brickSprites;
	public GameObject Rookpref;
	AudioSource whoosh;
	LevelManager levelmanager;

	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
		whoosh = GetComponent<AudioSource> ();
		brickCount++;
		print (brickCount);
	}

	void Update () {
		if (Ball.life <= 0) {
			brickCount = brickCount - brickCount;
			levelmanager.LaadLevel ("Lose");
			Ball.life = 4;
		}
	}

	void OnCollisionEnter2D (Collision2D ball) {
		if (ball.transform.name == "Ball") {
			if (HP >= 2) {
				sprite = HP - 2;
			} else {
				sprite = 0;
			}
			HP--;
			GetComponent<SpriteRenderer> ().sprite = brickSprites[sprite];
			if (HP <= 0) {
				whoosh.Play ();
				brickCount--;
				print (brickCount);
                GameObject rook = Instantiate (Rookpref, new Vector2 (transform.position.x,
					transform.position.y), Quaternion.identity) as GameObject;
				Destroy (gameObject);
				
				if (brickCount <= 0) {
					levelmanager.loadNextLevel ();
					
				}
			}
		}
	}

}

/* void OnGUI()
	{
		GUI.skin = tekstSkin;
		GUI.Label(new Rect(10,10,300,100), "levens: " + life);
	}

	void death () {
		counter--;
		levelmanager.LaadLevel (6);
		life = 5;
	} */