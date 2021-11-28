using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffIfDarkDies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("DarkEnemy").Length==0){
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
