using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public GameObject fadeScreen;
    public GameObject bezier;
    private void OnCollisionEnter2D(Collision2D other)
    {
        fadeScreen.GetComponent<Animator> ().SetBool("isFadeOut",true);
        bezier.GetComponent<BezierFollow>().setCoroutineFalse();
        Invoke("LoadNext",1);
    }
    void LoadNext(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
