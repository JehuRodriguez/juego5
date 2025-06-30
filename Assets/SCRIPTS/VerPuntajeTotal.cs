using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class VerPuntajeTotal : MonoBehaviour
{
    public TextMeshProUGUI textoResultado;

    public void AlPresionar()
    {
        StartCoroutine(Consultar());
    }

    IEnumerator Consultar()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/juego5/obtener_puntaje_total.php"))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                textoResultado.text = " Error: " + www.error;
            }
            else
            {
                textoResultado.text = " Puntaje total:\n" + www.downloadHandler.text;
            }
        }
    }

}
