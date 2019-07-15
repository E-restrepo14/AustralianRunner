using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSorterScript : MonoBehaviour
{
    public GameObject[] distanciasArray;

	public ClasePlayerInfo myClasePlayerInfo;

	void Awake()
	{
		myClasePlayerInfo = GetComponent<ClasePlayerInfo>();
	}



void Update()
{
    if(Input.GetKeyDown(KeyCode.A))
    AgregarNombreALaTabla(Random.Range(0,100f));
    
}


    public void AgregarNombreALaTabla(float ultimaDistancia)
    {
        if (ultimaDistancia > float.Parse(distanciasArray[8].transform.GetChild(0).GetComponent<Text>().text))
		// si la puntuacion del argumento es mayor a: (la ultima del top 10 mejores puntuaciones)
		// se va a cambiar el valor del texto numero 8 del array, y la del hijo tambien...
        {
            distanciasArray[8].transform.GetChild(0).gameObject.GetComponent<Text>().text =  ultimaDistancia.ToString();
            distanciasArray[8].GetComponent<Text>().text =  myClasePlayerInfo.nametext.text;
        }


        for (int j = 0; j < distanciasArray.Length - 1; j++)
        {
            for (int i = 0; i < distanciasArray.Length - 1; i++)
            {
                if  (
                        float.Parse(distanciasArray[i].transform.GetChild(0).gameObject.GetComponent<Text>().text) 
                        < 
                        float.Parse(distanciasArray[i + 1].transform.GetChild(0).gameObject.GetComponent<Text>().text)
                    )
                {
                    float temp = float.Parse(distanciasArray[i].transform.GetChild(0).gameObject.GetComponent<Text>().text);
                    distanciasArray[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = distanciasArray[i + 1].transform.GetChild(0).gameObject.GetComponent<Text>().text;
                    distanciasArray[i + 1].transform.GetChild(0).gameObject.GetComponent<Text>().text = temp.ToString();

                    string temp2 =  distanciasArray[i].GetComponent<Text>().text;
                     distanciasArray[i].GetComponent<Text>().text = distanciasArray[i + 1].GetComponent<Text>().text;
                    distanciasArray[i + 1].GetComponent<Text>().text = temp2;
                }
            }
        }
    }
}
