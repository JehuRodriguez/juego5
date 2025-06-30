using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class VerPuntajePorNivel : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TextMeshProUGUI textoResultado;

    public void AlPresionar()
    {
        StartCoroutine(Consultar());
    }

    IEnumerator Consultar()
    {
        string nombre = inputNombre.text;

        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", inputNombre.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego5/obtener_puntaje_por_nivel.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error al consultar: " + www.error);
                textoResultado.text = " Error: " + www.error;
            }
            else
            {
                string respuesta = www.downloadHandler.text;
                Debug.Log("Puntajes:\n" + respuesta);
                textoResultado.text = " Puntajes de " + nombre + ":\n" + respuesta;
            }
        }
    }
}
