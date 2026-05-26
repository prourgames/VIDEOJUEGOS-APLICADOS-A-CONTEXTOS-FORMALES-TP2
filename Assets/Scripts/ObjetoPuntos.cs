using UnityEngine;

public class ObjetoPuntos : MonoBehaviour
{
    [Header("Puntos")]
    public int puntos = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SistemaPuntos.instance.SumarPuntos(puntos);

            Destroy(gameObject);
        }
    }
}