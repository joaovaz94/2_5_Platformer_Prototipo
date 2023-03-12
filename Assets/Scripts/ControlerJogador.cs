using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerJogador : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravidade = -20;
    [SerializeField] private Transform confereChao;
    [SerializeField] private LayerMask camadaChao;
    [SerializeField] private bool podePuloDuplo = true;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform modeloPersonagem;



    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        animator.SetFloat("speed", Mathf.Abs(hInput));
        bool estaNoChao = Physics.CheckSphere(confereChao.position, 0.2f, camadaChao);
        animator.SetBool("estaNoChao", estaNoChao);
        if (estaNoChao)
        {
            direction.y = -1;
            podePuloDuplo = true;
            if (Input.GetButtonDown("Jump"))
            {
                Pulo();
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("BolaDeFogo");
            }
        }
        else
        {
            direction.y += gravidade * Time.deltaTime;
            if(podePuloDuplo & Input.GetButtonDown("Jump"))
            {
                PuloDuplo();
            }
        }
        if(hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            modeloPersonagem.rotation = newRotation;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fireball"))
        {
            return;
        }
        controller.Move(direction * Time.deltaTime);
    }


    private void PuloDuplo()
    {
        animator.SetTrigger("puloDuplo");
        direction.y = jumpForce;
        podePuloDuplo = false;
    }

    private void Pulo()
    {
        direction.y = jumpForce;
    }
}
