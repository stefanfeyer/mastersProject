using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTeacherIntoStudent : MonoBehaviour
{
    public GameObject studentZero;
    public GameObject studentHip;
    public GameObject teacherZero;
    public GameObject teacherHip;
    public GameObject teacherZeroProps;

    public GameObject exoTeacherBody1;
    public GameObject exoTeacherBody2;
    public GameObject exoTeacherBody3;
    public GameObject exoTeacherBody4;
    public GameObject exoTeacherProps1;
    public GameObject exoTeacherProps2;
    public GameObject exoTeacherProps3;
    public GameObject exoTeacherProps4;

    public bool enableSpeedMechanic = true;
    // Start is called before the first frame update

    private GameObject[] teacherBodies;
    private GameObject[] teacherProps;

    void Start()
    {
        teacherBodies = new GameObject[]{exoTeacherBody1, exoTeacherBody2, exoTeacherBody3, exoTeacherBody4};
        teacherProps = new GameObject[]{exoTeacherProps1,exoTeacherProps2,exoTeacherProps3,exoTeacherProps4};
        foreach (var item in teacherBodies)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = 0;
            }
        }
        foreach (var item in teacherProps)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = 0;
            }
        }
    }


    float stopDistance = 0f;
    float fullSpeedDistance = 0.15f;

    // Update is called once per frame
    void Update()
    {
        if (enableSpeedMechanic == false)
        {
            stopDistance = 50f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            stopDistance = 0.3f;
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
            teacherZeroProps.GetComponent<Animator>().speed = 0;
            foreach (var item in teacherBodies)
            {
                if (item != null)
                {
                    item.GetComponent<Animator>().speed = 0;
                }
            }
            foreach (var item in teacherProps)
            {
                if (item != null)
                {
                    item.GetComponent<Animator>().speed = 0;
                }
            }
            //if(exoTeacherBody1!=null){exoTeacherBody1.GetComponent<Animator>().speed = 0;}
            //if(exoTeacherBody2!=null){exoTeacherBody2.GetComponent<Animator>().speed = 0;}
            //if(exoTeacherBody3!=null){exoTeacherBody3.GetComponent<Animator>().speed = 0;}
            //if(exoTeacherBody4!=null){exoTeacherBody4.GetComponent<Animator>().speed = 0;}
            //if(exoTeacherProps1!=null){exoTeacherBody1.GetComponent<Animator>().speed = 0;}
            //if(exoTeacherProps2!=null){exoTeacherBody2.GetComponent<Animator>().speed = 0;}
            //if(exoTeacherProps3!=null){exoTeacherBody3.GetComponent<Animator>().speed = 0;}
            //if(exoTeacherProps4!=null){exoTeacherBody4.GetComponent<Animator>().speed = 0;}
        }
        else
        {
            teacherZero.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            teacherZeroProps.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            foreach (var item in teacherBodies)
            {
                if (item != null)
                {
                    item.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
                }
            }
            foreach (var item in teacherProps)
            {
                if (item != null)
                {
                    item.GetComponent<Animator>().speed  = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
                }
            }
            //if(exoTeacherBody1!=null){exoTeacherBody1.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
            //if(exoTeacherBody2!=null){exoTeacherBody2.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
            //if(exoTeacherBody3!=null){exoTeacherBody3.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
            //if(exoTeacherBody4!=null){exoTeacherBody4.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
            //if(exoTeacherProps1!=null){exoTeacherBody1.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
            //if(exoTeacherProps2!=null){exoTeacherBody2.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
            //if(exoTeacherProps3!=null){exoTeacherBody3.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
            //if(exoTeacherProps4!=null){exoTeacherBody4.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));}
        }   
    }
}
