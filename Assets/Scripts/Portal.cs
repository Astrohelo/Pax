using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject fadeScreen;
    void OnTriggerEnter2D(Collider2D col){
        
        fadeScreen.GetComponent<Animator> ().SetBool("isFadeOut",true);
        Invoke("PortalLoad",0.3f);
        Invoke("LoadNext",1);
    }

    void LoadNext(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void PortalLoad(){
        GetComponent<Animator>().SetBool("isDissapear",true);
    }
}
