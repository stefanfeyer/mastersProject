using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleToStudent : MonoBehaviour
{

    public float yTransform = 0;

    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!done & yTransform != 0){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - yTransform, this.transform.position.z);
            done = true;
            Debug.Log("done");
        }
        
        
    }
}
