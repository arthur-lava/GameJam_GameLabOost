using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public enum Abilities
    {
        None,
        Water,
        Fire
    }

    [SerializeField] private GameObject _currentPos;
    [SerializeField] private bool _active;
    [SerializeField] private Abilities _ability;

    public bool Active { get => _active; set => _active = value; }
    public Abilities Ability => _ability;
    
    private bool _repositionSelf = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_repositionSelf || 
            transform.position == _currentPos.transform.position)
        {
            _repositionSelf = false;
            return;
        }

        LerpToNewPos();
    }

    public void SetNewPos(GameObject pNewPos)
    {
        _currentPos = pNewPos;
        _repositionSelf = true;
    }

    private void LerpToNewPos()
    {
        transform.position = Vector3.Lerp(transform.position, _currentPos.transform.position, .2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Obstacle>(out var obstacle)) return;

        if (obstacle.Weakness != _ability)
        {
            Debug.Log("You took a hit");
        }
        else
        {
            Debug.Log("You destroyed the obstacle");
        }

        ObstaclePooler.Instance.DisableObstacle(obstacle);
        CameraShake.Instance.TriggerShake();
    }
}
