using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaleScript : MonoBehaviour 
{
    // animate the game object from -1 to +1 and back
    public float minimum = -1.0F;
    public float maximum =  1.0F;

    // starting value for the Lerp
    static float t = 0.0f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimum, maximum, t),transform.position.z);

        t += 0.25f * Time.deltaTime;
		transform.Rotate (0.25f,0,0);

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

		if (transform.position.y > -70f && maximum > minimum)
		{
			
			//transform.Rotate (0.5f,0,0);
			//print("wololo");

		}

		if (transform.position.y <= -99)
		{
			transform.rotation = Quaternion.Euler(60f,0f,0f);
		}



		// voy a meter dos if en este punto, cuando la ballena llegue al fondo se va a 
		//poner en rotacion 90 en x y cuando llegue a -70 de altura, se empezará a rotar hasta que la altura maxima llegue a 180
    }
}