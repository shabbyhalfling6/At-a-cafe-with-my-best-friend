using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {
    //make the mouse follow the camera, but cant look too far down/up
    float speed = 20f;

    private void Update()
    {
        {
            transform.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
        }
    }
}
