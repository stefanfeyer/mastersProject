using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStartSynchroniser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject teacher0;
    public GameObject props0;

    private Animator teacher0BodyAnimator;
    private Animator teacher0Props0Animator;
    void Start()
    {
        teacher0BodyAnimator = teacher0.GetComponent<Animator>();
        teacher0Props0Animator = props0.GetComponent<Animator>();
        teacher0BodyAnimator.speed = 0f;
        teacher0Props0Animator.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            //startAnimation();
        }
    }

    public void startAnimation(){
        teacher0BodyAnimator.speed = 1f;
        teacher0Props0Animator.speed = 1f;
    }
}
