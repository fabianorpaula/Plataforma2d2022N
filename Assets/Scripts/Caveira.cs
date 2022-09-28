using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caveira : MonoBehaviour
{

    private Rigidbody2D Corpo;
    private Animator Anim;
    public float velX = 1;
    public float posInicial;
    public float posFinal;
    // Start is called before the first frame update
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }


    void Update()
    {
        Mover();
    }

    void Mover()
    {
        Corpo.velocity = new Vector2(velX, 0);
        if(velX != 0)
        {
            Anim.SetBool("Andando", true);
        }
        else
        {
            Anim.SetBool("Andando", false);
        }
        if(transform.position.x < posInicial)
        {
            velX = 3;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if(transform.position.x > posFinal)
        {
            velX = -3;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
