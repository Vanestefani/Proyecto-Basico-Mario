using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mario : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float rotacion = 20.0f;

    CharacterController controller;
    Animator animator;
    AudioSource audioSource;
    // Este método se ejecuta una sola vez al inicio de cada objeto
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }

    // Este método se ejecuta una vez cada cuadro (una vez cada 60vo de segundo)
    private void Update()
    {
        animator.SetBool("Caminando", false);
        if(Input.GetKey(KeyCode.UpArrow))
        {
            controller.Move(transform.forward * Time.deltaTime * velocidad);
            animator.SetBool("Caminando", true);
        }
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Rotating");
            transform.Rotate(transform.up, rotacion * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Rotating");
            transform.Rotate(transform.up, -rotacion * Time.deltaTime);
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "moneda")
        {
            Destroy(other.gameObject);
            audioSource.Play();
        }
    }


}
