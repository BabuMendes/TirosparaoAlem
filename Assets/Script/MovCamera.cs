using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    public float velocidadeRotacao;
    private float rotacaoVertical;

    void Update()
    {
        rotacaoVertical += Input.GetAxis("Mouse Y") * velocidadeRotacao;
        float rotacaoX = Mathf.Clamp(-rotacaoVertical, -45, 45);
        transform.localEulerAngles = new Vector3(rotacaoX, transform.localEulerAngles.y, transform.localEulerAngles.z);

    }
}

