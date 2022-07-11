using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;    
    private RawImage _image;
    private float _uvPositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
        _uvPositionX = _image.uvRect.x;
    }

    private void Update()
    {
        _uvPositionX += _speed * Time.deltaTime;

        if(_uvPositionX > 1)
            _uvPositionX = 0;

        _image.uvRect = new Rect(_uvPositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
