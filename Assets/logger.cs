using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using UnityEngine;

public class logger : MonoBehaviour
{
    public string fileName = "testFile.txt";

    string path = @"C:\FEYER\logs\";

    StreamWriter file;

    DateTime startTime;

    public string taskId; //yxc

    public string conditionId; //yxc

    public bool taskInProgress; //yxc

    public int numberOfVisibleTeachers; //yxc

    //refine this:
    public GameObject teacher0; //yxc

    public GameObject teacher1; //yxc

    public GameObject teacher2; //yxc

    public GameObject teacher3; //yxc
    public GameObject teacher4; //yxc

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

    Vector3 studentHMDPos;

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

    Vector3 teacherHMDPos;

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
        string csvHeader =
            "milisecondsElapsed;time;studentHMDPosX;studentHMDPosY;studentHMDPosZ;studentHMDRotX;studentHMDRotY;studentHMDRotZ;studentHMDPos;studentHMDRot;studentLeftHandTrackerPosX;studentLeftHandTrackerPosY;studentLeftHandTrackerPosZ;studentLeftHandTrackerRotX;studentLeftHandTrackerRotY;studentLeftHandTrackerRotZ;studentLeftHandTrackerPos;studentLeftHandTrackerRot;studentRightHandTrackerPosX;studentRightHandTrackerPosY;studentRightHandTrackerPosZ;studentRightHandTrackerRotX;studentRightHandTrackerRotY;studentRightHandTrackerRotZ;studentRightHandTrackerPos;studentRightHandTrackerRot;studentLeftShoulderTrackerPosX;studentLeftShoulderTrackerPosY;studentLeftShoulderTrackerPosZ;studentLeftShoulderTrackerRotX;studentLeftShoulderTrackerRotY;studentLeftShoulderTrackerRotZ;studentLeftShoulderTrackerPos;studentLeftShoulderTrackerRot;studentRightShoulderTrackerPosX;studentRightShoulderTrackerPosY;studentRightShoulderTrackerPosZ;studentRightShoulderTrackerRotX;studentRightShoulderTrackerRotY;studentRightShoulderTrackerRotZ;studentRightShoulderTrackerPos;studentRightShoulderTrackerRot;studentUpperHipTrackerPosX;studentUpperHipTrackerPosY;studentUpperHipTrackerPosZ;studentUpperHipTrackerRotX;studentUpperHipTrackerRotY;studentUpperHipTrackerRotZ;studentUpperHipTrackerPos;studentUpperHipTrackerRot;studentLowerHipTrackerPosX;studentLowerHipTrackerPosY;studentLowerHipTrackerPosZ;studentLowerHipTrackerRotX;studentLowerHipTrackerRotY;studentLowerHipTrackerRotZ;studentLowerHipTrackerPos;studentLowerHipTrackerRot;studentLeftFootTrackerPosX;studentLeftFootTrackerPosY;studentLeftFootTrackerPosZ;studentLeftFootTrackerRotX;studentLeftFootTrackerRotY;studentLeftFootTrackerRotZ;studentLeftFootTrackerPos;studentLeftFootTrackerRot;studentRightFootTrackerPosX;studentRightFootTrackerPosY;studentRightFootTrackerPosZ;studentRightFootTrackerRotX;studentRightFootTrackerRotY;studentRightFootTrackerRotZ;studentRightFootTrackerPos;studentRightFootTrackerRot;studentBoxTrackerPosX;studentBoxTrackerPosY;studentBoxTrackerPosZ;studentBoxTrackerRotX;studentBoxTrackerRotY;studentBoxTrackerRotZ;studentBoxTrackerPos;studentBoxTrackerRot;studentTableTrackerPosX;studentTableTrackerPosY;studentTableTrackerPosZ;studentTableTrackerRotX;studentTableTrackerRotY;studentTableTrackerRotZ;studentTableTrackerPos;studentTableTrackerRot;studentHeadPosX;studentHeadPosY;studentHeadPosZ;studentHeadRotX;studentHeadRotY;studentHeadRotZ;studentHeadPos;studentHeadRot;studentLowerHipPosX;studentLowerHipPosY;studentLowerHipPosZ;studentLowerHipRotX;studentLowerHipRotY;studentLowerHipRotZ;studentLowerHipPos;studentLowerHipRot;studentUpperHipPosX;studentUpperHipPosY;studentUpperHipPosZ;studentUpperHipRotX;studentUpperHipRotY;studentUpperHipRotZ;studentUpperHipPos;studentUpperHipRot;studentLeftHandPosX;studentLeftHandPosY;studentLeftHandPosZ;studentLeftHandRotX;studentLeftHandRotY;studentLeftHandRotZ;studentLeftHandPos;studentLeftHandRot;studentRightHandPosX;studentRightHandPosY;studentRightHandPosZ;studentRightHandRotX;studentRightHandRotY;studentRightHandRotZ;studentRightHandPos;studentRightHandRot;studentLeftFootPosX;studentLeftFootPosY;studentLeftFootPosZ;studentLeftFootRotX;studentLeftFootRotY;studentLeftFootRotZ;studentLeftFootPos;studentLeftFootRot;studentRightFootPosX;studentRightFootPosY;studentRightFootPosZ;studentRightFootRotX;studentRightFootRotY;studentRightFootRotZ;studentRightFootPos;studentRightFootRot;studentLeftShoulderPosX;studentLeftShoulderPosY;studentLeftShoulderPosZ;studentLeftShoulderRotX;studentLeftShoulderRotY;studentLeftShoulderRotZ;studentLeftShoulderPos;studentLeftShoulderRot;studentRightShoulderPosX;studentRightShoulderPosY;studentRightShoulderPosZ;studentRightShoulderRotX;studentRightShoulderRotY;studentRightShoulderRotZ;studentRightShoulderPos;studentRightShoulderRot;studentLeftElbowPosX;studentLeftElbowPosY;studentLeftElbowPosZ;studentLeftElbowRotX;studentLeftElbowRotY;studentLeftElbowRotZ;studentLeftElbowPos;studentLeftElbowRot;studentRightElbowPosX;studentRightElbowPosY;studentRightElbowPosZ;studentRightElbowRotX;studentRightElbowRotY;studentRightElbowRotZ;studentRightElbowPos;studentRightElbowRot;studentLeftKneePosX;studentLeftKneePosY;studentLeftKneePosZ;studentLeftKneeRotX;studentLeftKneeRotY;studentLeftKneeRotZ;studentLeftKneePos;studentLeftKneeRot;studentRightKneePosX;studentRightKneePosY;studentRightKneePosZ;studentRightKneeRotX;studentRightKneeRotY;studentRightKneeRotZ;studentRightKneePos;studentRightKneeRot;studentBoxPosX;studentBoxPosY;studentBoxPosZ;studentBoxRotX;studentBoxRotY;studentBoxRotZ;studentBoxPos;studentBoxRot;studentTablePosX;studentTablePosY;studentTablePosZ;studentTableRotX;studentTableRotY;studentTableRotZ;studentTablePos;studentTableRot;teacherHMDPosX;teacherHMDPosY;teacherHMDPosZ;teacherHMDRotX;teacherHMDRotY;teacherHMDRotZ;teacherHMDPos;teacherHMDRot;teacherLeftHandTrackerPosX;teacherLeftHandTrackerPosY;teacherLeftHandTrackerPosZ;teacherLeftHandTrackerRotX;teacherLeftHandTrackerRotY;teacherLeftHandTrackerRotZ;teacherLeftHandTrackerPos;teacherLeftHandTrackerRot;teacherRightHandTrackerPosX;teacherRightHandTrackerPosY;teacherRightHandTrackerPosZ;teacherRightHandTrackerRotX;teacherRightHandTrackerRotY;teacherRightHandTrackerRotZ;teacherRightHandTrackerPos;teacherRightHandTrackerRot;teacherLeftShoulderTrackerPosX;teacherLeftShoulderTrackerPosY;teacherLeftShoulderTrackerPosZ;teacherLeftShoulderTrackerRotX;teacherLeftShoulderTrackerRotY;teacherLeftShoulderTrackerRotZ;teacherLeftShoulderTrackerPos;teacherLeftShoulderTrackerRot;teacherRightShoulderTrackerPosX;teacherRightShoulderTrackerPosY;teacherRightShoulderTrackerPosZ;teacherRightShoulderTrackerRotX;teacherRightShoulderTrackerRotY;teacherRightShoulderTrackerRotZ;teacherRightShoulderTrackerPos;teacherRightShoulderTrackerRot;teacherUpperHipTrackerPosX;teacherUpperHipTrackerPosY;teacherUpperHipTrackerPosZ;teacherUpperHipTrackerRotX;teacherUpperHipTrackerRotY;teacherUpperHipTrackerRotZ;teacherUpperHipTrackerPos;teacherUpperHipTrackerRot;teacherLowerHipTrackerPosX;teacherLowerHipTrackerPosY;teacherLowerHipTrackerPosZ;teacherLowerHipTrackerRotX;teacherLowerHipTrackerRotY;teacherLowerHipTrackerRotZ;teacherLowerHipTrackerPos;teacherLowerHipTrackerRot;teacherLeftFootTrackerPosX;teacherLeftFootTrackerPosY;teacherLeftFootTrackerPosZ;teacherLeftFootTrackerRotX;teacherLeftFootTrackerRotY;teacherLeftFootTrackerRotZ;teacherLeftFootTrackerPos;teacherLeftFootTrackerRot;teacherRightFootTrackerPosX;teacherRightFootTrackerPosY;teacherRightFootTrackerPosZ;teacherRightFootTrackerRotX;teacherRightFootTrackerRotY;teacherRightFootTrackerRotZ;teacherRightFootTrackerPos;teacherRightFootTrackerRot;teacherBoxTrackerPosX;teacherBoxTrackerPosY;teacherBoxTrackerPosZ;teacherBoxTrackerRotX;teacherBoxTrackerRotY;teacherBoxTrackerRotZ;teacherBoxTrackerPos;teacherBoxTrackerRot;teacherTableTrackerPosX;teacherTableTrackerPosY;teacherTableTrackerPosZ;teacherTableTrackerRotX;teacherTableTrackerRotY;teacherTableTrackerRotZ;teacherTableTrackerPos;teacherTableTrackerRot;teacherHeadPosX;teacherHeadPosY;teacherHeadPosZ;teacherHeadRotX;teacherHeadRotY;teacherHeadRotZ;teacherHeadPos;teacherHeadRot;teacherLowerHipPosX;teacherLowerHipPosY;teacherLowerHipPosZ;teacherLowerHipRotX;teacherLowerHipRotY;teacherLowerHipRotZ;teacherLowerHipPos;teacherLowerHipRot;teacherUpperHipPosX;teacherUpperHipPosY;teacherUpperHipPosZ;teacherUpperHipRotX;teacherUpperHipRotY;teacherUpperHipRotZ;teacherUpperHipPos;teacherUpperHipRot;teacherLeftHandPosX;teacherLeftHandPosY;teacherLeftHandPosZ;teacherLeftHandRotX;teacherLeftHandRotY;teacherLeftHandRotZ;teacherLeftHandPos;teacherLeftHandRot;teacherRightHandPosX;teacherRightHandPosY;teacherRightHandPosZ;teacherRightHandRotX;teacherRightHandRotY;teacherRightHandRotZ;teacherRightHandPos;teacherRightHandRot;teacherLeftFootPosX;teacherLeftFootPosY;teacherLeftFootPosZ;teacherLeftFootRotX;teacherLeftFootRotY;teacherLeftFootRotZ;teacherLeftFootPos;teacherLeftFootRot;teacherRightFootPosX;teacherRightFootPosY;teacherRightFootPosZ;teacherRightFootRotX;teacherRightFootRotY;teacherRightFootRotZ;teacherRightFootPos;teacherRightFootRot;teacherLeftShoulderPosX;teacherLeftShoulderPosY;teacherLeftShoulderPosZ;teacherLeftShoulderRotX;teacherLeftShoulderRotY;teacherLeftShoulderRotZ;teacherLeftShoulderPos;teacherLeftShoulderRot;teacherRightShoulderPosX;teacherRightShoulderPosY;teacherRightShoulderPosZ;teacherRightShoulderRotX;teacherRightShoulderRotY;teacherRightShoulderRotZ;teacherRightShoulderPos;teacherRightShoulderRot;teacherLeftElbowPosX;teacherLeftElbowPosY;teacherLeftElbowPosZ;teacherLeftElbowRotX;teacherLeftElbowRotY;teacherLeftElbowRotZ;teacherLeftElbowPos;teacherLeftElbowRot;teacherRightElbowPosX;teacherRightElbowPosY;teacherRightElbowPosZ;teacherRightElbowRotX;teacherRightElbowRotY;teacherRightElbowRotZ;teacherRightElbowPos;teacherRightElbowRot;teacherLeftKneePosX;teacherLeftKneePosY;teacherLeftKneePosZ;teacherLeftKneeRotX;teacherLeftKneeRotY;teacherLeftKneeRotZ;teacherLeftKneePos;teacherLeftKneeRot;teacherRightKneePosX;teacherRightKneePosY;teacherRightKneePosZ;teacherRightKneeRotX;teacherRightKneeRotY;teacherRightKneeRotZ;teacherRightKneePos;teacherRightKneeRot;teacherBoxPosX;teacherBoxPosY;teacherBoxPosZ;teacherBoxRotX;teacherBoxRotY;teacherBoxRotZ;teacherBoxPos;teacherBoxRot;teacherTablePosX;teacherTablePosY;teacherTablePosZ;teacherTableRotX;teacherTableRotY;teacherTableRotZ;teacherTablePos;teacherTableRot;isFeetPlacementError;feetDistance;isSquatError;squatDistance;isSpineTwistError;spineTwistAngle;isSpindBendError;spineBendAngle;distanceStudentTeacherBox;rayTraceHitTeacherId;";
        file.WriteLine(csvHeader);

