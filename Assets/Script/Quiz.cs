using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    GameObject StartQuizObj;
    Animator animator;
    public string[] pick;
    GameObject[] answer = new GameObject[4];

    GameObject FruitQuiz, BreadQuiz, FishQuiz, VegeQuiz;

    GameObject Score;
    GameObject Info;

    void Start()
    {
        StartQuizObj = GameObject.Find("StartQuiz");
        StartQuizObj.SetActive(false);
        
        Player.speed = 0;

        animator = GameObject.Find("Player").GetComponent<Animator>();
        animator.enabled = false;

        FruitQuiz = GameObject.Find("FruitQuiz"); FruitQuiz.SetActive(false);
        BreadQuiz = GameObject.Find("BreadQuiz"); BreadQuiz.SetActive(false);
        FishQuiz = GameObject.Find("FishQuiz"); FishQuiz.SetActive(false);
        VegeQuiz = GameObject.Find("VegeQuiz"); VegeQuiz.SetActive(false);

        Score = GameObject.Find("Canvas");

        Info = GameObject.Find("Info");

        StartCoroutine(IInfo());
    }


    IEnumerator IInfo()
    {
        yield return new WaitForSeconds(5f);
        Info.SetActive(false);
        StartCoroutine(IStartQuiz());
    }

    IEnumerator IStartQuiz()
    {
        yield return new WaitForSeconds(1f);

        StartQuizObj.SetActive(true);
        GameObject[] Fruits = GameObject.FindGameObjectsWithTag("Fruit");
        foreach (GameObject fruit in Fruits)
        {
            fruit.SetActive(false);
        }

        GameObject[] Breads = GameObject.FindGameObjectsWithTag("Bread");
        foreach (GameObject bread in Breads)
        {
            bread.SetActive(false);
        }

        GameObject[] Fishes = GameObject.FindGameObjectsWithTag("Fish");
        foreach (GameObject fish in Fishes)
        {
            fish.SetActive(false);
        }

        GameObject[] Vegetables = GameObject.FindGameObjectsWithTag("Vegetable");
        foreach (GameObject vege in Vegetables)
        {
            vege.SetActive(false);
        }

        answer[0] = Fruits[Random.Range(0, 4)]; answer[0].SetActive(true);
        answer[1] = Breads[Random.Range(0, 4)]; answer[1].SetActive(true);
        answer[2] = Fishes[Random.Range(0, 4)]; answer[2].SetActive(true);
        answer[3] = Vegetables[Random.Range(0, 4)]; answer[3].SetActive(true);

        yield return new WaitForSeconds(3f);
        StartQuizObj.SetActive(false);
        Player.speed = Player.defaultSpeed;
        animator.enabled = true;
    }

    public IEnumerator IFruit()
    {
        FruitQuiz.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (pick.Length == 0)
        {
            pick = new List<string>(pick) { " " }.ToArray();
        }
        FruitQuiz.SetActive(false);
        Player.speed = Player.defaultSpeed;
        animator.enabled = true;
    }

    public IEnumerator IBread()
    {
        BreadQuiz.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (pick.Length == 1)
        {
            pick = new List<string>(pick) { " " }.ToArray();
        }
        BreadQuiz.SetActive(false);
        Player.speed = Player.defaultSpeed;
        animator.enabled = true;
    }

    public IEnumerator IFish()
    {
        FishQuiz.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (pick.Length == 2)
        {
            pick = new List<string>(pick) { " " }.ToArray();
        }
        FishQuiz.SetActive(false);
        Player.speed = Player.defaultSpeed;
        animator.enabled = true;
    }

    public IEnumerator IVege()
    {
        VegeQuiz.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (pick.Length == 3)
        {
            pick = new List<string>(pick) { " " }.ToArray();
        }
        VegeQuiz.SetActive(false);
        Player.speed = Player.defaultSpeed;
        animator.enabled = true;
    }

    public void Result()
    {
        int correct = 0;

        for (int i = 0; i < 4; i++)
        {
            if (pick[i] == answer[i].name)
            {
                correct++;
            }
        }

        PlayerPrefs.SetInt("Score", correct);
    }
}
