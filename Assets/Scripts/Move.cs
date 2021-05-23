using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private Vector3 _target;
    private MouseInputs _mouseInputs;
    private GameManager _gameManager;
    private void Awake()
    {
        _mouseInputs = new MouseInputs();
        _rb = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.ChangeSpeed += ChangeSpeed;
    }

    private void Start()
    {
        _target = _rb.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _target = _mouseInputs.GetMousePos();
        }
    }
    private void FixedUpdate()
    {
        MovementPlayer();
    }
    private void MovementPlayer()
    {
        _rb.position = Vector3.Lerp(_rb.position, _target, _speed * Time.deltaTime);
    }
    private void ChangeSpeed(float speed)
    {
        _speed = speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var target = collision.gameObject.GetComponent<IDestroy>();
        if (target is IDestroy)
            target.DestroyObject();
    }
}
