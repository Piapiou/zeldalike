﻿using UnityEngine;
using System.Collections;

public class EnemyDrop : MonoBehaviour {

	public GameObject item;
	public float dropRate = 1.0f;
	public Transform position;

	private bool isQuitting = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy(){
		if (!isQuitting) {
			dropItem ();
		}
	}

	void dropItem(){
		float rand = Random.value;
		if (item != null) {
			if (rand <= dropRate) {
				GameObject droppedItem = GameObject.Instantiate (item);
				droppedItem.transform.position = setItemPosition ();
			}
		}
	}

	Vector3 setItemPosition(){
		Vector3 itemPosition = position.position;
		itemPosition += new Vector3 (0, -0.1f, 0);
		return itemPosition;
	}

	void OnApplicationQuit(){
		isQuitting = true;
	}

}
