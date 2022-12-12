using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 PlayerPos = Player.transform.position;
        transform.position = new Vector3(PlayerPos.x, transform.position.y, transform.position.z);
    }
}
