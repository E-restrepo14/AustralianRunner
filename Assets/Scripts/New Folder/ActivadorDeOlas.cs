using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeOlas : MonoBehaviour 
{
	public GameObject sourceDeOlas;
	public AudioClip holeajeAudio;
	public AudioClip avesAudio;

	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("MaleCharacterTag") || other.gameObject.CompareTag("FemaleCharacterTag"))
		{
			sourceDeOlas.GetComponent<AudioSource>().clip = holeajeAudio;
			sourceDeOlas.GetComponent<AudioSource>().Play();
		}		
	}

	void OnTriggerExit(Collider other)
	{
        if (other.gameObject.CompareTag("MaleCharacterTag") || other.gameObject.CompareTag("FemaleCharacterTag"))
		{
			sourceDeOlas.GetComponent<AudioSource>().clip = avesAudio;
			sourceDeOlas.GetComponent<AudioSource>().Play();

		}		
	}
}
