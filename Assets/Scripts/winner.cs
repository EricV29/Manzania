using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class winner : MonoBehaviour
{
    public GameObject malus;
    public Camera camerawin;
    public Camera cameraplayer;
    public GameObject particlehum;
    public GameObject particlefire;
    public Animator animator; //Animación nave 
    public AudioSource audioship; //Audio nave
    public score scoreS;

    //TEXTURA FALTAN MANZANAS
    public Texture2D fa1Texture; // La imagen de faltan manzanas
    private Vector2 posFa1 = new Vector2(250, 130); //Posición de la etiqueta en la pantalla
    private bool showFa1Texture = false;
    public Texture2D fa2Texture; // La imagen de faltan manzanas
    private Vector2 posFa2 = new Vector2(250, 220); //Posición de la etiqueta en la pantalla
    private bool showFa2Texture = false;

    //TEXTURA GANADOR
    public Texture2D winnTexture; // La imagen de ganar
    private Vector2 posWinn = new Vector2(250, 130); //Posición de la etiqueta en la pantalla
    private bool showWinnTexture = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioship = GetComponent<AudioSource>();
        particlehum.SetActive(false);
        particlefire.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        int numApples = scoreS.apples;
        //DESAPARECER A MALUS
        if (col.gameObject.CompareTag("Player"))
        {
            if (numApples == 10)
            {
                malus.SetActive(false);
                particlehum.SetActive(true);
                particlefire.SetActive(true);
                //CAMBIAR A LA SEGUNDA CÁMARA
                cameraplayer.enabled = false;
                camerawin.enabled = true;
                showWinnTexture = true;
                Invoke("HideText", 2f);
                Invoke("ActivateWinnerTrigger", 3.5f); // Activa la animación "winner"
            }
            else 
            {
                showFa1Texture = true;
                Invoke("HideText", 3f);
            }
        }
    }

    void ActivateWinnerTrigger()
    {
        animator.SetTrigger("winner"); // activa el trigger "winner"
        audioship.Play();
        Invoke("Menu", 5.0f);
    }

    //IR A MENU
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    void HideText()
    {
        // Ocultar la etiqueta
        showFa1Texture = false;
        showFa2Texture = false;
        showWinnTexture = false;
    }

    private void OnGUI()
    {
        //ETIQUETA FALTAN MANZANAS
        if (showFa1Texture)
        {
            GUI.DrawTexture(new Rect(posFa1.x, posFa1.y, 500, 100), fa1Texture);
            GUI.DrawTexture(new Rect(posFa2.x, posFa2.y, 500, 90), fa2Texture);
        }

        //ETIQUETA GANADOR
        if (showWinnTexture)
        {
            GUI.DrawTexture(new Rect(posWinn.x, posWinn.y, 500, 90), winnTexture);
        }
    }
}
