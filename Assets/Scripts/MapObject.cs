using UnityEngine;
using System.Collections;

public class MapObject : MonoBehaviour {

	public Texture2D pixelTexture;
	//public Rect rt = new Rect (10, 1, 24, 24);
	public Vector2 SizeBlock = new Vector2 (24, 24);
	public Vector2 vec = new Vector2 (0, 0);
	public Vector2 offset = new Vector2 (0, 0);
	public Vector2 position = new Vector2 (0, 0);

	SpriteRenderer render;
	int count = 0;
	public int NumberTiled;
	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		Rect rectText = calculation (NumberTiled);
		if (render != null && pixelTexture != null)
			render.sprite = Sprite.Create (pixelTexture, rectText, vec, 24);
	}
	Rect calculation(int number)
	{
		int start = pixelTexture.height - (int)SizeBlock.x;
		int countRow = pixelTexture.width / (int)SizeBlock.x;
		int CountCollumn = pixelTexture.height / (int)SizeBlock.y;
		int Y = number / countRow;
		int X = number % countRow;
		int yy = start - (Y * (int)SizeBlock.y)  + count;
		Debug.Log (X * (int)SizeBlock.x + offset.x);
		Debug.Log ((Y * (int)SizeBlock.y) + offset.y);
		Rect rect = new Rect (X * (int)SizeBlock.x + offset.x ,start - (Y * (int)SizeBlock.y ) + offset.y , SizeBlock.x, SizeBlock.y);
		return rect;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			transform.position = new Vector2 (transform.position.x + 1, 0);
			count++;
			render.sprite = Sprite.Create (pixelTexture, calculation (count), vec, 24);
		}

	}
}
