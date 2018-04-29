using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float Xmax;
    public float Xmin;

    public Vector3 offset;
    public Transform player;

    public float lerpSpeed;

    void Update()
    {
        Vector3 target = player.transform.position + offset;

        float camXExtent = Camera.main.orthographicSize * Camera.main.aspect;


        if (target.x + camXExtent > Xmax + camXExtent)
        {
            target.x = Xmax;
        }

        if (target.x - camXExtent < Xmin - camXExtent)
        {
            target.x = Xmin;
        }


        transform.position += (target - transform.position) * lerpSpeed;
    }
}