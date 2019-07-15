using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour 
{
	// era muy complicado hacer que la animacion del barramundi saltara del agua asi que tocó darle ese efecto por medio de rotacion y para eso se creó este codigo
	public float speed = 4;

	void Update()
	{
		
		transform.Rotate (1*speed,0,0);

		if(gameObject.CompareTag("FishTag"))
		{
			transform.Rotate(Vector3.up, Space.World);
		}
		else 
		transform.Rotate(Vector3.up*0.1f, Space.World);	
	}
}
