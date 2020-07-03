using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 


public class Enemigos_IA : MonoBehaviour
{

    public float attaqueRatio = 1f;
    float tiempoSiguienteAtaque = 0f;

    NavMeshAgent nav;
    Transform player;
    private Animator animacionActivador;
    //public GameObject ataqueParametro;
 

    public float distanciaSeguir = 17f;
    public float distanciaAtaque = 1.5f;
    public float distanciaDesistir = 12f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        animacionActivador = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
 
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < distanciaSeguir)
        {
            
            //bool perseguirEnemigo = true;
            animacionActivador.SetBool("Correr", true);
            nav.SetDestination(player.position);
     

            if (distance >= distanciaDesistir)
            {

                animacionActivador.SetBool("Correr", false);
                animacionActivador.SetBool("sinEstado", true);
                nav.ResetPath();
                nav.GetComponent<NavMeshAgent>().velocity = Vector3.zero;

            }

            if (distance <= distanciaAtaque)
            {
                animacionActivador.SetBool("Correr", false);
                //animacionActivador.SetBool("Atacar", true);
                //animacionActivador.SetTrigger("Atacar");

                if (Time.time >= tiempoSiguienteAtaque)
                {
                    GetComponent<Combate_Enemigo>().Atacar();
                    tiempoSiguienteAtaque = Time.time + 1f / attaqueRatio;
                }

            }

            if (distance > distanciaDesistir)
            {
                animacionActivador.SetBool("Ataca", false);
                animacionActivador.SetBool("sinEstado", true);
                nav.ResetPath();
                nav.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                

            }

        }

  
        
    }

 
}
