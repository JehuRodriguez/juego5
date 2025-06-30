using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VerPuntajeTotal : MonoBehaviour
{
    public void AlPresionar()
    {
        StartCoroutine(Consultar());
    }

    IEnumerator Consultar()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/juego5/obtener_puntaje_total.php"))
        {
            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);
        }
    }

}