        studentHMDPosX = studentHMD.transform.position.x;
        studentHMDPosY = studentHMD.transform.position.y;
        studentHMDPosZ = studentHMD.transform.position.z;
        studentHMDRotX = studentHMD.transform.position.x;
        studentHMDRotY = studentHMD.transform.position.y;
        studentHMDRotZ = studentHMD.transform.position.z;
        studentHMDPos = studentHMD.transform.position;
        studentHMDRot = studentHMD.transform.rotation.eulerAngles;

        studentLeftHandTrackerPosX = studentLeftHandTracker.transform.position.x;
        studentLeftHandTrackerPosY = studentLeftHandTracker.transform.position.y;
        studentLeftHandTrackerPosZ = studentLeftHandTracker.transform.position.z;
        studentLeftHandTrackerRotX = studentLeftHandTracker.transform.position.x;
        studentLeftHandTrackerRotY = studentLeftHandTracker.transform.position.y;
        studentLeftHandTrackerRotZ = studentLeftHandTracker.transform.position.z;
        studentLeftHandTrackerPos = studentLeftHandTracker.transform.position;
        studentLeftHandTrackerRot = studentLeftHandTracker.transform.rotation.eulerAngles;

        studentRightHandTrackerPosX = studentRightHandTracker.transform.position.x;
        studentRightHandTrackerPosY = studentRightHandTracker.transform.position.y;
        studentRightHandTrackerPosZ = studentRightHandTracker.transform.position.z;
        studentRightHandTrackerRotX = studentRightHandTracker.transform.position.x;
        studentRightHandTrackerRotY = studentRightHandTracker.transform.position.y;
        studentRightHandTrackerRotZ = studentRightHandTracker.transform.position.z;
        studentRightHandTrackerPos = studentRightHandTracker.transform.position;
        studentRightHandTrackerRot = studentRightHandTracker.transform.rotation.eulerAngles;

