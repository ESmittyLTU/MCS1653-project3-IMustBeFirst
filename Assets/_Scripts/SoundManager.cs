using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //WHAT IS MY PURPOSE???
    //You store sound effects.
    //OH MY GOSH.

    public static AudioClip
        win,
        powerOff,
        powerOn,
        cutPower,
        endCall,
        mainMenuMusic,
        levelMusic,
        place,
        button;

    public AudioClip
        SFX_win,
        SFX_powerOff,
        SFX_powerOn,
        SFX_cutPower,
        SFX_endCall,
        SFX_mainMenuMusic,
        SFX_levelMusic,
        SFX_place,
        SFX_button;

    private void Awake()
    {
        win = SFX_win;
        powerOff = SFX_powerOff;
        powerOn = SFX_powerOn;
        cutPower = SFX_cutPower;
        endCall = SFX_endCall;
        mainMenuMusic = SFX_mainMenuMusic;
        levelMusic = SFX_levelMusic;
        place = SFX_place;
        button = SFX_button;








    }
}
