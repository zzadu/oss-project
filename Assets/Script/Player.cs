using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float defaultSpeed = 0.05f;
    public static float speed = defaultSpeed;
    Animator animator;
    GameObject Quiz;

    void Start()
    {
        animator = GetComponent<Animator>();
        Quiz = GameObject.Find("Quiz");
    }

    void Update()
    {
        transform.Translate(transform.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Store"))
        {
            speed = 0;
            animator.enabled = false;

            if (collision.name == "fruitStore")
            {
                StartCoroutine(Quiz.GetComponent<Quiz>().IFruit());
            }
            else if (collision.name == "bakery")
            {
                StartCoroutine(Quiz.GetComponent<Quiz>().IBread());
            }
            else if (collision.name == "fishStore")
            {
                StartCoroutine(Quiz.GetComponent<Quiz>().IFish());
            }
            else if (collision.name == "vegetableStore")
            {
                StartCoroutine(Quiz.GetComponent<Quiz>().IVege());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            speed = 0;
            animator.enabled = false;
            Quiz.GetComponent<Quiz>().Result();
            SceneManager.LoadScene("Score");
        }
    }

}
