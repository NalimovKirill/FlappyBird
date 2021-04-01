using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
   [SerializeField] private GameObject _mainCamera;
   [SerializeField] private float _parallaxEffect;

   private float _length, _startPosition, _temp, _dist;

   private void Start()
   {
      _startPosition = transform.position.x;
      _length = GetComponent<SpriteRenderer>().bounds.size.x;
   }

   private void FixedUpdate()
   {
      _temp = (_mainCamera.transform.position.x * (1 - _parallaxEffect));
      _dist = (_mainCamera.transform.position.x * _parallaxEffect);
      
      transform.position = new Vector3(_startPosition + _dist, transform.position.y, transform.position.z);

      if (_temp > _startPosition + _length)
         _startPosition += _length;
      else if (_temp < _startPosition - _length)
         _startPosition -= _length;
   }
}
