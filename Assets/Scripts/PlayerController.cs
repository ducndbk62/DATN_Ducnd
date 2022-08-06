using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int hP;
    public GameObject playerTank;
    public Renderer tankRenderer, turretRenderer;
    public GameObject tankExplosion;
    public Slider hPBar;

    private int currentHP;
    private GameObject gameController;
    private Color startColor;
    private bool onShieldActive;

    // Start is called before the first frame update
    void Start()
    {
        onShieldActive = false;
        currentHP = hP;
        hPBar.maxValue = hP;
        hPBar.value = currentHP;
        hPBar.minValue = 0;
        gameController = GameObject.FindGameObjectWithTag("GameController");
        startColor = tankRenderer.material.color;
    }

    public void GetHit(int damage)
    {
        if (!onShieldActive)
        {
            StartCoroutine(ChangeGetHitColor());
            currentHP -= damage;
            hPBar.value = currentHP;

            if (currentHP <= 0) Dead();
        }
    }

    public void ActiveShield()
    {
        onShieldActive = true;
        StartCoroutine(ChangeColorOnShield());
    }

    void Dead()
    {
        Instantiate(tankExplosion, gameObject.transform.position, Quaternion.identity);
        Destroy(playerTank);
        gameController.GetComponent<GameController>().EndGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeRendererColor(Color newColor)
    {
        tankRenderer.material.color = newColor;
        turretRenderer.material.color = newColor;
    }

    public IEnumerator ChangeGetHitColor()
    {
        ChangeRendererColor(new Color(0.8f, 0.1f, 0f));
        yield return new WaitForSeconds(0.3f);
        ChangeRendererColor(startColor);
    }

    public IEnumerator ChangeColorOnShield()
    {
        for (int i = 0; i < 9; i++)
        {
            ChangeRendererColor(new Color(.5f, .4f, .1f));
            yield return new WaitForSeconds(0.3f);
            ChangeRendererColor(new Color(.1f, .4f, .5f));
            yield return new WaitForSeconds(0.3f);
            ChangeRendererColor(new Color(.6f, .2f, .8f));
            yield return new WaitForSeconds(0.3f);
            ChangeRendererColor(startColor);
        }
        onShieldActive = false;
    }
}
