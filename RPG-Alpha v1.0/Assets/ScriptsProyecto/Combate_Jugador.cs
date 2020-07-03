using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;



public class Combate_Jugador : MonoBehaviour
{
    public Animator animador;
    public ThirdPersonCharacter velocidad;
    public Transform attackPoint;
    public LayerMask enemigoLayers;
    
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
            velocidad.m_MoveSpeedMultiplier = 2.5f;


        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animador.SetBool("Run", false);
            velocidad.m_MoveSpeedMultiplier = 1f;

        }

    }

    void Atacar()
    {
        animador.SetBool("Atacar", true);
        Collider[] hitEnemigos = Physics.OverlapSphere(attackPoint.position, rangoAtaque, enemigoLayers);
        foreach (Collider enemy in hitEnemigos)
        {
            enemy.GetComponent<vidaEnemigo>().obtenerDano(danoAtaque);
            //Debug.Log("Le diste!!!" + enemy.name);
        }
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
