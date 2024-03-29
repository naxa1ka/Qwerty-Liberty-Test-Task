﻿using UnityEngine;
using Zenject;


public class RacketMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _boundary;
    
    private IInput _input;

    private float _currentHorizontalMovement;

    [Inject]
    private void Constructor(IInput input)
    {
        _input = input;
    }
    
    private void Update()
    {
        _currentHorizontalMovement = _input.HorizontalMovement;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * (_currentHorizontalMovement * _speed * Time.fixedDeltaTime));
        
        var transformPosition = transform.position;
        if (transformPosition.x > _boundary)
        {
            transformPosition.x = _boundary;
        } else if (transformPosition.x < -_boundary)
        {
            transformPosition.x = -_boundary;
        }
        transform.position = transformPosition;
    }
}