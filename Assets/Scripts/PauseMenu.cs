using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject pauseMenuUi;
    [SerializeField] private Slider volSlider;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private TMPro.TMP_Dropdown qualityDropdown;
    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private static bool gameIsPaused = false;

    
    // Start is called before the first frame update
    void Start()
    {
        volSlider.value= PlayerPrefs.GetFloat("volume");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityLevel"));
        
        if(PlayerPrefs.GetInt("fullScreen")==1){
            Screen.fullScreen = true;
        }
        else{
            Screen.fullScreen = false;
        }
        fullscreenToggle.isOn=Screen.fullScreen;
        qualityDropdown.value = PlayerPrefs.GetInt("qualityLevel");
        qualityDropdown.RefreshShownValue();


        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex= PlayerPrefs.GetInt("currentResIndex");
        for (int i =0; i< resolutions.Length; i++){
            string option = resolutions[i].width.ToString()+'x'+resolutions[i].height.ToString();
            options.Add(option);
            
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        Time.timeScale = 1f;
        gameIsPaused= false;
        pauseMenuUi.SetActive(false);
        PlayerPrefs.SetInt("timeIsPaused",1);
    }

    public void Pause(){
        Time.timeScale = 0f;
        gameIsPaused= true;
        pauseMenuUi.SetActive(true);
        PlayerPrefs.SetInt("timeIsPaused",0);
    }


    public void SetVolume(float volume){
        audioMixer.SetFloat("volume",volume);
    }

    
    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetFloat("qualityLevel",qualityIndex);
    }

    public void SetResolution(int resolutionIndex){
        Resolution res= resolutions[resolutionIndex];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullscreen){
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetFloat("fullScreen",isFullscreen?1:0);
    }
}
