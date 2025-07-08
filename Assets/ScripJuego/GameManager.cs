using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text textoPuntaje;

    int nivel;
    string jugador;
    int puntaje;


    int enemigosEliminados = 0;
    [HideInInspector]
    public int totalEnemigosNivel;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        jugador = PlayerPrefs.GetString("Jugador", "Anon");
        nivel = PlayerPrefs.GetInt("Nivel", 1);
        ActualizarUI();
    }

    public void SumarPuntaje(int p)
    {
        puntaje += p;
        enemigosEliminados++;
        ActualizarUI();

        if (enemigosEliminados >= totalEnemigosNivel) 
        {
            Debug.Log("¡Todos los enemigos eliminados! Puedes presionar el botón TERMINAR NIVEL.");
        }
    }

    void ActualizarUI()
    {
        textoPuntaje.text = "Puntaje: " + puntaje;
    }

    public void TerminarNivel()
    {
        StartCoroutine(EnviarPuntaje());
    }

    IEnumerator EnviarPuntaje()
    {
        WWWForm form = new WWWForm();

        string nombre_nivel = "Nivel " + nivel;

        Debug.Log(" Enviando puntaje...");
        form.AddField("nombre_usuario", jugador);
        form.AddField("nombre_nivel", nombre_nivel);
        form.AddField("puntaje", puntaje);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego5/insertar_actualizar_puntaje.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(" Puntaje enviado con éxito: " + www.downloadHandler.text);
            SceneManager.LoadScene("MenuPrincipal");
        }
        else
        {
            Debug.Log(" Error al enviar puntaje: " + www.error);
        }
    }

}
