using UnityEngine;
using System.Collections;

public class SpriteBillboard : MonoBehaviour
{
    public Camera m_Camera;

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up); // it makes the object point in the same direction as the camera's forward axis
    }
}