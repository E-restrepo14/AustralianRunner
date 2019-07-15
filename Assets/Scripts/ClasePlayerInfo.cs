using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClasePlayerInfo : MonoBehaviour 
{
	// Clase contenedora de información: nombre Y Distancia recorrida 

	public Text distancetext;
	public Text nametext;
	public GameObject myMenuReguistro;
	public GameObject myMenuPersonajes;


	[HideInInspector] public string distanciaRecorrida;
	[HideInInspector] public string nombreDeUsuario;

	void Update()
	{
		PlayerPrefs.SetFloat(distanciaRecorrida, ((transform.position.z-54)/3));
		distancetext.text= ("distance: ")+ (PlayerPrefs.GetFloat(distanciaRecorrida)).ToString("f0");
	}	


	void Start()
	{
		print(PlayerPrefs.GetString(nombreDeUsuario).ToString());
	}

	public void YaIngresoNombre(Text nombrecito)
	{
		if (nombrecito.text != "" )
		{
			PlayerPrefs.SetString(nombreDeUsuario, nombrecito.text);
			nametext.text =  PlayerPrefs.GetString(nombreDeUsuario);
			myMenuReguistro.SetActive(false);
		}
	}
}
