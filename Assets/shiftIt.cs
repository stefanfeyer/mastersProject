using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiftIt : MonoBehaviour
{
    public int charId;
    private float shiftX;
    private float shiftZ;
    public GameObject source;

    public GameObject scriptholder;
    private shiftValues shiftValues;
    void Start()
    {
        shiftValues = scriptholder.GetComponent<shiftValues>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        switch (charId)
        {
            case 1:
                shiftX = shiftValues.shiftXChar1;
                shiftZ = shiftValues.shiftZChar1;
                break;
            case 2:
                shiftX = shiftValues.shiftXChar2;
                shiftZ = shiftValues.shiftZChar2;
                break;
            case 3:
                shiftX = shiftValues.shiftXChar3;
                shiftZ = shiftValues.shiftZChar3;
                break;
            case 4:
                shiftX = shiftValues.shiftXChar4;
                shiftZ = shiftValues.shiftZChar4;
                break;
            default:
                break;
            
        }

        this.transform.position = new Vector3(source.transform.position.x + shiftX, source.transform.position.y, source.transform.position.z + shiftZ);
        this.transform.rotation = source.transform.rotation;           
    }
}
