using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;//var. which makes ref to the comp. Transform of the player
    public float smoothing;//Following speed's camera of the player

    Vector3 offset;//init distance between the camera and the player

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCamPos = player.position + offset;

        transform.position = Vector3.Lerp(transform.position,targetCamPos,
                                        smoothing*Time.deltaTime);
    }
}
