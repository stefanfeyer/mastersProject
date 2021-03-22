using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class logging : MonoBehaviour
{
    [Header("1, 2, 3")]
    public int taskId = 1;

    [Header("ego, exo, egoexo")]
    public string perspectiveId = "ego";

    [Header("PT1, PT2, PT3")]
    public string participantId = "PT1";
    public GameObject studentBody;
    public GameObject teacherBody;
    public GameObject studentProps;
    public GameObject teacherProps;
    public GameObject rayCast;
    public GameObject neckHead;

    private string state = "init";
    private string fileName;

    private string path = @"C:\FEYER\logs\";
    //private string theLog = "";
    private int currentAnimationFrame = 0;
    private int totalAnimationFrames = 0;
    private Boolean isLogging = false;
    private string header = "";
    private Vector3 hipUpwardVector;
    private bool isSpressed = false;

    private string[] logArray = new string[100000];
    private int logArrayIndex = 1;

    StreamWriter file;

    DateTime startTime;
    // Start is called before the first frame update

    // !!! TODO yxc: log hip - box distance. log upward vector. store in arry. log every frame.fix dat!
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // prevent s is pressed doubled
            if (!isSpressed)
            {
                Debug.Log("Logging start");
                startTime = DateTime.Now;
                isLogging = true;
                isSpressed = true;
            }
        }

        // debug
        if (Input.GetKeyDown(KeyCode.L))
        {
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

        // store the calibration data
        if (Input.GetKeyDown(KeyCode.V))
        {
            state = "calibration";
            createLogEntry();
            state = "init";
        }

        if (isLogging)
        {
            int oldAnimationFrame = currentAnimationFrame;

            // logging only per animation frame
            // if (getCurrentAnimationFrame() > oldAnimationFrame){createLogEntry();}

            // log every frame
            getCurrentAnimationFrame();
            createLogEntry();

            // get the frames the movements do start
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(currentAnimationFrame);
            }

            // end logging if last animation frame is played
            if (currentAnimationFrame >= totalAnimationFrames)
            {
                isLogging = false;
                addHeaderToLog();
                storeData();
            }
        }
    }

    public void createLogEntry()
    {
        addLine();
    }
    private void addLine()
    {
        string logLine = getElaplsedTimeInMs() + getCurrentAnimationFrameString() + getTotalAnimationFrameString() + getState() + getAccuracyDistance() + getAccuracyAngle() + getRiskMetrics() + getHipBoxDistance() + getLookingAt() + studentHeadValues() + studentBodyValues() + teacherBodyValues() + studentPropsValues() + teacherPropsValues() + "\n";
        //theLog = theLog + getElaplsedTimeInMs() + getCurrentAnimationFrameString() + getTotalAnimationFrameString() + getState() + getAccuracyDistance() + getAccuracyAngle() + getRiskMetrics() + getLookingAt() + studentHeadValues() + studentBodyValues() + teacherBodyValues() + studentPropsValues() + teacherPropsValues() + "\n";
        logArray[logArrayIndex] = logLine;
        logArrayIndex++;
        if (logArrayIndex % 1800 == 0)
        {
            Debug.Log("LogArrayIndex is at " + logArrayIndex + " of 100.000 frame slots.");
        }
    }

    private int getCurrentAnimationFrame()
    {
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



    private void addHeaderToLog()
    {
        // theLog = header + "\n" + theLog;
        logArray[0] = header + "\n";
    }


    private bool firstTimeStudentBodyValues = true;
    private string studentBodyValues()
    {
        if (firstTimeStudentBodyValues)
        {
            foreach (Transform child in studentBody.transform)
            {
                header = header + "student" + child.name + "PosX;" + "student" + child.name + "PosY;" + "student" + child.name + "PosZ;" + "student" + child.name + "RotX;" + "student" + child.name + "RotY;" + "student" + child.name + "RotZ;";
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
        return transformToString(neckHead.transform) + ";"; // missing ;
    }

    private string transformToString(Transform t)
    {

        Vector3 pos = t.position;
        Quaternion rot = t.rotation;
        string output = pos.x + ";" + pos.y + ";" + pos.z + ";" + rot.x + ";" + rot.y + ";" + rot.z;
        return output;
    }

    private bool firstTimeElapsedTime = true;
    private string getElaplsedTimeInMs()
    {
        if (firstTimeElapsedTime)
        {
            header = header + "elapsedTime;";
            firstTimeElapsedTime = false;
        }
        return (int)(DateTime.Now - startTime).TotalMilliseconds + ";";
    }

    private bool firstTimeLookingAt = true;
    private string getLookingAt()
    {
        if (firstTimeLookingAt)
        {
            header = header + "lookingAt;";
            firstTimeLookingAt = false;
        }
        //Debug.Log(rayCast.GetComponent<lookingAt>().rayCastHitName);
        return rayCast.GetComponent<lookingAt>().rayCastHitName + ";";
    }

    private bool firstTimeRiskMetrics = true;
    private string getRiskMetrics()
    {
        if (firstTimeRiskMetrics)
        {
            header = header + "studentSpineBendAngle;studentFootDistance;studentSquatDistance;teacherSpineBendAngle;teacherFootDistance;teacherSquatDistance;";
            firstTimeRiskMetrics = false;
        }
        //student
        string studentRiskMetrics = ""
        + calculateSpineBendAngle(studentBody.transform.Find("Hip").gameObject, studentBody.transform.Find("upperHipTracker").gameObject)
        + ";"
        + calculateDistanceBetweenFeet(studentBody.transform.Find("LeftFootTracker").gameObject, studentBody.transform.Find("RightFootTracker").gameObject)
        + ";"
        + calculateSquatDistance(studentBody.transform.Find("Hip").gameObject)
        + ";";
        //teacher
        string teacherRiskMetrics = ""
        + calculateSpineBendAngle(teacherBody.transform.Find("Hip").gameObject, teacherBody.transform.Find("upperHipTracker").gameObject)
        + ";"
        + calculateDistanceBetweenFeet(teacherBody.transform.Find("LeftFootTracker").gameObject, teacherBody.transform.Find("RightFootTracker").gameObject)
        + ";"
        + calculateSquatDistance(teacherBody.transform.Find("Hip").gameObject)
        + ";";
        return "" + studentRiskMetrics + teacherRiskMetrics;
    }

    float calculateSpineBendAngle(GameObject _lowerHip, GameObject _upperHip)
    {
        GameObject refPointBendAngle = new GameObject();
        float a, b, c;
        Vector3 hipUpwardVector = new Vector3(0, 0.2f, 0); // straight upward vector. but on calibration, the upward vector is set by the value of the body
        refPointBendAngle.transform.position = _lowerHip.transform.position + hipUpwardVector;
        //Distance of the segments that form a triangle (necessary for LawOfCosines)
        b = Vector3.Distance(_lowerHip.transform.position, refPointBendAngle.transform.position);
        a = Vector3.Distance(_lowerHip.transform.position, _upperHip.transform.position);
        c = Vector3.Distance(_upperHip.transform.position, refPointBendAngle.transform.position);
        float angle = lawOfCosines(a, b, c);
        float angleindegrees = angle * 180 / Mathf.PI;
        Destroy(refPointBendAngle);

        //Debug.Log("spine Bend: " + angleindegrees);
        return angleindegrees;//return 180-angleindegrees;
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

    private bool firstTimeAccDist = true;
    private string getAccuracyDistance()
    {
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
        //Debug.Log("box distance: " + Vector3.Distance(studentProps.transform.Find("Box").transform.position, teacherProps.transform.Find("Box").transform.position));
        return accuracyValues;
    }

    private bool firstTimeHipBoxDistance = true;
    private string getHipBoxDistance()
    {
        if (firstTimeHipBoxDistance)
        {
            header = header + "studentHipBoxDistance;teacherHipBoxDistance;";
            firstTimeHipBoxDistance = false;
        }
        string hipBoxDistance = ""
        + Vector3.Distance(studentBody.transform.Find("Hip").transform.position, studentProps.transform.Find("Box").transform.position)
        + ";"
        + Vector3.Distance(teacherBody.transform.Find("Hip").transform.position, teacherProps.transform.Find("Box").transform.position)
        + ";";
        return hipBoxDistance;
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
        + Quaternion.Angle(studentBody.transform.Find("Hip").transform.rotation, teacherBody.transform.Find("Hip").transform.rotation)
        + ";"
        + Quaternion.Angle(studentBody.transform.Find("LeftHandTracker").transform.rotation, teacherBody.transform.Find("LeftHandTracker").transform.rotation)
        + ";"
        + Quaternion.Angle(studentBody.transform.Find("RightHandTracker").transform.rotation, teacherBody.transform.Find("RightHandTracker").transform.rotation)
        + ";"
        + Quaternion.Angle(studentBody.transform.Find("LeftFootTracker").transform.rotation, teacherBody.transform.Find("LeftFootTracker").transform.rotation)
        + ";"
        + Quaternion.Angle(studentBody.transform.Find("RightFootTracker").transform.rotation, teacherBody.transform.Find("RightFootTracker").transform.rotation)
        + ";"
        + Quaternion.Angle(neckHead.transform.rotation, teacherBody.transform.Find("Head").transform.rotation)
        + ";"
        + Quaternion.Angle(studentProps.transform.Find("Box").transform.rotation, teacherProps.transform.Find("Box").transform.rotation)
        + ";";

        //Debug.Log("box angle: " + Quaternion.Angle(studentProps.transform.Find("Box").transform.rotation, teacherProps.transform.Find("Box").transform.rotation));

        return accuracyValues;
    }



    private void storeData()
    {
        fileName = participantId + "_" + perspectiveId + "_T" + taskId + ".txt";
        Debug.Log("started storing file: " + path + fileName);
        file = new System.IO.StreamWriter(path + fileName, true);
        int i = 0;
        foreach (string _logLine in logArray)
        {
            if (_logLine != "")
            {
                file.Write(_logLine);
            }
            if (i % 10000 == 0)
            {
                Debug.Log("stored " + i / 10000 + "0%");
            }
            i++;
        }
        file.Flush();
        file.Close();
        //file = new System.IO.StreamWriter(path + fileName, true);
        //file.Write(theLog);
        //file.Flush();
        //file.Close();
        Debug.Log("stored the file!");
    }

    private bool firstTimeState = true;
    private string getState()
    {
        if (firstTimeState)
        {
            header = header + "subTaskId;";
            firstTimeState = false;
        }

        switch (taskId)
        {
            case 1:
                getStateTask1();
                break;
            case 2:
                getStateTask2();
                break;
            case 3:
                getStateTask3();
                break;
        }
        return state + ";";

    }

    private String getStafeForFrame(Tuple<String, int>[] listOfTuples, int frame)
    {
        var item = Array.FindLastIndex(listOfTuples, it => it.Item2 < frame);
        if( item == -1){
            return listOfTuples[0].Item1;
        }
        return listOfTuples[item + 1].Item1;
        
    }

    private void getStateTask1()
    {
        state = getStafeForFrame(listOfTuplesT1, currentAnimationFrame);
    }

    private void getStateTask2()
    {
        state = getStafeForFrame(listOfTuplesT2, currentAnimationFrame);
    }

    private void getStateTask3()
    {
        state = getStafeForFrame(listOfTuplesT3, currentAnimationFrame);
    }

    private Tuple<String, int>[] listOfTuplesT1 = {
       new Tuple<String, int>("lift", 0),
       new Tuple<String, int>("lift", 427),
       new Tuple<String, int>("carry", 854),
       new Tuple<String, int>("place", 1058),
       new Tuple<String, int>("push", 1278),
       new Tuple<String, int>("fold", 1544),
       new Tuple<String, int>("walk", 1977),
       new Tuple<String, int>("fold", 2210),
       new Tuple<String, int>("pull", 2432),
       new Tuple<String, int>("pick", 2629),
       new Tuple<String, int>("carry", 3136),
       new Tuple<String, int>("lower", 3366),
       new Tuple<String, int>("lift", 3785),
       new Tuple<String, int>("carry", 4247),
       new Tuple<String, int>("place", 4517),
       new Tuple<String, int>("turn", 4733),
       new Tuple<String, int>("push", 5101),
       new Tuple<String, int>("pull", 5214),
       new Tuple<String, int>("turn", 5541),
       new Tuple<String, int>("fold", 5806),
       new Tuple<String, int>("pull", 6075),
       new Tuple<String, int>("walk", 6503),
       new Tuple<String, int>("pull", 6741),
       new Tuple<String, int>("turn", 7007),
       new Tuple<String, int>("push", 7270),
       new Tuple<String, int>("fold", 7623),
       new Tuple<String, int>("push", 7772),
       new Tuple<String, int>("walk", 8233),
       new Tuple<String, int>("walk", 8632),
       new Tuple<String, int>("turn", 8879),
       new Tuple<String, int>("pick", 9124),
       new Tuple<String, int>("carry", 9527),
       new Tuple<String, int>("lower", 9884),
       new Tuple<String, int>("lift", 10156),
       new Tuple<String, int>("lower", 10449),
       new Tuple<String, int>("lower", int.MaxValue),
       new Tuple<String, int>("lower", int.MaxValue),
    };

    private Tuple<String, int>[] listOfTuplesT2 =   {
        new Tuple<String, int>("lift", 0),
        new Tuple<String, int>("lift", 405),
        new Tuple<String, int>("carry", 973),
        new Tuple<String, int>("lower", 1285),
        new Tuple<String, int>("lift", 1572),
        new Tuple<String, int>("carry", 2052),
        new Tuple<String, int>("place", 2295),
        new Tuple<String, int>("push", 2722),
        new Tuple<String, int>("walk", 3042),
        new Tuple<String, int>("pull", 3394),
        new Tuple<String, int>("push", 3640),
        new Tuple<String, int>("walk", 4047),
        new Tuple<String, int>("fold", 4331),
        new Tuple<String, int>("turn", 4572),
        new Tuple<String, int>("fold", 4772),
        new Tuple<String, int>("turn", 5014),
        new Tuple<String, int>("push", 5354),
        new Tuple<String, int>("turn", 5687),
        new Tuple<String, int>("pull", 5851),
        new Tuple<String, int>("fold", 6204),
        new Tuple<String, int>("turn", 6502),
        new Tuple<String, int>("walk", 6984),
        new Tuple<String, int>("pull", 7283),
        new Tuple<String, int>("fold", 7502),
        new Tuple<String, int>("push", 7849),
        new Tuple<String, int>("walk", 8181),
        new Tuple<String, int>("pull", 8559),
        new Tuple<String, int>("pick", 8741),
        new Tuple<String, int>("place", 8996),
        new Tuple<String, int>("pick", 9146),
        new Tuple<String, int>("carry", 9768),
        new Tuple<String, int>("lower", 10096),
        new Tuple<String, int>("lift", 10400),
        new Tuple<String, int>("carry", 10983),
        new Tuple<String, int>("lower", 11320),
        new Tuple<String, int>("lower", int.MaxValue),
        new Tuple<String, int>("lower", int.MaxValue),
    };

    private Tuple<String, int>[] listOfTuplesT3 =   {
        new Tuple<String, int>("lift", 0),
        new Tuple<String, int>("lift", 447),
        new Tuple<String, int>("carry", 1026),
        new Tuple<String, int>("place", 1303),
        new Tuple<String, int>("fold", 1554),
        new Tuple<String, int>("walk", 1957),
        new Tuple<String, int>("turn", 2274),
        new Tuple<String, int>("fold", 2519),
        new Tuple<String, int>("push", 2830),
        new Tuple<String, int>("walk", 3315),
        new Tuple<String, int>("pull", 3622),
        new Tuple<String, int>("fold", 3898),
        new Tuple<String, int>("turn", 4183),
        new Tuple<String, int>("push", 4436),
        new Tuple<String, int>("walk", 4725),
        new Tuple<String, int>("fold", 5003),
        new Tuple<String, int>("turn", 5260),
        new Tuple<String, int>("pick", 5497),
        new Tuple<String, int>("carry", 5946),
        new Tuple<String, int>("lower", 6233),
        new Tuple<String, int>("lift", 6505),
        new Tuple<String, int>("lower", 6884),
        new Tuple<String, int>("lift", 7175),
        new Tuple<String, int>("carry", 7635),
        new Tuple<String, int>("place", 7869),
        new Tuple<String, int>("push", 8066),
        new Tuple<String, int>("pull", 8297),
        new Tuple<String, int>("turn", 8596),
        new Tuple<String, int>("walk", 8970),
        new Tuple<String, int>("pull", 9211),
        new Tuple<String, int>("push", 9427),
        new Tuple<String, int>("pull", 9577),
        new Tuple<String, int>("pick", 9821),
        new Tuple<String, int>("carry", 10317),
        new Tuple<String, int>("lower", 10679),
        new Tuple<String, int>("lower", int.MaxValue),
        new Tuple<String, int>("lower", int.MaxValue),
    };
}
