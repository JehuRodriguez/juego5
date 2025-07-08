using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabEnemigo;
    public Transform[] puntos;

    void Start()
    {
        StartCoroutine(SpawnEnemigos());
    }

    IEnumerator SpawnEnemigos()
    {
        for (int i = 0; i < puntos.Length; i++)
        {
            GameObject e = Instantiate(prefabEnemigo, puntos[i].position, Quaternion.identity);
            e.GetComponent<Enemigo>().valorPuntos = Random.Range(2, 6);
        }

        yield return new WaitForSeconds(10f);
        GameManager.instance.TerminarNivel(); 
    }
}
