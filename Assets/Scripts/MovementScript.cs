using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Neutrons", 10);
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Input.touchSupported) 
		{
			if (Input.GetKey (KeyCode.UpArrow)) {
				//this.transform.Translate(0,0,0.1f);
				rigidbody.AddForce (0, 0, 4f);
			}
		
			if (Input.GetKey (KeyCode.DownArrow)) {
				//this.transform.Translate(0,0,-0.1f);
				rigidbody.AddForce (0, 0, -4f);
			}
		
			if (Input.GetKey (KeyCode.RightArrow)) {
				//this.transform.Translate(0.1f,0,0);
				rigidbody.AddForce (4f, 0, 0);
			}
		
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//this.transform.Translate(-0.1f,0,0);
				rigidbody.AddForce (-4f, 0, 0);
			}
		} 
		else 
		{
			if (Input.acceleration.y >= 0) {
				//this.transform.Translate(0,0,0.1f);
				rigidbody.AddForce (0, 0, 4f);
			}
			
			if (Input.acceleration.y <= 0) {
				//this.transform.Translate(0,0,-0.1f);
				rigidbody.AddForce (0, 0, -4f);
			}
			
			if (Input.acceleration.x <= 0) {
				//this.transform.Translate(0.1f,0,0);
				rigidbody.AddForce (4f, 0, 0);
			}
			
			if (Input.acceleration.x >= 0) {
			//this.transform.Translate(-0.1f,0,0);
			rigidbody.AddForce (-4f, 0, 0);
			}
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Uranio238" || col.gameObject.name == "Cube") {
			Restart (this.gameObject);
		} else if (col.gameObject.name == "Uranio235") {
			Instantiate(this.gameObject);
			Instantiate(GameObject.Find ("Uranio235"));
		}

	}
	void Restart(GameObject a)
	{
		Destroy (a);
		if (PlayerPrefs.GetInt ("Neutrons") > 0) {
			Application.LoadLevel (Application.loadedLevel + 1);
			PlayerPrefs.SetInt ("Neutrons", PlayerPrefs.GetInt ("Neutrons") - 1);
		} else {
			Application.LoadLevel("Derrota");
		}
	}
}
