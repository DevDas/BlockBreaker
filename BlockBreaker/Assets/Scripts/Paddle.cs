using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float MinX = 0;
    [SerializeField] float MaxX = 17.5f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float MousePositionX = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        transform.position = new Vector2(Mathf.Clamp(MousePositionX, MinX, MaxX), transform.position.y);
    }
}
