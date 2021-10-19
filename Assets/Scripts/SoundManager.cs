using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static AudioClip playerJump, playerHurt;
    private static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerJump = Resources.Load<AudioClip>("jump");
        playerHurt = Resources.Load<AudioClip>("playerHurt");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string name)
    {
        switch (name)
        {
            case "jump":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "playerHurt":
                audioSrc.PlayOneShot(playerHurt);
                break;
        }
    }
}
