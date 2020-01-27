using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnCollision : MonoBehaviour 
{

	private AudioSource audioSource;
	public AudioClip ballCollide;
	public AudioClip wallCollide;
	private float randomfloat;

	void OnCollisionEnter(Collision collision)
	{		
		randomfloat = Random.Range(0.6f,1.3f);
		if (collision.gameObject.tag == "0" || 
		    collision.gameObject.tag == "1" ||
			collision.gameObject.tag == "2" ||
			collision.gameObject.tag == "3" || 
			collision.gameObject.tag == "4" ||
			collision.gameObject.tag == "5" ||
			collision.gameObject.tag == "6" || 
			collision.gameObject.tag == "7" ||
			collision.gameObject.tag == "8" ||
			collision.gameObject.tag == "9" || 
			collision.gameObject.tag == "10" ||
			collision.gameObject.tag == "11")
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = ballCollide;
			audioSource.pitch = randomfloat+0.5f;
			audioSource.volume = 1;
			audioSource.Play();
		}

		if(collision.gameObject.tag == "Wall")
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = wallCollide;
			audioSource.pitch = randomfloat-0.4f;
			audioSource.volume = 0.8f;
			audioSource.Play();
		}

	
	}
}
