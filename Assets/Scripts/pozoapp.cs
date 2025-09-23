using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pozoapp : MonoBehaviour
{
    public GameObject appler;
    public GameObject particle;
    private bool debeActivarseAppler = false;
    void Start()
    {
        appler.SetActive(false);
    }

    void Update()
    {
        if (debeActivarseAppler && appler != null)
        {
            appler.SetActive(true);
            debeActivarseAppler = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //APARECER MANZANA
        if (col.gameObject.CompareTag("Player"))
        {
            debeActivarseAppler = true;
            particle.SetActive(false);
        }
    }
}
