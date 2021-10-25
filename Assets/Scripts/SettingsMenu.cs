using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex=0;
        for (int i =0; i< resolutions.Length; i++){
            string option = resolutions[i].width.ToString()+'x'+resolutions[i].height.ToString();
            options.Add(option);
            if(resolutions[i].width==Screen.currentResolution.width &&
            resolutions[i].height==Screen.currentResolution.height){
                currentResIndex=i;
                PlayerPrefs.SetFloat("currentResIndex",currentResIndex);
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("volume",volume);
        PlayerPrefs.SetFloat("volume",volume);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityLevel",qualityIndex);
    }

    public void SetResolution(int resolutionIndex){
        Resolution res= resolutions[resolutionIndex];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
        PlayerPrefs.SetInt("currentResIndex",resolutionIndex);
    }

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("fullScreen",isFullscreen?1:0);
    }
}
