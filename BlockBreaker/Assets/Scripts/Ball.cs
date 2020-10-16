using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip[] Clips;
    [SerializeField] Paddle Paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 2f;
    [SerializeField] float RandomFactor = 0.2f;

    AudioSource MySource;
    Rigidbody2D RigidBodyComponent;

    //State
    Vector2 PaddleToBallVector;
    bool bLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        PaddleToBallVector = transform.position - Paddle1.transform.position;
        MySource = GetComponent<AudioSource>();
        RigidBodyComponent = GetComponent<Rigidbody2D>();
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
            RigidBodyComponent.velocity = new Vector2(xPush, yPush);
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

        Vector2 VelocityTweak = new Vector2(Random.Range(0f, RandomFactor), Random.Range(0f, RandomFactor));
        RigidBodyComponent.velocity += VelocityTweak;

        AudioClip clip = Clips[Random.Range(0, Clips.Length)];    
        MySource.PlayOneShot(clip);
    }
}
