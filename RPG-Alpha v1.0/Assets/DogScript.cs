using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogScript : MonoBehaviour
{
    public NavMeshAgent navegacion;
 
    public Jugador scriptJugador;
    public int VidaTotal = 100;
    public int VidaActual;
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
        VidaActual = VidaTotal;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navegacion = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < distanciaSeguir)
        {

            animador.SetBool("Correr", true);
            navegacion.SetDestination(player.position);
            if (distance >= distanciaDesistir)
            {
                animador.SetBool("Correr", false);
            }

            if (distance <= distanciaAtaque)
            {
                if (scriptJugador.currentHealth1 > 0)
                {
                    animador.SetBool("Correr", false);
                    if (Time.time >= tiempoSiguienteAtaque)
                    {
                        Atacar();
                        tiempoSiguienteAtaque = Time.time + 1f / attaqueRatio;
                    }
                }
                else
                {
                    animador.SetBool("Correr", false);
                    animador.SetBool("Atacar", false);
           
                }
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
        
    }

    public void Atacar()
    {
        animador.SetTrigger("Atacar");
        //Collider[] hitEnemigos = Physics.OverlapSphere(attackPoint.position, rangoAtaque, enemigosLayers);
        //foreach (MeshCollider enemy in hitEnemigos)
        //{
            
            player.GetComponent<Jugador>().obtenerDano(danoAtaque);
            //Debug.Log(" " + isDeadPlayer.ToString());
        //}
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
