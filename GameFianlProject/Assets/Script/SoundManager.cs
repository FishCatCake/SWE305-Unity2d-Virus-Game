using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip pick;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        pick = Resources.Load<AudioClip>("coinPick");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayPickClip()
    {
        audioSrc.PlayOneShot(pick);
    }
    
}
