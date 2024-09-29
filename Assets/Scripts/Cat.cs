using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float velocidade;
    public float distanciaPara;
    public Transform alvo;
    public bool ladoDireito = false;
    public Animator animator;
    public bool seguir = true;
    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, alvo.position)> distanciaPara)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(alvo.position.x, transform.position.y), velocidade * Time.deltaTime);
            seguir = true;
            animator.SetBool("Seguir", seguir);
        }  
        else 
        {
            seguir = false;
            animator.SetBool("Seguir", seguir);
        }
        if ((transform.position.x - alvo.position.x) < 0 && !ladoDireito){
            Vire();
        }
        if ((transform.position.x - alvo.position.x) > 0 && ladoDireito){
            Vire();
        }
    }

    public void Vire()
    {
        ladoDireito =! ladoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;
    }
}
