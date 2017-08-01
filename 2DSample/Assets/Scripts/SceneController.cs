using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	public const int gridRows = 2;
	public const int gridCols = 4;
	public const float offsetX = 2.0f;
	public const float offsetY = 2.5f;

	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	private int score = 0;

	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;
	[SerializeField] private TextMesh scoreLabel;

	public bool canRevealed{
		get { return _secondRevealed == null;}
	}

	public void cardRevealed(MemoryCard card){
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
//			Debug.Log ("Match?" + _firstRevealed.id == _secondRevealed.id);
			StartCoroutine(CheckMatch());
		}
	}


	// Use this for initialization
	void Start () {
//		int id = Random.Range (0, images.Length);
//		originalCard.setCard (id, images [id]);
		Vector3 startPos = originalCard.transform.position;
		int[] numbers = {0,0,1,1,2,2,3,3};
		numbers = ShuffleArray (numbers);
		for(int i = 0;i<gridCols;i++){
			for (int j = 0; j < gridRows; j++) {
				MemoryCard card;
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate<MemoryCard> (originalCard);
				}
				int id = numbers[i*gridRows+j];
				card.setCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY,startPos.z);
			}
		}
	}

	public void ReStart(){
		Application.LoadLevel ("Scene");
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	private int[] ShuffleArray(int[] nums){
		int[] newArr = nums.Clone () as int[];
		for (int i = 0; i < newArr.Length; i++) {
			int tmp = newArr [i];
			int pos = Random.Range (0, newArr.Length);
			newArr [i] = newArr [pos];
			newArr [pos] = tmp;
		}
		return newArr;
	}

	private IEnumerator CheckMatch(){
		if (_firstRevealed.id == _secondRevealed.id) {
			score++;
			scoreLabel.text = "Score: " + score;
//			Debug.Log ("Score: " + score);
		} else {
			yield return new WaitForSeconds (.5f);
			_firstRevealed.Unreveal ();
			_secondRevealed.Unreveal ();
		}
		_firstRevealed = null;
		_secondRevealed = null;
	}
}
