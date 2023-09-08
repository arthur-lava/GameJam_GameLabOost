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
        ResetHP();
        Hero.OnObstacleHit += DecreaseHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ResetHP() {
        HP = 2;
    }

    private void DecreaseHP()
    {
        HP -= 1;
        if(HP <= 1) {
            Death();
        }
    }

    private void Death() {
        // Show End UI
    }
    private void OnDestroy()
    {
        Hero.OnObstacleHit -= DecreaseHP;
    }
}
