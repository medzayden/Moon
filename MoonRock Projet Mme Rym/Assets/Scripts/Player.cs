using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorRed;
    public Color colorPurple;
    public Color colorGreen;
    public Color colorBlue;
    public Color colorWihite;

    public string sceneToLoad;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;
    
    void Start()
    {
        SetRandomColor();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = Vector2.up * jumpForce;
            jumpSoundEffect.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AttributeChanger")
        {
            collectSoundEffect.Play();
            SetRandomColor();
            Destroy(col.gameObject);
            return;
            
        }

        if (col.tag != currentColor && col.tag != "White")
        {
            SceneManager.LoadScene(sceneToLoad);
            

        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Fire";
                sr.color = colorRed;
                break;
            case 1:
                currentColor = "Wind";
                sr.color = colorPurple;
                break;
            case 2:
                currentColor = "Earth";
                sr.color = colorGreen;
                break;
            case 3:
                currentColor = "Water";
                sr.color = colorBlue;
                break;
        }
    }
}