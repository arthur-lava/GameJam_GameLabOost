using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject _pauseUi;
    public static PauseManager Instance { get; private set; }
    public bool Paused { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Unpause();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SetPause();
    }

    private void SetPause()
    {
        Paused = !Paused;
        Time.timeScale = Paused ? 0 : 1;
        _pauseUi.SetActive(Paused);
    }

    public void Unpause()
    {
        Paused = false;
        Time.timeScale = 1;
        _pauseUi.SetActive(false);
    }
}
