using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftIt : MonoBehaviour
{
    public float shiftX;
    public float shiftZ;
    public GameObject source;
    public bool augExo = false;
    // Start is called before the first frame update
    public GameObject teacherHipReference;
    public GameObject teacherZero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 deltaStudentTeacher = studentHip.transform.position - (teacherHip.transform.position - teacherZero.transform.position);
        //this.transform.position = new Vector3(source.transform.position.x + shiftX, source.transform.position.y, source.transform.position.z + shiftZ) - this.transform.position;
        if (augExo)
        {
            Vector3 deltaStudentTeacher = this.transform.position - (teacherHipReference.transform.position -teacherZero.transform.position);
            this.transform.position = this.transform.position + deltaStudentTeacher;
            //Vector3 deltaStudentTeacher = this.transform.position - (teacherHipReference.transform.position - teacherZero.transform.position);
            //this.transform.position = new Vector3(this.transform.position.x + deltaStudentTeacher.x, this.transform.position.y, this.transform.position.z + deltaStudentTeacher.z) - this.transform.position;
        } else
        {
        this.transform.position = new Vector3(source.transform.position.x + shiftX, source.transform.position.y, source.transform.position.z + shiftZ);
        this.transform.rotation = source.transform.rotation;    
        
        }
        
    }
}
