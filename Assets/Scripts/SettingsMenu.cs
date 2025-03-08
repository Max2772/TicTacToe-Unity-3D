using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Resolution[] availableResolutions;
    public AudioMixer audioMixer;
    //[SerializeField] private Dropdown dropdownResolution;

    void Start(){
        //availableResolutions = Screen.resolutions;
        //dropdownResolution.ClearOptions();

        //List<string> options = new List<string>();

        //for(int i = 0; i < availableResolutions.Length; ++i){
            //string option = 
        //}  
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
