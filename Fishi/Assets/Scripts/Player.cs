using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	public static bool gameFinished = false;

	public float horizontalSpeed;
	public float timeToTopSpeed;
	public float verticalSpeed;
	float verticalAcceleration;
	float directionChangedTime;

	bool playing = false;
	public Transform startPos;

	public GameObject clickMenu;
	public GameObject diedMenu;
	public static float dist;

	AudioSource audioSource;
	public GameObject trail;
	public GameObject bubbles;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		trail.SetActive (false);
		bubbles.SetActive (true);
		transform.position = startPos.position;
		playing = false;
		dist = 0;
	}

	void Update ()
	{
		if(playing)
		{
			Movement ();
		}
	}

	void Movement()
	{
		dist = transform.position.x - startPos.position.x;

		if (Time.time - directionChangedTime > timeToTopSpeed) {
			verticalAcceleration = 1f;
		} else {
			verticalAcceleration =  (Time.time - directionChangedTime) / timeToTopSpeed;
		}

		if (Input.GetKey (KeyCode.Mouse0)) {
			rb.velocity = new Vector2 (horizontalSpeed, verticalAcceleration * verticalSpeed);
		} else {
			rb.velocity = new Vector2 (horizontalSpeed, verticalAcceleration * -verticalSpeed);
		}

		if (Input.GetKeyUp (KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0)) {
			directionChangedTime = Time.time;
		}
	}

	public void StartFish()
	{
		playing = true;
		trail.SetActive (true);
		bubbles.SetActive (false);
		clickMenu.SetActive (false);
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "FinishLine")
			gameFinished = true;

		StartCoroutine ("GameOver");
	}

	IEnumerator GameOver()
	{
		playing = false;
		rb.velocity = Vector2.zero;
		audioSource.Play ();
		trail.SetActive (false);
		bubbles.SetActive (true);

		yield return new WaitForSeconds (1f);
		diedMenu.SetActive (true);
	}

	public void PlayAgain()
	{
		diedMenu.SetActive (false);
		transform.position = startPos.position;
		gameFinished = false;
		clickMenu.SetActive (true);
	}
}
