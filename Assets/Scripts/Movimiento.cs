using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;

    [Header("Limites")]
    public float limiteIzquierdo = -5f;
    public float limiteDerecho = 5f;

    [Header("Dash")]
    public float fuerzaDash = 15f;
    public float duracionDash = 0.5f;
    public float cooldownDash = 1f;

    [Header("Audio")]
    public AudioClip sonidoDash;

    private AudioSource audioSource;

    private bool haciendoDash = false;
    private float velocidadDashActual;
    private float tiempoDash;
    private float ultimoDash;

    private int direccionDash = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (!haciendoDash && Time.time >= ultimoDash + cooldownDash)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
            {
                IniciarDash(-1);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
            {
                IniciarDash(1);
            }
        }

        if (!haciendoDash)
        {
            float movimiento = 0f;

            if (Input.GetKey(KeyCode.A))
            {
                movimiento = -1f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                movimiento = 1f;
            }

            transform.Translate(Vector3.right * movimiento * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * direccionDash * velocidadDashActual * Time.deltaTime);

            velocidadDashActual = Mathf.Lerp(velocidadDashActual, 0f, 8f * Time.deltaTime);

            tiempoDash -= Time.deltaTime;

            if (tiempoDash <= 0f)
            {
                haciendoDash = false;
            }
        }

        Vector3 posicion = transform.position;

        posicion.x = Mathf.Clamp(posicion.x, limiteIzquierdo, limiteDerecho);

        transform.position = posicion;
    }

    void IniciarDash(int direccion)
    {
        haciendoDash = true;

        direccionDash = direccion;

        velocidadDashActual = fuerzaDash;

        tiempoDash = duracionDash;

        ultimoDash = Time.time;

        if (sonidoDash != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoDash);
        }
    }
}