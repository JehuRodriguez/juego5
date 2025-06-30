using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class VerRankingNivel : MonoBehaviour
{
    public TMP_InputField inputNivel;
    public TextMeshProUGUI textoResultado; 

    public void AlPresionar()
    {
        StartCoroutine(Consultar());
    }

    IEnumerator Consultar()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_nivel", inputNivel.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego5/obtener_ranking_por_nivel.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                textoResultado.text = " Error: " + www.error;
            }
            else
            {
                textoResultado.text = "Ranking para " + inputNivel.text + ":\n" + www.downloadHandler.text;
            }
        }
    }


}
