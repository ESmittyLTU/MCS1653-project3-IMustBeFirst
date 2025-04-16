using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnClick()
    {
        AudioSource.PlayClipAtPoint(SoundManager.button, Camera.main.transform.position);
        Application.Quit();
    }
}
