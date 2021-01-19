using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riskMetrics : MonoBehaviour
{
    public GameObject studentLeftFoot;
    public GameObject studentRightFoot;
    public GameObject studentLowerHip;
    public GameObject studentUpperHip;
    public GameObject studentLeftShoulder;
    public GameObject studentRightShoulder;

    public GameObject teacherLeftFoot;
    public GameObject teacherRightFoot;
    public GameObject teacherLowerHip;
    public GameObject teacherUpperHip;
    public GameObject teacherLeftShoulder;
    public GameObject teacherRightShoulder;

    GameObject refPointBendAngle;
    // Start is called before the first frame update
    void Start()
    {
        refPointBendAngle = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CalculateSpineBendAngle(studentLowerHip, studentUpperHip));
        Debug.Log(CalculateSquatDistance(studentLowerHip));
        Debug.Log(CalculateDistanceBetweenFeet(studentLeftFoot, studentRightFoot));
        Debug.Log(CalculateSpineTwist(studentLowerHip, studentLeftShoulder, studentRightShoulder));
    }

    float CalculateSpineBendAngle(GameObject _lowerHip, GameObject _upperHip)
    {
        float a, b, c;
        Vector3 upward = new Vector3(0, 1f, 0); //Magnitude for the reference point
        refPointBendAngle.transform.position = _lowerHip.transform.position + upward;
        //Distance of the segments that form a triangle (necessary for LawOfCosines)
        b = Vector3.Distance(_lowerHip.transform.position, refPointBendAngle.transform.position);
        a = Vector3.Distance(_lowerHip.transform.position, _upperHip.transform.position);
        c = Vector3.Distance(_upperHip.transform.position, refPointBendAngle.transform.position);
        float angle = LawOfCosines(a, b, c);
        float angleindegrees = angle * 180 / Mathf.PI;

        return angleindegrees;
    }

    float LawOfCosines(float a, float b, float c)
    {
        float numerator, denominator, answer;

        numerator = Mathf.Pow(a, 2) + Mathf.Pow(b, 2) - Mathf.Pow(c, 2);
        denominator = (2 * a * b);
        answer = Mathf.Acos(numerator / denominator);

        return answer;
    }

    float CalculateDistanceBetweenFeet(GameObject _leftFoot, GameObject _rightFoot)
    {
        float baseDistance;
        baseDistance = Vector3.Distance(_leftFoot.transform.position, _rightFoot.transform.position);
        return baseDistance;
    }

    float CalculateSquatDistance(GameObject _lowerHip)
    {
        float pelvisDistance;
        pelvisDistance = _lowerHip.transform.position.y;

        return pelvisDistance;
    }

    float CalculateSpineTwist(GameObject _lowerHip, GameObject _leftShoulder, GameObject _rightShoulder)
    {
        GameObject leftHipReference = new GameObject();
        GameObject rightHipReference = new GameObject();
        leftHipReference.transform.parent = _lowerHip.transform;
        rightHipReference.transform.parent = _lowerHip.transform;
        leftHipReference.transform.localPosition = new Vector3(-1f, 0, 0);
        rightHipReference.transform.localPosition = new Vector3(1f, 0, 0);

        float rotationAngle;
        Vector3 hipVector = leftHipReference.transform.position - rightHipReference.transform.position;
        Vector3 shoulderVector = _leftShoulder.transform.position - _rightShoulder.transform.position;

        Destroy(leftHipReference);
        Destroy(rightHipReference);

        rotationAngle = Vector3.Angle(hipVector, shoulderVector);
        

        return rotationAngle;
    }
}
