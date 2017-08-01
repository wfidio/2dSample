﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour {

	[SerializeField] private GameObject targetObject;
	[SerializeField] private string targetMessage;
	public Color highLightColor = Color.cyan;

	public void OnMouseOver(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			sprite.color = highLightColor;
		}
	}

	public void OnMouseExit(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			sprite.color = Color.white;
		}
	}

	public void OnMouseDown(){
		transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
	}

	public void OnMouseUp(){
		transform.localScale = Vector3.one;
		if (targetObject != null) {
			targetObject.SendMessage (targetMessage);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
