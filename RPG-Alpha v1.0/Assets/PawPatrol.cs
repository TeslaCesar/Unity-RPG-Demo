using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PawPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Animator animador;
    public int Velocidad = 2;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

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
}
