using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo5 : MonoBehaviour
{
    public NavMeshAgent nav;
    public Animator animacion;

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
        animacion.SetBool("isDead", true);
        Destroy(this);
        GetComponent<Collider>().enabled = false;
        nav.ResetPath();
        nav.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        nav.isStopped = true;
        this.enabled = false;
    }
}

