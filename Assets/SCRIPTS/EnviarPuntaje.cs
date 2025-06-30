using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class EnviarPuntaje : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_InputField inputNivel;
    public TMP_InputField inputPuntaje;

    public void AlPresionar()
    {
        StartCoroutine(Enviar());
    }

    IEnumerator Enviar()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", inputNombre.text);
        form.AddField("nombre_nivel", inputNivel.text);
        form.AddField("puntaje", int.Parse(inputPuntaje.text));

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego5/insertar_actualizar_puntaje.php", form))
        {
            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);
        }
    }



}
