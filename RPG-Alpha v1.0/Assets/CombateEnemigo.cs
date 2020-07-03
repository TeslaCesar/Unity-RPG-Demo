using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateEnemigo : MonoBehaviour
{
    public Animator animador;
    public Transform attackPoint;
    public LayerMask enemigosLayers;

    public float rangoAtaque = 1f;
    public int danoAtaque = 10;
    public Jugador jugador;


    // Update is called once per frame
    void Update()
    {

       
          
    }

    public void Atacar()
    {
        animador.SetTrigger("Atacar");
        jugador.GetComponent<Jugador>().obtenerDano(danoAtaque);

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
