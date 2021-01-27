using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
    

public class logging : MonoBehaviour
{
    public GameObject studentBody;
    public GameObject teacherBody;
    public GameObject studentProps;
    public GameObject teacherProps;
    public GameObject rayCast;
    public GameObject neckHead;

    private string state = "init";
    public string fileName = "testFile.txt";

    private string path = @"C:\FEYER\logs\";
    private string theLog = "";
    private int currentAnimationFrame = 0;
    private int totalAnimationFrames = 0;
    private Boolean isLogging = false;
    private string header = "";
    private Vector3 hipUpwardVector;
    private Vector3 shoulderVectorAtCalibration;
    
    StreamWriter file;

    DateTime startTime;
    // Start is called before the first frame update

    // !!! TODO yxc: log hip - box distance. log upward vector. store in arry. log every frame.fix dat!
    void Start()
    {
        // rechts/links händer?
    }

    // Update is called once per frame
    void Update()
    {
        //debug(studentBody.transform.Find("Hip").gameObject);
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Logging start");
            startTime = DateTime.Now;
            isLogging = true;
        }

        // debug
        if(Input.GetKeyDown(KeyCode.L)){
            Debug.Log("created single log entry");
            startTime = DateTime.Now;
            createLogEntry();
        }

        // kill recording and store the data
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Logging killed");
            addHeaderToLog();
            storeData();
            isLogging = false;
        }

        // store the calibration data, check if it is really happening after the calibration
        if (Input.GetKeyDown(KeyCode.V))
        {
            calcHipUpwardVector(studentBody.transform.Find("Hip").gameObject, studentBody.transform.Find("upperHipTracker").gameObject);
            // if you have time, implement that
            //calcShoulderVectorAtCalibration(studentBody.transform.Find("LeftShoulderTracker").gameObject, studentBody.transform.Find("RightShoulderTracker").gameObject);
            state = "calibration";
            createLogEntry();
            state = "init";
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //calculateSpineBendAngle(studentBody.transform.Find("Hip").gameObject, studentBody.transform.Find("upperHipTracker").gameObject);
            //calculateSpineTwist(studentBody.transform.Find("Hip").gameObject, studentBody.transform.Find("LeftShoulderTracker").gameObject, studentBody.transform.Find("RightShoulderTracker").gameObject);
        }

        if (isLogging)
        {
            int oldAnimationFrame = currentAnimationFrame;

            // logging only per animation frame
            if (getCurrentAnimationFrame() > oldAnimationFrame)
            {
                createLogEntry();    
            }

            // log every frame
            createLogEntry();

            // get the frames the movements do start
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(currentAnimationFrame);
            }

            // end logging if last animation frame is played
            if (currentAnimationFrame  >= totalAnimationFrames)
            {
                isLogging = false;
                addHeaderToLog();
                storeData();
            }
        }
    }

    public void createLogEntry(){
        addLine();
    }
    private void addLine()
    {
        theLog = theLog + getElaplsedTimeInMs() + getCurrentAnimationFrameString() + getTotalAnimationFrameString() + getState() + getAccuracyDistance() + getAccuracyAngle() + getRiskMetrics() + getLookingAt() + studentHeadValues() + studentBodyValues() + teacherBodyValues() + studentPropsValues() + teacherPropsValues() + "\n";
    }

    private int getCurrentAnimationFrame(){
        if (teacherBody != null)
        {
            Animator teacherAnimator = teacherBody.GetComponent<Animator>();
            AnimatorClipInfo[] animationClip = teacherAnimator.GetCurrentAnimatorClipInfo(0);
            float time = teacherAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            totalAnimationFrames = (int)(animationClip[0].weight * (animationClip[0].clip.length * animationClip[0].clip.frameRate));
            currentAnimationFrame = (int)(time * totalAnimationFrames);
            return currentAnimationFrame;
        }
        return currentAnimationFrame;
        
    }

    private bool firstTimeAF = true;
    private string getCurrentAnimationFrameString()
    {
        if (firstTimeAF)
        {
            header = header + "currentAnimationFrame;";
            firstTimeAF = false;
        }
        return currentAnimationFrame + ";";

    }

    private bool firstTimeTA = true;
    private string getTotalAnimationFrameString()
    {
        if (firstTimeTA)
        {
            header = header + "totalAnimationFrame;";
            firstTimeTA = false;
        }
        return totalAnimationFrames + ";";

    }

    private bool firstTimeState = true;
    private string getState(){
        if (firstTimeState)
        {
            header = header + "subTaskId;";
            firstTimeState = false;
        }

        if (currentAnimationFrame >= 58)
        {
            state = "lift";
        }
        if (currentAnimationFrame >= 268)
        {
            state = "carry";
        }
        if (currentAnimationFrame >= 700)
        {
            state = "place";
        }
        return state + ";";
        
    }

    private void addHeaderToLog(){
        theLog = header + "\n" + theLog;
    }

    
    private bool firstTimeStudentBodyValues = true;
    private string studentBodyValues(){
        if (firstTimeStudentBodyValues)
        {
            foreach (Transform child in studentBody.transform)
            {
                header = header + "student" + child.name + "PosX;"+ "student" + child.name + "PosY;"+ "student" + child.name + "PosZ;"+ "student" + child.name + "RotX;"+ "student" + child.name + "RotY;"+ "student" + child.name + "RotZ;";
            }
            firstTimeStudentBodyValues = false;
        }
        string output = "";
        foreach (Transform child in studentBody.transform)
        {
            output = output + transformToString(child) + ";";
        }
        return output;

    }
    private bool firstTimeStudentTeacherValues = true;
    private string teacherBodyValues()
    {
        if (firstTimeStudentTeacherValues)
        {
            foreach (Transform child in teacherBody.transform)
            {
                header = header + "teacher" + child.name + "PosX;" + "teacher" + child.name + "PosY;" + "teacher" + child.name + "PosZ;" + "teacher" + child.name + "RotX;" + "teacher" + child.name + "RotY;" + "teacher" + child.name + "RotZ;";
            }
            firstTimeStudentTeacherValues = false;
        }
        string output = "";
        foreach (Transform child in teacherBody.transform)
        {
            output = output + transformToString(child) + ";";
        }
        return output;
    }

    private bool firstTimeStudentPropsValues = true;
    private string studentPropsValues()
    {
        if (firstTimeStudentPropsValues)
        {
            foreach (Transform child in studentProps.transform)
            {
                header = header + "student" + child.name + "PosX;" + "student" + child.name + "PosY;" + "student" + child.name + "PosZ;" + "student" + child.name + "RotX;" + "student" + child.name + "RotY;" + "student" + child.name + "RotZ;";
            }
            firstTimeStudentPropsValues = false;
        }
        string output = "";
        foreach (Transform child in studentProps.transform)
        {
            output = output + transformToString(child) + ";";
        }
        return output;
    }
    private bool firstTimeTeacherPropsValues = true;
    private string teacherPropsValues()
    {
        if (firstTimeTeacherPropsValues)
        {
            foreach (Transform child in teacherProps.transform)
            {
                header = header + "teacher" + child.name + "PosX;" + "teacher" + child.name + "PosY;" + "teacher" + child.name + "PosZ;" + "teacher" + child.name + "RotX;" + "teacher" + child.name + "RotY;" + "teacher" + child.name + "RotZ;";
            }
            firstTimeTeacherPropsValues = false;
        }
        string output = "";
        foreach (Transform child in teacherProps.transform)
        {
            output = output + transformToString(child) + ";";
        }
        return output;

    }

    private bool firstTimeStudentHead = true;
    private string studentHeadValues()
    {
        if (firstTimeStudentHead)
        {
            header = header + "studentHeadPosX;studentHeadPosY;studentHeadPosZ;studentHeadRotX;studentHeadRotY;studentHeadRotZ;";
            firstTimeStudentHead = false;
        }
        return transformToString(neckHead.transform);
    }

    private string transformToString(Transform t){
        
        Vector3 pos = t.position;
        Quaternion rot = t.rotation;
        string output = pos.x + ";" + pos.y + ";" + pos.z+ ";" + rot.x+ ";" + rot.y+ ";" + rot.z;
        return output;
    }

    private bool firstTimeElapsedTime = true;
    private string getElaplsedTimeInMs(){
        if (firstTimeElapsedTime)
        {
            header = header + "elapsedTime;";
            firstTimeElapsedTime = false;
        }
        return (int)(DateTime.Now - startTime).TotalMilliseconds + ";";
    }

    private bool firstTimeLookingAt = true;
    private string getLookingAt(){
        if (firstTimeLookingAt)
        {
            header = header + "lookingAt;";
            firstTimeLookingAt = false;
        }
        return rayCast.GetComponent<lookingAt>().rayCastHitName + ";";
    }

    private bool firstTimeRiskMetrics = true;
    private string getRiskMetrics(){
        if (firstTimeRiskMetrics)
        {
            header = header + "studentSpineBendAngle;studentFootDistance;studentSquatDistance;studentSpineTwistAngle;teacherSpineBendAngle;teacherFootDistance;teacherSquatDistance;teacherSpineTwistAngle;";
            firstTimeRiskMetrics = false;
        }
        //student
        string studentRiskMetrics = "" 
        + calculateSpineBendAngle(studentBody.transform.Find("Hip").gameObject, studentBody.transform.Find("upperHipTracker").gameObject) 
        + ";"
        + calculateDistanceBetweenFeet(studentBody.transform.Find("LeftFootTracker").gameObject, studentBody.transform.Find("RightFootTracker").gameObject)
        + ";"
        + calculateSquatDistance(studentBody.transform.Find("Hip").gameObject)
        + ";"
        + calculateSpineTwist(studentBody.transform.Find("Hip").gameObject, studentBody.transform.Find("LeftShoulderTracker").gameObject, studentBody.transform.Find("RightShoulderTracker").gameObject)
        + ";";
        //teacher
        string teacherRiskMetrics = ""
        + calculateSpineBendAngle(teacherBody.transform.Find("Hip").gameObject, teacherBody.transform.Find("upperHipTracker").gameObject)
        + ";"
        + calculateDistanceBetweenFeet(teacherBody.transform.Find("LeftFootTracker").gameObject, teacherBody.transform.Find("RightFootTracker").gameObject)
        + ";"
        + calculateSquatDistance(teacherBody.transform.Find("Hip").gameObject)
        + ";"
        + calculateSpineTwist(teacherBody.transform.Find("Hip").gameObject, teacherBody.transform.Find("LeftShoulderTracker").gameObject, teacherBody.transform.Find("RightShoulderTracker").gameObject)
        + ";";
        return "" + studentRiskMetrics + teacherRiskMetrics;
    }

    private void calcHipUpwardVector(GameObject _lowerHip, GameObject _upperHip){
        hipUpwardVector = _upperHip.transform.position - _lowerHip.transform.position;
    }

    private void calcShoulderVectorAtCalibration(GameObject _leftShoulder, GameObject _rightShoulder){
        shoulderVectorAtCalibration = _leftShoulder.transform.position - _rightShoulder.transform.position;
        Debug.Log("shoulderVectorAtCalibration: " + shoulderVectorAtCalibration);
    }

    private bool firstTimeHipUpwardVektor = true;
    private string getUpwardVector(){
        if (firstTimeHipUpwardVektor)
        {
            header = header + "hipUpwardVectorAtCalibration";
            firstTimeHipUpwardVektor = false;
        }
        
        return hipUpwardVector + ";";
    }

    float calculateSpineBendAngle(GameObject _lowerHip, GameObject _upperHip)
    {
        GameObject refPointBendAngle = new GameObject();
        float a, b, c;
        //Vector3 upward = new Vector3(0, 1f, 0); // straight upward vector. but on calibration, the upward vector is set by the value of the body
        refPointBendAngle.transform.position = _lowerHip.transform.position + hipUpwardVector;
        //Distance of the segments that form a triangle (necessary for LawOfCosines)
        b = Vector3.Distance(_lowerHip.transform.position, refPointBendAngle.transform.position);
        a = Vector3.Distance(_lowerHip.transform.position, _upperHip.transform.position);
        c = Vector3.Distance(_upperHip.transform.position, refPointBendAngle.transform.position);
        float angle = lawOfCosines(a, b, c);
        float angleindegrees = angle * 180 / Mathf.PI;
        Destroy(refPointBendAngle);
        
        Debug.Log("spine Bend: " + angleindegrees);
        return angleindegrees;
    }

    float lawOfCosines(float a, float b, float c)
    {
        float numerator, denominator, answer;

        numerator = Mathf.Pow(a, 2) + Mathf.Pow(b, 2) - Mathf.Pow(c, 2);
        denominator = (2 * a * b);
        answer = Mathf.Acos(numerator / denominator);

        return answer;
    }

    float calculateDistanceBetweenFeet(GameObject _leftFoot, GameObject _rightFoot)
    {
        float baseDistance;
        baseDistance = Vector3.Distance(_leftFoot.transform.position, _rightFoot.transform.position);
        return baseDistance;
    }

    float calculateSquatDistance(GameObject _lowerHip)
    {
        float pelvisDistance;
        pelvisDistance = _lowerHip.transform.position.y;

        return pelvisDistance;
    }


    float calculateSpineTwist(GameObject _lowerHip, GameObject _leftShoulder, GameObject _rightShoulder)
    {
        // exclude z rotation of tracker
        GameObject _lowerHipModifiedCopy = new GameObject();        
        _lowerHipModifiedCopy.transform.parent = _lowerHip.transform;
        _lowerHipModifiedCopy.transform.localPosition = new Vector3(0,0,0);
        _lowerHipModifiedCopy.transform.localRotation = Quaternion.Euler(0, 0, -_lowerHip.transform.eulerAngles.z);

        GameObject leftHipReference = new GameObject();;
        GameObject rightHipReference = new GameObject();;
        leftHipReference.transform.parent = _lowerHipModifiedCopy.transform;
        rightHipReference.transform.parent = _lowerHipModifiedCopy.transform;
        leftHipReference.transform.localPosition = new Vector3(-1f, 0, 0);
        rightHipReference.transform.localPosition = new Vector3(1f, 0, 0);
        leftHipReference.transform.localRotation = new Quaternion(0, 0, 0, 0);
        rightHipReference.transform.localRotation = new Quaternion(0, 0, 0, 0);

        float rotationAngle;
        Vector3 hipVector = leftHipReference.transform.position - rightHipReference.transform.position;
        Vector3 shoulderVector = _leftShoulder.transform.position - _rightShoulder.transform.position; 

        
        Destroy(leftHipReference);
        Destroy(rightHipReference);
        Destroy(_lowerHipModifiedCopy);

        rotationAngle = Vector3.Angle(hipVector, shoulderVector) ;
        Debug.Log("spineTwist: " + rotationAngle);
        
        return rotationAngle;
    }

    private bool firstTimeAccDist = true;
    private string getAccuracyDistance(){
        if (firstTimeAccDist)
        {
            header = header + "hipDistance;leftHandDistance;rightHandDistance;leftFootDistance;rightFootDistance;headDistance;boxDistance;";
            firstTimeAccDist = false;    
        }
        

        string accuracyValues = ""
        + Vector3.Distance(studentBody.transform.Find("Hip").transform.position, teacherBody.transform.Find("Hip").transform.position)
        + ";"
        + Vector3.Distance(studentBody.transform.Find("LeftHandTracker").transform.position, teacherBody.transform.Find("LeftHandTracker").transform.position)
        + ";"
        + Vector3.Distance(studentBody.transform.Find("RightHandTracker").transform.position, teacherBody.transform.Find("RightHandTracker").transform.position)
        + ";"
        + Vector3.Distance(studentBody.transform.Find("LeftFootTracker").transform.position, teacherBody.transform.Find("LeftFootTracker").transform.position)
        + ";"
        + Vector3.Distance(studentBody.transform.Find("RightFootTracker").transform.position, teacherBody.transform.Find("RightFootTracker").transform.position)
        + ";"
        + Vector3.Distance(neckHead.transform.position, teacherBody.transform.Find("Head").transform.position)
        + ";"
        + Vector3.Distance(studentProps.transform.Find("Box").transform.position, teacherProps.transform.Find("Box").transform.position)
        + ";";

        return accuracyValues;
    }

    private bool firstTimeAccAngle = true;
    private string getAccuracyAngle()
    {
        if (firstTimeAccAngle)
        {
            header = header + "hipAngle;leftHandAngle;rightHandAngle;leftFootAngle;rightFootAngle;headAngle;boxAngle;";
            firstTimeAccAngle = false;
        }

        string accuracyValues = ""
        + Vector3.Angle(studentBody.transform.Find("Hip").transform.position, teacherBody.transform.Find("Hip").transform.position)
        + ";"
        + Vector3.Angle(studentBody.transform.Find("LeftHandTracker").transform.position, teacherBody.transform.Find("LeftHandTracker").transform.position)
        + ";"
        + Vector3.Angle(studentBody.transform.Find("RightHandTracker").transform.position, teacherBody.transform.Find("RightHandTracker").transform.position)
        + ";"
        + Vector3.Angle(studentBody.transform.Find("LeftFootTracker").transform.position, teacherBody.transform.Find("LeftFootTracker").transform.position)
        + ";"
        + Vector3.Angle(studentBody.transform.Find("RightFootTracker").transform.position, teacherBody.transform.Find("RightFootTracker").transform.position)
        + ";"
        + Vector3.Angle(neckHead.transform.position, teacherBody.transform.Find("Head").transform.position)
        + ";"
        + Vector3.Angle(studentProps.transform.Find("Box").transform.position, teacherProps.transform.Find("Box").transform.position)
        + ";";

        return accuracyValues;
    }

    

    private void storeData(){
        file = new System.IO.StreamWriter(path + fileName, true);
        file.Write(theLog);
        file.Flush();
        file.Close();
        Debug.Log("stored the file!");
    }


}
