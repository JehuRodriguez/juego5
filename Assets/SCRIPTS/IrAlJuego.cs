using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlJuego : MonoBehaviour
{
    public void CargarJuego()
    {
        SceneManager.LoadScene("GameScene");
    }
}
