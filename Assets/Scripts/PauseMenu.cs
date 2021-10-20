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
    private static bool gameIsPaused = false;

    
    // Start is called before the first frame update
    void Start()
    {
        volSlider.value= PlayerPrefs.GetFloat("volume");
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
    }

    public void Pause(){
        Time.timeScale = 0f;
        gameIsPaused= true;
        pauseMenuUi.SetActive(true);
    }


    public void SetVolume(float volume){
        audioMixer.SetFloat("volume",volume);
    }
}
