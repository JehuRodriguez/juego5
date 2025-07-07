using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Transform jugador;
    public float velocidad = 2f;

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (jugador != null)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }
}
