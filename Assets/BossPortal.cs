using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BossPortal : MonoBehaviour
{
    public GameObject boss;
    void OnTriggerEnter2D(Collider2D col){
        if(boss.GetComponent<SlimeBoss>().getHealthBar()<=0){
            Invoke("PortalLoad",0.3f);
            Invoke("LoadNext",1);
        }
        
    }

    void LoadNext(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void PortalLoad(){
        GetComponent<Animator>().SetBool("isDissapear",true);
    }
}
