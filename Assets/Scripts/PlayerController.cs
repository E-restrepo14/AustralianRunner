using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public static PlayerController Instance;

	/*  Esta clase guarda referencia al modelo del jugador y recibe llamados de un InputManager para mover el jugador a la izquierda o derecha.
		ecide qué pasa en las colisiones del jugador. */

	public Animator miAnimeitor ;
	public float speed = 10;
	public float translation;
	private ImputManager myImputManager;
	public GameManager myGameManager;
	public ScoreSorterScript myScoreSorterScript;
	public GameObject maleCharacter;
	public GameObject femaleCharacter;
	public GameObject personajeElejigo;
	[SerializeField] private GameObject miGameOver; 
	public GameObject particulasDeAgua;
		public GameObject particulasGoteo;

	public GameObject ropaColor;
	public bool seMojo = false;

	public int life = 100;

void Awake()
{
	Instance = this;
	myImputManager = GetComponent<ImputManager>();
	myGameManager = GetComponent<GameManager>();
	myScoreSorterScript = GetComponent<ScoreSorterScript>();

}
	
	void Start()
	{
		translation = 1 * speed;
        translation *= Time.deltaTime;

		if (maleCharacter.activeSelf == true)
		ConfirmarPersonaje(maleCharacter);
		else
		if (femaleCharacter.activeSelf == true)
		ConfirmarPersonaje(femaleCharacter);

	}	

// este subproceso lo cree aparte porque va a ser llamado externamente por medio de los botones del menu de personajes
	public void ConfirmarPersonaje(GameObject myPersonajito)
	{
		personajeElejigo = myPersonajito;
		miAnimeitor = personajeElejigo.GetComponent<Animator>();
		
	}

	public IEnumerator esperarYCorrer()
    {
		HudManager.Instance.lifebar.gameObject.GetComponent<Image>().fillAmount =100f;
		myGameManager.isRunning = false;
		speed = 10;
		translation = 1 * speed;
        translation *= Time.deltaTime; 
		miAnimeitor.Play ("dieAnimation(1)",-1,1f);
		miAnimeitor.SetBool("chocoConAlgo",false);
		miAnimeitor.SetBool("entroAlAgua",false);
		miAnimeitor.SetBool("isRunning",false);
		miAnimeitor.SetBool("lifeIsCero",false);
		miAnimeitor.SetBool("seCayo",false);
		life = 100;
		
		
		transform.position = new Vector3(transform.position.x,transform.position.y,54f);

		HudManager.Instance.OcultarGameObject(HudManager.Instance.obstaclesInfo);
        ropaColor = personajeElejigo.transform.GetChild(0).gameObject;
		miAnimeitor.SetBool("entroAlAgua",true);
		StartCoroutine(ColorearCamisa());
		yield return new WaitForSeconds(4);
		miAnimeitor.SetBool("isRunning",true);
		myGameManager.isRunning = true;
		miAnimeitor.SetBool("entroAlAgua",false);
		AudioManager.Instance.SonarRepetidamente (AudioManager.Instance.corriendo, Random.Range(0.5f, 0.2f));
    }

	void Update()
	{
// este update se encarga de hacer que el objeto padre del personaje avance automaticamente hacia adelante, entre el escenario. y tambien de hacerlo moverse de derecha a izquierda
// 
		if (myGameManager.isRunning == true)
		{
			if ((personajeElejigo.transform.position.x > 0.5f && myImputManager.direction > 0 ) || (personajeElejigo.transform.position.x < -0.5f && myImputManager.direction < 0 ))
			transform.Translate(0, 0, translation);

			else
 			{
			personajeElejigo.transform.Translate(myImputManager.direction, 0, 0);
		 	transform.Translate(0, 0, translation);
	 		particulasGoteo.transform.parent.position = personajeElejigo.transform.position;
								// si la particula de agua está activa, activa la coroutina de cambiar el color de la camisa, 
								// el booleano es para que no se repita mil veces por segundo la orden de mojarse o secarse la ropa			
				if (particulasDeAgua.activeSelf)
				{
				particulasDeAgua.transform.position = personajeElejigo.transform.position;
					
					if (seMojo == true)
					{
						seMojo = false;
						ropaColor.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black,  Time.time/4);
					}	
				}

				else
				{	
					if (seMojo == false)
					{
						seMojo = true;
						StartCoroutine(ColorearCamisa());
					}					
					
				}
			}

		//	if (Input.GetKeyDown(KeyCode.Escape))
		//	{
		//		myGameManager.Pausar();
		//	}
		}
	//	else
		if(transform.position.z >= 7699)
		{
			HudManager.Instance.ActivarGameObject(miGameOver);
			miGameOver.transform.GetChild(0).GetComponent<Text>().text = "Game Over";
		}
	//	if (Input.GetKeyDown(KeyCode.Escape))
	//		{
	//			myGameManager.Despausar();
	//		}
	}

	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("WaterTag"))
		{
		miAnimeitor.SetBool("entroAlAgua",true);
		AudioManager.Instance.Sonar (AudioManager.Instance.sumergiendose, Random.Range(0.5f, 0.2f));
		AudioManager.Instance.SonarRepetidamente (AudioManager.Instance.nadando, Random.Range(0.5f, 0.2f));
		particulasDeAgua.SetActive(true);
		translation /= 1.5f;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("WaterTag"))
		{
		miAnimeitor.SetBool("entroAlAgua",false);
		AudioManager.Instance.Sonar(AudioManager.Instance.emergiendo, Random.Range(0.5f, 0.2f));
		AudioManager.Instance.SonarRepetidamente (AudioManager.Instance.corriendo, Random.Range(0.5f, 0.2f));
		particulasDeAgua.SetActive(false);
		Gotear();
		translation *= 1.5f;

		}

	}

	public IEnumerator ColorearCamisa()
	{
		float i =0;
		while (i<1)
		{
		ropaColor.GetComponent<Renderer>().material.color = Color.Lerp(Color.black, Color.white,  i);
		i += Time.deltaTime;
		yield return new WaitForSeconds(0.25f);
		}
	}

	void Gotear()
	{
		particulasGoteo.GetComponent<ParticleSystem>().Play();
	}

	public IEnumerator PerderVida()
	{
		miAnimeitor.SetBool("chocoConAlgo",true);
		yield return new WaitForSeconds (1);
		miAnimeitor.SetBool("chocoConAlgo",false);

		if (life <= 0)
		{
			myGameManager.isRunning = false;
			miAnimeitor.SetBool("lifeIsCero",true);
			AudioManager.Instance.Sonar( AudioManager.Instance.muriendo, Random.Range(0.5f, 0.2f));
			while(translation>0)
			{
			AudioManager.Instance.audioSourceLoopeado.volume = Mathf.Lerp(0,1,translation);
			speed -= Time.deltaTime*4;
			translation = 1 * speed*Time.deltaTime;
			transform.Translate(0, 0, translation);
			yield return new WaitForSeconds(0);
			}		
			myScoreSorterScript.AgregarNombreALaTabla((transform.position.z-54)/3);
			HudManager.Instance.ActivarGameObject(miGameOver);
			miGameOver.transform.GetChild(0).GetComponent<Text>().text = "Game Over";
		}
		else
		miGameOver.transform.GetChild(0).GetComponent<Text>().text = "pause";
	}

	
	
	// este subproceso se llama desde un boton en el canvas
	public void Salir ()
	{
		Application.Quit();
	}


}
