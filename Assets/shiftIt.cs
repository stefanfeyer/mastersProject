using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftIt : MonoBehaviour
{
    public float shiftX;
    public float shiftZ;
    public GameObject source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 deltaStudentTeacher = studentHip.transform.position - (teacherHip.transform.position - teacherZero.transform.position);
        //this.transform.position = new Vector3(source.transform.position.x + shiftX, source.transform.position.y, source.transform.position.z + shiftZ) - this.transform.position;
        this.transform.position = new Vector3(source.transform.position.x + shiftX, source.transform.position.y, source.transform.position.z + shiftZ);
        this.transform.rotation = source.transform.rotation;
    }
}
