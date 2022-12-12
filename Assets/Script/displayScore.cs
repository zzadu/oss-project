using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class displayScore : MonoBehaviour
{
    GameObject one, two, three, zero;
    int correct;
    public AudioClip ClearSound, FailSound;
    AudioSource _audio;

    void Start()
    {
        one = GameObject.Find("OneStar");
        two = GameObject.Find("TwoStars");
        three = GameObject.Find("ThreeStars");
        zero = GameObject.Find("NoStar");

        _audio = GameObject.Find("Canvas").GetComponent<AudioSource>();
        PresentScore();
    }

    public void PresentScore()
    {
        correct = PlayerPrefs.GetInt("Score");
        AudioClip clip = ClearSound;

        if (correct == 4)
        {
            one.SetActive(false);
            two.SetActive(false);
            zero.SetActive(false);
        }
        else if (correct == 3)
        {
            one.SetActive(false);
            three.SetActive(false);
            zero.SetActive(false);
        }
        else if (correct == 2)
        {
            two.SetActive(false);
            three.SetActive(false);
            zero.SetActive(false);
        }
        else if (correct <= 1)
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            clip = FailSound;
        }

        _audio.clip = clip;
        _audio.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene("MiddleProject");
    }

    
}
