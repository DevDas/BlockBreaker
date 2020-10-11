using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip[] Clips;
    [SerializeField] Paddle Paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 2f;

    AudioSource MySource;

    //State
    Vector2 PaddleToBallVector;
    bool bLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        PaddleToBallVector = transform.position - Paddle1.transform.position;
        MySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle();
        LaunchOnMouseClick();
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            bLaunched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        if (!bLaunched)
        {
            Vector2 PaddlePosition = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
            transform.position = PaddlePosition + PaddleToBallVector;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!bLaunched) return;
        AudioClip clip = Clips[UnityEngine.Random.Range(0, Clips.Length)];
        //AudioSource.PlayClipAtPoint(Clips[RandomNum], transform.position);
        MySource.PlayOneShot(clip);
    }
}
