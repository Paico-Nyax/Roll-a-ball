
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Arraste o Player para este campo no Inspector
    public GameObject player;

    // Distância entre a câmera e o Player
    private Vector3 offset;

    void Start()
    {
        // Verifica se o Player foi atribuído
        if (player != null)
        {
            // Calcula a distância inicial entre a câmera e o Player
            offset = transform.position - player.transform.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Mantém a câmera acompanhando o Player
            transform.position = player.transform.position + offset;
        }
    }
}
