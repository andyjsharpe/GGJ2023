using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class sanity : MonoBehaviour
{
    private float sanityTarget;
    private float sanityVal = 0;    //0 = "full", higher values are more "insane"
    private float randVal = 0;
    private Volume mainVol;
    private VolumeProfile profile;
    private Vignette vignetteComp;
    private LensDistortion lensDistortionComp;
    private ChromaticAberration chromaticAberrationComp;
    
    // Start is called before the first frame update
    void Start()
    {
        sanityTarget = PlayerPrefs.GetFloat("sanityTarget");

        mainVol = GetComponent<Volume>();

        profile = mainVol.profile;

        //gets all of the post processing components on the profile that we are going to change

        if(!profile.TryGet<Vignette>(out vignetteComp)) {
            vignetteComp = profile.Add<Vignette>(false);
        }
        if (!profile.TryGet<LensDistortion>(out lensDistortionComp)) {
            lensDistortionComp = profile.Add<LensDistortion>(false);
        }
        if (!profile.TryGet<ChromaticAberration>(out chromaticAberrationComp)) {
            chromaticAberrationComp = profile.Add<ChromaticAberration>(false);
        }
    }

    private void Update()
    {
        sanityVal = Mathf.Lerp(sanityVal, sanityTarget, Time.deltaTime / 4);    //interpolate to the target value smoothly
        randVal += Random.Range(0.0f, 1) * sanityVal * sanityVal * Time.deltaTime * 2.0f * Mathf.PI;
        SetComps();
    }

    private void SetComps()
    {
        //creates composite value of the other sanity values
        float randCalc = Mathf.Sin(randVal) * sanityVal / 10.0f;
        float calcSanity = sanityVal + randCalc;

        float vignetteVal = calcSanity / 1.5f;
        vignetteComp.intensity.overrideState = true;
        vignetteComp.intensity.max = vignetteVal;
        vignetteComp.intensity.min = 0;
        vignetteComp.intensity.value = vignetteVal;

        float lensDistrotionVal = calcSanity;
        lensDistortionComp.intensity.overrideState = true;
        lensDistortionComp.intensity.max = lensDistrotionVal;
        lensDistortionComp.intensity.min = 0;
        lensDistortionComp.intensity.value = lensDistrotionVal;

        float lensDistrotionVal2 = 1 - lensDistrotionVal / 2;
        lensDistortionComp.xMultiplier.overrideState = true;
        lensDistortionComp.xMultiplier.max = lensDistrotionVal2;
        lensDistortionComp.xMultiplier.min = 0;
        lensDistortionComp.xMultiplier.value = lensDistrotionVal2;

        lensDistortionComp.yMultiplier.overrideState = true;
        lensDistortionComp.yMultiplier.max = lensDistrotionVal2;
        lensDistortionComp.yMultiplier.min = 0;
        lensDistortionComp.yMultiplier.value = lensDistrotionVal2;

        float chromaticAberrationVal = calcSanity / 3;
        chromaticAberrationComp.intensity.overrideState = true;
        chromaticAberrationComp.intensity.max = chromaticAberrationVal;
        chromaticAberrationComp.intensity.min = 0;
        chromaticAberrationComp.intensity.value = chromaticAberrationVal;
    }

}
