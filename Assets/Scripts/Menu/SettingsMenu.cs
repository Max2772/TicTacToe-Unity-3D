using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Resolution[] availableResolutions;
    public AudioMixer audioMixer;
    [SerializeField] private TMP_Dropdown dropdownResolution;

    void Start(){
        availableResolutions = Screen.resolutions;
        dropdownResolution.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIdx = 0;

        for(int i = 0; i < availableResolutions.Length; ++i){
            string option = availableResolutions[i].width + "x" + availableResolutions[i].height;
            options.Add(option);

            if(availableResolutions[i].width == Screen.currentResolution.width &&
              availableResolutions[i].height == Screen.currentResolution.height){
                currentResolutionIdx = i;
            }
        }
        
        dropdownResolution.AddOptions(options);
        dropdownResolution.value = currentResolutionIdx;
        dropdownResolution.RefreshShownValue();
    }

    public void SetResolution(int resolutionIdx){
        Screen.SetResolution(availableResolutions[resolutionIdx].width, availableResolutions[resolutionIdx].height, Screen.fullScreen);
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetGraphicsQuality(int qualityIdx){
        QualitySettings.SetQualityLevel(qualityIdx);
    }

    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen; 
    }

}
