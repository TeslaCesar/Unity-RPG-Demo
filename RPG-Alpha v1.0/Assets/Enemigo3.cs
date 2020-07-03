using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo3 : MonoBehaviour
{
    public NavMeshAgent nav;
    public Animator animacion;

    public int maxHealth3 = 100;
    public int currentHealth3;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth3 = maxHealth3;
    }

    public void obtenerDano(int damage)
    {

        currentHealth3 = currentHealth3 - damage;
        animacion.SetTrigger("getHit");
        if (currentHealth3 <= 0)
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
