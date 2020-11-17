using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Valve.VR;

public class trackedObjectIdent : MonoBehaviour
{
    // Start is called before the first frame update
    // B1:  LHR-67E402D1 Hip
    // B2:  LHR-36F48476 free
    // B3:  LHR-32C38603 RFoot
    // B4:  ?
    // B5:  LHR-4E4C94A4 LFoot
    // B6:  LHR-B925C963 Table
    // B7:  LHR-30899C17 free
    // B8:  LHR-89131158 BOX
    // B9:  LHR-31D0CDF2 LHand
    // B10: LHR-CAC69A3C RHand
    // B12: LHR-2B0A3940 free
    // B13: LHR-57C1EE09 free
    // B14: LHR-6C32F5E5 upper hip
    // B15: LHR-60970C40 left shoulder
    // B16: LHR-130A9431 right shoulder
    // LightHouse ids: LHB-4F239B5C, LHB-C77E538D, LHB-CC27DD6F, LHB-303A3DA5
    // HMD Valve Index: LHR-249568A0

    // GameObjects with the SteacmVRTrackedObject scripts
    public GameObject studentHip;

    // tanv: lower hip steamVrTrackedObject
    public GameObject studentRH;

    // tanv: right hand steamVrTrackedObject
    public GameObject studentLH;

    // tanv: left hand steamVrTrackedObject
    public GameObject studentRF;

    // tanv: right foot steamVrTrackedObject
    public GameObject studentLF;

    // tanv: left foot steamVrTrackedObject
    public GameObject studentBox;

    // tanv: you dont need that
    public GameObject studentTable;

    // tanv: you dont need that
    public GameObject studentLeftShoulder;

    // tanv: left shoulder steamVrTrackedObject
    public GameObject studentRightShoulder;

    // tanv: tight shoulder steamVrTrackedObject
    public GameObject studentUpperHip;

    // tanv: upper hip steamVrTrackedObject
    void Start()
    {
        for (uint i = 0; i <= 16; i++)
        {
            ETrackedPropertyError error = new ETrackedPropertyError();
            StringBuilder sb = new StringBuilder();
            OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_SerialNumber_String, sb, OpenVR.k_unMaxPropertyStringSize, ref error);
            var serial = sb.ToString();
            Debug.Log("index: " + i + ": " + serial);
            
            // assignment of the trackers to the GameObjects with SteamVRTrackedObject scripts
            switch (serial)
            {
                case "LHR-67E402D1":
                    Debug.Log("Found device with ID LHR-67E402D1 (B1, Hip). I assing Hip with device index: " + i);
                    studentHip.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    break;
                case "LHR-32C38603":
                    studentRF.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-32C38603 (B3, RFoot). I assing RFoot with device index: " + i);
                    break;
                case "LHR-4E4C94A4":
                    studentLF.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-4E4C94A4 (B5, LFoot). I assing LFoot with device index: " + i);
                    break;
                case "LHR-89131158":
                    studentBox.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-89131158 (B8, Box). I assing Box with device index: " + i);
                    break;
                case "LHR-31D0CDF2":
                    studentLH.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug
                        .Log("Found device with ID LHR-31D0CDF2 (B9, LHand). I assing LHand with device index: " + i);
                    break;
                case "LHR-CAC69A3C":
                    studentRH.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-CAC69A3C (B10, RHand). I assing RHand with device index: " + i);
                    break;
                case "LHR-B925C963":
                    studentTable.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-B925C963 (B6, Table). I assing Table with device index: " + i);
                    break;
                case "LHR-60970C40":
                    studentLeftShoulder.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-60970C40 (B15, left shoulder). I assing left shoulder with device index: " + i);
                    break;
                case "LHR-130A9431":
                    studentRightShoulder.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-130A9431 (B16, right shoulder). I assing right shoulder with device index: " +i);
                    break;
                case "LHR-6C32F5E5":
                    studentUpperHip.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int) i);
                    Debug.Log("Found device with ID LHR-6C32F5E5 (B14, upper hip). I assing upper hip with device index: " +i);
                    break;
                case "LHR-249568A0":
                    Debug.Log("Found device with ID LHR-249568A0 (HTC Vive). It has device index: " +i);
                    break;
                case "LHB-303A3DA5":
                    Debug.Log("Found device with ID LHB-303A3DA5 (LightHouse 1). It has device index: " +i);
                    break;
                case "LHB-CC27DD6F":
                    Debug.Log("Found device with ID LHB-CC27DD6F (LightHouse 2). It has device index: " +i);
                    break;
                case "LHB-C77E538D":
                    Debug.Log("Found device with ID LHB-C77E538D (LightHouse 3). It has device index: " +i);
                    break;
                case "LHB-4F239B5C":
                    Debug.Log("Found device with ID LHB-4F239B5C (LightHouse 4). It has device index: " +i);
                    break;
                default:
                    break;
            }
        }
        //var temp = GameObject.Find("1").GetComponent<SteamVR_TrackedObject>();
        //temp.SetDeviceIndex(10);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
