using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy_IA : MonoBehaviour
{
    public Jugador scriptJugador;
    public float attaqueRatio = 1f;
    float tiempoSiguienteAtaque = 0f;
    
    NavMeshAgent nav;
    Transform player;
    private Animator animacionActivador;
    public float distanciaSeguir = 17f;
    public float distanciaAtaque = 2f;
    public float distanciaDesistir = 12f;
    public int isDeadPlayer;


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
        isDeadPlayer = scriptJugador.currentHealth1;
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < distanciaSeguir)
        {
  
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
                if (isDeadPlayer > 0)
                {
                    animacionActivador.SetBool("Correr", false);
                    if (Time.time >= tiempoSiguienteAtaque)
                    {
                        GetComponent<CombateEnemigo>().Atacar();
                        tiempoSiguienteAtaque = Time.time + 1f / attaqueRatio;
                    }
                }
                else
                {
                    animacionActivador.SetBool("Correr", false);
                    animacionActivador.SetBool("Atacar",false);
                    animacionActivador.SetBool("sinEstado", true);
                }
            }

            if (distance > distanciaDesistir)
            {
                animacionActivador.SetBool("Atacar", false);
                animacionActivador.SetBool("sinEstado", true);
                nav.ResetPath();
                nav.GetComponent<NavMeshAgent>().velocity = Vector3.zero;


            }

        }



    }
}
