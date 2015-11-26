using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public Rigidbody rigidbody;
	public GameObject kriptonioPrefab;
	public GameObject barioPrefab;
	private bool explosion;
	private int a;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Neutrons", 10);
		rigidbody = GetComponent<Rigidbody> ();
		rigidbody.useGravity = false;
		explosion = false;
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

			if (Input.GetKey (KeyCode.Escape)) 
			{
				Application.Quit();
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
		if (col.gameObject.tag == "Uranio238" || col.gameObject.name == "Cube" && !explosion) {
			Restart (this.gameObject);
		}
		else if(col.gameObject.tag == "Uranio238" || col.gameObject.name == "Cube" && explosion){
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else if (col.gameObject.name == "Uranio235") {
			explosion = true;
			GameObject kriptonio = Instantiate(kriptonioPrefab, this.gameObject.transform.position,Quaternion.identity) as GameObject;
			GameObject bario = Instantiate(barioPrefab, this.gameObject.transform.position,Quaternion.identity) as GameObject;
			if(Application.loadedLevel >= 5)
			{
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

	}
	void Restart(GameObject a)
	{
		Destroy (a);
		Application.LoadLevel (Application.loadedLevel);
	}

}
