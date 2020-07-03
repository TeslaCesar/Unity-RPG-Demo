using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo4 : MonoBehaviour
{
    public NavMeshAgent nav;
    public Animator animacion;

    public int maxHealth4 = 100;
    public int currentHealth4;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth4 = maxHealth4;
    }

    public void obtenerDano(int damage)
    {

        currentHealth4 = currentHealth4 - damage;
        animacion.SetTrigger("getHit");
        if (currentHealth4 <= 0)
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
