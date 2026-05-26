using TMPro;
using UnityEngine;

public class SistemaPuntos : MonoBehaviour
{
    public static SistemaPuntos instance;

    [Header("UI")]
    public TextMeshProUGUI textoPuntos;

    private int puntos = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPuntos.text = "Puntos: " + puntos;
    }
}