using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	
	
	public static Music instance = null;
	public AudioSource audioSource;
	public static bool soundOn = true;
	
	void Awake() 
	{
		if (instance == null) {
			DontDestroyOnLoad (this.gameObject);
			instance = this;
		} else
			Destroy (this.gameObject);
		
	} 
	
	
	void Start () {
		
		audioSource = GetComponent<AudioSource> ();
		audioSource.Play ();
		
	}
	
	public static void PlayMusic()
	{
		if(instance != null) 
			instance.audioSource.Play ();
	}
	
	public static void StopMusic()
	{
		if(instance != null)
			instance.audioSource.Stop ();
	}
	
	public static void ToggleMusic()
	{
		soundOn = !soundOn;
		if (soundOn)
			PlayMusic ();
		else
			StopMusic ();
		
	}
	
	
	
}
