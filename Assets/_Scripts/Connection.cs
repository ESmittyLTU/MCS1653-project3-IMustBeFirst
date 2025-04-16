using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public User[] connectedUsers;
    public SpriteRenderer sr, action;
    public Sprite greenLine, redLine;
    public int currentAction = -1;

    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = greenLine;
    }

    // Update is called once per frame
    public void runCheck(int action)
    {
        foreach (User user in connectedUsers) 
        {
            if (action == -1)
            {
                user.connectedToFriends = true;
                user.powerCut = false;
                sr.sprite = greenLine;
                user.runCheck(user.currentAction);
            }
            else if (action == 2)
            {
                user.connectedToFriends = false;
                user.powerCut = false;
                sr.sprite = redLine;
                AudioSource.PlayClipAtPoint(SoundManager.endCall, Camera.main.transform.position);
                user.runCheck(user.currentAction);
            }
            else if (action == 3) 
            {
                user.connectedToFriends = false;
                user.powerCut = true;
                sr.sprite = redLine;
                AudioSource.PlayClipAtPoint(SoundManager.cutPower, Camera.main.transform.position);
                user.runCheck(user.currentAction);
            }
        }
    }
}
