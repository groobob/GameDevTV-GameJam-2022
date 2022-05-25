using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInput : MonoBehaviour
{
    [SerializeField] PlayerMovement m_Movement;

    Queue<InputFrame> m_Inputs;

    public void Initialize(Queue<InputFrame> a_Inputs)
    {
        m_Inputs = a_Inputs;
    }

    void FixedUpdate()
    {
        if (m_Inputs.Count > 0)
        {
            m_Movement.Move(m_Inputs.Dequeue());
        }
    }
}