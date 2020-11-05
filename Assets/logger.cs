using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using System;
using System.Diagnostics;

public class logger : MonoBehaviour
{
    public string fileName = "testFile.txt";
    string path = @"C:\FEYER\logs\";
    StreamWriter file;
    DateTime startTime;
    public string taskId;
    public string conditionId;
    public bool taskInProgress;
    public int numberOfVisibleTeachers;
    //refine this:
    public GameObject teacher0;
    public GameObject teacher1;
    public GameObject teacher2;
    public GameObject teacher3;
    public GameObject teacher4;

    // eye Tracker?
    // task sequence? lift, lower, turn, push, pull

    // student
    // tracker
    public GameObject studentHMD;
    float studentHMDPosX;
    float studentHMDPosY;
    float studentHMDPosZ;
    float studentHMDRotX;
    float studentHMDRotY;
    float studentHMDRotZ;
    Vector3 rFoostudentHMDPos;
    Vector3 studentHMDRot;

    public GameObject studentLeftHandTracker;
    float studentLeftHandTrackerPosX;
    float studentLeftHandTrackerPosY;
    float studentLeftHandTrackerPosZ;
    float studentLeftHandTrackerRotX;
    float studentLeftHandTrackerRotY;
    float studentLeftHandTrackerRotZ;
    Vector3 studentLeftHandTrackerPos;
    Vector3 studentLeftHandTrackerRot;

    public GameObject studentRightHandTracker;
    float studentRightHandTrackerPosX;
    float studentRightHandTrackerPosY;
    float studentRightHandTrackerPosZ;
    float studentRightHandTrackerRotX;
    float studentRightHandTrackerRotY;
    float studentRightHandTrackerRotZ;
    Vector3 studentRightHandTrackerPos;
    Vector3 studentRightHandTrackerRot;

    public GameObject studentLeftShoulderTracker;
    float studentLeftShoulderTrackerPosX;
    float studentLeftShoulderTrackerPosY;
    float studentLeftShoulderTrackerPosZ;
    float studentLeftShoulderTrackerRotX;
    float studentLeftShoulderTrackerRotY;
    float studentLeftShoulderTrackerRotZ;
    Vector3 studentLeftShoulderTrackerPos;
    Vector3 studentLeftShoulderTrackerRot;

    public GameObject studentRightShoulderTracker;
    float studentRightShoulderTrackerPosX;
    float studentRightShoulderTrackerPosY;
    float studentRightShoulderTrackerPosZ;
    float studentRightShoulderTrackerRotX;
    float studentRightShoulderTrackerRotY;
    float studentRightShoulderTrackerRotZ;
    Vector3 studentRightShoulderTrackerPos;
    Vector3 studentRightShoulderTrackerRot;

    public GameObject studentUpperHipTracker;
    float studentUpperHipTrackerPosX;
    float studentUpperHipTrackerPosY;
    float studentUpperHipTrackerPosZ;
    float studentUpperHipTrackerRotX;
    float studentUpperHipTrackerRotY;
    float studentUpperHipTrackerRotZ;
    Vector3 studentUpperHipTrackerPos;
    Vector3 studentUpperHipTrackerRot;

    public GameObject studentLowerHipTracker;
    float studentLowerHipTrackerPosX;
    float studentLowerHipTrackerPosY;
    float studentLowerHipTrackerPosZ;
    float studentLowerHipTrackerRotX;
    float studentLowerHipTrackerRotY;
    float studentLowerHipTrackerRotZ;
    Vector3 studentLowerHipTrackerPos;
    Vector3 studentLowerHipTrackerRot;

    public GameObject studentLeftFootTracker;
    float studentLeftFootTrackerPosX;
    float studentLeftFootTrackerPosY;
    float studentLeftFootTrackerPosZ;
    float studentLeftFootTrackerRotX;
    float studentLeftFootTrackerRotY;
    float studentLeftFootTrackerRotZ;
    Vector3 studentLeftFootTrackerPos;
    Vector3 studentLeftFootTrackerRot;

    public GameObject studentRightFootTracker;
    float studentRightFootTrackerPosX;
    float studentRightFootTrackerPosY;
    float studentRightFootTrackerPosZ;
    float studentRightFootTrackerRotX;
    float studentRightFootTrackerRotY;
    float studentRightFootTrackerRotZ;
    Vector3 studentRightFootTrackerPos;
    Vector3 studentRightFootTrackerRot;

    public GameObject studentBoxTracker;
    float studentBoxTrackerPosX;
    float studentBoxTrackerPosY;
    float studentBoxTrackerPosZ;
    float studentBoxTrackerRotX;
    float studentBoxTrackerRotY;
    float studentBoxTrackerRotZ;
    Vector3 studentBoxTrackerPos;
    Vector3 studentBoxTrackerRot;

    public GameObject studentTableTracker;
    float studentTableTrackerPosX;
    float studentTableTrackerPosY;
    float studentTableTrackerPosZ;
    float studentTableTrackerRotX;
    float studentTableTrackerRotY;
    float studentTableTrackerRotZ;
    Vector3 studentTableTrackerPos;
    Vector3 studentTableTrackerRot;

    // avatar references
    public GameObject studentHead;
    float studentHeadPosX;
    float studentHeadPosY;
    float studentHeadPosZ;
    float studentHeadRotX;
    float studentHeadRotY;
    float studentHeadRotZ;
    Vector3 studentHeadPos;
    Vector3 studentHeadRot;

    public GameObject studentLowerHip;
    float studentLowerHipPosX;
    float studentLowerHipPosY;
    float studentLowerHipPosZ;
    float studentLowerHipRotX;
    float studentLowerHipRotY;
    float studentLowerHipRotZ;
    Vector3 studentLowerHipPos;
    Vector3 studentLowerHipRot;

    public GameObject studentUpperHip;
    float studentUpperHipPosX;
    float studentUpperHipPosY;
    float studentUpperHipPosZ;
    float studentUpperHipRotX;
    float studentUpperHipRotY;
    float studentUpperHipRotZ;
    Vector3 studentUpperHipPos;
    Vector3 studentUpperHipRot;


    public GameObject studentLeftHand;
    float studentLeftHandPosX;
    float studentLeftHandPosY;
    float studentLeftHandPosZ;
    float studentLeftHandRotX;
    float studentLeftHandRotY;
    float studentLeftHandRotZ;
    Vector3 studentLeftHandPos;
    Vector3 studentLeftHandRot;

    public GameObject studentRightHand;
    float studentRightHandPosX;
    float studentRightHandPosY;
    float studentRightHandPosZ;
    float studentRightHandRotX;
    float studentRightHandRotY;
    float studentRightHandRotZ;
    Vector3 studentRightHandPos;
    Vector3 studentRightHandRot;

    public GameObject studentLeftFoot;
    float studentLeftFootPosX;
    float studentLeftFootPosY;
    float studentLeftFootPosZ;
    float studentLeftFootRotX;
    float studentLeftFootRotY;
    float studentLeftFootRotZ;
    Vector3 studentLeftFootPos;
    Vector3 studentLeftFootRot;

