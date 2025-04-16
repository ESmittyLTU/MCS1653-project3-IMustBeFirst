using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class User : MonoBehaviour
{
    //Tags
    public bool
        //Immune to bans
        mod,
        //immune to punch
        gymbro,
        //stays active after power cut
        laptopUser;

    //MAYBE public game object array, put all friends in there, so that can iterate through array
    public User[] friends;
    public bool happy = true;
    public bool connectedToFriends = false;
    public bool powerCut = false;

    public int currentAction = -1;

    //Selected action
    public SpriteRenderer action;

    //Face info
    public TextMeshProUGUI nametag;
    public Sprite happyFace, angryFace;
    public SpriteRenderer face;

    //Color info
    public Renderer facebg;
    public Renderer facering;
    public Material redRing;
    public Material greenRing;
   

    // Start is called before the first frame update
    void Start()
    {
        //Set the user's face after it's decided by UserList
        setStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Updates user facial expression and ring color, if bool is true, will use angry variant instead
    void setStatus(bool angry = false)
    {
        if (angry)
        {
            face.sprite = angryFace;
            facering.material = redRing;
            happy = false;
            AudioSource.PlayClipAtPoint(SoundManager.powerOff, Camera.main.transform.position);
        }
        else
        {
            face.sprite = happyFace;
            facering.material = greenRing;
            happy = true;
            AudioSource.PlayClipAtPoint(SoundManager.powerOn, Camera.main.transform.position);
        }
    }

    public void runCheck(int action)
    {
        //Only check these if no friends or if all friends' tags dont interfere
        if (action == 0 && !mod)
        {
            setStatus(true);
        }
        else if (action == 1 && !gymbro)
        {
            setStatus(true);
        } 
        else if (action == -1)
        {
            setStatus(false);
        }

        if (friends.Length > 0 && connectedToFriends)
        {
            foreach (User friend in friends)
            {
                if (action == 0 && friend.mod)
                {
                    setStatus(false);
                }
                else if (action == 1 && friend.gymbro)
                {
                    setStatus(false);
                }
            }
        }

        if (powerCut && !laptopUser)
        {
            setStatus(true);
        }
    }
}
