using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftIt : MonoBehaviour
{
    public float shiftX;
    public float shiftZ;
    public GameObject source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        this.transform.position = new Vector3(source.transform.position.x + shiftX, source.transform.position.y, source.transform.position.z + shiftZ);
        this.transform.rotation = source.transform.rotation;           
    }
}
