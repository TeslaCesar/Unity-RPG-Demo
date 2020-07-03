using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public NavMeshAgent nav;
    public Animator animacion;

    public int maxHealth2 = 100;
    public int currentHealth2;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth2 = maxHealth2;
    }

    public void obtenerDano(int damage)
    {

        currentHealth2 = currentHealth2 - damage;
        animacion.SetTrigger("getHit");
        if (currentHealth2 <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animacion.SetBool("isDead", true);
        
        GetComponent<Collider>().enabled = false;
        nav.ResetPath();
        nav.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        nav.isStopped = true;
        this.enabled = false;
        
    }
}
