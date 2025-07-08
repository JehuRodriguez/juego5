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
        ActualizarUI();
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
        form.AddField("nombre_usuario", jugador);
        form.AddField("id_nivel", nivel);
        form.AddField("valor_puntaje", puntaje);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego_niveles2/insertar_actualizar_puntaje.php", form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            SceneManager.LoadScene("Menu Principal");
        }
    }

}
