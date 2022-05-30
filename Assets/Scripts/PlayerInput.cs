using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] PlayerMovement m_Movement;
    [SerializeField] GhostInput m_GhostPrefab;

    Vector3 m_SpawnPoint;

    List<Queue<InputFrame>> m_Replays = new List<Queue<InputFrame>>();

    Queue<InputFrame> m_CurrentReplay = new Queue<InputFrame>();

    List<GhostInput> m_Ghosts = new List<GhostInput>();

    bool m_JumpPressed = false;

    public void Awake()
    {
        m_SpawnPoint = transform.position;
    }

    public void ResetLevel()
    {
        m_Replays.Add(m_CurrentReplay);

        m_CurrentReplay = new Queue<InputFrame>();

        transform.position = m_SpawnPoint;

        for (int i = 0; i < m_Ghosts.Count; i++)
        {
            Destroy(m_Ghosts[i].gameObject);
        }

        m_Ghosts.Clear();

        for (int i = 0; i < m_Replays.Count; i++)
        {
            GhostInput _Ghost = Instantiate(m_GhostPrefab, transform.position, Quaternion.identity);
            _Ghost.Initialize(new Queue<InputFrame>(m_Replays[i]));

            m_Ghosts.Add(_Ghost);
        }

        for (int i = 0; i < Bullet.Bullets.Count; i++)
        {
            Destroy(Bullet.Bullets[i].gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_JumpPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            ResetLevel();
        }
    }

    void FixedUpdate()
    {
        InputFrame _Frame = new InputFrame();

        _Frame.Jump = m_JumpPressed;
        _Frame.Left = Input.GetKey(KeyCode.A);
        _Frame.Right = Input.GetKey(KeyCode.D);

        m_JumpPressed = false;

        m_CurrentReplay.Enqueue(_Frame);

        m_Movement.Move(_Frame);
    }
}
