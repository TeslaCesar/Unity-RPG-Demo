using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vidaPlayer : MonoBehaviour
{
   

    public NavMeshAgent nav;
    public Animator animacion;
    //public Transform player;
    
    public int maxHealth = 100;
    public int currentHealth;
 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void obtenerDano(int damage)
    {
        currentHealth = currentHealth - damage;
        animacion.SetTrigger("getHit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

        GetComponent<Collider>().enabled = false;
            GetComponent<Combate_Enemigo>().animador.SetBool("Ataca", false);
            //GetComponent<Combate_Enemigo>().animador.SetTrigger("Victoria");
            nav.isStopped = true;
            nav.enabled = false;
            this.enabled = false;
            
            //nav.ResetPath();
            //nav.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            //player.SetActive(false);
    }

   
}
