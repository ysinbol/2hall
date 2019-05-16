using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    public AudioClip damageClip;
    private AudioSource audio;

    bool isDead;
    bool damaged;
    private float changeRed = 0.0f;
    private float changeGreen = 1.0f;
    private float changeBlue = 0.0f;
    private float changeAlpha = 1.0f;

    private void Awake()
    {
        currentHealth = startingHealth;
        if(healthSlider == null) { Debug.Log("sliderisnull"); }
        healthSlider.fillRect.GetComponent<Image>().color = new Color(changeRed, changeGreen, changeBlue, changeAlpha);
        audio = GetComponent<AudioSource>();
        audio.clip = damageClip;
    }

    //ダメージを受けたら画面が赤く光る
    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            //赤く光ったものを戻す
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed
                * Time.deltaTime);
        }
        damaged = false;

        if (currentHealth == 2)
        {
            healthSlider.fillRect.GetComponent<Image>().color = new Color(1.0f, 0.75f, 0.0f, 1.0f);
        }

        if (currentHealth == 1)
        {
            healthSlider.fillRect.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

        if (currentHealth == 0)
        {
            healthSlider.fillRect.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    //ダメージを受ける関数
    public void TakeDamage(int amount)
    {
        damaged = true;

        audio.Play();
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        Debug.Log(currentHealth);
    }

    void Death()
    {
        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }

}