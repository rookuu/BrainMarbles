﻿using UnityEngine;
using System.Collections;

/* Modified mouse pointer script for the tutorial, slightly simplified */

public class Tutorial_mousePointer : MonoBehaviour {

	public Sprite lightOff;
	public bool ready = false;

	private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = lightOff;
	}

	// Update is called once per frame
	void Update () {
		var mousePos = Input.mousePosition;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hitInfo.collider == null) {
				KillNearestMarble ();
			}
			else if (hitInfo.collider.gameObject.tag == "Marble" && GameObject.Find("Main Camera").GetComponent<PauseMenu>().paused == false && ready == true) {
				hitInfo.collider.gameObject.GetComponent<tutorialMarble> ().catchMarble ();
			}
		}
	}

	void KillNearestMarble() {
		GameObject[] marbles = GameObject.FindGameObjectsWithTag ("Marble");
		GameObject nearest = null;
		float minDistance = Mathf.Infinity;

		foreach (GameObject marble in marbles) {
			float objDist = (marble.transform.position - transform.position).sqrMagnitude;

			if (objDist < minDistance) {
				nearest = marble;
				minDistance = objDist;
			}
		}

		nearest.GetComponent<tutorialMarble> ().badCatch ();
	}

}
