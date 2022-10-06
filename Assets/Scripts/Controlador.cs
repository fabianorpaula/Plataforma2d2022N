using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJogo()
    {
        Time.timeScale = 1;
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(0);
    }

    public void Morreu()
    {
        GameOver.SetActive(true);
    }
}
