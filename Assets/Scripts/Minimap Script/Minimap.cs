using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 20, 0);

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
