﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private int a = 1;
    AudioSource myAudio;

    public AudioClip PCThrowKnife;
    public AudioClip PCThrowKnife2;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayerThrow()
    {
        if (a == 1)
        {
            myAudio.PlayOneShot(PCThrowKnife);
            a++;
        }
        else if (a== 2)
        {
            myAudio.PlayOneShot(PCThrowKnife2);
            a = 1;
        }
        
    }
}