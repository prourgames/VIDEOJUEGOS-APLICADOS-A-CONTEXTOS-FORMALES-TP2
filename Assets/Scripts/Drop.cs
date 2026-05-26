using UnityEngine;

public class Drop : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] prefabs;

    [Header("Spawn")]
    public BoxCollider zonaSpawn;
    public float tiempoEntreSpawns = 2f;
    public float alturaSpawn = 10f;

    private float temporizador;

    void Update()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= tiempoEntreSpawns)
        {
            SpawnObjeto();
            temporizador = 0f;
        }
    }

    void SpawnObjeto()
    {
        if (prefabs.Length == 0 || zonaSpawn == null)
            return;

        GameObject prefabElegido = prefabs[Random.Range(0, prefabs.Length)];

        Bounds bounds = zonaSpawn.bounds;

        Vector3 posicionSpawn = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            bounds.max.y + alturaSpawn,
            Random.Range(bounds.min.z, bounds.max.z)
        );

        Instantiate(prefabElegido, posicionSpawn, Quaternion.identity);
    }
}