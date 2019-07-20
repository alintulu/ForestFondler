using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    public AudioClip onClick;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadMain()
    {
        audioSource.PlayOneShot(onClick, 0.7F);
        //(SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Debug.Log("Load Main");
    }

    public void LoadCredits()
    {
        audioSource.PlayOneShot(onClick, 0.7F);
        //SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
        Debug.Log("Load Credits");
    }

    public void Exit()
    {
        //Application.Quit();
    }
}
