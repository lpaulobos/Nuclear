using UnityEngine;
using System.Collections;

public class LevelManagment : MonoBehaviour {

	public void levelManager (string level) {
		
		Application.LoadLevel (level); 	
	}
}