        studentLeftShoulderTrackerPosX = studentLeftShoulderTracker.transform.position.x; ;
        studentLeftShoulderTrackerPosY = studentLeftShoulderTracker.transform.position.y; ;
        studentLeftShoulderTrackerPosZ = studentLeftShoulderTracker.transform.position.z; ;
        studentLeftShoulderTrackerRotX = studentLeftShoulderTracker.transform.position.x; ;
        studentLeftShoulderTrackerRotY = studentLeftShoulderTracker.transform.position.y; ;
        studentLeftShoulderTrackerRotZ = studentLeftShoulderTracker.transform.position.z; ;
        studentLeftShoulderTrackerPos = studentLeftShoulderTracker.transform.position; ;
        studentLeftShoulderTrackerRot = studentLeftShoulderTracker.transform.rotation.eulerAngles; ;

        studentRightShoulderTrackerPosX = studentRightShoulderTracker.transform.position.x;
        studentRightShoulderTrackerPosY = studentRightShoulderTracker.transform.position.y;
        studentRightShoulderTrackerPosZ = studentRightShoulderTracker.transform.position.z;
        studentRightShoulderTrackerRotX = studentRightShoulderTracker.transform.position.x;
        studentRightShoulderTrackerRotY = studentRightShoulderTracker.transform.position.y;
        studentRightShoulderTrackerRotZ = studentRightShoulderTracker.transform.position.z;
        studentRightShoulderTrackerPos = studentRightShoulderTracker.transform.position;
        studentRightShoulderTrackerRot = studentRightShoulderTracker.transform.rotation.eulerAngles;

        studentUpperHipTrackerPosX = studentUpperHipTracker.transform.position.x;
        studentUpperHipTrackerPosY = studentUpperHipTracker.transform.position.y;
        studentUpperHipTrackerPosZ = studentUpperHipTracker.transform.position.z;
        studentUpperHipTrackerRotX = studentUpperHipTracker.transform.position.x;
        studentUpperHipTrackerRotY = studentUpperHipTracker.transform.position.y;
        studentUpperHipTrackerRotZ = studentUpperHipTracker.transform.position.z;
        studentUpperHipTrackerPos = studentUpperHipTracker.transform.position;
        studentUpperHipTrackerRot = studentUpperHipTracker.transform.rotation.eulerAngles;

        studentLowerHipTrackerPosX = studentLowerHipTracker.transform.position.x;
        studentLowerHipTrackerPosY = studentLowerHipTracker.transform.position.y;
        studentLowerHipTrackerPosZ = studentLowerHipTracker.transform.position.z;
        studentLowerHipTrackerRotX = studentLowerHipTracker.transform.position.x;
        studentLowerHipTrackerRotY = studentLowerHipTracker.transform.position.y;
        studentLowerHipTrackerRotZ = studentLowerHipTracker.transform.position.z;
        studentLowerHipTrackerPos = studentLowerHipTracker.transform.position;
        studentLowerHipTrackerRot = studentLowerHipTracker.transform.rotation.eulerAngles;

        studentLeftFootTrackerPosX = studentLeftFootTracker.transform.position.x;
        studentLeftFootTrackerPosY = studentLeftFootTracker.transform.position.y;
        studentLeftFootTrackerPosZ = studentLeftFootTracker.transform.position.z;
        studentLeftFootTrackerRotX = studentLeftFootTracker.transform.position.x;
        studentLeftFootTrackerRotY = studentLeftFootTracker.transform.position.y;
        studentLeftFootTrackerRotZ = studentLeftFootTracker.transform.position.z;
        studentLeftFootTrackerPos = studentLeftFootTracker.transform.position;
        studentLeftFootTrackerRot = studentLeftFootTracker.transform.rotation.eulerAngles;

        studentRightFootTrackerPosX = studentRightFootTracker.transform.position.x;
        studentRightFootTrackerPosY = studentRightFootTracker.transform.position.y;
        studentRightFootTrackerPosZ = studentRightFootTracker.transform.position.z;
        studentRightFootTrackerRotX = studentRightFootTracker.transform.position.x;
        studentRightFootTrackerRotY = studentRightFootTracker.transform.position.y;
        studentRightFootTrackerRotZ = studentRightFootTracker.transform.position.z;
        studentRightFootTrackerPos = studentRightFootTracker.transform.position;
        studentRightFootTrackerRot = studentRightFootTracker.transform.rotation.eulerAngles;

        studentBoxTrackerPosX = studentBoxTracker.transform.position.x;
        studentBoxTrackerPosY = studentBoxTracker.transform.position.y;
        studentBoxTrackerPosZ = studentBoxTracker.transform.position.z;
        studentBoxTrackerRotX = studentBoxTracker.transform.position.x;
        studentBoxTrackerRotY = studentBoxTracker.transform.position.y;
        studentBoxTrackerRotZ = studentBoxTracker.transform.position.z;
        studentBoxTrackerPos = studentBoxTracker.transform.position;
        studentBoxTrackerRot = studentBoxTracker.transform.rotation.eulerAngles;

        studentTableTrackerPosX = studentTableTracker.transform.position.x;
        studentTableTrackerPosY = studentTableTracker.transform.position.y;
        studentTableTrackerPosZ = studentTableTracker.transform.position.z;
        studentTableTrackerRotX = studentTableTracker.transform.position.x;
        studentTableTrackerRotY = studentTableTracker.transform.position.y;
        studentTableTrackerRotZ = studentTableTracker.transform.position.z;
        studentTableTrackerPos = studentTableTracker.transform.position;
        studentTableTrackerRot = studentTableTracker.transform.rotation.eulerAngles;

        // avatar references
        studentHeadPosX = studentHead.transform.position.x;
        studentHeadPosY = studentHead.transform.position.y;
        studentHeadPosZ = studentHead.transform.position.z;
        studentHeadRotX = studentHead.transform.position.x;
        studentHeadRotY = studentHead.transform.position.y;
        studentHeadRotZ = studentHead.transform.position.z;
        studentHeadPos = studentHead.transform.position;
        studentHeadRot = studentHead.transform.rotation.eulerAngles;

        studentLowerHipPosX = studentLowerHip.transform.position.x;
        studentLowerHipPosY = studentLowerHip.transform.position.y;
        studentLowerHipPosZ = studentLowerHip.transform.position.z;
        studentLowerHipRotX = studentLowerHip.transform.position.x;
        studentLowerHipRotY = studentLowerHip.transform.position.y;
        studentLowerHipRotZ = studentLowerHip.transform.position.z;
        studentLowerHipPos = studentLowerHip.transform.position;
        studentLowerHipRot = studentLowerHip.transform.rotation.eulerAngles;

        studentUpperHipPosX = studentUpperHip.transform.position.x;
        studentUpperHipPosY = studentUpperHip.transform.position.y;
        studentUpperHipPosZ = studentUpperHip.transform.position.z;
        studentUpperHipRotX = studentUpperHip.transform.position.x;
        studentUpperHipRotY = studentUpperHip.transform.position.y;
        studentUpperHipRotZ = studentUpperHip.transform.position.z;
        studentUpperHipPos = studentUpperHip.transform.position;
        studentUpperHipRot = studentUpperHip.transform.rotation.eulerAngles;

        studentLeftHandPosX = studentLeftHand.transform.position.x;
        studentLeftHandPosY = studentLeftHand.transform.position.y;
        studentLeftHandPosZ = studentLeftHand.transform.position.z;
        studentLeftHandRotX = studentLeftHand.transform.position.x;
        studentLeftHandRotY = studentLeftHand.transform.position.y;
        studentLeftHandRotZ = studentLeftHand.transform.position.z;
        studentLeftHandPos = studentLeftHand.transform.position;
        studentLeftHandRot = studentLeftHand.transform.rotation.eulerAngles;

        studentRightHandPosX = studentRightHand.transform.position.x;
        studentRightHandPosY = studentRightHand.transform.position.y;
        studentRightHandPosZ = studentRightHand.transform.position.z;
        studentRightHandRotX = studentRightHand.transform.position.x;
        studentRightHandRotY = studentRightHand.transform.position.y;
        studentRightHandRotZ = studentRightHand.transform.position.z;
        studentRightHandPos = studentRightHand.transform.position;
        studentRightHandRot = studentRightHand.transform.rotation.eulerAngles;

