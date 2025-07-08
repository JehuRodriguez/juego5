using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(x, 0, z);
        transform.Translate(mov * velocidad * Time.deltaTime);
    }
}
