using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class postProcessingManager : MonoBehaviour {
    public PostProcessingProfile profile;
   // ColorGradingModel.Settings colorSettings = processingBehaviour.colorGrading.settings;
    // Update is called once per frame
    void Update()
    {
       // ColorGradingModel.Settings colorSettings = processingBehaviour.colorGrading.settings;

        if (GameManager.gotBlanket)
        {
           // ChangeSaturation(1);
        }
        if (GameManager.gotBalloons && GameManager.gotBlanket && GameManager.gotBouquet && GameManager.gotWine && GameManager.gotRadio)
        {
            profile.colorGrading.enabled = false;
        }
        //processingBehaviour.colorGrading.settings = colorSettings;
    }

    void ChangeSaturation(int saturationInt)
    {
        ColorGradingModel.Settings colorSettings = profile.colorGrading.settings;
     //  colorSettings.colorGrading.intensity = saturationInt; 
        profile.colorGrading.settings = colorSettings;
    }
}
