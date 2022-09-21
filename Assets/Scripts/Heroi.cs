using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroi : MonoBehaviour
{
    private Rigidbody2D Corpo;
    private Animator Anim;
    public GameObject MeuAtk;
    public int qtdpulos = 2;
    // Start is called before the first frame update
    void Start()
    {
        Corpo = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimento
        float velX = Input.GetAxis("Horizontal")*4;
        float minhaG = Corpo.velocity.y;
        
        Corpo.velocity = new Vector2(velX, minhaG);

        if(velX == 0)
        {
            Anim.SetBool("Andar", false);
        }
        else
        {
            Anim.SetBool("Andar", true);
            if(velX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Anim.SetTrigger("Ataque");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if(qtdpulos > 0)
            {
                qtdpulos--;
                Pular();
            }
                

           
            
        }

    }


    void Pular()
    {
        Corpo.AddForce(Vector2.up * 330);
    }

    public void AtivarATK()
    {
        MeuAtk.SetActive(true);
    }

    public void DesativarATK()
    {
        MeuAtk.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D colidiu)
    {
        if(colidiu.gameObject.tag == "Chao")
        {
            qtdpulos = 2;
        }
    }
}
