using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this script should be called animationSpeedController
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

    public GameObject scriptHolder;

    public bool enableSpeedMechanic = true;
    // Start is called before the first frame update

    public float etdMin = 0.0001f;
    public enum etdMaxEnum {a1000, a1250, a1500, a1875, a2250, a2813, a3375, a4219, a5063};
    public etdMaxEnum etdMax;
    public enum easingFunctionEum {linear, sine, digital, exponential};
    public easingFunctionEum easingFunction;


    private GameObject[] teacherBodies;
    private GameObject[] teacherProps;

    private bool animationHalt = true;

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


    
    
    // Update is called once per frame
    void Update()
    {
        float fullSpeedDistance = etdMin;
        float stopDistance = 0f;
        switch (etdMax)
            {
                case etdMaxEnum.a1000: 
                    stopDistance = 0.1f;
                    break;
                case etdMaxEnum.a1250: 
                    stopDistance = 0.125f;
                    break;
                case etdMaxEnum.a1500: 
                    stopDistance = 0.15f;
                    break;
                case etdMaxEnum.a1875: 
                    stopDistance = 0.1875f;
                    break;
                case etdMaxEnum.a2250: 
                    stopDistance = 0.225f;
                    break;
                case etdMaxEnum.a2813: 
                    stopDistance = 0.2813f;
                    break;
                case etdMaxEnum.a3375: 
                    stopDistance = 0.3375f;
                    break;
                case etdMaxEnum.a4219: 
                    stopDistance = 0.4219f;
                    break;
                case etdMaxEnum.a5063: 
                    stopDistance = 0.5063f;
                    break;
                default:
                    stopDistance = 0.1f;
                    break;
            }
        Debug.Log("stopDistance: " + stopDistance);
        if (enableSpeedMechanic == false)
        {
            // this disables the speed mechanic by setting the etdMax to unreachable value
            stopDistance = 50f;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            // 0.3 it was. starts the animation by setting the stop distance to greater than 0
            animationHalt = !animationHalt;
            Debug.Log("s pressed " + animationHalt);
        }

        Vector3 studentHipPositionOnFloor = new Vector3(studentHip.transform.position.x, 0, studentHip.transform.position.z);
        Vector3 teacherHipPositionOnFloor = new Vector3(teacherHip.transform.position.x, 0, teacherHip.transform.position.z);
        Vector3 teacherZeroPositionOnFloor = new Vector3(teacherZero.transform.position.x, 0, teacherZero.transform.position.z);
        // distance on the flor: 
        Vector3 deltaStudentTeacher = studentHipPositionOnFloor - (teacherHipPositionOnFloor - teacherZeroPositionOnFloor);
        // the original with hip distance: Vector3 deltaStudentTeacher = studentHip.transform.position - (teacherHip.transform.position - teacherZero.transform.position);
        //teacherZero.transform.position = deltaStudentTeacher;
       if (animationHalt)
       {
           stopAnimation();
       }
       else
       {
        if(deltaStudentTeacher.magnitude >= stopDistance) {
            stopAnimation();
        }
        else
        {
            switch (easingFunction)
            {
                case easingFunctionEum.linear: 
                    Debug.Log("easing function: linear");
                    linearSpeed(stopDistance, fullSpeedDistance, deltaStudentTeacher.magnitude);
                    break;
                case easingFunctionEum.sine:
                    Debug.Log("easing function: sine");
                    sineSpeed(stopDistance, fullSpeedDistance, deltaStudentTeacher.magnitude);
                    break;
                case easingFunctionEum.digital: 
                    Debug.Log("easing function: digital");
                    digitalSpeed(stopDistance, fullSpeedDistance, deltaStudentTeacher.magnitude);
                    break;
                case easingFunctionEum.exponential:
                    Debug.Log("easing function: exponential");
                    exponentialSpeed(stopDistance, fullSpeedDistance, deltaStudentTeacher.magnitude);
                    break;
                default:
                    linearSpeed(stopDistance, fullSpeedDistance, deltaStudentTeacher.magnitude);
                    break;
            }
        }

        

            // the original stuff
            //scriptHolder.GetComponent<makeTeacherHeadTransparent>().makeTeacherAvatarHeadTransparent();
            //Debug.Log("speed: " + Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance))) );
            //teacherZero.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            //teacherZeroProps.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            //foreach (var item in teacherBodies)
            //{
            //    if (item != null)
            //    {
            //        item.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            //    }
            //}
            //foreach (var item in teacherProps)
            //{
            //    if (item != null)
            //    {
            //        item.GetComponent<Animator>().speed  = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacher.magnitude / fullSpeedDistance)));
            //    }
            //}
            
       }   
    }

    private void stopAnimation(){
        scriptHolder.GetComponent<makeTeacherHeadTransparent>().makeTeacherAvatarHeadVisible();
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
    }

    private void linearSpeed(float stopDistance, float fullSpeedDistance, float deltaStudentTeacherMagnitude){
        
        scriptHolder.GetComponent<makeTeacherHeadTransparent>().makeTeacherAvatarHeadTransparent();
        teacherZero.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacherMagnitude / fullSpeedDistance)));
        teacherZeroProps.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacherMagnitude / fullSpeedDistance)));
        foreach (var item in teacherBodies)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacherMagnitude / fullSpeedDistance)));
            }
        }
        foreach (var item in teacherProps)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacherMagnitude / fullSpeedDistance)));
            }
        }
    }

    private void digitalSpeed(float stopDistance, float fullSpeedDistance, float deltaStudentTeacherMagnitude){
        scriptHolder.GetComponent<makeTeacherHeadTransparent>().makeTeacherAvatarHeadTransparent();
        teacherZero.GetComponent<Animator>().speed = 1.0f;
        teacherZeroProps.GetComponent<Animator>().speed = 1.0f;
        foreach (var item in teacherBodies)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = 1.0f;
            }
        }
        foreach (var item in teacherProps)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = 1.0f;
            }
        }
    }

    private void sineSpeed(float stopDistance, float fullSpeedDistance, float deltaStudentTeacherMagnitude){
        //plot[sin(1.5x^3), {x,0,1}] -> wolfram alpha
        scriptHolder.GetComponent<makeTeacherHeadTransparent>().makeTeacherAvatarHeadTransparent();
        float linearInterpolatedValue = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacherMagnitude / fullSpeedDistance)));
        float speed = Mathf.Sin(1.5f * Mathf.Pow(linearInterpolatedValue, 3));
        teacherZero.GetComponent<Animator>().speed = speed;
        teacherZeroProps.GetComponent<Animator>().speed = speed;
        foreach (var item in teacherBodies)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = speed;
            }
        }
        foreach (var item in teacherProps)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = speed;
            }
        }
    }

    private void exponentialSpeed(float stopDistance, float fullSpeedDistance, float deltaStudentTeacherMagnitude){
        //plot[exp(x^5)-1, {x,0,1}] -> wolfram alpha
        scriptHolder.GetComponent<makeTeacherHeadTransparent>().makeTeacherAvatarHeadTransparent();
        float linearInterpolatedValue = Mathf.Min(1f, (stopDistance / fullSpeedDistance - (deltaStudentTeacherMagnitude / fullSpeedDistance)));
        float speed = Mathf.Exp(Mathf.Pow(linearInterpolatedValue, 5)-1);
        teacherZero.GetComponent<Animator>().speed = speed;
        teacherZeroProps.GetComponent<Animator>().speed = speed;
        foreach (var item in teacherBodies)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = speed;
            }
        }
        foreach (var item in teacherProps)
        {
            if (item != null)
            {
                item.GetComponent<Animator>().speed = speed;
            }
        }
    }
}
