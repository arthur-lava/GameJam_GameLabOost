using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    private void Scroll() => gameObject.transform.position += _direction * _speed * Time.deltaTime;
}