        studentLeftFootPosX = studentLeftFoot.transform.position.x;
        studentLeftFootPosY = studentLeftFoot.transform.position.y;
        studentLeftFootPosZ = studentLeftFoot.transform.position.z;
        studentLeftFootRotX = studentLeftFoot.transform.position.x;
        studentLeftFootRotY = studentLeftFoot.transform.position.y;
        studentLeftFootRotZ = studentLeftFoot.transform.position.z;
        studentLeftFootPos = studentLeftFoot.transform.position;
        studentLeftFootRot = studentLeftFoot.transform.rotation.eulerAngles;

        studentRightFootPosX = studentRightFoot.transform.position.x; ;
        studentRightFootPosY = studentRightFoot.transform.position.y; ;
        studentRightFootPosZ = studentRightFoot.transform.position.z; ;
        studentRightFootRotX = studentRightFoot.transform.position.x; ;
        studentRightFootRotY = studentRightFoot.transform.position.y; ;
        studentRightFootRotZ = studentRightFoot.transform.position.z; ;
        studentRightFootPos = studentRightFoot.transform.position; ;
        studentRightFootRot = studentRightFoot.transform.rotation.eulerAngles; ;

        studentLeftShoulderPosX = studentLeftShoulder.transform.position.x;
        studentLeftShoulderPosY = studentLeftShoulder.transform.position.y;
        studentLeftShoulderPosZ = studentLeftShoulder.transform.position.z;
        studentLeftShoulderRotX = studentLeftShoulder.transform.position.x;
        studentLeftShoulderRotY = studentLeftShoulder.transform.position.y;
        studentLeftShoulderRotZ = studentLeftShoulder.transform.position.z;
        studentLeftShoulderPos = studentLeftShoulder.transform.position;
        studentLeftShoulderRot = studentLeftShoulder.transform.rotation.eulerAngles;

        studentRightShoulderPosX = studentRightShoulder.transform.position.x;
        studentRightShoulderPosY = studentRightShoulder.transform.position.y;
        studentRightShoulderPosZ = studentRightShoulder.transform.position.z;
        studentRightShoulderRotX = studentRightShoulder.transform.position.x;
        studentRightShoulderRotY = studentRightShoulder.transform.position.y;
        studentRightShoulderRotZ = studentRightShoulder.transform.position.z;
        studentRightShoulderPos = studentRightShoulder.transform.position;
        studentRightShoulderRot = studentRightShoulder.transform.rotation.eulerAngles;

        studentLeftElbowPosX = studentLeftElbow.transform.position.x;
        studentLeftElbowPosY = studentLeftElbow.transform.position.y;
        studentLeftElbowPosZ = studentLeftElbow.transform.position.z;
        studentLeftElbowRotX = studentLeftElbow.transform.position.x;
        studentLeftElbowRotY = studentLeftElbow.transform.position.y;
        studentLeftElbowRotZ = studentLeftElbow.transform.position.z;
        studentLeftElbowPos = studentLeftElbow.transform.position;
        studentLeftElbowRot = studentLeftElbow.transform.rotation.eulerAngles;

        studentRightElbowPosX = studentRightElbow.transform.position.x;
        studentRightElbowPosY = studentRightElbow.transform.position.y;
        studentRightElbowPosZ = studentRightElbow.transform.position.z;
        studentRightElbowRotX = studentRightElbow.transform.position.x;
        studentRightElbowRotY = studentRightElbow.transform.position.y;
        studentRightElbowRotZ = studentRightElbow.transform.position.z;
        studentRightElbowPos = studentRightElbow.transform.position;
        studentRightElbowRot = studentRightElbow.transform.rotation.eulerAngles;

        studentLeftKneePosX = studentLeftKnee.transform.position.x;
        studentLeftKneePosY = studentLeftKnee.transform.position.y;
        studentLeftKneePosZ = studentLeftKnee.transform.position.z;
        studentLeftKneeRotX = studentLeftKnee.transform.position.x;
        studentLeftKneeRotY = studentLeftKnee.transform.position.y;
        studentLeftKneeRotZ = studentLeftKnee.transform.position.z;
        studentLeftKneePos = studentLeftKnee.transform.position;
        studentLeftKneeRot = studentLeftKnee.transform.rotation.eulerAngles;

        studentRightKneePosX = studentRightKnee.transform.position.x;
        studentRightKneePosY = studentRightKnee.transform.position.y;
        studentRightKneePosZ = studentRightKnee.transform.position.z;
        studentRightKneeRotX = studentRightKnee.transform.position.x;
        studentRightKneeRotY = studentRightKnee.transform.position.y;
        studentRightKneeRotZ = studentRightKnee.transform.position.z;
        studentRightKneePos = studentRightKnee.transform.position;
        studentRightKneeRot = studentRightKnee.transform.rotation.eulerAngles;

        studentBoxPosX = studentBox.transform.position.x;
        studentBoxPosY = studentBox.transform.position.y;
        studentBoxPosZ = studentBox.transform.position.z;
        studentBoxRotX = studentBox.transform.position.x;
        studentBoxRotY = studentBox.transform.position.y;
        studentBoxRotZ = studentBox.transform.position.z;
        studentBoxPos = studentBox.transform.position;
        studentBoxRot = studentBox.transform.rotation.eulerAngles;

        studentTablePosX = studentTable.transform.position.x;
        studentTablePosY = studentTable.transform.position.y;
        studentTablePosZ = studentTable.transform.position.z;
        studentTableRotX = studentTable.transform.position.x;
        studentTableRotY = studentTable.transform.position.y;
        studentTableRotZ = studentTable.transform.position.z;
        studentTablePos = studentTable.transform.position;
        studentTableRot = studentTable.transform.rotation.eulerAngles;

        // teacher
        // tracker
        teacherHMDPosX = teacherHMD.transform.position.x;
        teacherHMDPosY = teacherHMD.transform.position.y;
        teacherHMDPosZ = teacherHMD.transform.position.z;
        teacherHMDRotX = teacherHMD.transform.position.x;
        teacherHMDRotY = teacherHMD.transform.position.y;
        teacherHMDRotZ = teacherHMD.transform.position.z;
        teacherHMDPos = teacherHMD.transform.position;
        teacherHMDRot = teacherHMD.transform.rotation.eulerAngles;

        teacherLeftHandTrackerPosX = teacherLeftHandTracker.transform.position.x;
        teacherLeftHandTrackerPosY = teacherLeftHandTracker.transform.position.y;
        teacherLeftHandTrackerPosZ = studentLeftHandTracker.transform.position.z;
        teacherLeftHandTrackerRotX = teacherLeftHandTracker.transform.position.x;
        teacherLeftHandTrackerRotY = teacherLeftHandTracker.transform.position.y;
        teacherLeftHandTrackerRotZ = teacherLeftHandTracker.transform.position.z;
        teacherLeftHandTrackerPos = teacherLeftHandTracker.transform.position;
        teacherLeftHandTrackerRot = teacherLeftHandTracker.transform.rotation.eulerAngles;

        teacherRightHandTrackerPosX = teacherRightHandTracker.transform.position.x; ;
        teacherRightHandTrackerPosY = teacherRightHandTracker.transform.position.y; ;
        teacherRightHandTrackerPosZ = teacherRightHandTracker.transform.position.z; ;
        teacherRightHandTrackerRotX = teacherRightHandTracker.transform.position.x; ;
        teacherRightHandTrackerRotY = teacherRightHandTracker.transform.position.y; ;
        teacherRightHandTrackerRotZ = teacherRightHandTracker.transform.position.z; ;
        teacherRightHandTrackerPos = teacherRightHandTracker.transform.position; ;
        teacherRightHandTrackerRot = teacherRightHandTracker.transform.rotation.eulerAngles; ;

        teacherLeftShoulderTrackerPosX = teacherLeftShoulderTracker.transform.position.x;
        teacherLeftShoulderTrackerPosY = teacherLeftShoulderTracker.transform.position.y;
        teacherLeftShoulderTrackerPosZ = teacherLeftShoulderTracker.transform.position.z;
        teacherLeftShoulderTrackerRotX = teacherLeftShoulderTracker.transform.position.x;
        teacherLeftShoulderTrackerRotY = teacherLeftShoulderTracker.transform.position.y;
        teacherLeftShoulderTrackerRotZ = teacherLeftShoulderTracker.transform.position.z;
        teacherLeftShoulderTrackerPos = teacherLeftShoulderTracker.transform.position;
        teacherLeftShoulderTrackerRot = teacherLeftShoulderTracker.transform.rotation.eulerAngles;

