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

    private string state = "start;";
    public string fileName = "testFile.txt";

    private string path = @"C:\FEYER\logs\";
    private string theLog = "";
    private int currentAnimationFrame = 0;
    private int totalAnimationFrames = 0;
    private Boolean isLogging = false;
    private string header = "";

    StreamWriter file;

    DateTime startTime;
    // Start is called before the first frame update

    // !!! TODO yxc: check right foot distance, log neckHead, 5 more value entries than header entries. log hip - box distance. log total animationframes. fix dat!
    void Start()
    {
        // rechts/links händer?
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Logging start");
            startTime = DateTime.Now;
            isLogging = true;
        }

        // debug
        if(Input.GetKeyDown(KeyCode.L)){
            Debug.Log("Logging start");
            startTime = DateTime.Now;
            createLogEntry();
        }

        // kill recording and store the data
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Logging end");
            addHeaderToLog();
            storeData();
            isLogging = false;
        }

        if (isLogging)
        {
            int oldAnimationFrame = currentAnimationFrame;

            if (getCurrentAnimationFrame() > oldAnimationFrame)
            {
                createLogEntry();    
            }

            // get the frames the movements do start
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(currentAnimationFrame);
            }

            if (currentAnimationFrame  >= totalAnimationFrames)
            {
                isLogging = false;
                addHeaderToLog();
                storeData();
            }
        }
    }

    private void createLogEntry(){
        Debug.Log("creating log entry for frame: " + currentAnimationFrame);
        addLine();
    }
    private void addLine()
    {
        theLog = theLog + getElaplsedTimeInMs() + getCurrentAnimationFrameString() + getState() + getAccuracyDistance() + getAccuracyAngle() + getRiskMetrics() + getLookingAt() + studentBodyValues() + teacherBodyValues() + studentPropsValues() + teacherPropsValues() + "\n";
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
    private string getCurrentAnimationFrameString(){
        if (firstTimeAF)
        {
            header = header + "currentAnimationFrame;";
            firstTimeAF = false;
        }
        return currentAnimationFrame + ";";

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
            state = "lift;";
        }
        if (currentAnimationFrame >= 268)
        {
            state = "carry;";
        }
        if (currentAnimationFrame >= 700)
        {
            state = "place;";
        }
        Debug.Log(state);
        return state;
        
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
                Debug.Log("logged studentBody header");
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
                Debug.Log("logged studentProps header");
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

    float calculateSpineBendAngle(GameObject _lowerHip, GameObject _upperHip)
    {
        GameObject refPointBendAngle = new GameObject();
        float a, b, c;
        Vector3 upward = new Vector3(0, 1f, 0); //Magnitude for the reference point
        refPointBendAngle.transform.position = _lowerHip.transform.position + upward;
        //Distance of the segments that form a triangle (necessary for LawOfCosines)
        b = Vector3.Distance(_lowerHip.transform.position, refPointBendAngle.transform.position);
        a = Vector3.Distance(_lowerHip.transform.position, _upperHip.transform.position);
        c = Vector3.Distance(_upperHip.transform.position, refPointBendAngle.transform.position);
        float angle = lawOfCosines(a, b, c);
        float angleindegrees = angle * 180 / Mathf.PI;
        Destroy(refPointBendAngle);

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
