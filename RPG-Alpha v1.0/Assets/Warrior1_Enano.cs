using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Warrior1_Enano : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Animator animador;
    public int Velocidad = 2;
    public int VidaMaxima = 100;
    public int vidaActual;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        vidaActual = VidaMaxima;
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        animador.SetBool("Caminar", true);
        // Retorna por si no existen WayPoints
        if (points.Length == 0)
        {
            animador.SetBool("Caminar", false);
            return;
        }
        // Selecciona el agente para el destino seleccionado
        agent.destination = points[destPoint].position;

        // Escoje el siguiente punto o wapypoint si es necesario.
        destPoint = (destPoint + 1) % points.Length;
    }

    public void Die()
    {
        if(vidaActual <= 0)
        {
            animador.SetBool("isDead", true);
        }
    }

    public void obtenerDano(int damage)
    {
        vidaActual = vidaActual - damage;
        animador.SetTrigger("getHit");
        //healthBar.sizeDelta = new Vector2(maxHealth1, healthBar.sizeDelta.y);
        if (vidaActual <= 0)
        {
            Die();
        }
    }
}
