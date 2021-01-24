using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDoIt : MonoBehaviour
{
    public GameObject parent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion localRotation = parent.transform.rotation;
        this.transform.Rotate(0,0,parent.transform.rotation.z);
        
    }
}
