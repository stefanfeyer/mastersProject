using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
using Valve.VR;

namespace RootMotion.Demos
{

    public class VRIKCalibrationController : MonoBehaviour
    {

        [Tooltip("Reference to the VRIK component on the avatar.")] public VRIK ik;
        [Tooltip("The settings for VRIK calibration.")] public VRIKCalibrator.Settings settings;
        [Tooltip("The HMD.")] public Transform headTracker;
        [Tooltip("(Optional) A tracker placed anywhere on the body of the player, preferrably close to the pelvis, on the belt area.")] public Transform bodyTracker;
        [Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's left hand.")] public Transform leftHandTracker;
        [Tooltip("(Optional) A tracker or hand controller device placed anywhere on or in the player's right hand.")] public Transform rightHandTracker;
        [Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's left leg.")] public Transform leftFootTracker;
        [Tooltip("(Optional) A tracker placed anywhere on the ankle or toes of the player's right leg.")] public Transform rightFootTracker;

        [Header("Data stored by Calibration")]
        public VRIKCalibrator.CalibrationData data = new VRIKCalibrator.CalibrationData();

        public bool showTrackers = false;
        public bool showMirror = false;

        public GameObject teacherCalibrationController;
        public GameObject teacherCalibrationController1;
        public GameObject teacherCalibrationController2;
        public GameObject teacherCalibrationController3;
        public GameObject teacherCalibrationController4;

        public GameObject studentCalibrationController1;
        public GameObject studentCalibrationController2;
        public GameObject studentCalibrationController3;
        public GameObject studentCalibrationController4;

        public GameObject teacherBody0;
        public GameObject teacherBody1;
        public GameObject teacherBody2;
        public GameObject teacherBody3;
        public GameObject teacherBody4;

        public bool isStudent;
        public GameObject avatarToResize;
        
        float scale;
        

        public GameObject studentTable;
        public GameObject studentScale;

        public GameObject neckStudent;
        public GameObject neckTeacher;

        public GameObject mirror;

        public GameObject scriptHolder;
 
        void LateUpdate()
        {           
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("C-block in calibration controller");
                // Calibrate the character, store data of the calibration
                if (isStudent)
                {
                    data = VRIKCalibrator.Calibrate(ik, settings, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);
                    scale = neckStudent.transform.position.y / neckTeacher.transform.position.y;
                    
                    GameObject[] teacherReferences = {teacherBody0,teacherBody1,teacherBody2,teacherBody3,teacherBody4};
                    GameObject[] callibrationControllers = {teacherCalibrationController,teacherCalibrationController1,teacherCalibrationController2,teacherCalibrationController3,teacherCalibrationController4};                    
                    GameObject[] studentCalibrationControllers = {studentCalibrationController1,studentCalibrationController2,studentCalibrationController3,studentCalibrationController4};
         
                    foreach (var item in teacherReferences)
                    {
                        if (item != null)
                        {
                            item.transform.localScale *= scale;//new Vector3(1f, scale, 1f);
                        }
                    }

                    foreach (var item in callibrationControllers)
                    {
                        if (item != null)
                        {
                            Debug.Log("TEACHER cal contr calibrate");
                            item.GetComponent<VRIKCalibrationController>().calibrate();
                        }
                    }

                    foreach (var item in studentCalibrationControllers)
                    {
                        if (item != null)
                        {
                            Debug.Log("STUDENT cal contr calibrate");
                            item.GetComponent<VRIKCalibrationController>().calibrate();
                        }
                    }
                    
                    studentTable.GetComponent<SteamVR_TrackedObject>().enabled = false;
                    studentScale.GetComponent<SteamVR_TrackedObject>().enabled = false;                    

                    removeTrackerRendering();
                    if (!showMirror)
                    {
                        removeMirror();    
                    }                        
                }

            }

            /*
             * calling Calibrate with settings will return a VRIKCalibrator.CalibrationData, which can be used to calibrate that same character again exactly the same in another scene (just pass data instead of settings), 
             * without being dependent on the pose of the player at calibration time.
             * Calibration data still depends on bone orientations though, so the data is valid only for the character that it was calibrated to or characters with identical bone structures.
             * If you wish to use more than one character, it would be best to calibrate them all at once and store the CalibrationData for each one.
             * */
            if (false)
            {
                if (data.scale == 0f)
                {
                    Debug.LogError("No Calibration Data to calibrate to, please calibrate with settings first.");
                }
                else
                {
                    // Use data from a previous calibration to calibrate that same character again.
                    VRIKCalibrator.Calibrate(ik, data, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);
                }
            }

            // Recalibrates avatar scale only. Can be called only if the avatar has been calibrated already.
            if (false)
            {
                if (data.scale == 0f)
                {
                    Debug.LogError("Avatar needs to be calibrated before RecalibrateScale is called.");
                }
                VRIKCalibrator.RecalibrateScale(ik, settings);
            }
        }

        void calibrate(){
            Debug.Log("calibrate teacher or student");
            data = VRIKCalibrator.Calibrate(ik, settings, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);
            //avatarToResize.GetComponent<VRIKAvatarScaleCalibrationSteamVR>().resize();
        }

        void removeTrackerRendering(){
            if (!showTrackers)
            {
                foreach (GameObject tracker in GameObject.FindGameObjectsWithTag("tracker"))
                {
                    tracker.transform.localScale = new Vector3(0f,0f,0f);
                }
                
            }
        }
        void removeMirror(){
            mirror.SetActive(false);
        }
    }
}
