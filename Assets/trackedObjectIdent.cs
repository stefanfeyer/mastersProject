using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Valve.VR;

public class trackedObjectIdent : MonoBehaviour
{

    // Start is called before the first frame update
    
    // B1: LHR-67E402D1 Hip
    // B3: LHR-32C38603 RFoot
    // B5: LHR-4E4C94A4 LFoot
    // B6: LHR-B925C963 Table
    // B8: LHR-89131158 BOX
    // B7: LHR-30899C17 null
    // B9: LHR-31D0CDF2 LHand
    // B10: LHR-CAC69A3C RHand

    public GameObject studentHip;
    public GameObject studentRH;
    public GameObject studentLH;
    public GameObject studentRF;
    public GameObject studentLF;
    public GameObject studentBox;
    public GameObject studentTable;

    void Start()
    {
        for(uint i = 0; i <= 16; i++){
        // uint index = 0;
        ETrackedPropertyError error = new ETrackedPropertyError();
        StringBuilder sb = new StringBuilder();
        OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_SerialNumber_String, sb, OpenVR.k_unMaxPropertyStringSize, ref error);
        var serial = sb.ToString();
        Debug.Log("index: " + i + ": "+ serial);

        switch (serial)
        {
            // Hip
            case "LHR-67E402D1":
                Debug.Log("Found device with ID LHR-67E402D1 (Hip). I assing Hip with device index: " + i);
                studentHip.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int)i);
                break;
            case "LHR-32C38603":
                studentRF.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int)i);
                Debug.Log("Found device with ID LHR-32C38603 (RFoot). I assing RFoot with device index: " + i);
                break;
            case "LHR-4E4C94A4":
                studentLF.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int)i);
                Debug.Log("Found device with ID LHR-4E4C94A4 (LFoot). I assing LFoot with device index: " + i);
                break;
            case "LHR-89131158":
                studentBox.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int)i);
                Debug.Log("Found device with ID LHR-89131158 (Box1). I assing Box1 with device index: " + i);
                break;
            case "LHR-31D0CDF2":
                studentLH.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int)i);
                Debug.Log("Found device with ID LHR-31D0CDF2 (LHand). I assing LHand with device index: " + i);
                break;
            case "LHR-CAC69A3C":
                studentRH.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int)i);
                Debug.Log("Found device with ID LHR-CAC69A3C (RHand). I assing RHand with device index: " + i);
                break;
            case "LHR-B925C963":
                studentTable.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex((int)i);
                Debug.Log("Found device with ID LHR-30899C17 (Table). I assing Table with device index: " + i);
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