        teacherRightShoulderTrackerPosX = teacherRightShoulderTracker.transform.position.x;
        teacherRightShoulderTrackerPosY = teacherRightShoulderTracker.transform.position.y;
        teacherRightShoulderTrackerPosZ = teacherRightShoulderTracker.transform.position.z;
        teacherRightShoulderTrackerRotX = teacherRightShoulderTracker.transform.position.x;
        teacherRightShoulderTrackerRotY = teacherRightShoulderTracker.transform.position.y;
        teacherRightShoulderTrackerRotZ = teacherRightShoulderTracker.transform.position.z;
        teacherRightShoulderTrackerPos = teacherRightShoulderTracker.transform.position;
        teacherRightShoulderTrackerRot = teacherRightShoulderTracker.transform.rotation.eulerAngles;

        teacherUpperHipTrackerPosX = teacherUpperHipTracker.transform.position.x;
        teacherUpperHipTrackerPosY = teacherUpperHipTracker.transform.position.y;
        teacherUpperHipTrackerPosZ = teacherUpperHipTracker.transform.position.z;
        teacherUpperHipTrackerRotX = teacherUpperHipTracker.transform.position.x;
        teacherUpperHipTrackerRotY = teacherUpperHipTracker.transform.position.y;
        teacherUpperHipTrackerRotZ = teacherUpperHipTracker.transform.position.z;
        teacherUpperHipTrackerPos = teacherUpperHipTracker.transform.position;
        teacherUpperHipTrackerRot = teacherUpperHipTracker.transform.rotation.eulerAngles;

        teacherLowerHipTrackerPosX = teacherLowerHipTracker.transform.position.x;
        teacherLowerHipTrackerPosY = teacherLowerHipTracker.transform.position.y;
        teacherLowerHipTrackerPosZ = teacherLowerHipTracker.transform.position.z;
        teacherLowerHipTrackerRotX = teacherLowerHipTracker.transform.position.x;
        teacherLowerHipTrackerRotY = teacherLowerHipTracker.transform.position.y;
        teacherLowerHipTrackerRotZ = teacherLowerHipTracker.transform.position.z;
        teacherLowerHipTrackerPos = teacherLowerHipTracker.transform.position;
        teacherLowerHipTrackerRot = teacherLowerHipTracker.transform.rotation.eulerAngles;

        teacherLeftFootTrackerPosX = teacherLeftFootTracker.transform.position.x;
        teacherLeftFootTrackerPosY = teacherLeftFootTracker.transform.position.y;
        teacherLeftFootTrackerPosZ = teacherLeftFootTracker.transform.position.z;
        teacherLeftFootTrackerRotX = teacherLeftFootTracker.transform.position.x;
        teacherLeftFootTrackerRotY = teacherLeftFootTracker.transform.position.y;
        teacherLeftFootTrackerRotZ = teacherLeftFootTracker.transform.position.z;
        teacherLeftFootTrackerPos = teacherLeftFootTracker.transform.position;
        teacherLeftFootTrackerRot = teacherLeftFootTracker.transform.rotation.eulerAngles;

        teacherRightFootTrackerPosX = teacherRightFootTracker.transform.position.x;
        teacherRightFootTrackerPosY = teacherRightFootTracker.transform.position.y;
        teacherRightFootTrackerPosZ = teacherRightFootTracker.transform.position.z;
        teacherRightFootTrackerRotX = teacherRightFootTracker.transform.position.x;
        teacherRightFootTrackerRotY = teacherRightFootTracker.transform.position.y;
        teacherRightFootTrackerRotZ = teacherRightFootTracker.transform.position.z;
        teacherRightFootTrackerPos = teacherRightFootTracker.transform.position;
        teacherRightFootTrackerRot = teacherRightFootTracker.transform.rotation.eulerAngles;

        teacherBoxTrackerPosX = teacherBoxTracker.transform.position.x;
        teacherBoxTrackerPosY = teacherBoxTracker.transform.position.y;
        teacherBoxTrackerPosZ = teacherBoxTracker.transform.position.z;
        teacherBoxTrackerRotX = teacherBoxTracker.transform.position.x;
        teacherBoxTrackerRotY = teacherBoxTracker.transform.position.y;
        teacherBoxTrackerRotZ = teacherBoxTracker.transform.position.z;
        teacherBoxTrackerPos = teacherBoxTracker.transform.position;
        teacherBoxTrackerRot = teacherBoxTracker.transform.rotation.eulerAngles;

        teacherTableTrackerPosX = teacherTableTracker.transform.position.x;
        teacherTableTrackerPosY = teacherTableTracker.transform.position.y;
        teacherTableTrackerPosZ = teacherTableTracker.transform.position.z;
        teacherTableTrackerRotX = teacherTableTracker.transform.position.x;
        teacherTableTrackerRotY = teacherTableTracker.transform.position.y;
        teacherTableTrackerRotZ = teacherTableTracker.transform.position.z;
        teacherTableTrackerPos = teacherTableTracker.transform.position;
        teacherTableTrackerRot = teacherTableTracker.transform.rotation.eulerAngles;

        // avatar references
        teacherHeadPosX = teacherHead.transform.position.x;
        teacherHeadPosY = teacherHead.transform.position.y;
        teacherHeadPosZ = teacherHead.transform.position.z;
        teacherHeadRotX = teacherHead.transform.position.x;
        teacherHeadRotY = teacherHead.transform.position.y;
        teacherHeadRotZ = teacherHead.transform.position.z;
        teacherHeadPos = teacherHead.transform.position;
        teacherHeadRot = teacherHead.transform.rotation.eulerAngles;

        teacherLowerHipPosX = teacherLowerHip.transform.position.x;
        teacherLowerHipPosY = teacherLowerHip.transform.position.y;
        teacherLowerHipPosZ = teacherLowerHip.transform.position.z;
        teacherLowerHipRotX = teacherLowerHip.transform.position.x;
        teacherLowerHipRotY = teacherLowerHip.transform.position.y;
        teacherLowerHipRotZ = teacherLowerHip.transform.position.z;
        teacherLowerHipPos = teacherLowerHip.transform.position;
        teacherLowerHipRot = teacherLowerHip.transform.rotation.eulerAngles;

        teacherUpperHipPosX = teacherUpperHip.transform.position.x;
        teacherUpperHipPosY = teacherUpperHip.transform.position.y;
        teacherUpperHipPosZ = teacherUpperHip.transform.position.z;
        teacherUpperHipRotX = teacherUpperHip.transform.position.x;
        teacherUpperHipRotY = teacherUpperHip.transform.position.y;
        teacherUpperHipRotZ = teacherUpperHip.transform.position.z;
        teacherUpperHipPos = teacherUpperHip.transform.position;
        teacherUpperHipRot = teacherUpperHip.transform.rotation.eulerAngles;

        teacherLeftHandPosX = teacherLeftHand.transform.position.x;
        teacherLeftHandPosY = teacherLeftHand.transform.position.y;
        teacherLeftHandPosZ = teacherLeftHand.transform.position.z;
        teacherLeftHandRotX = teacherLeftHand.transform.position.x;
        teacherLeftHandRotY = teacherLeftHand.transform.position.y;
        teacherLeftHandRotZ = teacherLeftHand.transform.position.z;
        teacherLeftHandPos = teacherLeftHand.transform.position;
        teacherLeftHandRot = teacherLeftHand.transform.rotation.eulerAngles;

        teacherRightHandPosX = teacherRightHand.transform.position.x;
        teacherRightHandPosY = teacherRightHand.transform.position.y;
        teacherRightHandPosZ = teacherRightHand.transform.position.z;
        teacherRightHandRotX = teacherRightHand.transform.position.x;
        teacherRightHandRotY = teacherRightHand.transform.position.y;
        teacherRightHandRotZ = teacherRightHand.transform.position.z;
        teacherRightHandPos = teacherRightHand.transform.position;
        teacherRightHandRot = teacherRightHand.transform.rotation.eulerAngles;

