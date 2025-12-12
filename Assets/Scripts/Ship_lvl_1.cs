using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship_lvl_1 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float acceleration = 300f;

    [Header("Shooting")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Controls")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;

    [Header("Explosion")]
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private AudioClip explosionSound;

    [Header("Audio")]
    public AudioClip shootSound;
    private AudioSource audioSource;

    Vector2 currentVelocity = Vector2.zero;
    const float rawMoveThresholdForBraking = 0.1f;

    private Camera cam;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        shoot.action.started += OnShoot;
    }

    private void Start()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rawMove.magnitude < rawMoveThresholdForBraking)
        {
            currentVelocity *= 0.1f * Time.deltaTime;
        }

        currentVelocity += rawMove * acceleration * Time.deltaTime;

        float linearVelocity = currentVelocity.magnitude;
        linearVelocity = Mathf.Clamp(linearVelocity, 0, maxSpeed);
        currentVelocity = currentVelocity.normalized * linearVelocity;

        transform.Translate(rawMove * maxSpeed * Time.deltaTime);

        if (cam != null)
        {
            Vector3 pos = transform.position;

            // Bordes de pantalla en coordenadas del mundo
            Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

            // Tamaño del sprite
            float halfWidth = spriteRenderer.bounds.extents.x;
            float halfHeight = spriteRenderer.bounds.extents.y;

            // Clamp (límites)
            pos.x = Mathf.Clamp(pos.x, min.x + halfWidth, max.x - halfWidth);
            pos.y = Mathf.Clamp(pos.y, min.y + halfHeight, max.y - halfHeight);

            transform.position = pos;
        }
    }

    private void OnDisable()
    {
        move.action.Disable();
        shoot.action.Disable();

        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;

        shoot.action.started -= OnShoot;
    }

    Vector2 rawMove;
    private void OnMove(InputAction.CallbackContext obj)
    {
        rawMove = obj.ReadValue<Vector2>();
    }

    private void OnShoot(InputAction.CallbackContext obj)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(shootSound);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy_1"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position, 5f);
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
