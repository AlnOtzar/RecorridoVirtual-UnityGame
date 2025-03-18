using UnityEngine;

public class MovJugador : MonoBehaviour
{
    Transform cam; // Cámara
    CharacterController control; // Controlador del jugador

    public float speedCam = 100f; // Velocidad de la cámara
    public float camRotation = 0f; // Rotación de la cámara
    public float playerSpeed = 5f; // Velocidad del jugador

    public float fuerzaSalto = 5f; // Fuerza del salto
    public float gravityForce = -9.81f; // Gravedad
    private float gravityMove = 0f; // Movimiento vertical del jugador

    private void Start()
    {
        control = GetComponent<CharacterController>(); // Obtener el CharacterController
        cam = transform.GetChild(0).GetComponent<Transform>(); // Obtener la cámara

        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor
    }

    private void Update()
    {
        // Movimiento de la cámara con el mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * speedCam * Time.deltaTime); // Rotación horizontal

        camRotation -= mouseY * speedCam * Time.deltaTime;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f); // Limitar la rotación de la cámara
        cam.localRotation = Quaternion.Euler(camRotation, 0f, 0f);

        // Movimiento del jugador con WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * moveX + transform.forward * moveZ) * playerSpeed;

        // Aplicar gravedad
        if (control.isGrounded)
        {
            if (gravityMove < 0) gravityMove = -2f; // Evita que la gravedad se acumule cuando toca el suelo
        }
        else
        {
            gravityMove += gravityForce * Time.deltaTime; // Aplica gravedad continuamente cuando está en el aire
        }

        // Aplicar salto
        if (Input.GetKeyDown(KeyCode.Space) && control.isGrounded)
        {
            gravityMove = fuerzaSalto; // Salto
        }

        // Aplicar movimiento y gravedad
        Vector3 finalMove = movement * Time.deltaTime;
        finalMove.y = gravityMove * Time.deltaTime;
        control.Move(finalMove);
    }
}
