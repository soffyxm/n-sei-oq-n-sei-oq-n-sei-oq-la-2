using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    public int Speed = 5;
    public int Jump = 4;
    bool chao, puloDuplo;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        pular();
    }

    void mover()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed,rig.velocity.y);
    }

    void pular()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(chao)
            {
                rig.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                chao=false;
                puloDuplo=true;
            }else if (puloDuplo)
            {
                rig.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Plataforma"))
        {
            chao=true;
            puloDuplo=false;
        }
    }
}
