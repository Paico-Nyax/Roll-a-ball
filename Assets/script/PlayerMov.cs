
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimentação")]
    public float speed = 10f;

    [Header("Pontuação")]
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();

        // Esconde o texto de vitória no início
        if (winTextObject != null)
        {
            winTextObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(
            moveHorizontal,
            0.0f,
            moveVertical
        );

        rb.AddForce(movement * speed);
    }

    // Detecta a coleta de itens
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count += 1;

            SetCountText();
        }

        if (other.gameObject.CompareTag("MorePoints"))
        {
            other.gameObject.SetActive(false);

            count += 3;

            SetCountText();
        }
    }

    // Atualiza a pontuação e verifica a vitória
    void SetCountText()
    {
        if (countText != null)
        {
            countText.text = "Pontos: " + count.ToString();
        }

        if (count >= 20)
        {
            if (winTextObject != null)
            {
                winTextObject.SetActive(true);
            }
        }
    }
}
