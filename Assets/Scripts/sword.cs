using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public Animator animator; //Animaci�n 
    public AudioSource audioSource; //Audio espada

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("swordd"); // Activa la animaci�n "sword"
            audioSource.Play();
        }
    }
}
