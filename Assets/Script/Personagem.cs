using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    public int mortos;
    private Rigidbody Rb;
    //private Animator Anim;
    public float sensibilidade;
    private float velocidadeP;
    public Image vitoria;
    public List<GameObject> ListaInimigos;
    public int indiceInimigos = 0;

    public int hp = 100;



    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        //Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();

        if (indiceInimigos < ListaInimigos.Count)
        {
            indiceInimigos++;
        }

        if (mortos == indiceInimigos)
        {
            vitoria.gameObject.SetActive(true);
        }
    }

    public void Contar(int contagem)
    {
        mortos = mortos + contagem;
    }


    void Mover()
    {
        //Correr;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeP = 5;
        }
        else
        {
            velocidadeP = 2;
        }

        //Movimento Andar
        float velZ = Input.GetAxis("Vertical") * velocidadeP;
        float velX = Input.GetAxis("Horizontal") * velocidadeP;
        //PosCorrigida
        Vector3 velCorrigida = velX * transform.right + velZ * transform.forward;

        Rb.velocity = new Vector3(velCorrigida.x, Rb.velocity.y, velCorrigida.z);

        //Movimento Girar
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);



    }
}

