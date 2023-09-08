using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
    public static ObstaclePooler Instance { get; private set; }

    [SerializeField] private Obstacle[] _prefabs;
    [SerializeField] private int _amountObjectsPerPool = 5;

    private Dictionary<Hero.Abilities, List<Obstacle>> _obstacles = new Dictionary<Hero.Abilities, List<Obstacle>>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiateObstacles();
    }

    private void InstantiateObstacles()
    {
        foreach (var prefab in _prefabs)
        {
            for (int i = 0; i < _amountObjectsPerPool; i++)
            {
                if(i < 1) _obstacles[prefab.Weakness] = new List<Obstacle>();

                var newObstacle = Instantiate(prefab);
                newObstacle.gameObject.SetActive(false);

                _obstacles[prefab.Weakness].Add(newObstacle);
            }
        }
    }

    private Obstacle AddNewObstacle(Hero.Abilities pObstacleWeakness)
    {
        foreach (var prefab in _prefabs)
        {
            if (prefab.Weakness != pObstacleWeakness) continue;

            Obstacle newObstacle = Instantiate(prefab);
            newObstacle.gameObject.SetActive(false);

            _obstacles[pObstacleWeakness].Add(newObstacle);

            return newObstacle;
        }

        return null;
    }

    private Hero.Abilities ChooseRandomWeakness()
    {
        int ranNum = Random.Range(0, _prefabs.Length);
        Debug.Log(ranNum);
        return _prefabs[ranNum].Weakness;
    }

    public Obstacle EnableObstacle()
    {
        Hero.Abilities ranAbility = ChooseRandomWeakness();
        Debug.Log(ranAbility);

        return EnableObstacle(ranAbility);
    }

    public Obstacle EnableObstacle(Hero.Abilities pObstacleWeakness)
    {
        foreach(var obstacle in _obstacles[pObstacleWeakness])
        {
            if (!obstacle.isActiveAndEnabled) return obstacle;
        }

        //no obstacle available, so we create a new one
        return AddNewObstacle(pObstacleWeakness);
    }

    public void DisableObstacle(Obstacle pObstacle) => pObstacle.gameObject.SetActive(false);
}
