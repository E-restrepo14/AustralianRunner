using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour 
{
	public static HudManager Instance;
	// este codigo lo poseerá la camara misma
// esta Clase tine las funciones de mostrar y modificar cualquier información en la interfaz de usuario
public RectTransform lifebar;
public RectTransform sprite;
float step ;
public Color transparenciaDeImagen = Color.white;

public GameObject foto;
public GameObject gameOverSprite;
public GameObject obstaclesInfo;
public GameObject botonplay2;

public float spritespeed;

void Awake()
{
	step = spritespeed * Time.deltaTime;
	Instance = this;
}


		public void MostrarSprite(Sprite mysprite, int damage )
		{
			sprite.gameObject.GetComponent<Image>().sprite = mysprite;
			PlayerController.Instance.life -= damage; 
				if (PlayerController.Instance.life > 100)
				{
				PlayerController.Instance.life = 100;
				}
			StartCoroutine ("EnviarSpriteALaBarraDeVida");	
		}

		public void OcultarGameObject(GameObject go)
		{
			go.SetActive(false);
		}
		public void ActivarGameObject(GameObject go)
		{
			go.SetActive(true);
		}

		public void ElegirImagen(Sprite myImagenHD)
		{
			foto.GetComponent<Image>().sprite = myImagenHD;
		}

	IEnumerator EnviarSpriteALaBarraDeVida()
    {
		
		sprite.anchoredPosition = new Vector2(0.5f, 0.5f);
        while (sprite.position != lifebar.position)
		{
			float dist = Vector3.Distance (sprite.position, lifebar.position);
			sprite.GetComponent<Image>().color  = transparenciaDeImagen;
			transparenciaDeImagen.a = Mathf.Lerp(0,1,dist/500f);
			sprite.position = Vector3.MoveTowards(sprite.position, lifebar.position, step);
		yield return new WaitForSeconds(0); 
		}
		CambiarValorLifeBar(PlayerController.Instance.life);

	}

	public void CambiarValorLifeBar(int vida)
	{
		lifebar.gameObject.GetComponent<Image>().fillAmount = (vida /100f);
	}
	
}
