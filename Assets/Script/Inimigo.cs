using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Animator Anim;
    private GameObject Jogador;
    public GameObject MeuAtaque;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Jogador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(Jogador.transform.position);
        if (Vector3.Distance(Jogador.transform.position, transform.position) < 6)
        {
            Anim.SetBool("Atacando", true);

        }
        else
        {
            Anim.SetBool("Atacando", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Destroy(collision.gameObject);
            Anim.SetTrigger("Morte");
            Destroy(this.gameObject, 2f);
        }
    }

    public void AtivarSoco()
    {
        MeuAtaque.SetActive(true);
    }

    public void DesativarSoco()
    {
        MeuAtaque.SetActive(false);
    }
}