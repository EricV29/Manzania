using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trasword : MonoBehaviour
{
    public GameObject sworddO;
    void Start()
    {
        sworddO.SetActive(false);

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        //ESPADA
        if (col.gameObject.CompareTag("sword"))
        {
            sworddO.SetActive(true);
        }
    }
}
