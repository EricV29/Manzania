using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScenes : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    //Moverse a escena Frutalia
    public void EscenaFrutalia()
    {
        SceneManager.LoadScene("Frutalia");
    }

    //Moverse a escena Manzarr
    public void EscenaManzarr()
    {
        SceneManager.LoadScene("Manzarr");
    }

    //Moverse a escena Pomandar
    public void EscenaPomandar()
    {
        SceneManager.LoadScene("Pomandar");
    }

    //Moverse a escena Creditos
    public void EscenaCreditos()
    {
        SceneManager.LoadScene("Credits");
    }
}
