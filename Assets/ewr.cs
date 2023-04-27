using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ewr : MonoBehaviour
{
    public Material Material;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<MeshRenderer>().material = Material;
        }
    }
}
