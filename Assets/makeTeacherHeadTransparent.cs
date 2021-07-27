using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTeacherHeadTransparent : MonoBehaviour
{
    public GameObject teacherAvatar;
    public Material transparentMaterial;

    // head materials
    public Material headMaterial;
    public Material bodyMaterial;
    public Material armMaterial;
    public Material legMaterial;
    public Material nailsMaterial;
    public Material eyeLashMaterial;

    // eye base material
    public Material eyeRMaterial;
    public Material corneaRMaterial;
    public Material eyeLMaterial;
    public Material corneaLMaterial;

    // eye occlusion materials
    public Material eyeOcclusionRMaterial;
    public Material eyeOcclusionLMaterial;

    // tear line materials
    public Material eyeTearlineRMaterial;
    public Material eyeTearlineLMaterial;

    // teeth materials
    public Material upperTeethMaterial;
    public Material lowerTeethMaterial;

    // toungue material
    public Material tongueMaterial;

    // hair materials
    public Material scalpHighMaterial;
    public Material highPolyMaterial;

    private bool isVisible = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            makeTeacherAvatarHeadTransparent();
            isVisible = false;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            makeTeacherAvatarHeadVisible();
            isVisible = true;
        }
    }

    public void makeTeacherAvatarHeadTransparent(){
        if (isVisible)
        {
            makeHeadTransparent();
            makeTeethTransparent();
            //makeHairTransparent();
            makeEyesTransparent();
            makeTongueTransparent();
            Debug.Log("makeTransparent");
            isVisible = false;
        }
    }

    public void makeTeacherAvatarHeadVisible()
    {
        if (!isVisible)
        {
            makeHeadVisible();
            makeTeethVisible();
            //makeHairVisible();
            makeEyesVisible();
            makeTongueVisible();
            Debug.Log("makeVisible");
            isVisible = true;
        }
    }

    private void makeHeadTransparent(){
        Material[] headMaterialsArray = new Material[] { transparentMaterial, bodyMaterial, armMaterial, legMaterial, nailsMaterial, transparentMaterial };
        teacherAvatar.transform.Find("CC_Base_Body").gameObject.GetComponent<SkinnedMeshRenderer>().materials = headMaterialsArray;
    }

    private void makeTeethTransparent()
    {
        Material[] teethMaterialsArray = new Material[] { transparentMaterial, transparentMaterial };
        teacherAvatar.transform.Find("CC_Base_Teeth").gameObject.GetComponent<SkinnedMeshRenderer>().materials = teethMaterialsArray;
    }

    private void makeHairTransparent()
    {
        Material[] hairMaterialsArray = new Material[] { transparentMaterial, transparentMaterial };
        teacherAvatar.transform.Find("Hair").gameObject.GetComponent<SkinnedMeshRenderer>().materials = hairMaterialsArray;
    }

    private void makeEyesTransparent(){
        Material[] eyeBaseMaterialsArray = new Material[] { transparentMaterial, transparentMaterial, transparentMaterial, transparentMaterial };
        teacherAvatar.transform.Find("CC_Base_Eye").gameObject.GetComponent<SkinnedMeshRenderer>().materials = eyeBaseMaterialsArray;
        Material[] eyeOcclusionMaterialsArray = new Material[] { transparentMaterial, transparentMaterial };
        teacherAvatar.transform.Find("CC_Base_EyeOcclusion").gameObject.GetComponent<SkinnedMeshRenderer>().materials = eyeOcclusionMaterialsArray;
        Material[] eyeTearlineMaterialsArray = new Material[] { transparentMaterial, transparentMaterial };
        teacherAvatar.transform.Find("CC_Base_TearLine").gameObject.GetComponent<SkinnedMeshRenderer>().materials = eyeTearlineMaterialsArray;
    }

    private void makeTongueTransparent(){
        Material[] tongueMaterialsArray = new Material[] { transparentMaterial };
        teacherAvatar.transform.Find("CC_Base_Tongue").gameObject.GetComponent<SkinnedMeshRenderer>().materials = tongueMaterialsArray;
    }

    // ------------------------

    private void makeHeadVisible()
    {
        Material[] headMaterialsArray = new Material[] { headMaterial, bodyMaterial, armMaterial, legMaterial, nailsMaterial, eyeLashMaterial };
        teacherAvatar.transform.Find("CC_Base_Body").gameObject.GetComponent<SkinnedMeshRenderer>().materials = headMaterialsArray;
    }

    private void makeTeethVisible()
    {
        Material[] teethMaterialsArray = new Material[] { upperTeethMaterial, lowerTeethMaterial };
        teacherAvatar.transform.Find("CC_Base_Teeth").gameObject.GetComponent<SkinnedMeshRenderer>().materials = teethMaterialsArray;
    }

    private void makeHairVisible()
    {
        Material[] hairMaterialsArray = new Material[] { scalpHighMaterial, highPolyMaterial };
        teacherAvatar.transform.Find("Hair").gameObject.GetComponent<SkinnedMeshRenderer>().materials = hairMaterialsArray;
    }

    private void makeEyesVisible()
    {
        Material[] eyeBaseMaterialsArray = new Material[] { eyeRMaterial, corneaRMaterial, eyeLMaterial, corneaLMaterial };
        teacherAvatar.transform.Find("CC_Base_Eye").gameObject.GetComponent<SkinnedMeshRenderer>().materials = eyeBaseMaterialsArray;
        Material[] eyeOcclusionMaterialsArray = new Material[] { eyeOcclusionRMaterial, eyeOcclusionLMaterial };
        teacherAvatar.transform.Find("CC_Base_EyeOcclusion").gameObject.GetComponent<SkinnedMeshRenderer>().materials = eyeOcclusionMaterialsArray;
        Material[] eyeTearlineMaterialsArray = new Material[] { eyeTearlineRMaterial, eyeTearlineLMaterial };
        teacherAvatar.transform.Find("CC_Base_TearLine").gameObject.GetComponent<SkinnedMeshRenderer>().materials = eyeTearlineMaterialsArray;
    }

    private void makeTongueVisible()
    {
        Material[] toungeMaterialsArray = new Material[] { tongueMaterial };
        teacherAvatar.transform.Find("CC_Base_Tongue").gameObject.GetComponent<SkinnedMeshRenderer>().materials = toungeMaterialsArray;
    }

}
