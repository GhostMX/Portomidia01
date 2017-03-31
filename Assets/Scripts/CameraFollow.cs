using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public Transform target;
	public bool back;

	float depth = -10;

	// Use this for initialization
	void Start ()
	{
		//Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target) {
			if (back) {
				transform.localPosition = new Vector3 (0, 0, 15);
			} else {
				transform.position = Vector3.Lerp (transform.position, target.position, 0.1f) + new Vector3 (0, 0, depth);
			}
		}
	}
}
