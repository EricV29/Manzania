using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    public Animator animator; //Animación 
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
            animator.SetTrigger("swordd"); // Activa la animación "sword"
            audioSource.Play();
        }
    }
}
