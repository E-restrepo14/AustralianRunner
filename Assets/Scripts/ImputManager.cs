using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputManager : MonoBehaviour 
{
//     Clase que constantemente verifica los diferentes Inputs del dispositivo y envia los llamados a las instancias pertinentes (PlayeController, UIManager, etc.) 

    public float horizontalSpeed = 100.0F;
    public float direction; 

    void Update()
    {
    	direction = Input.GetAxis("Horizontal") * horizontalSpeed;
        direction *= Time.deltaTime;

    }
}
