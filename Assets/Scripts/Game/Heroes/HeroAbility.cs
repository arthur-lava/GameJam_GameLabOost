using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Hero))]
public abstract class HeroAbility : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private float _fallForce = 10f;
    [SerializeField] private float _maxJumpHeight;
    private Hero _hero;
    private bool _jumping = false;
    private bool _falling = false;
    
    private float _currentAltitude = 0;

    private void Awake()
    {
        _hero = GetComponent<Hero>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!_hero.Active) return;

        CheckInput();
    }

    protected virtual void FixedUpdate()
    {
        if (_jumping) Jump();
    }

    protected virtual void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumping = true;
        }
    }

    protected void Jump()
    {
        if (_currentAltitude >= _maxJumpHeight * .8f) _falling = true;

        if (_jumping && !_falling) _currentAltitude = Mathf.Lerp(_currentAltitude, _maxJumpHeight, _jumpForce);

        if (_falling)
        {
            _currentAltitude -= _fallForce;
        }

        if (_currentAltitude <= 0)
        {
            _falling = _jumping = false;
            _currentAltitude = 0;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, _currentAltitude, transform.localPosition.z);
    }
}
