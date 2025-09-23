using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemi : MonoBehaviour
{
    public float rangoAlerta;
    public LayerMask capaJugador;
    bool estarAlerta;
    public Transform jugador;
    public float speed;
    public int lifee = 30; //Variable para almacenar la vida del enemigo

    void Start()
    {
        
    }

    void Update()
    {
       estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);

        if(estarAlerta == true)
        {
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(jugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, speed * Time.deltaTime);
        }

        if (lifee <= 0)
        {
            Destroy(gameObject, 0.4F);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    }

    void OnCollisionEnter(Collision col)
    {
        //DANO DE ESPADA
        if (col.gameObject.CompareTag("swordatack"))
        {
            lifee -= 10; //Resta 10 de vida
        }
    }
}
