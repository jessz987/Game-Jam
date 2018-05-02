using UnityEngine;
using UnityEngine.PostProcessing;

public class CameraController : MonoBehaviour
{
    public float Xmax;
    public float Xmin;

    public Vector3 offset;
    public Transform player;

    public float lerpSpeed;

    public PostProcessingProfile processingBehaviour;

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

        if (GameManager.gotBalloons)
        {
            processingBehaviour.colorGrading.enabled = false;

        }

        transform.position += (target - transform.position) * lerpSpeed;
    }
}