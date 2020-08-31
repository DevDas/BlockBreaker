using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle Paddle1;

    Vector2 PaddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        PaddleToBallVector = transform.position - Paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PaddlePosition = new Vector2(Paddle1.transform.position.x, Paddle1.transform.position.y);
        transform.position = PaddlePosition + PaddleToBallVector;
    }
}
