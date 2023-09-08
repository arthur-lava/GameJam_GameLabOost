using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    public int HP { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Hero.OnObstacleHit += DecreaseHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecreaseHP()
    {

    }

    private void OnDestroy()
    {
        Hero.OnObstacleHit -= DecreaseHP;
    }
}
