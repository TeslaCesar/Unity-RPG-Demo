using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{

    public RectTransform healthBar;

    public NavMeshAgent nav;
    public Animator animacion;
    public int conteoFinal=0;

    public int currentEstamina = 5;
    public int MaxEstamina = 5;

    public int maxHealth1 = 100;
    public int currentHealth1;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth1 = maxHealth1;
        
    }
    void Update()
    {

        
        if (conteoFinal == 3)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void obtenerDano(int damage)
    {
        currentHealth1 = currentHealth1 - damage;
        animacion.SetTrigger("getHit");
        healthBar.sizeDelta = new Vector2(maxHealth1, healthBar.sizeDelta.y);
        if (currentHealth1 <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

        animacion.SetBool("isDead", true);
        GetComponent<NavMeshAgent>().enabled = false;
        SceneManager.LoadScene(2);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gemas"))
        { 
            conteoFinal += 1;      
          
        }
    }


}
