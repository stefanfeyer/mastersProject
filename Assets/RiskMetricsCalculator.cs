using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LitJson;

public class RiskMetricsCalculator : MonoBehaviour
{
    //JSONReader jsonData;

    public GameObject trackedL5PelvisHip; //This is the same as pelvis and hip location
    public GameObject trackedT8;
    public GameObject referenceObjectForBendAngle;

    public GameObject trackedLeftFoot;
    public GameObject trackedRightFoot;

    public GameObject trackedLeftShoulder;
    public GameObject trackedRightShoulder;

    public GameObject referenceLine;
    public GameObject leftHipReference;
    public GameObject rightHipReference;

    public GameObject insideSphere;
    private Vector3 shoulderVector;
    private Vector3 hipVector;

    private float angleOfSpineBending;
    private float angleOfSpineTwist;
    private float distanceBetweenFeet;
    private float distanceOfSquat; //Distance of pelvis
    private JsonData allComparisonValues;

    private bool feetErrorFlag = false;
    private bool squatErrorFlag = false;
    private bool spineBendErrorFlag = false;
    private bool spineTwistErrorFlag = false;

    public bool recordingGameObjects = false;
    public Hashtable remoteErrorTable;
    public List<int> errorLogForPlayer;
    private int logStartTime;

    public GameObject feetMesh;
    public GameObject hipsMesh;
    public GameObject lowerbackMesh;
    public GameObject shouldersMesh;

    public Material errorMaterial;
    public Material defaultMaterial;
    /*public Vector3 centre;
    public TextMeshPro dataDisplay;
    public TextMeshPro showBendAngle;
    public Transform bendAngleArc;*/

