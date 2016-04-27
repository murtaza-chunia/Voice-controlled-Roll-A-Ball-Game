/**This script is attached to the camera of our game.
	 */ 

using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Start () {

		offset = transform.position - player.transform.position;

	}

	/** Update is called once per frame after all the objects in the game have 
	 * been modified. Position of the camera is modified according to the position
	 * of the ball after the movement.
	 */ 
	void LateUpdate () {

		transform.position = player.transform.position + offset;

	}
}
