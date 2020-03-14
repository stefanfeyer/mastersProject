using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTeacherIntoStudent : MonoBehaviour
{
    public GameObject studentZero;
    public GameObject studentHip;
    public GameObject teacherZero;
    public GameObject teacherHip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float stopDistance = 0.3f;
    float fullSpeedDistance = 0.15f;

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaStudentTeacher = studentHip.transform.position - (teacherHip.transform.position - teacherZero.transform.position);
        //teacherZero.transform.position = deltaStudentTeacher;
        if(deltaStudentTeacher.magnitude > stopDistance){
            teacherZero.GetComponent<Animator>().speed = 0;
        }
        else{
            teacherZero.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
        }   
    }
}
