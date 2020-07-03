using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollectableScript : MonoBehaviour
{
    int contador = 0;
    Jugador scriptJug;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            gameObject.SetActive(false);
            contador++;
            scriptJug.conteoFinal = contador;

        }
    }
}
