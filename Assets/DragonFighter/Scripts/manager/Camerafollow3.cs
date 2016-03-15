﻿using UnityEngine;
using System.Collections;

public class Camerafollow3 : MonoBehaviour
{

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    void start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {

        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, 60f, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}