    // Start is called before the first frame update
    void Start()
    {
        remoteErrorTable = new Hashtable();
        //remoteErrorTable.Add(69, 11);
        //jsonData = new JSONReader(); //Class object yxc
        //allComparisonValues = jsonData.GetAllRiskMetrics("fully", "bedtochair", "gold");yxc
        //Debug.Log("JSON comparison values: " + allComparisonValues[0]);
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.C)){
                alignHipSensors();
            }
            

            //Assign values to global variables
            distanceBetweenFeet = CalculateDistanceBetweenFeet();
            distanceOfSquat = CalculateSquatDistance();
            angleOfSpineBending = CalculateSpineBendAngle();
            angleOfSpineTwist = CalculateSpineTwist();

            //Debug.Log("Angle of spine twist: " + angleOfSpineTwist);
            checkBaseDistance(distanceBetweenFeet);
            checkSquatDistance(distanceOfSquat);
            checkSpineBend(angleOfSpineBending);
            checkSpineTwist(angleOfSpineTwist);


        //bendAngleArc.GetComponent<Image>().fillAmount = angleOfSpineBending / 360f;
        // bendAngleArc.transform.position = trackedL5PelvisHip.transform.position;
    }

    float CalculateSpineBendAngle()
    {
        float a, b, c;
        Vector3 upward = new Vector3(0, 0.2f, 0); //Magnitude for the reference point
        Vector3 extraPoint = trackedL5PelvisHip.transform.position + upward; //Take a reference point on the vertical axis in world position
        referenceObjectForBendAngle.transform.position = extraPoint;

        //Distance of the segments that form a triangle (necessary for LawOfCosines)
        b = Vector3.Distance(trackedL5PelvisHip.transform.position, referenceObjectForBendAngle.transform.position);
        a = Vector3.Distance(trackedL5PelvisHip.transform.position, trackedT8.transform.position);
        c = Vector3.Distance(trackedT8.transform.position, referenceObjectForBendAngle.transform.position);
        float angle = LawOfCosines(a, b, c);
        float angleindegrees = angle * 180 / Mathf.PI;

        return angleindegrees;
    }

    //Law of Cosines implementation required for calculating the spine bending angle
    float LawOfCosines(float a, float b, float c)
    {
        float numerator, denominator, answer;

        numerator = Mathf.Pow(a, 2) + Mathf.Pow(b, 2) - Mathf.Pow(c, 2);
        denominator = (2 * a * b);
        answer = Mathf.Acos(numerator / denominator);

        return answer;
    }

    float CalculateDistanceBetweenFeet()
    {
        float baseDistance;
        baseDistance = Vector3.Distance(trackedLeftFoot.transform.position, trackedRightFoot.transform.position);

        // dataDisplay.SetText("Distance between the feet is: {0:2} metres \n Squat distance from floor is: {1:2}", Distance_, Distance2_);
        //Debug.Log("Distance between the feet is: " + Distance_);
        return baseDistance;
    }

    float CalculateSquatDistance()
    {
        float pelvisDistance;
        pelvisDistance = trackedL5PelvisHip.transform.position.y;

        return pelvisDistance;
    }

    float CalculateSpineTwist()
    {
        float rotationAngle;
        hipVector = leftHipReference.transform.position - rightHipReference.transform.position;
        shoulderVector = trackedLeftShoulder.transform.position - trackedRightShoulder.transform.position;

        rotationAngle = Vector3.Angle(hipVector, shoulderVector);
        //spineTwist.text = "Spine Twist = " + RotationAngle;

        return rotationAngle;
    }

    void checkBaseDistance(float currentDistance)
    {
        if (feetErrorFlag == false)
        {
            if (currentDistance > 0.70 || currentDistance < 0.40)
            {
                //FindObjectOfType<AudioManager>().Play("Error"); yxc
                Debug.Log("Error in base distance found");
                feetErrorFlag = true;
            }
        }
        else if (feetErrorFlag == true)
        {
            if (currentDistance < 0.70 && currentDistance > 0.40)
            {
                Debug.Log("Error in base distance fixed");
                feetErrorFlag = false;
            }
        }
    }

    void checkSquatDistance(float currentDistance)
    {
        if (squatErrorFlag == false)
        {
            if (currentDistance > 1.20 || currentDistance < 0.90)
            {
                //FindObjectOfType<AudioManager>().Play("Error");
                Debug.Log("Error in squat distance found");
                squatErrorFlag = true;
            }
        }
        else
        {
            if (currentDistance < 1.20 && currentDistance > 0.90)
            {
                Debug.Log("Error in squat distance fixed");
                squatErrorFlag = false;
            }
        }
    }

    void checkSpineBend(float currentAngle)
    {
        if (spineBendErrorFlag == false)
        {
            if (currentAngle > 39.0)
            {
                //FindObjectOfType<AudioManager>().Play("Error");
                Debug.Log("Error in Spine bend found");
                spineBendErrorFlag = true;
            }
        }
        else
        {
            if (currentAngle < 39.0)
            {
                Debug.Log("Error in Spine bend fixed");
                spineBendErrorFlag = false;
            }
        }
    }

    void checkSpineTwist(float currentAngle)
    {
        if (spineTwistErrorFlag == false)
        {
            if (currentAngle > 24.0)
            {
                //FindObjectOfType<AudioManager>().Play("Error");
                Debug.Log("Error in Spine twist found");
                spineTwistErrorFlag = true;
            }
        }
        else
        {
            if (currentAngle < 24.0)
            {
                Debug.Log("Error in Spine twist fixed");
                spineTwistErrorFlag = false;
            }
        }
    }
    public void StartLogError()
    {
        logStartTime = 0;
        InvokeRepeating(nameof(LogError), 0, 1.0f);
    }

    public void StopLogError()
    {
        CancelInvoke();
    }
    void alignHipSensors()
    {
        Vector3 left = new Vector3(-0.2f, 0, 0);
        Vector3 right = new Vector3(0.2f, 0, 0);

       // leftHipSensor.transform.position = trackedPelvis.transform.position + left;
       // RightHipSensor.transform.position = trackedPelvis.transform.position + right;
        referenceLine.transform.position = trackedL5PelvisHip.transform.position;
        
       // leftHipSensor.transform.parent = insideSphere.transform;
        //RightHipSensor.transform.parent = insideSphere.transform;
        referenceLine.transform.parent = insideSphere.transform;
        //savedLocationOfPelvis.transform.rotation = referenceLine.transform.rotation;
        //savedLocationOfPelvis.transform.localScale = referenceLine.transform.localScale;
    }
    void LogError()
    {

        logStartTime++;
        if (feetErrorFlag == true && squatErrorFlag == true && spineBendErrorFlag == true && spineTwistErrorFlag == true) //1 & 2 & 3 & 4
        {
            //errorLogForPlayer.Add(20);
            remoteErrorTable.Add(logStartTime, 15);
        }
        else if (squatErrorFlag == true && spineBendErrorFlag == true && spineTwistErrorFlag == true) // 2 & 3 & 4
        {
            remoteErrorTable.Add(logStartTime, 14);
        }
        else if (feetErrorFlag == true && spineBendErrorFlag == true && spineTwistErrorFlag == true) // 1 & 3 & 4
        {
            remoteErrorTable.Add(logStartTime, 13);
        }
        else if (feetErrorFlag == true && squatErrorFlag == true && spineTwistErrorFlag == true) // 1 & 2 & 4
        {
            remoteErrorTable.Add(logStartTime, 12);
        }
        else if (feetErrorFlag == true && squatErrorFlag == true && spineBendErrorFlag == true) // 1 & 2 & 3
        {
            remoteErrorTable.Add(logStartTime, 11);
        }
        else if (spineBendErrorFlag == true && spineTwistErrorFlag == true) // 3 & 4
        {
            remoteErrorTable.Add(logStartTime, 10);
        }
        else if (squatErrorFlag == true && spineTwistErrorFlag == true) // 2 & 4
        {
            remoteErrorTable.Add(logStartTime, 9);
        }
        else if (squatErrorFlag == true && spineBendErrorFlag == true) // 2 & 3
        {
            remoteErrorTable.Add(logStartTime, 8);
        }
        else if (feetErrorFlag == true && spineTwistErrorFlag == true) // 1 & 4
        {
            remoteErrorTable.Add(logStartTime, 7);
        }
        else if (feetErrorFlag == true && spineBendErrorFlag == true) // 1 & 3
        {
            remoteErrorTable.Add(logStartTime, 6);
        }
        else if (feetErrorFlag == true && squatErrorFlag == true) // 1 & 2
        {
            remoteErrorTable.Add(logStartTime, 5);
        }
        else if (spineTwistErrorFlag == true) // 4
        {
            remoteErrorTable.Add(logStartTime, 4);
        }
        else if (spineBendErrorFlag == true) // 3
        {
            remoteErrorTable.Add(logStartTime, 3);
        }
        else if (squatErrorFlag == true) // 2
        {
            remoteErrorTable.Add(logStartTime, 2);
        }
        else if (feetErrorFlag == true) // 1
        {
            remoteErrorTable.Add(logStartTime, 1);
        }
        else
        {
            remoteErrorTable.Add(logStartTime, 0);
        }
        //Debug.Log("This is printed every second");
    }
}
