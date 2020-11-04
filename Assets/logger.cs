using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using System;
using System.Diagnostics;

public class logger : MonoBehaviour
{
    public string taskId;
    public string conditionId;
    public GameObject studentLowerHip;
    public GameObject studentUpperHip;
    public GameObject studentLeftHand;
    public GameObject studentRightHand;
    public GameObject studentLeftFoot;
    public GameObject studentRightFoot;
    public GameObject studentLeftShoulder;
    public GameObject studentRightShoulder;
    public GameObject studentBox;

    public GameObject teacherLowerHip;
    public GameObject teacherUpperHip;
    public GameObject teacherLeftHand;
    public GameObject teacherRightHand;
    public GameObject teacherLeftFoot;
    public GameObject teacherRightFoot;
    public GameObject teacherLeftShoulder;
    public GameObject teacherRightShoulder;
    public GameObject teacherBox;

    public string fileName = "testFile.txt";
    string path = @"C:\FEYER\logs\";
    StreamWriter file;
    DateTime startTime;

    // Box
    int studentBoxPosX;
    int studentBoxPosY;
    int studentBoxPosZ;
    int studentBoxRotX;
    int studentBoxRotY;
    int studentBoxRotZ;
    Vector3 studentBoxPos;
    Vector3 studentBoxRot;

    int teacherBoxPosX;
    int teacherBoxPosY;
    int teacherBoxPosZ;
    int teacherBoxRotX;
    int teacherBoxRotY;
    int teacherBoxRotZ;
    Vector3 teacherBoxPos;
    Vector3 teacherBoxRot;

    float boxDistance;

    // avatar
    int studentAvatarPosX;
    int studentAvatarPosY;
    int studentAvatarPosZ;

    int teacherAvatarPosX;
    int teacherAvatarPosY;
    int teacherAvatarPosZ;

    int studentAvatarRotX;
    int studentAvatarRotY;
    int studentAvatarRotZ;

    int teacherAvatarRotX;
    int teacherAvatarRotY;
    int teacherAvatarRot;

    Vector3 studenAvatarPos;
    Vector3 teacheAvatarRot;

    // riskMeasures only Student
    // feet
    int lFootPosX;
    int lFootPosY;
    int lFootPosZ;
    int lFootRotX;
    int lFootRotY;
    int lFootRotZ;
    Vector3 lFootPos;
    Vector3 lFootRot;

    int rFootPosX;
    int rFootPosY;
    int rFootPosZ;
    int rFootRotX;
    int rFootRotY;
    int rFootRotZ;
    Vector3 rFootPos;
    Vector3 rFootRot;

    // hip
    int lowerHipPosX;
    int lowerHipPosY;
    int lowerHipPosZ;
    int lowerHipRotX;
    int lowerHipRotY;
    int lowerHipRotZ;
    Vector3 lowerHipPos;
    Vector3 lowerHipRot;

    int upperHipPosX;
    int upperHipPosY;
    int upperHipPosZ;
    int upperHipRotX;
    int upperHipRotY;
    int upperHipRotZ;
    Vector3 upperHipPos;
    Vector3 upperHipRot;

    // shoulder
    int rightShoulderPosX;
    int rightShoulderPosY;
    int rightShoulderPosZ;
    int rightShoulderRotX;
    int rightShoulderRotY;
    int rightShoulderRotZ;
    Vector3 rightShoulderPos;
    Vector3 rightShoulderRot;

    int leftShoulderPosX;
    int leftShoulderPosY;
    int leftShoulderPosZ;
    int leftShoulderRotX;
    int leftShoulderRotY;
    int leftShoulderRotZ;
    Vector3 leftShoulderPos;
    Vector3 leftShoulderRot;

    bool isFeetPlacementError;
    float feetDistance;
    bool isSquatError;
    float squatDistance;
    bool isSpineTwistError;
    float spineTwistAngle;
    bool isSpindBendError;
    float spineBendAngle;

    // head student only
    int headPosX;
    int headPosY;
    int headPosZ;
    int headRotX;
    int headRotY;
    int headRotZ;
    Vector3 headPos;
    Vector3 headRot;
    string rayTraceHitTeacherId;

