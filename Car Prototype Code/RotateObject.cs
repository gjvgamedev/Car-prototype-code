using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Velocidade de rotação (ajuste conforme necessário)
    public float velocidadeRotacao = 50f;

    void Update()
    {
        // Rotaciona o objeto em torno do seu próprio eixo
        transform.Rotate(Vector3.up, velocidadeRotacao * Time.deltaTime);
    }
}
