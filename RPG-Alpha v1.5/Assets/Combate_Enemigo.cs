using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate_Enemigo : MonoBehaviour
{
    public Animator animador;
    public Transform attackPoint;
    public LayerMask enemigosLayers;

    public float rangoAtaque = 1f;
    public int danoAtaque = 10;



    // Update is called once per frame
    void Update()
    {



    }

    public void Atacar()
    {

            animador.SetTrigger("Ataca");
            Collider[] hitEnemigos = Physics.OverlapSphere(attackPoint.position, rangoAtaque, enemigosLayers);
            foreach (Collider enemy in hitEnemigos)
            {
                enemy.GetComponent<vidaPlayer>().obtenerDano(danoAtaque);
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
