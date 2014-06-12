using UnityEngine;
using System.Collections;

public class TimedRandomAudio : MonoBehaviour {

	public AudioClip[] sound;
	public float seconds = 3;
	
	void Start(){
		InvokeRepeating("PlayClipAndChange",0.2f * Random.Range(0, 20),seconds);
	}
	
	void PlayClipAndChange(){
		audio.clip = sound[Random.Range(0, sound.Length)];
		audio.Play();
	}
}
