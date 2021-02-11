using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class studyManager : MonoBehaviour
{
    [Header("1, 2, 3")]
    public int taskId = 1;

    [Header("ego, exo, egoexo")]
    public string perspectiveId = "ego";
    
    [Header("PT1, PT2, PT3")]
    public string participantId = "PT1";
    public GameObject scriptHolder;

    [Header("AnimatorControllers")]
    public RuntimeAnimatorController t1Body;
    public RuntimeAnimatorController t1Props;
    public RuntimeAnimatorController t2Body;
    public RuntimeAnimatorController t2Props;
    public RuntimeAnimatorController t3Body;
    public RuntimeAnimatorController t3Props;

    [Header("Animators")]
    public GameObject teacher0Body;
    public GameObject teacher0Porps;
    public GameObject teacher1Body;
    public GameObject teacher1Porps;
    public GameObject teacher2Body;
    public GameObject teacher2Porps;
    public GameObject teacher3Body;
    public GameObject teacher3Porps;
    public GameObject teacher4Body;
    public GameObject teacher4Porps;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 /* 
    public void studySetup(){
        Debug.Log("Study Setup: " + taskId + participantId + perspectiveId);
        
        scriptHolder.GetComponent<logging>().taskId = taskId;
        scriptHolder.GetComponent<logging>().participantId = participantId;
        scriptHolder.GetComponent<logging>().perspectiveId = perspectiveId;

       
        GameObject[] propsAnimators = new GameObject[] { teacher0Porps, teacher1Porps, teacher2Porps, teacher3Porps, teacher4Porps };
        GameObject[] bodyAnimators = new GameObject[] { teacher0Body, teacher1Body, teacher2Body, teacher3Body, teacher4Body };
        foreach (GameObject item in bodyAnimators)
        {
            if (item != null)
            {
                switch (taskId)
                {
                    case 1:
                        item.GetComponent<Animator>().runtimeAnimatorController = t1Body;
                        break;
                    case 2:
                        item.GetComponent<Animator>().runtimeAnimatorController = t2Body;
                        break;
                    case 3:
                        item.GetComponent<Animator>().runtimeAnimatorController = t3Body;
                        break;
                    default:
                        break;
                }
            }
        }

        foreach (GameObject item in propsAnimators)
        {
            if (item != null)
            {
                switch (taskId)
                {
                    case 1:
                        item.GetComponent<Animator>().runtimeAnimatorController = t1Props;
                        break;
                    case 2:
                        item.GetComponent<Animator>().runtimeAnimatorController = t2Props;
                        break;
                    case 3:
                        item.GetComponent<Animator>().runtimeAnimatorController = t3Props;
                        break;
                    default:
                        break;
                }
            }
        }
    
    }
*/

}