    public GameObject studentRightFoot;
    float studentRightFootPosX;
    float studentRightFootPosY;
    float studentRightFootPosZ;
    float studentRightFootRotX;
    float studentRightFootRotY;
    float studentRightFootRotZ;
    Vector3 studentRightFootPos;
    Vector3 studentRightFootRot;

    public GameObject studentLeftShoulder;
    float studentLeftShoulderPosX;
    float studentLeftShoulderPosY;
    float studentLeftShoulderPosZ;
    float studentLeftShoulderRotX;
    float studentLeftShoulderRotY;
    float studentLeftShoulderRotZ;
    Vector3 studentLeftShoulderPos;
    Vector3 studentLeftShoulderRot;

    public GameObject studentRightShoulder;
    float studentRightShoulderPosX;
    float studentRightShoulderPosY;
    float studentRightShoulderPosZ;
    float studentRightShoulderRotX;
    float studentRightShoulderRotY;
    float studentRightShoulderRotZ;
    Vector3 studentRightShoulderPos;
    Vector3 studentRightShoulderRot;

    public GameObject studentLeftElbow;
    float studentLeftElbowPosX;
    float studentLeftElbowPosY;
    float studentLeftElbowPosZ;
    float studentLeftElbowRotX;
    float studentLeftElbowRotY;
    float studentLeftElbowRotZ;
    Vector3 studentLeftElbowPos;
    Vector3 studentLeftElbowRot;

    public GameObject studentRightElbow;
    float studentRightElbowPosX;
    float studentRightElbowPosY;
    float studentRightElbowPosZ;
    float studentRightElbowRotX;
    float studentRightElbowRotY;
    float studentRightElbowRotZ;
    Vector3 studentRightElbowPos;
    Vector3 studentRightElbowRot;

    public GameObject studentLeftKnee;
    float studentLeftKneePosX;
    float studentLeftKneePosY;
    float studentLeftKneePosZ;
    float studentLeftKneeRotX;
    float studentLeftKneeRotY;
    float studentLeftKneeRotZ;
    Vector3 studentLeftKneePos;
    Vector3 studentLeftKneeRot;

    public GameObject studentRightKnee;
    float studentRightKneePosX;
    float studentRightKneePosY;
    float studentRightKneePosZ;
    float studentRightKneeRotX;
    float studentRightKneeRotY;
    float studentRightKneeRotZ;
    Vector3 studentRightKneePos;
    Vector3 studentRightKneeRot;


    public GameObject studentBox;
    float studentBoxPosX;
    float studentBoxPosY;
    float studentBoxPosZ;
    float studentBoxRotX;
    float studentBoxRotY;
    float studentBoxRotZ;
    Vector3 studentBoxPos;
    Vector3 studentBoxRot;

    public GameObject studentTable;
    float studentTablePosX;
    float studentTablePosY;
    float studentTablePosZ;
    float studentTableRotX;
    float studentTableRotY;
    float studentTableRotZ;
    Vector3 studentTablePos;
    Vector3 studentTableRot;



    // teacher
    // tracker
    public GameObject teacherHMD;
    float teacherHMDPosX;
    float teacherHMDPosY;
    float teacherHMDPosZ;
    float teacherHMDRotX;
    float teacherHMDRotY;
    float teacherHMDRotZ;
    Vector3 rFooteacherHMDPos;
    Vector3 teacherHMDRot;

    public GameObject teacherLeftHandTracker;
    float teacherLeftHandTrackerPosX;
    float teacherLeftHandTrackerPosY;
    float teacherLeftHandTrackerPosZ;
    float teacherLeftHandTrackerRotX;
    float teacherLeftHandTrackerRotY;
    float teacherLeftHandTrackerRotZ;
    Vector3 teacherLeftHandTrackerPos;
    Vector3 teacherLeftHandTrackerRot;

    public GameObject teacherRightHandTracker;
    float teacherRightHandTrackerPosX;
    float teacherRightHandTrackerPosY;
    float teacherRightHandTrackerPosZ;
    float teacherRightHandTrackerRotX;
    float teacherRightHandTrackerRotY;
    float teacherRightHandTrackerRotZ;
    Vector3 teacherRightHandTrackerPos;
    Vector3 teacherRightHandTrackerRot;

    public GameObject teacherLeftShoulderTracker;
    float teacherLeftShoulderTrackerPosX;
    float teacherLeftShoulderTrackerPosY;
    float teacherLeftShoulderTrackerPosZ;
    float teacherLeftShoulderTrackerRotX;
    float teacherLeftShoulderTrackerRotY;
    float teacherLeftShoulderTrackerRotZ;
    Vector3 teacherLeftShoulderTrackerPos;
    Vector3 teacherLeftShoulderTrackerRot;

    public GameObject teacherRightShoulderTracker;
    float teacherRightShoulderTrackerPosX;
    float teacherRightShoulderTrackerPosY;
    float teacherRightShoulderTrackerPosZ;
    float teacherRightShoulderTrackerRotX;
    float teacherRightShoulderTrackerRotY;
    float teacherRightShoulderTrackerRotZ;
    Vector3 teacherRightShoulderTrackerPos;
    Vector3 teacherRightShoulderTrackerRot;

    public GameObject teacherUpperHipTracker;
    float teacherUpperHipTrackerPosX;
    float teacherUpperHipTrackerPosY;
    float teacherUpperHipTrackerPosZ;
    float teacherUpperHipTrackerRotX;
    float teacherUpperHipTrackerRotY;
    float teacherUpperHipTrackerRotZ;
    Vector3 teacherUpperHipTrackerPos;
    Vector3 teacherUpperHipTrackerRot;

    public GameObject teacherLowerHipTracker;
    float teacherLowerHipTrackerPosX;
    float teacherLowerHipTrackerPosY;
    float teacherLowerHipTrackerPosZ;
    float teacherLowerHipTrackerRotX;
    float teacherLowerHipTrackerRotY;
    float teacherLowerHipTrackerRotZ;
    Vector3 teacherLowerHipTrackerPos;
    Vector3 teacherLowerHipTrackerRot;

    public GameObject teacherLeftFootTracker;
    float teacherLeftFootTrackerPosX;
    float teacherLeftFootTrackerPosY;
    float teacherLeftFootTrackerPosZ;
    float teacherLeftFootTrackerRotX;
    float teacherLeftFootTrackerRotY;
    float teacherLeftFootTrackerRotZ;
    Vector3 teacherLeftFootTrackerPos;
    Vector3 teacherLeftFootTrackerRot;

    public GameObject teacherRightFootTracker;
    float teacherRightFootTrackerPosX;
    float teacherRightFootTrackerPosY;
    float teacherRightFootTrackerPosZ;
    float teacherRightFootTrackerRotX;
    float teacherRightFootTrackerRotY;
    float teacherRightFootTrackerRotZ;
    Vector3 teacherRightFootTrackerPos;
    Vector3 teacherRightFootTrackerRot;

    public GameObject teacherBoxTracker;
    float teacherBoxTrackerPosX;
    float teacherBoxTrackerPosY;
    float teacherBoxTrackerPosZ;
    float teacherBoxTrackerRotX;
    float teacherBoxTrackerRotY;
    float teacherBoxTrackerRotZ;
    Vector3 teacherBoxTrackerPos;
    Vector3 teacherBoxTrackerRot;

