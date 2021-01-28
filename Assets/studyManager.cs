using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class studyManager : MonoBehaviour
{
    // 1, 2, 3
    public int taskId = 1;

    // ego, exo, egoexo
    public string perspectiveId = "ego";
    
    // T1, T2, T3 ...
    public string participantId = "T1";

    public Animation task1AnimationBody;
    public Animation task2AnimationBody;
    public Animation task3AnimationBody;
    public Animation task1AnimationProps;
    public Animation task2AnimationProps;
    public Animation task3AnimationProps;

    public GameObject maleCharacter;
    public GameObject femaleCharacter;
    public GameObject scriptholder;

    private Animator teacherAnimator;
    private Animator studentAnimator;

    void Start()
    {
        scriptholder.GetComponent<logging>().taskId = taskId;
        scriptholder.GetComponent<logging>().participantId = participantId;
        scriptholder.GetComponent<logging>().perspectiveId = perspectiveId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
