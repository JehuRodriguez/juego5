using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoX, 0, movimientoZ);
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }
}
