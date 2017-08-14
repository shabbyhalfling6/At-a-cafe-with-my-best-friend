using UnityEngine;
using System.Collections;

public class SpriteBillboard : MonoBehaviour
{
    private Camera m_Camera;

    void Start()
    {
        m_Camera = Camera.main;
    }

    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up); // it makes the object point in the same direction as the camera's forward axis
    }
}