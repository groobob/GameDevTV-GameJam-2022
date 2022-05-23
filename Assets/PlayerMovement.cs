using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float m_MovementSpeed = 1.0f;
    [SerializeField] float m_JumpForce = 3.0f;

    Vector3 m_Velocity;

    bool m_Grounded = false;

    bool m_JumpPressed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_JumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (!m_Grounded)
        {
            m_Velocity += Physics.gravity * Time.fixedDeltaTime;
        }
        else
        {
            m_Velocity = Vector3.zero;

            if (Input.GetKey(KeyCode.A))
            {
                m_Velocity.x -= m_MovementSpeed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                m_Velocity.x += m_MovementSpeed;
            }
        }

        if (m_JumpPressed)
        {
            m_JumpPressed = false;

            if (m_Grounded)
            {
                m_Velocity.y = m_JumpForce;
            }
        }

        Vector3 m_ScaledVelocity = m_Velocity * Time.fixedDeltaTime;

        // We loop through the collision detection
        // Lets say we're moving upward and to the right
        // We hit a wall this frame, which stops the movement short
        // But we still have room to move up
        // We cancel out the rightward velocity, but keep the upward velocity to then compute on the next loop through
        if (m_ScaledVelocity.magnitude > 0.0001f)
        {
            // Check for collision before moving
            RaycastHit2D _Hit = Physics2D.BoxCast(transform.position, new Vector2(0.5f, 1.0f), 0, m_ScaledVelocity.normalized, m_ScaledVelocity.magnitude);

            if (_Hit)
            {
                Debug.Log($"Magnitude {m_ScaledVelocity.magnitude}");
                Debug.Log($"Hit Distance {_Hit.distance}");

                transform.position += m_ScaledVelocity.normalized * _Hit.distance;

                m_ScaledVelocity -= m_ScaledVelocity * _Hit.distance;

                // Reset velocity on axis that was hit
                Vector3 _MultVec = Vector3.one - new Vector3(Mathf.Abs(_Hit.normal.x), Mathf.Abs(_Hit.normal.y));

                m_ScaledVelocity = new Vector3(_MultVec.x * m_ScaledVelocity.x, _MultVec.y * m_ScaledVelocity.y, 0);

                // Push player away from obstacle to prevent further collisions
                transform.position += new Vector3(_Hit.normal.x * 0.01f, _Hit.normal.y * 0.01f, 0);

                Debug.Log($"MultVec {_MultVec}");
                Debug.Log($"Mult {m_ScaledVelocity.magnitude}");
            }
            else
            {
                transform.position += m_ScaledVelocity;
                m_ScaledVelocity = Vector3.zero;
            }
        }

        // Check for ground
        RaycastHit2D _GroundHit = Physics2D.BoxCast(transform.position, new Vector2(0.5f, 1.0f), 0, -Vector2.up, 0.01f);

        if (_GroundHit)
        {
            m_Grounded = true;
            transform.position -= new Vector3(0, _GroundHit.distance - 0.01f, 0);
        }
        else
        {
            m_Grounded = false;
        }
    }
}
