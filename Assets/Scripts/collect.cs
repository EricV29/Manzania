using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class collect : MonoBehaviour
{

    public enum CollectibleTypes { NoType, Type1, Type2, Type3, Type4, Type5, TypePozo }; // you can replace this with your own labels for the types of collectibles in your game!

    public CollectibleTypes CollectibleType; // Tipo de objeto de juego

    public bool rotate;

    public float rotationSpeed;

    public AudioClip collectSound;

    public GameObject collectEffect;

    void Start()
    {
    }

    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Collect();
        }
    }*/

    void OnCollisionEnter(Collision col)
    {
        //MANZANA ROJA
        if (col.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    public void Collect()
    {
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);


        if (CollectibleType == CollectibleTypes.NoType)
        {
            Debug.Log("No tiene tipo de objeto");
        }

        //TIPO 1 MANZANA ROJA 
        if (CollectibleType == CollectibleTypes.Type1)
        {
            //Destroy(gameObject, 0.4F);
        }

        //TIPO 2 MANZANA VERDE 
        if (CollectibleType == CollectibleTypes.Type2)
        {
            Destroy(gameObject, 0.4F);
        }

        //TIPO 3 MANZANA DORADA
        if (CollectibleType == CollectibleTypes.Type3)
        {
            Destroy(gameObject, 0.4F);
        }

        //TIPO 4 MANZANA MORADA
        if (CollectibleType == CollectibleTypes.Type4)
        {
            Destroy(gameObject, 0.4F);
        }

        //TIPO 5 ESPADA
        if (CollectibleType == CollectibleTypes.Type5)
        {
            Destroy(gameObject, 0.4F);
        }

        //TIPO POZO
        if (CollectibleType == CollectibleTypes.TypePozo)
        {
            Destroy(gameObject, 0.4F);
        }

        Destroy(gameObject);
    }

}
