using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

public class CombateJugador : MonoBehaviour
{
    public Animator animador;
    public ThirdPersonCharacter velocidad;
    public Transform attackPoint;
    public LayerMask enemigoLayers;
    public Transform enemigo;




    public float rangoAtaque = 1f;
    public int danoAtaque = 20;

    public float attaqueRatio = 1f;
    float tiempoSiguienteAtaque = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= tiempoSiguienteAtaque)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Atacar();
                tiempoSiguienteAtaque = Time.time + 1f / attaqueRatio;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
                animador.SetBool("Run", true);
                velocidad.m_MoveSpeedMultiplier = 2.0f;
                if(Input.GetKeyDown(KeyCode.Space))
                {
                animador.SetTrigger("Salta");
                }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animador.SetBool("Run", false);
            velocidad.m_MoveSpeedMultiplier = 1f;

        }

    }

    void Start()
    {
      
    }

    void Atacar()
    {
            animador.SetTrigger("Atacar");
            enemigo.GetComponent<Enemigo>().obtenerDano(danoAtaque);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, rangoAtaque);
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }
}
