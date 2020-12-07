using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using Valve.VR;

namespace RootMotion.Demos
{
    // Simple avatar scale calibration.
    public class VRIKAvatarScaleCalibrationSteamVR : MonoBehaviour
    {
        public VRIK ik;
        public GameObject box;
        public GameObject table;
        public float scaleMlp = 1f;

        public SteamVR_Action_Boolean grabPinch;
        public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

        private bool calibrateFlag;

        


        void OnEnable()
        {
            if (grabPinch != null)
            {
                grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
            }
        }

        private void OnDisable()
        {
            if (grabPinch != null)
            {
                grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSource);
            }
        }

        private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
        {
            // Return if trigger released
            if (!newState) return;

            // You can calibrate directly here only if you have "Input Update Mode" set to "OnLateUpdate" in the SteamVR_Settings file.
            calibrateFlag = false;
        }


        private void LateUpdate()
        {
            // Making sure calibration is done in LateUpdate
            //if (!calibrateFlag) return;
            //calibrateFlag = false;

            
            // Compare the height of the head target to the height of the head bone, multiply scale by that value.
            
            //float sizeF = (ik.solver.spine.headTarget.position.y - ik.references.root.position.y) / (ik.references.head.position.y - ik.references.root.position.y);
            //teacherReference.transform.localScale *= sizeF;
            //ik.references.root.localScale *= sizeF * scaleMlp;
            
            
            //float sizeF = (ik.solver.spine.headTarget.position.y - teacherIk.references.root.position.y) / (teacherIk.references.head.position.y - teacherIk.references.root.position.y);
            //Debug.Log(sizeF);
            //Debug.Log(ik.solver.spine.headTarget.position.y);
            //Debug.Log(teacherIk.solver.spine.headTarget.position.y);
            //float deltaY = ik.solver.spine.headTarget.position.y - teacherIk.solver.spine.headTarget.position.y;
            //teacherIk.references.root.localScale *= sizeF * scaleMlp;
            //teacherIk.solver.spine.headTarget.position = new Vector3(
            //teacherIk.solver.spine.headTarget.position.x,
            //teacherIk.solver.spine.headTarget.position.y -1,
            //teacherIk.solver.spine.headTarget.position.z);
            
        }

        private void Update(){
            //teacherDummy.transform.position = new Vector3(teacherDummy.transform.position.x, teacherDummy.transform.position.y + 1, teacherDummy.transform.position.z);
            //teacherIk.references.root.position = new Vector3(
            //teacherIk.references.root.position.x,
            //teacherIk.references.root.position.y -1,
            //teacherIk.references.root.position.z);
        }

        public float resize(){
            // Compare the height of the head target to the height of the head bone, multiply scale by that value.
            float sizeF = (ik.solver.spine.headTarget.position.y - ik.references.root.position.y) / (ik.references.head.position.y - ik.references.root.position.y);
            //teacherReference.transform.localScale *= sizeF;
            //ik.references.root.localScale *= sizeF * scaleMlp;
            
            Debug.Log("Calculated sizeF: ");
            Debug.Log(sizeF);
            box.transform.localScale *= 1/sizeF;
            table.transform.localScale *= 1/sizeF;
            return sizeF;
        }
    }
}
