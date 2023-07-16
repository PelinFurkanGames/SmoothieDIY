using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    [SerializeField] GameObject camPosDefault;
    [SerializeField] GameObject camPos2;
    [SerializeField] GameObject music;
    private void Start()
    {
        if (PlayerPrefs.GetInt("music") == 1)
        {
            music.GetComponent<AudioSource>().mute = true;
        }
        if (PlayerPrefs.GetInt("music") == 0)
        {
            music.GetComponent<AudioSource>().mute = false;
        }
    }
    public void StartGame()
    {
        GameManager.isGameStarted = true;
    }

    public void Blend()
    {
        GameManager.stage4end = true;
    }

    public void SceenLoad(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void ChangeCam(int num)
    {
        if(num == 0)
        {
            camPosDefault.SetActive(true);
            camPos2.SetActive(false);
        }
        if (num == 1)
        {
            camPosDefault.SetActive(false);
            camPos2.SetActive(true);
        }
    }
    public void MusicOnOff(int num)
    {
        if (num == 1)
        {
            music.GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetInt("music", 0);
        }
        if (num == 0)
        {
            music.GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetInt("music", 1);
        }
    }

    [ContextMenu("Delete PlayerPref")]
    public void DeletePrefabs()
    {
        PlayerPrefs.DeleteAll();
    }


}
