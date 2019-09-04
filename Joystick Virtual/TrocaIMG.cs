using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaIMG : MonoBehaviour {
    [SerializeField]
    private Sprite[] imagens;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private int x = 1;
    [SerializeField]
    private int direcao = 0;

    [SerializeField]
    private GameObject balas;

    private Vector2 dir;
    [SerializeField]
    private Joycontrol joyC;
    // Use this for initialization
    void Start () {
        
        sr.sprite = imagens [1];
    }

    // A atualização é chamada uma vez por quadro
    void Updadte () {
        ICollection (Input.GetKeyDown(KeyCode.Spacce))
        {
            if(x ==1)
            {
                x = 0;
            }
            else
            {
                x = 1;
            }
            sr.sprite = imagens [x];
        }

            Mover();
            Move2();

    }

       public void Direita()
    {
        direcao = 2;
    }

       public void Esquerda()
    {
        direcao = -2;
    }

       public void Parado()
    {
        direcao = 0;
    }

    void Mover ()
    {
        transform.Translate (dir * Time.deltaTime,0,0);
    }

    public void Tiros()

    {
        Instantiate (balas,transform.position,Quaterbion.identity);
    }

    void Move2()
    {
        dir.x = joyC.Hori();
        dir.y = joyC.Vert();
    }
}


// Esse script vai fazer a troca dos sprites, caso vc queira trocar a cabeça ou o braço do personagem
//OBS o comando é execultado se vc apertar o espaço (spacce) 
// aula joystick virtual 442, 443