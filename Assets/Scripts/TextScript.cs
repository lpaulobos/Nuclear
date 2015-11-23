using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	public Text tx;

	// Use this for initialization
	void Start () {
		tx = GetComponent<Text> ();	
	}
	
	// Update is called once per frame
	void Update () {
		tx.text = "Neutrons: " + PlayerPrefs.GetInt("Neutrons").ToString();
	}
}
