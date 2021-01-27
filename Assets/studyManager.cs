using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class studyManager : MonoBehaviour
{
    public enum TaskEnum
    {
        Task1,
        Task2,
        Task3
    } 
    public enum PerspectiveEnum
    {
        Ego,
        Exo,
        EgoExo
    } 
    public enum SexEnum
    {
        Male,
        Female
    } 
    public TaskEnum task = new TaskEnum();
    public PerspectiveEnum perspective = new PerspectiveEnum();
    public SexEnum sex = new SexEnum();

    public Animation task1Animation;
    public Animation task2Animation;
    public Animation task3Animation;
    public GameObject maleCharacter;
    public GameObject femaleCharacter;
    public GameObject scriptholder;

    private Animator teacherAnimator;
    private Animator studentAnimator;
    private logging loggingScript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
