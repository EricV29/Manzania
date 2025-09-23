using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatesword : MonoBehaviour
{

    public bool rotate;

    public float rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}
