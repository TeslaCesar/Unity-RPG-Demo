using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonScript : MonoBehaviour
{
    public NavMeshAgent navegacion;

    public Jugador scriptJugador;
    public int VidaTotal = 100;
    public int VidaActual = 0;
    public Transform player;
    public Animator animador;
    public Transform attackPoint;
    public LayerMask enemigosLayers;

    public float rangoAtaque = 1f;
    public int danoAtaque = 10;

    public float distanciaSeguir = 17f;
    public float distanciaAtaque = 2f;
    public float distanciaDesistir = 12f;

    public float attaqueRatio = 1f;
    float tiempoSiguienteAtaque = 0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navegacion = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
        VidaActual = VidaTotal;
       
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= distanciaSeguir)
        {
            animador.SetBool("Correr", true);
            navegacion.SetDestination(player.position);
            if (distance >= distanciaDesistir)
            {
                animador.SetBool("Correr", false);
                //navegacion.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                //navegacion.ResetPath();
            }

            if (distance <= distanciaAtaque)
            {
                if (VidaActual > 0)
                {
                    animador.SetBool("Correr", false);
                    if(Time.time >= tiempoSiguienteAtaque)
                    {
                        Atacar();
                        tiempoSiguienteAtaque = Time.time + 1f / attaqueRatio;
                    }
                }
                else
                {
                    animador.SetBool("Correr", false);
                    animador.SetBool("Atacar", false);
                    animador.SetBool("sinEstado", true);
                }
            }
            else
            {
                animador.SetBool("Correr", false);
                animador.SetBool("Atacar", false);

            }
            

            if (distance > distanciaDesistir)
            {
                animador.SetBool("Atacar", false);
                navegacion.ResetPath();
                navegacion.GetComponent<NavMeshAgent>().velocity = Vector3.zero;


            }

        }


    }

    public void obtenerDano(int damage)
    {
        VidaActual = VidaActual - damage;
        animador.SetTrigger("getHit");
        if (VidaActual <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animador.SetBool("isDead", true);
        navegacion.ResetPath();
        navegacion.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
    }

    public void Atacar()
    {
        animador.SetBool("Atacar", true);
        player.GetComponent<Jugador>().obtenerDano(danoAtaque);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, rangoAtaque);
    }
}
