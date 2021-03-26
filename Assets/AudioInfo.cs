using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInfo : MonoBehaviour {
	AudioSource audioSource;
	public AudioClip info;
	public AudioClip good;
	public AudioClip bad;
	float randomfloat;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void ChooseClip (AudioClip myClip) {
		audioSource = GetComponent<AudioSource>();
		randomfloat = Random.Range(0.6f, 1.3f);
		audioSource.clip = myClip;
		audioSource.pitch = randomfloat + 0.5f;
		audioSource.volume = 1;
		audioSource.Play();
	}
}
