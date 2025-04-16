using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public void OnClick()
    {
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(SoundManager.button, Camera.main.transform.position);
        SceneManager.LoadScene(SceneName);

    }
}
