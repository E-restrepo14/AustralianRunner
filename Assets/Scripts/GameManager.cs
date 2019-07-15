using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
//  esta clase tiene los estados... está corriendo, en menu.
private PlayerController myPlayerController;

public bool isRunning;
public bool isInMenu;

void Awake()
{
        myPlayerController = GetComponent<PlayerController>();
}
	public void MostrarTutorial ()
	{
		StartCoroutine ("MostrarInfo");
	}

	public IEnumerator MostrarInfo()
	{
		HudManager.Instance.ActivarGameObject(HudManager.Instance.obstaclesInfo);
		yield return new WaitForSeconds(4);
		HudManager.Instance.ActivarGameObject(HudManager.Instance.botonplay2);		
	}
	public void IniciarJuego ()
	{
		myPlayerController.StartCoroutine ("esperarYCorrer");
	}
// ojito con estos codigos que podrian no funcionar bien
	public void Despausar ()
	{
		Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
		isRunning = true;
	}

	public void Pausar ()
	{
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;	
		isRunning = false;
	}

}
