using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    private Animator Anim;
    private GameObject Jogador;
    public GameObject MeuAtaque;
    private NavMeshAgent Fantasma;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
        Fantasma = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        transform.LookAt(Jogador.transform.position);

        Fantasma.SetDestination(Jogador.transform.position);

        //if (Vector3.Distance(Jogador.transform.position, transform.position) < 6)
        //{
        //    Anim.SetBool("Atacando", true);

        //}
        //else
        //{
        //    Anim.SetBool("Atacando", false);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {

            Debug.Log("AQUUII");
                Anim.SetTrigger("Morte");
            Destroy(this.gameObject, 2f);
            Destroy(collision.gameObject);

        }
        Debug.Log("XXXXXXXXXXX");
    }

    //public void AtivarSoco()
    //{
       // MeuAtaque.SetActive(true);
    //}

   // public void DesativarSoco()
   // {
   //     MeuAtaque.SetActive(false);
   // }
}