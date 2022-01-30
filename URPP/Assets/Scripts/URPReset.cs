using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Rendering.Universal;

public class URPReset : MonoBehaviour
{
    
    [SerializeField] TMP_Dropdown Textures;
    [SerializeField] TMP_Dropdown antiAliasing;
    [SerializeField] Toggle HDR;
    [SerializeField] Scrollbar renderScaling;
    [SerializeField] Slider shadowDistance;

    
    // Start is called before the first frame update
    void Start()
    {
        ResetUI();

    }

    public void ResetUI()
    {
        Debug.Log("resetting UI");

        ResetTextures();

        ResetAntiAliasing();

        ResetHDR();

        ResetRendering();


        ResetShadows();
    }

    private void ResetShadows()
    {
        UniversalRenderPipelineAsset asset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;

        shadowDistance.value = asset.shadowDistance;

    }

    private void ResetRendering()
    {
        UniversalRenderPipelineAsset asset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;

        if (asset.renderScale <= 0.3f)
        {
            renderScaling.value = 0;
        }
        else 
        {
            renderScaling.value = asset.renderScale;
        }
    }



    

    private void ResetHDR()
    {
        UniversalRenderPipelineAsset pipeline = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;

        if (pipeline.supportsHDR == true)
            HDR.isOn = true;
        else
            HDR.isOn = false;
    }

    private void ResetAntiAliasing()
    {
        UniversalRenderPipelineAsset pipeline = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;

        if (pipeline.msaaSampleCount == 1)
        {
            antiAliasing.value = 0;
        }
        else if (pipeline.msaaSampleCount == 2)
        {
            antiAliasing.value = 1;
        }
        else if (pipeline.msaaSampleCount == 4)
        {
            antiAliasing.value = 2;
        }
        else if (pipeline.msaaSampleCount == 8)
        {
            antiAliasing.value = 3;
        }
    }

    void ResetTextures()
    {
        if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.Disable)
            Textures.value = 0;
        else if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.Enable)
            Textures.value = 1;
        else if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.ForceEnable)
            Textures.value = 2;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
