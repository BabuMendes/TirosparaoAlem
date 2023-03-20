using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recarrega : MonoBehaviour
{

    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Arma").GetComponent<Arma>().Carregar();
            Destroy(this.gameObject);
        }
    }

}
