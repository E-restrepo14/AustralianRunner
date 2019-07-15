using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaseObstaculo : MonoBehaviour
{
public Sprite mysprite ;
public int damage ;
public bool seCayo ;

public AudioClip privatesoundcolision;

// no creo que se utilice particulas siquiera, pero la idea es que este codigo lo posea el padre de este gameobject 
// public ParticleSystem hitParticle;

void Start()
{
    // setearse... setearse es elegir un carril y una rotacion, un daño que puede ser negativo para poder sumar salud, una particula para enviar a la barra de salud
    // y tambien leer un ecosistema para saber si instanciar una planta o un pez, y por ultimo por supuesto instanciar el pez o jabali.
}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MaleCharacterTag") || other.gameObject.CompareTag("FemaleCharacterTag"))
        {
           StartCoroutine ("Animar");

        HudManager.Instance.MostrarSprite(mysprite,damage);
        
        if(damage > 0){
        other.gameObject.GetComponentInParent<PlayerController>().StartCoroutine("PerderVida");
        }        
        other.gameObject.GetComponentInParent<PlayerController>().miAnimeitor.SetBool("seCayo",seCayo);
            
        }

        AudioManager.Instance.Sonar( privatesoundcolision, Random.Range(0.5f, 0.2f));
    }

    IEnumerator Animar()
   {
        if (gameObject.CompareTag("PowerUpTag"))
       {
            if (GetComponent<Animation>())
            GetComponent<Animation>().Play("attack3");

            yield return new WaitForSeconds(3);
            GetComponent<Animation>().Play("attack2");
            
        }
        else
        
        if (gameObject.CompareTag("SerpienteTag"))
        {
            transform.Rotate (-18,0,0);
            yield return new WaitForSeconds (3);
            transform.Rotate (18,0,0);
        }

        else

        if (gameObject.CompareTag ("CocodriloTag"))
        {
            this.transform.Translate (0,0,1);
            GetComponent<Animation>().Play("biteHigh");
            yield return new WaitForSeconds(3);
            this.transform.Translate (0,0,-1); 
        }
    }
}
