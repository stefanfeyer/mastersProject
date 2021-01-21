using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lookingAt : MonoBehaviour
{
    public GameObject scriptHolder;
    public string rayCastHitName;
    // Start is called before the first frame update
    void Start()
    {
        scriptHolder.GetComponent<logging>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        int layerMask = 1 << 8;
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 100.0f);
        
        
        //Debug.Log(hit.transform.gameObject.GetComponent<whoAmI>().id);
        if (hit.transform.gameObject.GetComponent<whoAmI>())
        {
            //Debug.Log(hit.transform.gameObject.GetComponent<whoAmI>().id);
            rayCastHitName = hit.transform.gameObject.GetComponent<whoAmI>().id;
        }
        
    }
}
