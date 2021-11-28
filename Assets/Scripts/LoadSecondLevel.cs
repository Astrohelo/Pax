using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecondLevel : MonoBehaviour
{
public GameObject fadeScreen;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col){
        fadeScreen.GetComponent<Animator> ().SetBool("isFadeOut",true);
            Invoke("LoadNext",1);
    }

    void LoadNext(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