    public GameObject teacherTableTracker;
    float teacherTableTrackerPosX;
    float teacherTableTrackerPosY;
    float teacherTableTrackerPosZ;
    float teacherTableTrackerRotX;
    float teacherTableTrackerRotY;
    float teacherTableTrackerRotZ;
    Vector3 teacherTableTrackerPos;
    Vector3 teacherTableTrackerRot;

    // avatar references
    public GameObject teacherHead;
    float teacherHeadPosX;
    float teacherHeadPosY;
    float teacherHeadPosZ;
    float teacherHeadRotX;
    float teacherHeadRotY;
    float teacherHeadRotZ;
    Vector3 teacherHeadPos;
    Vector3 teacherHeadRot;

    public GameObject teacherLowerHip;
    float teacherLowerHipPosX;
    float teacherLowerHipPosY;
    float teacherLowerHipPosZ;
    float teacherLowerHipRotX;
    float teacherLowerHipRotY;
    float teacherLowerHipRotZ;
    Vector3 teacherLowerHipPos;
    Vector3 teacherLowerHipRot;

    public GameObject teacherUpperHip;
    float teacherUpperHipPosX;
    float teacherUpperHipPosY;
    float teacherUpperHipPosZ;
    float teacherUpperHipRotX;
    float teacherUpperHipRotY;
    float teacherUpperHipRotZ;
    Vector3 teacherUpperHipPos;
    Vector3 teacherUpperHipRot;


    public GameObject teacherLeftHand;
    float teacherLeftHandPosX;
    float teacherLeftHandPosY;
    float teacherLeftHandPosZ;
    float teacherLeftHandRotX;
    float teacherLeftHandRotY;
    float teacherLeftHandRotZ;
    Vector3 teacherLeftHandPos;
    Vector3 teacherLeftHandRot;

    public GameObject teacherRightHand;
    float teacherRightHandPosX;
    float teacherRightHandPosY;
    float teacherRightHandPosZ;
    float teacherRightHandRotX;
    float teacherRightHandRotY;
    float teacherRightHandRotZ;
    Vector3 teacherRightHandPos;
    Vector3 teacherRightHandRot;

    public GameObject teacherLeftFoot;
    float teacherLeftFootPosX;
    float teacherLeftFootPosY;
    float teacherLeftFootPosZ;
    float teacherLeftFootRotX;
    float teacherLeftFootRotY;
    float teacherLeftFootRotZ;
    Vector3 teacherLeftFootPos;
    Vector3 teacherLeftFootRot;

    public GameObject teacherRightFoot;
    float teacherRightFootPosX;
    float teacherRightFootPosY;
    float teacherRightFootPosZ;
    float teacherRightFootRotX;
    float teacherRightFootRotY;
    float teacherRightFootRotZ;
    Vector3 teacherRightFootPos;
    Vector3 teacherRightFootRot;

    public GameObject teacherLeftShoulder;
    float teacherLeftShoulderPosX;
    float teacherLeftShoulderPosY;
    float teacherLeftShoulderPosZ;
    float teacherLeftShoulderRotX;
    float teacherLeftShoulderRotY;
    float teacherLeftShoulderRotZ;
    Vector3 teacherLeftShoulderPos;
    Vector3 teacherLeftShoulderRot;

    public GameObject teacherRightShoulder;
    float teacherRightShoulderPosX;
    float teacherRightShoulderPosY;
    float teacherRightShoulderPosZ;
    float teacherRightShoulderRotX;
    float teacherRightShoulderRotY;
    float teacherRightShoulderRotZ;
    Vector3 teacherRightShoulderPos;
    Vector3 teacherRightShoulderRot;

    public GameObject teacherLeftElbow;
    float teacherLeftElbowPosX;
    float teacherLeftElbowPosY;
    float teacherLeftElbowPosZ;
    float teacherLeftElbowRotX;
    float teacherLeftElbowRotY;
    float teacherLeftElbowRotZ;
    Vector3 teacherLeftElbowPos;
    Vector3 teacherLeftElbowRot;

    public GameObject teacherRightElbow;
    float teacherRightElbowPosX;
    float teacherRightElbowPosY;
    float teacherRightElbowPosZ;
    float teacherRightElbowRotX;
    float teacherRightElbowRotY;
    float teacherRightElbowRotZ;
    Vector3 teacherRightElbowPos;
    Vector3 teacherRightElbowRot;

    public GameObject teacherLeftKnee;
    float teacherLeftKneePosX;
    float teacherLeftKneePosY;
    float teacherLeftKneePosZ;
    float teacherLeftKneeRotX;
    float teacherLeftKneeRotY;
    float teacherLeftKneeRotZ;
    Vector3 teacherLeftKneePos;
    Vector3 teacherLeftKneeRot;

    public GameObject teacherRightKnee;
    float teacherRightKneePosX;
    float teacherRightKneePosY;
    float teacherRightKneePosZ;
    float teacherRightKneeRotX;
    float teacherRightKneeRotY;
    float teacherRightKneeRotZ;
    Vector3 teacherRightKneePos;
    Vector3 teacherRightKneeRot;


    public GameObject teacherBox;
    float teacherBoxPosX;
    float teacherBoxPosY;
    float teacherBoxPosZ;
    float teacherBoxRotX;
    float teacherBoxRotY;
    float teacherBoxRotZ;
    Vector3 teacherBoxPos;
    Vector3 teacherBoxRot;

    public GameObject teacherTable;
    float teacherTablePosX;
    float teacherTablePosY;
    float teacherTablePosZ;
    float teacherTableRotX;
    float teacherTableRotY;
    float teacherTableRotZ;
    Vector3 teacherTablePos;
    Vector3 teacherTableRot;

    // risk measurements
    bool isFeetPlacementError;
    float feetDistance;
    bool isSquatError;
    float squatDistance;
    bool isSpineTwistError;
    float spineTwistAngle;
    bool isSpindBendError;
    float spineBendAngle;

