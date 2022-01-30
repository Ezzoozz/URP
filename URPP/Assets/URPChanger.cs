using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using TMPro;

    public class URPChanger : MonoBehaviour
    {
        [SerializeField] RenderPipelineAsset[] qualityLevels;

        [SerializeField] TMP_Dropdown dropdownQuality;

        

        [SerializeField] TMP_Dropdown Textures;
        [SerializeField] TMP_Dropdown antiAliasing;
        [SerializeField] Toggle HDR;
        [SerializeField] Scrollbar renderScaling;
        [SerializeField] Slider shadowDistance;

        // Start is called before the first frame update
        void Start()
        {
     
            dropdownQuality.value = QualitySettings.GetQualityLevel();
            ResetUI();



        }

        void SetQualityToCustom()
        {
            Debug.Log("Quality set to custom");

            dropdownQuality.value = 3;

            QualitySettings.renderPipeline = qualityLevels[qualityLevels.Length - 1];
            

        }
        //Toggle betwenn different URPS
        //Attach function to TEXTMSH dropdownmenu in inspector
        //Different URPS can be set in the qualityLevels array
        public void ChangeLevelQuality(int value)
        {


            QualitySettings.SetQualityLevel(value);
            QualitySettings.renderPipeline = qualityLevels[value];

            
          

        }

        //Attach function to Textmesh dropdown menu (On value Changed)
        public void ChangeAnisotropicTextures(int value)
        {
            if (value == 0)
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;

            else if (value == 1)
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;

            else if (value == 2)
                QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;


           

        }

        //Attach function to TEXTMESH checkbox (On value changed)
        public void ChangeHDR(bool value)
        {
            SetQualityToCustom();

            UniversalRenderPipelineAsset asset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;



            if (value == false)
            {
                asset.supportsHDR = false;
            }
            else if (value == true)
            {

                asset.supportsHDR = true;
            }

            QualitySettings.renderPipeline = asset;

           

        }
        //Attach function to TEXTMESH dropdown menu (On value changed)
        public void ChangeAntiAliasing(int value)
        {
            SetQualityToCustom();
            UniversalRenderPipelineAsset asset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;


            if (value == 0)
            {
                asset.msaaSampleCount = 1;
            }
            else if (value == 1)
            {

                asset.msaaSampleCount = 2;
            }
            else if (value == 2)
            {

                asset.msaaSampleCount = 4;
            }
            else if (value == 3)
            {

                asset.msaaSampleCount = 8;
            }


            QualitySettings.renderPipeline = asset;

           

        }

        //Attach function to Textmesh slider/scrollbar  (On value Changed)
        public void ChangeRenderScaling(float value)
        {
            SetQualityToCustom();
            UniversalRenderPipelineAsset asset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;

            if (value <= 0.3)
            {
                asset.renderScale = 0.3f;
            }
            else
            {
                asset.renderScale = value;
            }

            QualitySettings.renderPipeline = asset;

            
        }

        //Attach function to Textmesh slider/scrollbar (On value Changed)
        public void ChangeShadowDistance(float value)
        {
            SetQualityToCustom();
            UniversalRenderPipelineAsset asset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;

            asset.shadowDistance = value;

            QualitySettings.renderPipeline = asset;

           

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

    }
