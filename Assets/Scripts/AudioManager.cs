using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    
    public AudioClip boarRoar;
	public AudioClip atravezandoarbusto;
	public AudioClip holeaje;

    public AudioClip crocodileRoar;

	public AudioClip corriendo;

	public AudioClip nadando;

	public AudioClip sumergiendose;

	public AudioClip emergiendo;

	public AudioClip muriendo;


	public AudioSource audioSourceLoopeado;
    public AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
		SonarRepetidamente (holeaje, Random.Range(0.5f, 0.2f));
    }

  
    public void Sonar (AudioClip privateaudioclip, float vol)
    {
        audioSource.clip = privateaudioclip;
		audioSource.volume = vol* 1.5f;
		audioSource.Play();
    }

	 public void SonarRepetidamente (AudioClip privateaudioclip, float vol)
    {
        audioSourceLoopeado.clip = privateaudioclip;
		audioSourceLoopeado.volume = vol* 0.3f;
		audioSourceLoopeado.Play();
    }
}