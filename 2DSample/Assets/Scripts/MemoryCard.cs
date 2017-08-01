using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard: MonoBehaviour {

	[SerializeField] private GameObject cardBack;
	[SerializeField] private Sprite image;
	// Use this for initialization
	[SerializeField] private SceneController controller;

	private int _id;

	public int id{
		get { return _id; }
	}

	public void setCard(int id,Sprite image){
		_id = id;
		GetComponent<SpriteRenderer> ().sprite = image;
	}


	void Start () {
//		GetComponent<SpriteRenderer> ().sprite = image;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown(){
		if (cardBack.activeSelf) {
			cardBack.SetActive (false);
			controller.cardRevealed (this);
		}
//		Debug.Log ("testing");
	}

	public void Unreveal(){
		cardBack.SetActive (true);
	}
}
