using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float velocidade = 5.0f;

    private Vector3 direcao;
    private Vector3 startPosition;
    
    GameManager gm;

    void Start()

    {
        startPosition = transform.position;
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;
        gm = GameManager.GetInstance();
    }


    void Update()
    {
        if (gm.gameState == GameManager.GameState.MENU) transform.position = startPosition;
        if (gm.gameState != GameManager.GameState.GAME) return;
        transform.position += direcao * Time.deltaTime * velocidade;

    }

    private void Reset()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = playerPosition + new Vector3(0, 0.5f, 0);

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(2.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;
        gm.vidas--;
        if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("RaqueteLeft"))
        {
            float dirX = Random.Range(-5.0f, 0.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }
        else if (col.gameObject.CompareTag("RaqueteCenter"))
        {
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(direcao.x, dirY).normalized;
        }
        else if (col.gameObject.CompareTag("RaqueteRight"))
        {
            float dirX = Random.Range(0.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }
        else if (col.gameObject.CompareTag("Bloco LR"))
        {
            direcao = new Vector3(-direcao.x, direcao.y);
            gm.pontos++;
        }
        else if (col.gameObject.CompareTag("Bloco UD"))
        {
            direcao = new Vector3(direcao.x, -direcao.y);
            gm.pontos++;
        }
        else if (col.gameObject.CompareTag("Delimitador LR"))
        {
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        else if (col.gameObject.CompareTag("Delimitador UP"))
        {
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        else if (col.gameObject.CompareTag("Delimitador DOWN"))
        {
            Reset();
        }
    }
}
