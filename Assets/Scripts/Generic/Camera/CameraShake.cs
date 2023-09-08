using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float _intensity;
    [SerializeField] float _duration;

    public static CameraShake Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0;

        while(elapsed < _duration)
        {
            float x = Random.Range(-1f, 1f) * _intensity;
            float y = Random.Range(-1f, 1f) * _intensity;

            transform.localPosition = new Vector3(x, y, transform.localPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
