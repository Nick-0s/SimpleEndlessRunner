using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    private Vector3 _currentPositionOnLines;
    private Vector3 _targetPosition;
    private Coroutine _moving;
    public event UnityAction Stoped;
    public event UnityAction MovedUp;
    public event UnityAction MovedDown;

    private void Start()
    {
        _currentPositionOnLines = transform.position;
        _targetPosition = transform.position;
        _moving = null;
    }

    /* private void Update()
    {
        if(_currentPositionOnLines transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
            _currentPositionOnLines = _targetPosition;
    } */

    public Vector3 CurrentPosition => _currentPositionOnLines;
    public Vector3 TargetPosition => _targetPosition;

    public void TryMoveUp()
    {
        if(_targetPosition.y < _maxHeight)
        {
            SetNextPosition(_stepSize);
            StartNewMoving();

            MovedUp?.Invoke();
        }
    }   

    public void TryMoveDown()
    {
        if(_targetPosition.y > _minHeight)
        {
            SetNextPosition(-_stepSize);
            StartNewMoving();

            MovedDown?.Invoke();
        }
    }

    private void StartNewMoving()
    {
        if(_moving != null)
            StopCoroutine(_moving);

        _moving = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while(transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

            yield return null;
        }

        _currentPositionOnLines = _targetPosition;
        Stoped?.Invoke();
    }

    private void SetNextPosition(float step)
    {
        _targetPosition.y += step;
    }
}
