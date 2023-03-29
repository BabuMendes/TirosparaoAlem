using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    public Personagem Personagem;
    private Animator Anim;
    private GameObject Jogador;
    public GameObject MeuAtaque;
    private NavMeshAgent Fantasma;
    public Image derrota;


    public float distProcurar;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
        Fantasma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(Jogador.transform.position, transform.position);
        bool procurar = (dist < distProcurar);

        if (procurar == true)
        {
            transform.LookAt(Jogador.transform.position);
            Fantasma.SetDestination(Jogador.transform.position);
        }

        if (procurar == false);
        {
            transform.LookAt(transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Personagem.Contar(1);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player") 
        {
            derrota.gameObject.SetActive(true);
            UnityEngine.Cursor.visible = true;
        }
    }
}