using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckButton : MonoBehaviour
{
    public GameObject winScreen;
    
    public GameObject[] users;
    public TextMeshProUGUI statusText;

    void Start()
    {
        users = GameObject.FindGameObjectsWithTag("User");
    }

    public void OnClick()
    {
        foreach (GameObject user in users)
        {
            User userScript = user.GetComponent<User>();
            if (userScript.happy == true)
            {
                statusText.text = "I am NOT first.";
                return;
            }
            else
            {
                continue;
            }
        }
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        AudioSource.PlayClipAtPoint(SoundManager.win, Camera.main.transform.position);
        Debug.Log("YOU WIN");
        winScreen.SetActive(true);
        statusText.text = "I AM first!";
    }
}
