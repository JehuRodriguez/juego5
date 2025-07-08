using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int valorPuntos = 5;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.instance.SumarPuntaje(valorPuntos);
            Destroy(gameObject);
        }
    }
}
