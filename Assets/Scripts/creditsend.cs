using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditsend : MonoBehaviour
{
    
    void Start()
    {
        Invoke("WaitForEnd", 30);
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    public void WaitForEnd()
    {
        SceneManager.LoadScene("Menu");
    }
}
