using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform birdTrasform;
    Vector3 range;

    void Awake()
    { // Calculate the range between the camera's position and the bird position 
        range = transform.position - birdTrasform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { // Make the camera follows the bird's movement on the X axis
      // and keep the Y axis constant
        transform.position = new Vector3(range.x + birdTrasform.position.x, transform.position.y, range.z + birdTrasform.position.z);

        
    }
}