    // hands
    int lHandPosX;
    int lHandPosY;
    int lHandPosZ;
    int lHandRotX;
    int lHandRotY;
    int lHandRotZ;
    Vector3 lHandPos;
    Vector3 lHandRot;

    int rHandPosX;
    int rHandPosY;
    int rHandPosZ;
    int rHandRotX;
    int rHandRotY;
    int rHandRotZ;
    Vector3 rHandPos;
    Vector3 rHandRot;


    // eye Tracker?
    // task sequence? lift, lower, turn, push, pull


    void doSth()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
        file = new System.IO.StreamWriter(path + fileName, true);
        string csvHeader = "milisecondsElapsed;time;teacherBoxPosition;studentBoxPosition;teacherBoxRotation;studentBoxRotation;boxPosition;boxDistance";
        file.WriteLine(csvHeader);

        studentBoxPosX = studentBox.transform.position.X;
        studentBoxPosY;
        studentBoxPosZ;
        studentBoxRotX;
        studentBoxRotY;
        studentBoxRotZ;
        studentBoxPos;
        studentBoxRot;
        teacherBoxPosX;
        teacherBoxPosY;
        teacherBoxPosZ;
        teacherBoxRotX;
        teacherBoxRotY;
        teacherBoxRotZ;
        teacherBoxPos;
        teacherBoxRot;
        boxDistance;
        studentAvatarPosX;
        studentAvatarPosY;
        studentAvatarPosZ;
        teacherAvatarPosX;
        teacherAvatarPosY;
        teacherAvatarPosZ;
        studentAvatarRotX;
        studentAvatarRotY;
        studentAvatarRotZ;
        teacherAvatarRotX;
        teacherAvatarRotY;
        teacherAvatarRot;
        studenAvatarPos;
        teacheAvatarRot;
        lFootPosX;
        lFootPosY;
        lFootPosZ;
        lFootRotX;
        lFootRotY;
        lFootRotZ;
        lFootPos;
        lFootRot;
        rFootPosX;
        rFootPosY;
        rFootPosZ;
        rFootRotX;
        rFootRotY;
        rFootRotZ;
        rFootPos;
        rFootRot;
        lowerHipPosX;
        lowerHipPosY;
        lowerHipPosZ;
        lowerHipRotX;
        lowerHipRotY;
        lowerHipRotZ;
        lowerHipPos;
        lowerHipRot;
        upperHipPosX;
        upperHipPosY;
        upperHipPosZ;
        upperHipRotX;
        upperHipRotY;
        upperHipRotZ;
        upperHipPos;
        upperHipRot;
        rightShoulderPosX;
        rightShoulderPosY;
        rightShoulderPosZ;
        rightShoulderRotX;
        rightShoulderRotY;
        rightShoulderRotZ;
        rightShoulderPos;
        rightShoulderRot;
        leftShoulderPosX;
        leftShoulderPosY;
        leftShoulderPosZ;
        leftShoulderRotX;
        leftShoulderRotY;
        leftShoulderRotZ;
        leftShoulderPos;
        leftShoulderRot;
        isFeetPlacementError;
        feetDistance;
        isSquatError;
        squatDistance;
        isSpineTwistError;
        spineTwistAngle;
        isSpindBendError;
        spineBendAngle;
        headPosX;
        headPosY;
        headPosZ;
        headRotX;
        headRotY;
        headRotZ;
        headPos;
        headRot;
        rayTraceHitTeacherId;
        lHandPosX;
        lHandPosY;
        lHandPosZ;
        lHandRotX;
        lHandRotY;
        lHandRotZ;
        lHandPos;
        lHandRot;
        rHandPosX;
        rHandPosY;
        rHandPosZ;
        rHandRotX;
        rHandRotY;
        rHandRotZ;
        rHandPos;
        rHandRot;
    }

    // Update is called once per frame
    void Update()
    {
        int millisecondsElapsed = (int)(DateTime.Now - startTime).TotalMilliseconds;
        DateTime time = DateTime.Now;
        string lineToWrite = millisecondsElapsed + ";" + time + ";";
        file.WriteLine(lineToWrite);

    }
}
