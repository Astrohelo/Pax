using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusHealth : MonoBehaviour
{
    bool elso;
    void OnTriggerEnter2D(Collider2D col){
        if(elso){
            GameObject player=GameObject.FindGameObjectsWithTag("Player")[0];
            player.GetComponent<PlayerController>().addMaxHealth();
            elso=false;
            gameObject.SetActive(false);
        }
        

    }

    
    // Start is called before the first frame update
    void Start()
    {
        elso=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
