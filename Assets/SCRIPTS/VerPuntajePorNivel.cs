using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class VerPuntajePorNivel : MonoBehaviour
{
    public TMP_InputField inputNombre;

    public void AlPresionar()
    {
        StartCoroutine(Consultar());
    }

    IEnumerator Consultar()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", inputNombre.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego5/obtener_puntaje_por_nivel.php", form))
        {
            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);
        }
    }
}
