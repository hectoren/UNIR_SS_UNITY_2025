using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 movementSpeed;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;    
    }

    void Update()
    {
        offset = movementSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
