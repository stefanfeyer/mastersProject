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

        public GameObject teacherCalibrationController;
        public GameObject teacherCalibrationController1;
        public GameObject teacherCalibrationController2;
        public GameObject teacherCalibrationController3;
        public GameObject teacherCalibrationController4;

        public GameObject studentCalibrationController1;
        public GameObject studentCalibrationController2;
        public GameObject studentCalibrationController3;
        public GameObject studentCalibrationController4;

        public bool isStudent;
        public GameObject avatarToResize;
        
        float scale;
        public GameObject teacherReference;
        public GameObject teacherReference1;
        public GameObject teacherReference2;
        public GameObject teacherReference3;
        public GameObject teacherReference4;

        public GameObject teacherBox;
        public GameObject teacherBox1;
        public GameObject teacherBox2;
        public GameObject teacherBox3;
        public GameObject teacherBox4;

        public GameObject teacherTable;
        public GameObject teacherTable1;
        public GameObject teacherTable2;
        public GameObject teacherTable3;
        public GameObject teacherTable4;

        public GameObject studentTable;

        public GameObject eyesStudent;
        public GameObject eyesTeacher;
 
        void LateUpdate()
        {
           
            if (Input.GetKeyDown(KeyCode.C))
            {
                // Calibrate the character, store data of the calibration
                if (isStudent)
                {
                    data = VRIKCalibrator.Calibrate(ik, settings, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);
                    scale = eyesStudent.transform.position.y / eyesTeacher.transform.position.y;
                    //Debug.Log("teacherEye:");
                    //Debug.Log(eyesTeacher.transform.position.y);
                    //Debug.Log("studentEye:");
                    //Debug.Log(eyesStudent.transform.position.y);
                    //Debug.Log("scale");
                    //Debug.Log(scale);
                    //scale = avatarToResize.GetComponent<VRIKAvatarScaleCalibrationSteamVR>().resize();
                    
                    GameObject[] teacherReferences = {teacherReference,teacherReference1,teacherReference2,teacherReference3,teacherReference4};
                    GameObject[] callibrationControllers = {teacherCalibrationController,teacherCalibrationController1,teacherCalibrationController2,teacherCalibrationController3,teacherCalibrationController4};
                    GameObject[] boxes = {teacherBox,teacherBox1,teacherBox2,teacherBox3,teacherBox4};
                    GameObject[] tables = {teacherTable,teacherTable1,teacherTable2,teacherTable3,teacherTable4};
                    GameObject[] studentCalibrationControllers = {studentCalibrationController1,studentCalibrationController2,studentCalibrationController3,studentCalibrationController4};
                    
                    

                    foreach (var item in teacherReferences)
                    {
                        if (item != null)
                        {
                            item.transform.localScale = new Vector3(1f, scale, 1f);
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

                    foreach (var item in boxes)
                    {
                        if (item != null)
                        {
                            Debug.Log("BOX");
                            item.transform.localScale *= (1 / scale);
                        }
                    }
                    
                    foreach (var item in tables)
                    {
                        if (item != null)
                        {
                            Debug.Log("TABLE");
                            item.transform.localScale *= (1 / scale);
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
                    
                    
                    //teacherReference.transform.localScale = new Vector3(1f, scale, 1f);
                    //teacherReference1.transform.localScale = new Vector3(1f, scale, 1f);
                    //teacherReference2.transform.localScale = new Vector3(1f, scale, 1f);
                    //teacherReference3.transform.localScale = new Vector3(1f, scale, 1f);
                    //teacherReference4.transform.localScale = new Vector3(1f, scale, 1f);

                    //teacherCalibrationController.GetComponent<VRIKCalibrationController>().calibrate();
                    //teacherCalibrationController1.GetComponent<VRIKCalibrationController>().calibrate();
                    //teacherCalibrationController2.GetComponent<VRIKCalibrationController>().calibrate();
                    //teacherCalibrationController3.GetComponent<VRIKCalibrationController>().calibrate();
                    //teacherCalibrationController4.GetComponent<VRIKCalibrationController>().calibrate();

                    //teacherBox.transform.localScale *= 1 / scale;
                    //teacherBox1.transform.localScale *= 1 / scale;
                    //teacherBox2.transform.localScale *= 1 / scale;
                    //teacherBox3.transform.localScale *= 1 / scale;
                    //teacherBox4.transform.localScale *= 1 / scale;

                    //teacherTable.transform.localScale *= 1 / scale;
                    //teacherTable1.transform.localScale *= 1 / scale;
                    //teacherTable2.transform.localScale *= 1 / scale;
                    //teacherTable3.transform.localScale *= 1 / scale;
                    //teacherTable4.transform.localScale *= 1 / scale;

                    avatarToResize.GetComponent<VRIKAvatarScaleCalibrationSteamVR>().resize();
                    studentTable.GetComponent<SteamVR_TrackedObject>().enabled = false;
                    
                    
                    //teacherCalibrationController.GetComponent<VRIKCalibrationController>().data = data;
                    //teacherCalibrationController.GetComponent<VRIKCalibrationController>().calibrate();
                    //avatarToResize.GetComponent<VRIKAvatarScaleCalibrationSteamVR>().resize();
                        
                }
                //data = VRIKCalibrator.Calibrate(ik, settings, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);
                
                //toResize.GetComponent<VRIKAvatarScaleCalibrationSteamVR>().resize();
                //data = VRIKCalibrator.Calibrate(ik, settings, headTracker, bodyTracker, leftHandTracker, rightHandTracker, leftFootTracker, rightFootTracker);

            }

            /*
             * calling Calibrate with settings will return a VRIKCalibrator.CalibrationData, which can be used to calibrate that same character again exactly the same in another scene (just pass data instead of settings), 
             * without being dependent on the pose of the player at calibration time.
             * Calibration data still depends on bone orientations though, so the data is valid only for the character that it was calibrated to or characters with identical bone structures.
             * If you wish to use more than one character, it would be best to calibrate them all at once and store the CalibrationData for each one.
             * */
            if (Input.GetKeyDown(KeyCode.D))
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
            if (Input.GetKeyDown(KeyCode.S))
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
            avatarToResize.GetComponent<VRIKAvatarScaleCalibrationSteamVR>().resize();
        }
    }
}
