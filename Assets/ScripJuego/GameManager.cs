using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    int nivel;
    string jugador;
    int puntaje;

    void Start()
    {
        jugador = PlayerPrefs.GetString("Jugador", "Anon");
        nivel = PlayerPrefs.GetInt("Nivel", 1);

        Debug.Log("Jugador: " + jugador);
        Debug.Log("Nivel: " + nivel);

        switch (nivel)
        {
            case 1:
                Debug.Log("Nivel 1: pocos enemigos");
                puntaje = 150; 
                break;
            case 2:
                Debug.Log("Nivel 2: más enemigos");
                puntaje = 100;
                break;
            case 3:
                Debug.Log("Nivel 3: dificultad alta");
                puntaje = 50;
                break;
            default:
                Debug.Log("Nivel desconocido");
                puntaje = 0;
                break;
        }
    }

    public void TerminarNivel()
    {
        Debug.Log("Nivel terminado, enviando puntaje...");
        StartCoroutine(EnviarPuntaje());
    }

    IEnumerator EnviarPuntaje()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", jugador);
        form.AddField("id_nivel", nivel);
        form.AddField("valor_puntaje", puntaje);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego_niveles2/Insertar_puntaje.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Puntaje guardado correctamente");
            SceneManager.LoadScene("Menu Principal"); 
        }
        else
        {
            Debug.Log("Error al enviar puntaje: " + www.error);
        }
    }

}
