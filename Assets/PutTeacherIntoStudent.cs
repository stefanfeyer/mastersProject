using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTeacherIntoStudent : MonoBehaviour
{
    public GameObject studentZero;
    public GameObject studentHip;
    public GameObject teacherZero;
    public GameObject teacherHip;

    public GameObject teacher1;
    public GameObject teacher2;
    public GameObject teacher3;
    public GameObject teacher4;
    
    public bool enableSpeedMechanic = true;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    float stopDistance = 0.3f;
    float fullSpeedDistance = 0.15f;

    // Update is called once per frame
    void Update()
    {
        if (enableSpeedMechanic == false)
        {
            stopDistance = 5f;
        }
        Vector3 studentHipPositionOnFloor = new Vector3(studentHip.transform.position.x, 0, studentHip.transform.position.z);
        Vector3 teacherHipPositionOnFloor = new Vector3(teacherHip.transform.position.x, 0, teacherHip.transform.position.z);
        Vector3 teacherZeroPositionOnFloor = new Vector3(teacherZero.transform.position.x, 0, teacherZero.transform.position.z);
        // distance on the flor: 
        Vector3 deltaStudentTeacher = studentHipPositionOnFloor - (teacherHipPositionOnFloor - teacherZeroPositionOnFloor);
        // the original with hip distance: Vector3 deltaStudentTeacher = studentHip.transform.position - (teacherHip.transform.position - teacherZero.transform.position);
        //teacherZero.transform.position = deltaStudentTeacher;
        if(deltaStudentTeacher.magnitude >= stopDistance){
            teacherZero.GetComponent<Animator>().speed = 0;
            teacher1.GetComponent<Animator>().speed = 0;
            teacher2.GetComponent<Animator>().speed = 0;
            teacher3.GetComponent<Animator>().speed = 0;
            teacher4.GetComponent<Animator>().speed = 0;
        }
        else{
            teacherZero.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            teacher1.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            teacher2.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            teacher3.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            teacher4.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
        }   
    }
}
