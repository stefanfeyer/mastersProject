using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recorderController : MonoBehaviour
{
    public GameObject body;
    public GameObject props;

    public string fileName = "";

    private UnityAnimationRecorder bodyRecorder;
    private UnityAnimationRecorder propsRecorder;
    // Start is called before the first frame update
    void Start()
    {
        bodyRecorder = body.GetComponent<UnityAnimationRecorder>();
        propsRecorder = props.GetComponent<UnityAnimationRecorder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            startRecording();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            stopRecording();
        }
    }

    void startRecording(){
        bodyRecorder.fileName = fileName + "Student";
        bodyRecorder.StartRecording();
        propsRecorder.fileName = fileName + "Props";
        propsRecorder.StartRecording();
    }

    void stopRecording(){
        bodyRecorder.StopRecording();
        propsRecorder.StopRecording();
    }
}
