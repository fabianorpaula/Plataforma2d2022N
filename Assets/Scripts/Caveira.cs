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
    private int vida = 3;
    private bool morreu = false;
    // Start is called before the first frame update
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }


    void Update()
    {
        
            
        
        if(morreu == true)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            Mover();
        }
        
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

    private void OnTriggerStay2D(Collider2D colidiu)
    {
        if (colidiu.gameObject.tag == "AtaqueHeroi")
        {
            Anim.SetTrigger("Dano");
        }

    }

    public void PerdeuHP()
    {
        vida--;
        if (vida < 0)
        {
            Anim.SetBool("Morto", true);
        }
    }

    public void Morrer()
    {   
        
        Corpo.velocity = new Vector2(0, 0);
        morreu = true;
        
    }

    public void Desaparecer()
    {
        Destroy(this.gameObject);
    }
}
