using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator animator;
    public float velocidade;
    public bool ladoDireito = true;
    public bool noChao = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0){
            transform.Translate(new Vector3(Input.GetAxis("Horizontal") * velocidade * Time.deltaTime, 0, 0));
        }
        animator.SetFloat("Velocidade", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxis("Horizontal") > 0 && !ladoDireito)
        {
            Vire();
        }
        if (Input.GetAxis("Horizontal") < 0 && ladoDireito)
        {
            Vire();
        }
        if (noChao && Input.GetButtonDown("Jump")){
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,315));
            noChao=false;
        }
        animator.SetBool("NoChao", noChao);

    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name=="chao"){
            noChao = true;
        }

    } 
    void Vire()
    {
        ladoDireito =! ladoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;
    }
}
