using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateTerrain : MonoBehaviour
{
    [SerializeField] private ScrollingObject _otherTerrain;
    [SerializeField] private float _triggerZ;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void Update()
    {
        if (!CloseEnough(transform.position.z, _triggerZ, 0.2f)) return;
        Translate();
    }

    void Translate()
    {
        Vector3 currentPos = transform.position;
        transform.position = new Vector3(currentPos.x, currentPos.y, _otherTerrain.transform.position.z - _otherTerrain.transform.localScale.z * 10);
    }

    private bool CloseEnough(float pValueA, float pValueB, float pAcceptance) => Mathf.Abs(pValueA - pValueB) < pAcceptance;
}