        teacherLeftFootPosX = teacherLeftFoot.transform.position.x;
        teacherLeftFootPosY = teacherLeftFoot.transform.position.y;
        teacherLeftFootPosZ = teacherLeftFoot.transform.position.z;
        teacherLeftFootRotX = teacherLeftFoot.transform.position.x;
        teacherLeftFootRotY = teacherLeftFoot.transform.position.y;
        teacherLeftFootRotZ = teacherLeftFoot.transform.position.z;
        teacherLeftFootPos = teacherLeftFoot.transform.position;
        teacherLeftFootRot = teacherLeftFoot.transform.rotation.eulerAngles;

        teacherRightFootPosX = teacherRightFoot.transform.position.x;
        teacherRightFootPosY = teacherRightFoot.transform.position.y;
        teacherRightFootPosZ = teacherRightFoot.transform.position.z;
        teacherRightFootRotX = teacherRightFoot.transform.position.x;
        teacherRightFootRotY = teacherRightFoot.transform.position.y;
        teacherRightFootRotZ = teacherRightFoot.transform.position.z;
        teacherRightFootPos = teacherRightFoot.transform.position;
        teacherRightFootRot = teacherRightFoot.transform.rotation.eulerAngles;

        teacherLeftShoulderPosX = teacherLeftShoulder.transform.position.x;
        teacherLeftShoulderPosY = teacherLeftShoulder.transform.position.y;
        teacherLeftShoulderPosZ = teacherLeftShoulder.transform.position.z;
        teacherLeftShoulderRotX = teacherLeftShoulder.transform.position.x;
        teacherLeftShoulderRotY = teacherLeftShoulder.transform.position.y;
        teacherLeftShoulderRotZ = teacherLeftShoulder.transform.position.z;
        teacherLeftShoulderPos = teacherLeftShoulder.transform.position;
        teacherLeftShoulderRot = teacherLeftShoulder.transform.rotation.eulerAngles;

        teacherRightShoulderPosX = teacherRightShoulder.transform.position.x;
        teacherRightShoulderPosY = teacherRightShoulder.transform.position.y;
        teacherRightShoulderPosZ = teacherRightShoulder.transform.position.z;
        teacherRightShoulderRotX = teacherRightShoulder.transform.position.x;
        teacherRightShoulderRotY = teacherRightShoulder.transform.position.y;
        teacherRightShoulderRotZ = teacherRightShoulder.transform.position.z;
        teacherRightShoulderPos = teacherRightShoulder.transform.position;
        teacherRightShoulderRot = teacherRightShoulder.transform.rotation.eulerAngles;

        teacherLeftElbowPosX = teacherLeftElbow.transform.position.x;
        teacherLeftElbowPosY = teacherLeftElbow.transform.position.y;
        teacherLeftElbowPosZ = teacherLeftElbow.transform.position.z;
        teacherLeftElbowRotX = teacherLeftElbow.transform.position.x;
        teacherLeftElbowRotY = teacherLeftElbow.transform.position.y;
        teacherLeftElbowRotZ = teacherLeftElbow.transform.position.z;
        teacherLeftElbowPos = teacherLeftElbow.transform.position;
        teacherLeftElbowRot = teacherLeftElbow.transform.rotation.eulerAngles;

        teacherRightElbowPosX = teacherRightElbow.transform.position.x;
        teacherRightElbowPosY = teacherRightElbow.transform.position.y;
        teacherRightElbowPosZ = teacherRightElbow.transform.position.z;
        teacherRightElbowRotX = teacherRightElbow.transform.position.x;
        teacherRightElbowRotY = teacherRightElbow.transform.position.y;
        teacherRightElbowRotZ = teacherRightElbow.transform.position.z;
        teacherRightElbowPos = teacherRightElbow.transform.position;
        teacherRightElbowRot = teacherRightElbow.transform.rotation.eulerAngles;

        teacherLeftKneePosX = teacherLeftKnee.transform.position.x;
        teacherLeftKneePosY = teacherLeftKnee.transform.position.y;
        teacherLeftKneePosZ = teacherLeftKnee.transform.position.z;
        teacherLeftKneeRotX = teacherLeftKnee.transform.position.x;
        teacherLeftKneeRotY = teacherLeftKnee.transform.position.y;
        teacherLeftKneeRotZ = teacherLeftKnee.transform.position.z;
        teacherLeftKneePos = teacherLeftKnee.transform.position;
        teacherLeftKneeRot = teacherLeftKnee.transform.rotation.eulerAngles;

        teacherRightKneePosX = teacherRightKnee.transform.position.x;
        teacherRightKneePosY = teacherRightKnee.transform.position.y;
        teacherRightKneePosZ = teacherRightKnee.transform.position.z;
        teacherRightKneeRotX = teacherRightKnee.transform.position.x;
        teacherRightKneeRotY = teacherRightKnee.transform.position.y;
        teacherRightKneeRotZ = teacherRightKnee.transform.position.z;
        teacherRightKneePos = teacherRightKnee.transform.position;
        teacherRightKneeRot = teacherRightKnee.transform.rotation.eulerAngles;

        teacherBoxPosX = teacherBox.transform.position.x;
        teacherBoxPosY = teacherBox.transform.position.y;
        teacherBoxPosZ = teacherBox.transform.position.z;
        teacherBoxRotX = teacherBox.transform.position.x;
        teacherBoxRotY = teacherBox.transform.position.y;
        teacherBoxRotZ = teacherBox.transform.position.z;
        teacherBoxPos = teacherBox.transform.position;
        teacherBoxRot = teacherBox.transform.rotation.eulerAngles;

        teacherTablePosX = teacherTable.transform.position.x;
        teacherTablePosY = teacherTable.transform.position.y;
        teacherTablePosZ = teacherTable.transform.position.z;
        teacherTableRotX = teacherTable.transform.position.x;
        teacherTableRotY = teacherTable.transform.position.y;
        teacherTableRotZ = teacherTable.transform.position.z;
        teacherTablePos = teacherTable.transform.position;
        teacherTableRot = teacherTable.transform.rotation.eulerAngles;

        // risk measurements
        // yxc set
        isFeetPlacementError = false;
        feetDistance = 1f;
        isSquatError = false;
        squatDistance = 1f;
        isSpineTwistError = false;
        spineTwistAngle = 1f;
        isSpindBendError = false;
        spineBendAngle = 1f;

