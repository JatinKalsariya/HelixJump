using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform ball;
    Vector3 offset;
    Vector3 pos;
    void Start()
    {
        offset = transform.position - ball.position;
        pos = transform.position;
    }

    void Update()
    { 
        if (pos.y > ball.position.y)
        {
            pos = ball.position;
            var movement = ball.position + offset;
            transform.position = movement;
        }

    }
}
