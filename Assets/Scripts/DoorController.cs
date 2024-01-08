using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject mainDoor;
    public GameObject player;
    public AudioSource task2;

    public static bool isKeyCollected = false;

    private void Update()
    {
        if (isKeyCollected && Vector3.Distance(transform.position, player.transform.position) < 3f)
        {
                door.GetComponent<Animator>().SetTrigger("Open");
                task2.Play();
                isKeyCollected = false;
        }
    }
}

