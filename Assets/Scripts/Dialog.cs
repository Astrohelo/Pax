using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
public class Dialog : MonoBehaviour
{

public TextMeshProUGUI textDisplay;
public Image currentImage;
public string[] sentences;
public Sprite[] images;
private int index;
public float typingSpeed;

public GameObject continueButton;
public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Pause();
        StartCoroutine(Type());
    }

    
    public static class CoroutineUtil
 {
     public static IEnumerator WaitForRealSeconds(float time)
     {
         float start = Time.realtimeSinceStartup;
         while (Time.realtimeSinceStartup < start + time)
         {
             yield return null;
         }
     }
 }
    IEnumerator Type(){
        currentImage.sprite=images[index];
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(typingSpeed));
            //yield return new WaitForSecondsRealTime(typingSpeed);
        }
        continueButton.SetActive(true);
    }
    public void NextSentence(){
        continueButton.SetActive(false);
        if(index < sentences.Length -1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else{
            textDisplay.text="";
            panel.SetActive(false);
            Resume();
        }
    }

    public void Resume(){
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("timeIsPaused",1);
    }
    public void Pause(){
        Time.timeScale = 0f;
        PlayerPrefs.SetInt("timeIsPaused",0);
    }
}