        distanceStudentTeacherBox = 1f;
        rayTraceHitTeacherId = "teacherId";

    }

    // Update is called once per frame
    void Update()
    {
        float millisecondsElapsed =
            (int)(DateTime.Now - startTime).TotalMilliseconds;
        DateTime time = DateTime.Now;
        string lineToWrite = millisecondsElapsed + ";" + time + ";" + studentHMDPosX + ";" + studentHMDPosY + ";" + studentHMDPosZ + ";" + studentHMDRotX + ";" + studentHMDRotY + ";" + studentHMDRotZ + ";" + studentHMDPos + ";" + studentHMDRot + ";" + studentLeftHandTrackerPosX + ";" + studentLeftHandTrackerPosY + ";" + studentLeftHandTrackerPosZ + ";" + studentLeftHandTrackerRotX + ";" + studentLeftHandTrackerRotY + ";" + studentLeftHandTrackerRotZ + ";" + studentLeftHandTrackerPos + ";" + studentLeftHandTrackerRot + ";" + studentRightHandTrackerPosX + ";" + studentRightHandTrackerPosY + ";" + studentRightHandTrackerPosZ + ";" + studentRightHandTrackerRotX + ";" + studentRightHandTrackerRotY + ";" + studentRightHandTrackerRotZ + ";" + studentRightHandTrackerPos + ";" + studentRightHandTrackerRot + ";" + studentLeftShoulderTrackerPosX + ";" + studentLeftShoulderTrackerPosY + ";" + studentLeftShoulderTrackerPosZ + ";" + studentLeftShoulderTrackerRotX + ";" + studentLeftShoulderTrackerRotY + ";" + studentLeftShoulderTrackerRotZ + ";" + studentLeftShoulderTrackerPos + ";" + studentLeftShoulderTrackerRot + ";" + studentRightShoulderTrackerPosX + ";" + studentRightShoulderTrackerPosY + ";" + studentRightShoulderTrackerPosZ + ";" + studentRightShoulderTrackerRotX + ";" + studentRightShoulderTrackerRotY + ";" + studentRightShoulderTrackerRotZ + ";" + studentRightShoulderTrackerPos + ";" + studentRightShoulderTrackerRot + ";" + studentUpperHipTrackerPosX + ";" + studentUpperHipTrackerPosY + ";" + studentUpperHipTrackerPosZ + ";" + studentUpperHipTrackerRotX + ";" + studentUpperHipTrackerRotY + ";" + studentUpperHipTrackerRotZ + ";" + studentUpperHipTrackerPos + ";" + studentUpperHipTrackerRot + ";" + studentLowerHipTrackerPosX + ";" + studentLowerHipTrackerPosY + ";" + studentLowerHipTrackerPosZ + ";" + studentLowerHipTrackerRotX + ";" + studentLowerHipTrackerRotY + ";" + studentLowerHipTrackerRotZ + ";" + studentLowerHipTrackerPos + ";" + studentLowerHipTrackerRot + ";" + studentLeftFootTrackerPosX + ";" + studentLeftFootTrackerPosY + ";" + studentLeftFootTrackerPosZ + ";" + studentLeftFootTrackerRotX + ";" + studentLeftFootTrackerRotY + ";" + studentLeftFootTrackerRotZ + ";" + studentLeftFootTrackerPos + ";" + studentLeftFootTrackerRot + ";" + studentRightFootTrackerPosX + ";" + studentRightFootTrackerPosY + ";" + studentRightFootTrackerPosZ + ";" + studentRightFootTrackerRotX + ";" + studentRightFootTrackerRotY + ";" + studentRightFootTrackerRotZ + ";" + studentRightFootTrackerPos + ";" + studentRightFootTrackerRot + ";" + studentBoxTrackerPosX + ";" + studentBoxTrackerPosY + ";" + studentBoxTrackerPosZ + ";" + studentBoxTrackerRotX + ";" + studentBoxTrackerRotY + ";" + studentBoxTrackerRotZ + ";" + studentBoxTrackerPos + ";" + studentBoxTrackerRot + ";" + studentTableTrackerPosX + ";" + studentTableTrackerPosY + ";" + studentTableTrackerPosZ + ";" + studentTableTrackerRotX + ";" + studentTableTrackerRotY + ";" + studentTableTrackerRotZ + ";" + studentTableTrackerPos + ";" + studentTableTrackerRot + ";" + studentHeadPosX + ";" + studentHeadPosY + ";" + studentHeadPosZ + ";" + studentHeadRotX + ";" + studentHeadRotY + ";" + studentHeadRotZ + ";" + studentHeadPos + ";" + studentHeadRot + ";" + studentLowerHipPosX + ";" + studentLowerHipPosY + ";" + studentLowerHipPosZ + ";" + studentLowerHipRotX + ";" + studentLowerHipRotY + ";" + studentLowerHipRotZ + ";" + studentLowerHipPos + ";" + studentLowerHipRot + ";" + studentUpperHipPosX + ";" + studentUpperHipPosY + ";" + studentUpperHipPosZ + ";" + studentUpperHipRotX + ";" + studentUpperHipRotY + ";" + studentUpperHipRotZ + ";" + studentUpperHipPos + ";" + studentUpperHipRot + ";" + studentLeftHandPosX + ";" + studentLeftHandPosY + ";" + studentLeftHandPosZ + ";" + studentLeftHandRotX + ";" + studentLeftHandRotY + ";" + studentLeftHandRotZ + ";" + studentLeftHandPos + ";" + studentLeftHandRot + ";" + studentRightHandPosX + ";" + studentRightHandPosY + ";" + studentRightHandPosZ + ";" + studentRightHandRotX + ";" + studentRightHandRotY + ";" + studentRightHandRotZ + ";" + studentRightHandPos + ";" + studentRightHandRot + ";" + studentLeftFootPosX + ";" + studentLeftFootPosY + ";" + studentLeftFootPosZ + ";" + studentLeftFootRotX + ";" + studentLeftFootRotY + ";" + studentLeftFootRotZ + ";" + studentLeftFootPos + ";" + studentLeftFootRot + ";" + studentRightFootPosX + ";" + studentRightFootPosY + ";" + studentRightFootPosZ + ";" + studentRightFootRotX + ";" + studentRightFootRotY + ";" + studentRightFootRotZ + ";" + studentRightFootPos + ";" + studentRightFootRot + ";" + studentLeftShoulderPosX + ";" + studentLeftShoulderPosY + ";" + studentLeftShoulderPosZ + ";" + studentLeftShoulderRotX + ";" + studentLeftShoulderRotY + ";" + studentLeftShoulderRotZ + ";" + studentLeftShoulderPos + ";" + studentLeftShoulderRot + ";" + studentRightShoulderPosX + ";" + studentRightShoulderPosY + ";" + studentRightShoulderPosZ + ";" + studentRightShoulderRotX + ";" + studentRightShoulderRotY + ";" + studentRightShoulderRotZ + ";" + studentRightShoulderPos + ";" + studentRightShoulderRot + ";" + studentLeftElbowPosX + ";" + studentLeftElbowPosY + ";" + studentLeftElbowPosZ + ";" + studentLeftElbowRotX + ";" + studentLeftElbowRotY + ";" + studentLeftElbowRotZ + ";" + studentLeftElbowPos + ";" + studentLeftElbowRot + ";" + studentRightElbowPosX + ";" + studentRightElbowPosY + ";" + studentRightElbowPosZ + ";" + studentRightElbowRotX + ";" + studentRightElbowRotY + ";" + studentRightElbowRotZ + ";" + studentRightElbowPos + ";" + studentRightElbowRot + ";" + studentLeftKneePosX + ";" + studentLeftKneePosY + ";" + studentLeftKneePosZ + ";" + studentLeftKneeRotX + ";" + studentLeftKneeRotY + ";" + studentLeftKneeRotZ + ";" + studentLeftKneePos + ";" + studentLeftKneeRot + ";" + studentRightKneePosX + ";" + studentRightKneePosY + ";" + studentRightKneePosZ + ";" + studentRightKneeRotX + ";" + studentRightKneeRotY + ";" + studentRightKneeRotZ + ";" + studentRightKneePos + ";" + studentRightKneeRot + ";" + studentBoxPosX + ";" + studentBoxPosY + ";" + studentBoxPosZ + ";" + studentBoxRotX + ";" + studentBoxRotY + ";" + studentBoxRotZ + ";" + studentBoxPos + ";" + studentBoxRot + ";" + studentTablePosX + ";" + studentTablePosY + ";" + studentTablePosZ + ";" + studentTableRotX + ";" + studentTableRotY + ";" + studentTableRotZ + ";" + studentTablePos + ";" + studentTableRot + ";" + teacherHMDPosX + ";" + teacherHMDPosY + ";" + teacherHMDPosZ + ";" + teacherHMDRotX + ";" + teacherHMDRotY + ";" + teacherHMDRotZ + ";" + teacherHMDPos + ";" + teacherHMDRot + ";" + teacherLeftHandTrackerPosX + ";" + teacherLeftHandTrackerPosY + ";" + teacherLeftHandTrackerPosZ + ";" + teacherLeftHandTrackerRotX + ";" + teacherLeftHandTrackerRotY + ";" + teacherLeftHandTrackerRotZ + ";" + teacherLeftHandTrackerPos + ";" + teacherLeftHandTrackerRot + ";" + teacherRightHandTrackerPosX + ";" + teacherRightHandTrackerPosY + ";" + teacherRightHandTrackerPosZ + ";" + teacherRightHandTrackerRotX + ";" + teacherRightHandTrackerRotY + ";" + teacherRightHandTrackerRotZ + ";" + teacherRightHandTrackerPos + ";" + teacherRightHandTrackerRot + ";" + teacherLeftShoulderTrackerPosX + ";" + teacherLeftShoulderTrackerPosY + ";" + teacherLeftShoulderTrackerPosZ + ";" + teacherLeftShoulderTrackerRotX + ";" + teacherLeftShoulderTrackerRotY + ";" + teacherLeftShoulderTrackerRotZ + ";" + teacherLeftShoulderTrackerPos + ";" + teacherLeftShoulderTrackerRot + ";" + teacherRightShoulderTrackerPosX + ";" + teacherRightShoulderTrackerPosY + ";" + teacherRightShoulderTrackerPosZ + ";" + teacherRightShoulderTrackerRotX + ";" + teacherRightShoulderTrackerRotY + ";" + teacherRightShoulderTrackerRotZ + ";" + teacherRightShoulderTrackerPos + ";" + teacherRightShoulderTrackerRot + ";" + teacherUpperHipTrackerPosX + ";" + teacherUpperHipTrackerPosY + ";" + teacherUpperHipTrackerPosZ + ";" + teacherUpperHipTrackerRotX + ";" + teacherUpperHipTrackerRotY + ";" + teacherUpperHipTrackerRotZ + ";" + teacherUpperHipTrackerPos + ";" + teacherUpperHipTrackerRot + ";" + teacherLowerHipTrackerPosX + ";" + teacherLowerHipTrackerPosY + ";" + teacherLowerHipTrackerPosZ + ";" + teacherLowerHipTrackerRotX + ";" + teacherLowerHipTrackerRotY + ";" + teacherLowerHipTrackerRotZ + ";" + teacherLowerHipTrackerPos + ";" + teacherLowerHipTrackerRot + ";" + teacherLeftFootTrackerPosX + ";" + teacherLeftFootTrackerPosY + ";" + teacherLeftFootTrackerPosZ + ";" + teacherLeftFootTrackerRotX + ";" + teacherLeftFootTrackerRotY + ";" + teacherLeftFootTrackerRotZ + ";" + teacherLeftFootTrackerPos + ";" + teacherLeftFootTrackerRot + ";" + teacherRightFootTrackerPosX + ";" + teacherRightFootTrackerPosY + ";" + teacherRightFootTrackerPosZ + ";" + teacherRightFootTrackerRotX + ";" + teacherRightFootTrackerRotY + ";" + teacherRightFootTrackerRotZ + ";" + teacherRightFootTrackerPos + ";" + teacherRightFootTrackerRot + ";" + teacherBoxTrackerPosX + ";" + teacherBoxTrackerPosY + ";" + teacherBoxTrackerPosZ + ";" + teacherBoxTrackerRotX + ";" + teacherBoxTrackerRotY + ";" + teacherBoxTrackerRotZ + ";" + teacherBoxTrackerPos + ";" + teacherBoxTrackerRot + ";" + teacherTableTrackerPosX + ";" + teacherTableTrackerPosY + ";" + teacherTableTrackerPosZ + ";" + teacherTableTrackerRotX + ";" + teacherTableTrackerRotY + ";" + teacherTableTrackerRotZ + ";" + teacherTableTrackerPos + ";" + teacherTableTrackerRot + ";" + teacherHeadPosX + ";" + teacherHeadPosY + ";" + teacherHeadPosZ + ";" + teacherHeadRotX + ";" + teacherHeadRotY + ";" + teacherHeadRotZ + ";" + teacherHeadPos + ";" + teacherHeadRot + ";" + teacherLowerHipPosX + ";" + teacherLowerHipPosY + ";" + teacherLowerHipPosZ + ";" + teacherLowerHipRotX + ";" + teacherLowerHipRotY + ";" + teacherLowerHipRotZ + ";" + teacherLowerHipPos + ";" + teacherLowerHipRot + ";" + teacherUpperHipPosX + ";" + teacherUpperHipPosY + ";" + teacherUpperHipPosZ + ";" + teacherUpperHipRotX + ";" + teacherUpperHipRotY
         + ";" + teacherUpperHipRotZ + ";" + teacherUpperHipPos + ";" + teacherUpperHipRot + ";" + teacherLeftHandPosX + ";" + teacherLeftHandPosY + ";" + teacherLeftHandPosZ + ";" + teacherLeftHandRotX + ";" + teacherLeftHandRotY + ";" + teacherLeftHandRotZ + ";" + teacherLeftHandPos + ";" + teacherLeftHandRot + ";" + teacherRightHandPosX + ";" + teacherRightHandPosY + ";" + teacherRightHandPosZ + ";" + teacherRightHandRotX + ";" + teacherRightHandRotY + ";" + teacherRightHandRotZ + ";" + teacherRightHandPos + ";" + teacherRightHandRot + ";" + teacherLeftFootPosX + ";" + teacherLeftFootPosY + ";" + teacherLeftFootPosZ + ";" + teacherLeftFootRotX + ";" + teacherLeftFootRotY + ";" + teacherLeftFootRotZ + ";" + teacherLeftFootPos + ";" + teacherLeftFootRot + ";" + teacherRightFootPosX + ";" + teacherRightFootPosY + ";" + teacherRightFootPosZ + ";" + teacherRightFootRotX + ";" + teacherRightFootRotY + ";" + teacherRightFootRotZ + ";" + teacherRightFootPos + ";" + teacherRightFootRot + ";" + teacherLeftShoulderPosX + ";" + teacherLeftShoulderPosY + ";" + teacherLeftShoulderPosZ + ";" + teacherLeftShoulderRotX + ";" + teacherLeftShoulderRotY + ";" + teacherLeftShoulderRotZ + ";" + teacherLeftShoulderPos + ";" + teacherLeftShoulderRot + ";" + teacherRightShoulderPosX + ";" + teacherRightShoulderPosY + ";" + teacherRightShoulderPosZ + ";" + teacherRightShoulderRotX + ";" + teacherRightShoulderRotY + ";" + teacherRightShoulderRotZ + ";" + teacherRightShoulderPos + ";" + teacherRightShoulderRot + ";" + teacherLeftElbowPosX + ";" + teacherLeftElbowPosY + ";" + teacherLeftElbowPosZ + ";" + teacherLeftElbowRotX + ";" + teacherLeftElbowRotY + ";" + teacherLeftElbowRotZ + ";" + teacherLeftElbowPos + ";" + teacherLeftElbowRot + ";" + teacherRightElbowPosX + ";" + teacherRightElbowPosY + ";" + teacherRightElbowPosZ + ";" + teacherRightElbowRotX + ";" + teacherRightElbowRotY + ";" + teacherRightElbowRotZ + ";" + teacherRightElbowPos + ";" + teacherRightElbowRot + ";" + teacherLeftKneePosX + ";" + teacherLeftKneePosY + ";" + teacherLeftKneePosZ + ";" + teacherLeftKneeRotX + ";" + teacherLeftKneeRotY + ";" + teacherLeftKneeRotZ + ";" + teacherLeftKneePos + ";" + teacherLeftKneeRot + ";" + teacherRightKneePosX + ";" + teacherRightKneePosY + ";" + teacherRightKneePosZ + ";" + teacherRightKneeRotX + ";" + teacherRightKneeRotY + ";" + teacherRightKneeRotZ + ";" + teacherRightKneePos + ";" + teacherRightKneeRot + ";" + teacherBoxPosX + ";" + teacherBoxPosY + ";" + teacherBoxPosZ + ";" + teacherBoxRotX + ";" + teacherBoxRotY + ";" + teacherBoxRotZ + ";" + teacherBoxPos + ";" + teacherBoxRot + ";" + teacherTablePosX + ";" + teacherTablePosY + ";" + teacherTablePosZ + ";" + teacherTableRotX + ";" + teacherTableRotY + ";" + teacherTableRotZ + ";" + teacherTablePos + ";" + teacherTableRot + ";" + isFeetPlacementError + ";" + feetDistance + ";" + isSquatError + ";" + squatDistance + ";" + isSpineTwistError + ";" + spineTwistAngle + ";" + isSpindBendError + ";" + spineBendAngle + ";" + distanceStudentTeacherBox + ";" + rayTraceHitTeacherId;
        file.WriteLine(lineToWrite);
    }
}
