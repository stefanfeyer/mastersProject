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

    private string state = "start";
    public string fileName = "testFile.txt";

    private string path = @"C:\FEYER\logs\";
    private string theLog = "";
    private int currentAnimationFrame = 0;
    private int totalAnimationFrames = 0;

    StreamWriter file;

    DateTime startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = DateTime.Now;
        addHeaderToLog();
    }

    // Update is called once per frame
    void Update()
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

        if (totalAnimationFrames >= currentAnimationFrame)
        {
            storeData();
        }
    }

    private void createLogEntry(){
        Debug.Log("creating log entry for frame: " + currentAnimationFrame);
        addLine();
    }
    private void addLine()
    {
        theLog = theLog + getElaplsedTimeInMs() + getCurrentAnimationFrameString() + getState() + studentBodyValues() + teacherBodyValues() + studentPropsValues() + teacherPropsValues() + getRiskMetrics() + "\n";
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

    private string getCurrentAnimationFrameString(){
        return currentAnimationFrame + ";";
    }
    private string getState(){
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
        // todo
        theLog = theLog + "time;subTaskId";
    }

    

    private string studentBodyValues(){
        string output = "";
        foreach (Transform child in studentBody.transform)
        {
            output = output + transformToString(child) + ";";
        }
        return output;
    }
    private string teacherBodyValues()
    {
        string output = "";
        foreach (Transform child in teacherBody.transform)
        {
            output = output + transformToString(child) + ";";
        }
        return output;
    }
    private string studentPropsValues()
    {
        string output = "";
        foreach (Transform child in studentProps.transform)
        {
            output = output + transformToString(child) + ";";
        }
        return output;
    }
    private string teacherPropsValues()
    {
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

    private string getElaplsedTimeInMs(){
        return (int)(DateTime.Now - startTime).TotalMilliseconds + ";";
    }

    private string getLookingAt(){
        return rayCast.GetComponent<lookingAt>().rayCastHitName + ";";
    }

    private string getRiskMetrics(){
        //todo
        return ";";
    }

    private void storeData(){
        file = new System.IO.StreamWriter(path + fileName, true);
        file.Write(theLog);
    }
}