    string rayTraceHitTeacherId;
    float distanceStudentTeacherBox;



    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
        file = new System.IO.StreamWriter(path + fileName, true);
        string csvHeader = "milisecondsElapsed;time;studentHMDPosX;studentHMDPosY;studentHMDPosZ;studentHMDRotX;studentHMDRotY;studentHMDRotZ;rFoostudentHMDPos;studentHMDRot;studentLeftHandTrackerPosX;studentLeftHandTrackerPosY;studentLeftHandTrackerPosZ;studentLeftHandTrackerRotX;studentLeftHandTrackerRotY;studentLeftHandTrackerRotZ;studentLeftHandTrackerPos;studentLeftHandTrackerRot;studentRightHandTrackerPosX;studentRightHandTrackerPosY;studentRightHandTrackerPosZ;studentRightHandTrackerRotX;studentRightHandTrackerRotY;studentRightHandTrackerRotZ;studentRightHandTrackerPos;studentRightHandTrackerRot;studentLeftShoulderTrackerPosX;studentLeftShoulderTrackerPosY;studentLeftShoulderTrackerPosZ;studentLeftShoulderTrackerRotX;studentLeftShoulderTrackerRotY;studentLeftShoulderTrackerRotZ;studentLeftShoulderTrackerPos;studentLeftShoulderTrackerRot;studentRightShoulderTrackerPosX;studentRightShoulderTrackerPosY;studentRightShoulderTrackerPosZ;studentRightShoulderTrackerRotX;studentRightShoulderTrackerRotY;studentRightShoulderTrackerRotZ;studentRightShoulderTrackerPos;studentRightShoulderTrackerRot;studentUpperHipTrackerPosX;studentUpperHipTrackerPosY;studentUpperHipTrackerPosZ;studentUpperHipTrackerRotX;studentUpperHipTrackerRotY;studentUpperHipTrackerRotZ;studentUpperHipTrackerPos;studentUpperHipTrackerRot;studentLowerHipTrackerPosX;studentLowerHipTrackerPosY;studentLowerHipTrackerPosZ;studentLowerHipTrackerRotX;studentLowerHipTrackerRotY;studentLowerHipTrackerRotZ;studentLowerHipTrackerPos;studentLowerHipTrackerRot;studentLeftFootTrackerPosX;studentLeftFootTrackerPosY;studentLeftFootTrackerPosZ;studentLeftFootTrackerRotX;studentLeftFootTrackerRotY;studentLeftFootTrackerRotZ;studentLeftFootTrackerPos;studentLeftFootTrackerRot;studentRightFootTrackerPosX;studentRightFootTrackerPosY;studentRightFootTrackerPosZ;studentRightFootTrackerRotX;studentRightFootTrackerRotY;studentRightFootTrackerRotZ;studentRightFootTrackerPos;studentRightFootTrackerRot;studentBoxTrackerPosX;studentBoxTrackerPosY;studentBoxTrackerPosZ;studentBoxTrackerRotX;studentBoxTrackerRotY;studentBoxTrackerRotZ;studentBoxTrackerPos;studentBoxTrackerRot;studentTableTrackerPosX;studentTableTrackerPosY;studentTableTrackerPosZ;studentTableTrackerRotX;studentTableTrackerRotY;studentTableTrackerRotZ;studentTableTrackerPos;studentTableTrackerRot;// avatar referencesstudentHeadPosX;studentHeadPosY;studentHeadPosZ;studentHeadRotX;studentHeadRotY;studentHeadRotZ;studentHeadPos;studentHeadRot;studentLowerHipPosX;studentLowerHipPosY;studentLowerHipPosZ;studentLowerHipRotX;studentLowerHipRotY;studentLowerHipRotZ;studentLowerHipPos;studentLowerHipRot;studentUpperHipPosX;studentUpperHipPosY;studentUpperHipPosZ;studentUpperHipRotX;studentUpperHipRotY;studentUpperHipRotZ;studentUpperHipPos;studentUpperHipRot;studentLeftHandPosX;studentLeftHandPosY;studentLeftHandPosZ;studentLeftHandRotX;studentLeftHandRotY;studentLeftHandRotZ;studentLeftHandPos;studentLeftHandRot;studentRightHandPosX;studentRightHandPosY;studentRightHandPosZ;studentRightHandRotX;studentRightHandRotY;studentRightHandRotZ;studentRightHandPos;studentRightHandRot;studentLeftFootPosX;studentLeftFootPosY;studentLeftFootPosZ;studentLeftFootRotX;studentLeftFootRotY;studentLeftFootRotZ;studentLeftFootPos;studentLeftFootRot;studentRightFootPosX;studentRightFootPosY;studentRightFootPosZ;studentRightFootRotX;studentRightFootRotY;studentRightFootRotZ;studentRightFootPos;studentRightFootRot;studentLeftShoulderPosX;studentLeftShoulderPosY;studentLeftShoulderPosZ;studentLeftShoulderRotX;studentLeftShoulderRotY;studentLeftShoulderRotZ;studentLeftShoulderPos;studentLeftShoulderRot;studentRightShoulderPosX;studentRightShoulderPosY;studentRightShoulderPosZ;studentRightShoulderRotX;studentRightShoulderRotY;studentRightShoulderRotZ;studentRightShoulderPos;studentRightShoulderRot;studentLeftElbowPosX;studentLeftElbowPosY;studentLeftElbowPosZ;studentLeftElbowRotX;studentLeftElbowRotY;studentLeftElbowRotZ;studentLeftElbowPos;studentLeftElbowRot;studentRightElbowPosX;studentRightElbowPosY;studentRightElbowPosZ;studentRightElbowRotX;studentRightElbowRotY;studentRightElbowRotZ;studentRightElbowPos;studentRightElbowRot;studentLeftKneePosX;studentLeftKneePosY;studentLeftKneePosZ;studentLeftKneeRotX;studentLeftKneeRotY;studentLeftKneeRotZ;studentLeftKneePos;studentLeftKneeRot;studentRightKneePosX;studentRightKneePosY;studentRightKneePosZ;studentRightKneeRotX;studentRightKneeRotY;studentRightKneeRotZ;studentRightKneePos;studentRightKneeRot;studentBoxPosX;studentBoxPosY;studentBoxPosZ;studentBoxRotX;studentBoxRotY;studentBoxRotZ;studentBoxPos;studentBoxRot;studentTablePosX;studentTablePosY;studentTablePosZ;studentTableRotX;studentTableRotY;studentTableRotZ;studentTablePos;studentTableRot;// teacher// trackerteacherHMDPosX;teacherHMDPosY;teacherHMDPosZ;teacherHMDRotX;teacherHMDRotY;teacherHMDRotZ;rFooteacherHMDPos;teacherHMDRot;teacherLeftHandTrackerPosX;teacherLeftHandTrackerPosY;teacherLeftHandTrackerPosZ;teacherLeftHandTrackerRotX;teacherLeftHandTrackerRotY;teacherLeftHandTrackerRotZ;teacherLeftHandTrackerPos;teacherLeftHandTrackerRot;teacherRightHandTrackerPosX;teacherRightHandTrackerPosY;teacherRightHandTrackerPosZ;teacherRightHandTrackerRotX;teacherRightHandTrackerRotY;teacherRightHandTrackerRotZ;teacherRightHandTrackerPos;teacherRightHandTrackerRot;teacherLeftShoulderTrackerPosX;teacherLeftShoulderTrackerPosY;teacherLeftShoulderTrackerPosZ;teacherLeftShoulderTrackerRotX;teacherLeftShoulderTrackerRotY;teacherLeftShoulderTrackerRotZ;teacherLeftShoulderTrackerPos;teacherLeftShoulderTrackerRot;teacherRightShoulderTrackerPosX;teacherRightShoulderTrackerPosY;teacherRightShoulderTrackerPosZ;teacherRightShoulderTrackerRotX;teacherRightShoulderTrackerRotY;teacherRightShoulderTrackerRotZ;teacherRightShoulderTrackerPos;teacherRightShoulderTrackerRot;teacherUpperHipTrackerPosX;teacherUpperHipTrackerPosY;teacherUpperHipTrackerPosZ;teacherUpperHipTrackerRotX;teacherUpperHipTrackerRotY;teacherUpperHipTrackerRotZ;teacherUpperHipTrackerPos;teacherUpperHipTrackerRot;teacherLowerHipTrackerPosX;teacherLowerHipTrackerPosY;teacherLowerHipTrackerPosZ;teacherLowerHipTrackerRotX;teacherLowerHipTrackerRotY;teacherLowerHipTrackerRotZ;teacherLowerHipTrackerPos;teacherLowerHipTrackerRot;teacherLeftFootTrackerPosX;teacherLeftFootTrackerPosY;teacherLeftFootTrackerPosZ;teacherLeftFootTrackerRotX;teacherLeftFootTrackerRotY;teacherLeftFootTrackerRotZ;teacherLeftFootTrackerPos;teacherLeftFootTrackerRot;teacherRightFootTrackerPosX;teacherRightFootTrackerPosY;teacherRightFootTrackerPosZ;teacherRightFootTrackerRotX;teacherRightFootTrackerRotY;teacherRightFootTrackerRotZ;teacherRightFootTrackerPos;teacherRightFootTrackerRot;teacherBoxTrackerPosX;teacherBoxTrackerPosY;teacherBoxTrackerPosZ;teacherBoxTrackerRotX;teacherBoxTrackerRotY;teacherBoxTrackerRotZ;teacherBoxTrackerPos;teacherBoxTrackerRot;teacherTableTrackerPosX;teacherTableTrackerPosY;teacherTableTrackerPosZ;teacherTableTrackerRotX;teacherTableTrackerRotY;teacherTableTrackerRotZ;teacherTableTrackerPos;teacherTableTrackerRot;// avatar referencesteacherHeadPosX;teacherHeadPosY;teacherHeadPosZ;teacherHeadRotX;teacherHeadRotY;teacherHeadRotZ;teacherHeadPos;teacherHeadRot;teacherLowerHipPosX;teacherLowerHipPosY;teacherLowerHipPosZ;teacherLowerHipRotX;teacherLowerHipRotY;teacherLowerHipRotZ;teacherLowerHipPos;teacherLowerHipRot;teacherUpperHipPosX;teacherUpperHipPosY;teacherUpperHipPosZ;teacherUpperHipRotX;teacherUpperHipRotY;teacherUpperHipRotZ;teacherUpperHipPos;teacherUpperHipRot;teacherLeftHandPosX;teacherLeftHandPosY;teacherLeftHandPosZ;teacherLeftHandRotX;teacherLeftHandRotY;teacherLeftHandRotZ;teacherLeftHandPos;teacherLeftHandRot;teacherRightHandPosX;teacherRightHandPosY;teacherRightHandPosZ;teacherRightHandRotX;teacherRightHandRotY;teacherRightHandRotZ;teacherRightHandPos;teacherRightHandRot;teacherLeftFootPosX;teacherLeftFootPosY;teacherLeftFootPosZ;teacherLeftFootRotX;teacherLeftFootRotY;teacherLeftFootRotZ;teacherLeftFootPos;teacherLeftFootRot;teacherRightFootPosX;teacherRightFootPosY;teacherRightFootPosZ;teacherRightFootRotX;teacherRightFootRotY;teacherRightFootRotZ;teacherRightFootPos;teacherRightFootRot;teacherLeftShoulderPosX;teacherLeftShoulderPosY;teacherLeftShoulderPosZ;teacherLeftShoulderRotX;teacherLeftShoulderRotY;teacherLeftShoulderRotZ;teacherLeftShoulderPos;teacherLeftShoulderRot;teacherRightShoulderPosX;teacherRightShoulderPosY;teacherRightShoulderPosZ;teacherRightShoulderRotX;teacherRightShoulderRotY;teacherRightShoulderRotZ;teacherRightShoulderPos;teacherRightShoulderRot;teacherLeftElbowPosX;teacherLeftElbowPosY;teacherLeftElbowPosZ;teacherLeftElbowRotX;teacherLeftElbowRotY;teacherLeftElbowRotZ;teacherLeftElbowPos;teacherLeftElbowRot;teacherRightElbowPosX;teacherRightElbowPosY;teacherRightElbowPosZ;teacherRightElbowRotX;teacherRightElbowRotY;teacherRightElbowRotZ;teacherRightElbowPos;teacherRightElbowRot;teacherLeftKneePosX;teacherLeftKneePosY;teacherLeftKneePosZ;teacherLeftKneeRotX;teacherLeftKneeRotY;teacherLeftKneeRotZ;teacherLeftKneePos;teacherLeftKneeRot;teacherRightKneePosX;teacherRightKneePosY;teacherRightKneePosZ;teacherRightKneeRotX;teacherRightKneeRotY;teacherRightKneeRotZ;teacherRightKneePos;teacherRightKneeRot;teacherBoxPosX;teacherBoxPosY;teacherBoxPosZ;teacherBoxRotX;teacherBoxRotY;teacherBoxRotZ;teacherBoxPos;teacherBoxRot;teacherTablePosX;teacherTablePosY;teacherTablePosZ;teacherTableRotX;teacherTableRotY;teacherTableRotZ;teacherTablePos;teacherTableRot;";
        file.WriteLine(csvHeader);

