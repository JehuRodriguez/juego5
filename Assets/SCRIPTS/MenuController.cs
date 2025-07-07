using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_InputField inputNivel;

    public void Jugar()
    {
        string nombre = inputNombre.text.Trim();
        string nivelTexto = inputNivel.text.Trim();

        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(nivelTexto))
        {
            Debug.Log("Faltan datos.");
            return;
        }

        int nivelElegido = int.Parse(nivelTexto);

        PlayerPrefs.SetString("Jugador", nombre);
        PlayerPrefs.SetInt("Nivel", nivelElegido);

        SceneManager.LoadScene("Juego");




    }
}
