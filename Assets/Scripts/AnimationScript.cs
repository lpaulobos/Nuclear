using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	public Vector3 vector;

	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAround (GameObject.Find ("Uranio235").transform.position, vector, 2);
	}
}