        studentHMDPosX = studentHMD.transform.position.x;
        studentHMDPosY = studentHMD.transform.position.y;
        studentHMDPosZ = studentHMD.transform.position.z;
        studentHMDRotX = studentHMD.transform.position.x;
        studentHMDRotY = studentHMD.transform.position.y;
        studentHMDRotZ = studentHMD.transform.position.z;
        rFoostudentHMDPos = studentHMD.transform.position;
        studentHMDRot = studentHMD.transform.rotation.eulerAngles;
        /*


               studentLeftHandTrackerPosX;
               studentLeftHandTrackerPosY;
               studentLeftHandTrackerPosZ;
               studentLeftHandTrackerRotX;
               studentLeftHandTrackerRotY;
               studentLeftHandTrackerRotZ;
               studentLeftHandTrackerPos;
               studentLeftHandTrackerRot;


               studentRightHandTrackerPosX;
               studentRightHandTrackerPosY;
               studentRightHandTrackerPosZ;
               studentRightHandTrackerRotX;
               studentRightHandTrackerRotY;
               studentRightHandTrackerRotZ;
               studentRightHandTrackerPos;
               studentRightHandTrackerRot;

               studentLeftShoulderTrackerPosX;
               studentLeftShoulderTrackerPosY;
               studentLeftShoulderTrackerPosZ;
               studentLeftShoulderTrackerRotX;
               studentLeftShoulderTrackerRotY;
               studentLeftShoulderTrackerRotZ;
               studentLeftShoulderTrackerPos;
               studentLeftShoulderTrackerRot;

               studentRightShoulderTrackerPosX;
               studentRightShoulderTrackerPosY;
               studentRightShoulderTrackerPosZ;
               studentRightShoulderTrackerRotX;
               studentRightShoulderTrackerRotY;
               studentRightShoulderTrackerRotZ;
               studentRightShoulderTrackerPos;
               studentRightShoulderTrackerRot;

               studentUpperHipTrackerPosX;
               studentUpperHipTrackerPosY;
               studentUpperHipTrackerPosZ;
               studentUpperHipTrackerRotX;
               studentUpperHipTrackerRotY;
               studentUpperHipTrackerRotZ;
               studentUpperHipTrackerPos;
               studentUpperHipTrackerRot;

               studentLowerHipTrackerPosX;
               studentLowerHipTrackerPosY;
               studentLowerHipTrackerPosZ;
               studentLowerHipTrackerRotX;
               studentLowerHipTrackerRotY;
               studentLowerHipTrackerRotZ;
               studentLowerHipTrackerPos;
               studentLowerHipTrackerRot;

               studentLeftFootTrackerPosX;
               studentLeftFootTrackerPosY;
               studentLeftFootTrackerPosZ;
               studentLeftFootTrackerRotX;
               studentLeftFootTrackerRotY;
               studentLeftFootTrackerRotZ;
               studentLeftFootTrackerPos;
               studentLeftFootTrackerRot;

               studentRightFootTrackerPosX;
               studentRightFootTrackerPosY;
               studentRightFootTrackerPosZ;
               studentRightFootTrackerRotX;
               studentRightFootTrackerRotY;
               studentRightFootTrackerRotZ;
               studentRightFootTrackerPos;
               studentRightFootTrackerRot;

               studentBoxTrackerPosX;
               studentBoxTrackerPosY;
               studentBoxTrackerPosZ;
               studentBoxTrackerRotX;
               studentBoxTrackerRotY;
               studentBoxTrackerRotZ;
               studentBoxTrackerPos;
               studentBoxTrackerRot;

               studentTableTrackerPosX;
               studentTableTrackerPosY;
               studentTableTrackerPosZ;
               studentTableTrackerRotX;
               studentTableTrackerRotY;
               studentTableTrackerRotZ;
               studentTableTrackerPos;
               studentTableTrackerRot;

               // avatar references
               studentHeadPosX;
               studentHeadPosY;
               studentHeadPosZ;
               studentHeadRotX;
               studentHeadRotY;
               studentHeadRotZ;
               studentHeadPos;
               studentHeadRot;

               studentLowerHipPosX;
               studentLowerHipPosY;
               studentLowerHipPosZ;
               studentLowerHipRotX;
               studentLowerHipRotY;
               studentLowerHipRotZ;
               studentLowerHipPos;
               studentLowerHipRot;

               studentUpperHipPosX;
               studentUpperHipPosY;
               studentUpperHipPosZ;
               studentUpperHipRotX;
               studentUpperHipRotY;
               studentUpperHipRotZ;
               studentUpperHipPos;
               studentUpperHipRot;

               studentLeftHandPosX;
               studentLeftHandPosY;
               studentLeftHandPosZ;
               studentLeftHandRotX;
               studentLeftHandRotY;
               studentLeftHandRotZ;
               studentLeftHandPos;
               studentLeftHandRot;

               studentRightHandPosX;
               studentRightHandPosY;
               studentRightHandPosZ;
               studentRightHandRotX;
               studentRightHandRotY;
               studentRightHandRotZ;
               studentRightHandPos;
               studentRightHandRot;

               studentLeftFootPosX;
               studentLeftFootPosY;
               studentLeftFootPosZ;
               studentLeftFootRotX;
               studentLeftFootRotY;
               studentLeftFootRotZ;
               studentLeftFootPos;
               studentLeftFootRot;

               studentRightFootPosX;
               studentRightFootPosY;
               studentRightFootPosZ;
               studentRightFootRotX;
               studentRightFootRotY;
               studentRightFootRotZ;
               studentRightFootPos;
               studentRightFootRot;

               studentLeftShoulderPosX;
               studentLeftShoulderPosY;
               studentLeftShoulderPosZ;
               studentLeftShoulderRotX;
               studentLeftShoulderRotY;
               studentLeftShoulderRotZ;
               studentLeftShoulderPos;
               studentLeftShoulderRot;

               studentRightShoulderPosX;
               studentRightShoulderPosY;
               studentRightShoulderPosZ;
               studentRightShoulderRotX;
               studentRightShoulderRotY;
               studentRightShoulderRotZ;
               studentRightShoulderPos;
               studentRightShoulderRot;

               studentLeftElbowPosX;
               studentLeftElbowPosY;
               studentLeftElbowPosZ;
               studentLeftElbowRotX;
               studentLeftElbowRotY;
               studentLeftElbowRotZ;
               studentLeftElbowPos;
               studentLeftElbowRot;

               studentRightElbowPosX;
               studentRightElbowPosY;
               studentRightElbowPosZ;
               studentRightElbowRotX;
               studentRightElbowRotY;
               studentRightElbowRotZ;
               studentRightElbowPos;
               studentRightElbowRot;

               studentLeftKneePosX;
               studentLeftKneePosY;
               studentLeftKneePosZ;
               studentLeftKneeRotX;
               studentLeftKneeRotY;
               studentLeftKneeRotZ;
               studentLeftKneePos;
               studentLeftKneeRot;

               studentRightKneePosX;
               studentRightKneePosY;
               studentRightKneePosZ;
               studentRightKneeRotX;
               studentRightKneeRotY;
               studentRightKneeRotZ;
               studentRightKneePos;
               studentRightKneeRot;

               studentBoxPosX;
               studentBoxPosY;
               studentBoxPosZ;
               studentBoxRotX;
               studentBoxRotY;
               studentBoxRotZ;
               studentBoxPos;
               studentBoxRot;

               studentTablePosX;
               studentTablePosY;
               studentTablePosZ;
               studentTableRotX;
               studentTableRotY;
               studentTableRotZ;
               studentTablePos;
               studentTableRot;

               // teacher
               // tracker
               teacherHMDPosX;
               teacherHMDPosY;
               teacherHMDPosZ;
               teacherHMDRotX;
               teacherHMDRotY;
               teacherHMDRotZ;
               rFooteacherHMDPos;
               teacherHMDRot;

               teacherLeftHandTrackerPosX;
               teacherLeftHandTrackerPosY;
               teacherLeftHandTrackerPosZ;
               teacherLeftHandTrackerRotX;
               teacherLeftHandTrackerRotY;
               teacherLeftHandTrackerRotZ;
               teacherLeftHandTrackerPos;
               teacherLeftHandTrackerRot;

               teacherRightHandTrackerPosX;
               teacherRightHandTrackerPosY;
               teacherRightHandTrackerPosZ;
               teacherRightHandTrackerRotX;
               teacherRightHandTrackerRotY;
               teacherRightHandTrackerRotZ;
               teacherRightHandTrackerPos;
               teacherRightHandTrackerRot;

               teacherLeftShoulderTrackerPosX;
               teacherLeftShoulderTrackerPosY;
               teacherLeftShoulderTrackerPosZ;
               teacherLeftShoulderTrackerRotX;
               teacherLeftShoulderTrackerRotY;
               teacherLeftShoulderTrackerRotZ;
               teacherLeftShoulderTrackerPos;
               teacherLeftShoulderTrackerRot;

               teacherRightShoulderTrackerPosX;
               teacherRightShoulderTrackerPosY;
               teacherRightShoulderTrackerPosZ;
               teacherRightShoulderTrackerRotX;
               teacherRightShoulderTrackerRotY;
               teacherRightShoulderTrackerRotZ;
               teacherRightShoulderTrackerPos;
               teacherRightShoulderTrackerRot;

               teacherUpperHipTrackerPosX;
               teacherUpperHipTrackerPosY;
               teacherUpperHipTrackerPosZ;
               teacherUpperHipTrackerRotX;
               teacherUpperHipTrackerRotY;
               teacherUpperHipTrackerRotZ;
               teacherUpperHipTrackerPos;
               teacherUpperHipTrackerRot;

               teacherLowerHipTrackerPosX;
               teacherLowerHipTrackerPosY;
               teacherLowerHipTrackerPosZ;
               teacherLowerHipTrackerRotX;
               teacherLowerHipTrackerRotY;
               teacherLowerHipTrackerRotZ;
               teacherLowerHipTrackerPos;
               teacherLowerHipTrackerRot;

               teacherLeftFootTrackerPosX;
               teacherLeftFootTrackerPosY;
               teacherLeftFootTrackerPosZ;
               teacherLeftFootTrackerRotX;
               teacherLeftFootTrackerRotY;
               teacherLeftFootTrackerRotZ;
               teacherLeftFootTrackerPos;
               teacherLeftFootTrackerRot;

               teacherRightFootTrackerPosX;
               teacherRightFootTrackerPosY;
               teacherRightFootTrackerPosZ;
               teacherRightFootTrackerRotX;
               teacherRightFootTrackerRotY;
               teacherRightFootTrackerRotZ;
               teacherRightFootTrackerPos;
               teacherRightFootTrackerRot;

               teacherBoxTrackerPosX;
               teacherBoxTrackerPosY;
               teacherBoxTrackerPosZ;
               teacherBoxTrackerRotX;
               teacherBoxTrackerRotY;
               teacherBoxTrackerRotZ;
               teacherBoxTrackerPos;
               teacherBoxTrackerRot;

               teacherTableTrackerPosX;
               teacherTableTrackerPosY;
               teacherTableTrackerPosZ;
               teacherTableTrackerRotX;
               teacherTableTrackerRotY;
               teacherTableTrackerRotZ;
               teacherTableTrackerPos;
               teacherTableTrackerRot;

               // avatar references
               teacherHeadPosX;
               teacherHeadPosY;
               teacherHeadPosZ;
               teacherHeadRotX;
               teacherHeadRotY;
               teacherHeadRotZ;
               teacherHeadPos;
               teacherHeadRot;

               teacherLowerHipPosX;
               teacherLowerHipPosY;
               teacherLowerHipPosZ;
               teacherLowerHipRotX;
               teacherLowerHipRotY;
               teacherLowerHipRotZ;
               teacherLowerHipPos;
               teacherLowerHipRot;

               teacherUpperHipPosX;
               teacherUpperHipPosY;
               teacherUpperHipPosZ;
               teacherUpperHipRotX;
               teacherUpperHipRotY;
               teacherUpperHipRotZ;
               teacherUpperHipPos;
               teacherUpperHipRot;

               teacherLeftHandPosX;
               teacherLeftHandPosY;
               teacherLeftHandPosZ;
               teacherLeftHandRotX;
               teacherLeftHandRotY;
               teacherLeftHandRotZ;
               teacherLeftHandPos;
               teacherLeftHandRot;

               teacherRightHandPosX;
               teacherRightHandPosY;
               teacherRightHandPosZ;
               teacherRightHandRotX;
               teacherRightHandRotY;
               teacherRightHandRotZ;
               teacherRightHandPos;
               teacherRightHandRot;

               teacherLeftFootPosX;
               teacherLeftFootPosY;
               teacherLeftFootPosZ;
               teacherLeftFootRotX;
               teacherLeftFootRotY;
               teacherLeftFootRotZ;
               teacherLeftFootPos;
               teacherLeftFootRot;

               teacherRightFootPosX;
               teacherRightFootPosY;
               teacherRightFootPosZ;
               teacherRightFootRotX;
               teacherRightFootRotY;
               teacherRightFootRotZ;
               teacherRightFootPos;
               teacherRightFootRot;

               teacherLeftShoulderPosX;
               teacherLeftShoulderPosY;
               teacherLeftShoulderPosZ;
               teacherLeftShoulderRotX;
               teacherLeftShoulderRotY;
               teacherLeftShoulderRotZ;
               teacherLeftShoulderPos;
               teacherLeftShoulderRot;

               teacherRightShoulderPosX;
               teacherRightShoulderPosY;
               teacherRightShoulderPosZ;
               teacherRightShoulderRotX;
               teacherRightShoulderRotY;
               teacherRightShoulderRotZ;
               teacherRightShoulderPos;
               teacherRightShoulderRot;

               teacherLeftElbowPosX;
               teacherLeftElbowPosY;
               teacherLeftElbowPosZ;
               teacherLeftElbowRotX;
               teacherLeftElbowRotY;
               teacherLeftElbowRotZ;
               teacherLeftElbowPos;
               teacherLeftElbowRot;

               teacherRightElbowPosX;
               teacherRightElbowPosY;
               teacherRightElbowPosZ;
               teacherRightElbowRotX;
               teacherRightElbowRotY;
               teacherRightElbowRotZ;
               teacherRightElbowPos;
               teacherRightElbowRot;

               teacherLeftKneePosX;
               teacherLeftKneePosY;
               teacherLeftKneePosZ;
               teacherLeftKneeRotX;
               teacherLeftKneeRotY;
               teacherLeftKneeRotZ;
               teacherLeftKneePos;
               teacherLeftKneeRot;

               teacherRightKneePosX;
               teacherRightKneePosY;
               teacherRightKneePosZ;
               teacherRightKneeRotX;
               teacherRightKneeRotY;
               teacherRightKneeRotZ;
               teacherRightKneePos;
               teacherRightKneeRot;

               teacherBoxPosX;
               teacherBoxPosY;
               teacherBoxPosZ;
               teacherBoxRotX;
               teacherBoxRotY;
               teacherBoxRotZ;
               teacherBoxPos;
               teacherBoxRot;

               teacherTablePosX;
               teacherTablePosY;
               teacherTablePosZ;
               teacherTableRotX;
               teacherTableRotY;
               teacherTableRotZ;
               teacherTablePos;
               teacherTableRot;

               // risk measurements
               isFeetPlacementError;
               feetDistance;
               isSquatError;
               squatDistance;
               isSpineTwistError;
               spineTwistAngle;
               isSpindBendError;
               spineBendAngle;

               studentBoxPosX = studentBox.transform.position.x;
               studentBoxPosY = studentBox.transform.position.y;
               studentBoxPosZ = studentBox.transform.position.z;
               studentBoxRotX = studentBox.transform.rotation.x;
               studentBoxRotY = studentBox.transform.rotation.y;
               studentBoxRotZ = studentBox.transform.rotation.z;
               studentBoxPos = studentBox.transform.position;
               studentBoxRot = studentBox.transform.rotation.eulerAngles;

               teacherBoxPosX = teacherBox.transform.position.x;
               teacherBoxPosY = teacherBox.transform.position.y;
               teacherBoxPosZ = teacherBox.transform.position.z;
               teacherBoxRotX = teacherBox.transform.rotation.x;
               teacherBoxRotY = teacherBox.transform.rotation.y;
               teacherBoxRotZ = teacherBox.transform.rotation.z;
               teacherBoxPos = teacherBox.transform.position;
               teacherBoxRot = teacherBox.transform.rotation.eulerAngles;

               boxDistance = 1f;//yxc set

               // or better the avatar root?
               studentAvatarPosX = studentAvatar.transform.position.x;
               studentAvatarPosY = studentAvatar.transform.position.y;
               studentAvatarPosZ = studentAvatar.transform.position.z;
               studentAvatarRotX = studentAvatar.transform.position.x;
               studentAvatarRotY = studentAvatar.transform.position.y;
               studentAvatarRotZ = studentAvatar.transform.position.z;
               studentAvatarPos = studentAvatar.transform.position;
               studentAvatarRot = studentAvatar.transform.rotation.eulerAngles;

               // or better the avatar root?
               teacherAvatarPosX = teacherAvatar.transform.position.x;
               teacherAvatarPosY = teacherAvatar.transform.position.y;
               teacherAvatarPosZ = teacherAvatar.transform.position.z;
               teacherAvatarRotX = teacherAvatar.transform.position.x;
               teacherAvatarRotY = teacherAvatar.transform.position.y;
               teacherAvatarRotZ = teacherAvatar.transform.position.z;
               teacherAvatarPos = teacherAvatar.transform.position;
               teacherAvatarRot = teacherAvatar.transform.rotation.eulerAngles;

               // teacher foot? but no tracker there?
               lFootPosX = studentLeftFoot.transform.position.x;
               lFootPosY = studentLeftFoot.transform.position.y;
               lFootPosZ = studentLeftFoot.transform.position.z;
               lFootRotX = studentLeftFoot.transform.rotation.x;
               lFootRotY = studentLeftFoot.transform.rotation.y;
               lFootRotZ = studentLeftFoot.transform.rotation.z;
               lFootPos = studentLeftFoot.transform.position;
               lFootRot = studentLeftFoot.transform.rotation.eulerAngles;

               rFootPosX = studentRightFoot.transform.position.x;
               rFootPosY = studentRightFoot.transform.position.y;
               rFootPosZ = studentRightFoot.transform.position.z;
               rFootRotX = studentRightFoot.transform.rotation.x;
               rFootRotY = studentRightFoot.transform.rotation.y;
               rFootRotZ = studentRightFoot.transform.rotation.z;
               rFootPos = studentRightFoot.transform.position;
               rFootRot = studentRightFoot.transform.rotation.eulerAngles;

               lowerHipPosX = studentLowerHip.transform.position.x;
               lowerHipPosY = studentLowerHip.transform.position.y;
               lowerHipPosZ = studentLowerHip.transform.position.z;
               lowerHipRotX = studentLowerHip.transform.rotation.x;
               lowerHipRotY = studentLowerHip.transform.rotation.y;
               lowerHipRotZ = studentLowerHip.transform.rotation.z;
               lowerHipPos = studentLowerHip.transform.position;
               lowerHipRot = studentLowerHip.transform.rotation.eulerAngles;

               upperHipPosX = studentUpperHip.transform.position.x;
               upperHipPosY = studentUpperHip.transform.position.y;
               upperHipPosZ = studentUpperHip.transform.position.z;
               upperHipRotX = studentUpperHip.transform.rotation.x;
               upperHipRotY = studentUpperHip.transform.rotation.y;
               upperHipRotZ = studentUpperHip.transform.rotation.z;
               upperHipPos = studentUpperHip.transform.position;
               upperHipRot = studentUpperHip.transform.rotation.eulerAngles;

               rightShoulderPosX = studentRightShoulder.transform.position.x;
               rightShoulderPosY = studentRightShoulder.transform.position.y;
               rightShoulderPosZ = studentRightShoulder.transform.position.z;
               rightShoulderRotX = studentRightShoulder.transform.position.x;
               rightShoulderRotY = studentRightShoulder.transform.position.y;
               rightShoulderRotZ = studentRightShoulder.transform.position.z;
               rightShoulderPos = studentRightShoulder.transform.position;
               rightShoulderRot = studentRightShoulder.transform.rotation.eulerAngles;

               leftShoulderPosX = studentLeftShoulder.transform.position.x;
               leftShoulderPosY = studentLeftShoulder.transform.position.y;
               leftShoulderPosZ = studentLeftShoulder.transform.position.z;
               leftShoulderRotX = studentLeftShoulder.transform.rotation.x;
               leftShoulderRotY = studentLeftShoulder.transform.rotation.y;
               leftShoulderRotZ = studentLeftShoulder.transform.rotation.z;
               leftShoulderPos = studentLeftShoulder.transform.position;
               leftShoulderRot = studentLeftShoulder.transform.rotation.eulerAngles;

               // yxc set
               isFeetPlacementError = false;
               feetDistance = 1f;
               isSquatError = false;
               squatDistance = 1f;
               isSpineTwistError = false;
               spineTwistAngle = 1f;
               isSpindBendError = false;
               spineBendAngle = 1f;

               headPosX = studentHmd.transform.position.x;
               headPosY = studentHmd.transform.position.y;
               headPosZ = studentHmd.transform.position.z;
               headRotX = studentHmd.transform.rotation.x;
               headRotY = studentHmd.transform.rotation.y;
               headRotZ = studentHmd.transform.rotation.z;
               headPos = studentHmd.transform.position;
               headRot = studentHmd.transform.rotation.eulerAngles;

               rayTraceHitTeacherId = "teacherId"; //yxc set

               lHandPosX = studentLeftHand.transform.position.x;
               lHandPosY = studentLeftHand.transform.position.y;
               lHandPosZ = studentLeftHand.transform.position.z;
               lHandRotX = studentLeftHand.transform.rotation.x;
               lHandRotY = studentLeftHand.transform.rotation.y;
               lHandRotZ = studentLeftHand.transform.rotation.z;
               lHandPos = studentLeftHand.transform.position;
               lHandRot = studentLeftHand.transform.rotation.eulerAngles;

               rHandPosX = studentRightHand.transform.position.x;
               rHandPosY = studentRightHand.transform.position.y;
               rHandPosZ = studentRightHand.transform.position.z;
               rHandRotX = studentRightHand.transform.rotation.x;
               rHandRotY = studentRightHand.transform.rotation.y;
               rHandRotZ = studentRightHand.transform.rotation.z;
               rHandPos = studentRightHand.transform.position;
               rHandRot = studentRightHand.transform.rotation.eulerAngles;
               */
    }

    // Update is called once per frame
    void Update()
    {
        float millisecondsElapsed = (int)(DateTime.Now - startTime).TotalMilliseconds;
        DateTime time = DateTime.Now;
        string lineToWrite = millisecondsElapsed + ";" + time + ";";
        file.WriteLine(lineToWrite);

    }
}
