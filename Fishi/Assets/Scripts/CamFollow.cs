using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

	Transform player;
	public float xOffset;
	public float zOffset;
	float startY;

	void Start ()
	{
		player = GameObject.FindObjectOfType<Player> ().transform;
		startY = transform.position.y;
	}
	

	void LateUpdate ()
	{
		transform.position = new Vector3 (player.position.x + xOffset, startY, zOffset);
	}
}
