using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHeroes : MonoBehaviour
{
    [SerializeField] private Hero[] _heroes;
    [SerializeField] private GameObject[] _positions;

    private Hero _currentActiveHeroe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SwitchCurrentHeroes();
    }

    private void SwitchCurrentHeroes()
    {
        foreach(Hero hero in _heroes)
        {
            if (hero.Active)
            {
                hero.Active = false;
                continue;
            }

            _currentActiveHeroe = hero;
            hero.Active = true;
        }

        SwitchHeoresPos();
    }

    private void SwitchHeoresPos()
    {
        foreach(Hero hero in _heroes)
        {
            if(hero.Active)
            {
                hero.SetNewPos(_positions[0]);
                continue;
            }

            hero.SetNewPos(_positions[1]);
        }
    }

}
