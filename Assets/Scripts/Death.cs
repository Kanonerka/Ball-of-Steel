using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject Player;
    private Transform Place;
    public Rigidbody rb;
    public int DefaultLives;
    private int Lives;

    void Start()
    {
        Lives = DefaultLives;
        Debug.Log($"Lives = {Lives}");
    }

    private void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Deadly"))
        {
            Lives--;
            Debug.Log($"Lives = {Lives}");
            if (Lives < 0)
            {
                StartCoroutine("Restart");
            }
            else
            {
                StartCoroutine("Respawn");
            }
        }
        if (Object.CompareTag("Life"))
        {
            Lives++;
            Debug.Log($"Lives = {Lives}");
        }
        if (Object.CompareTag("Finish"))
        {
            StartCoroutine("NextScene");
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.5f);

        // Перезагрузка запущенного уровня
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Place = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        rb.MovePosition(Place.position); // Перемещение игрока в начало уровня
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Lives = DefaultLives; // Обновление  жизней

        Debug.Log($"Lives = {Lives}");
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.3f);

        Place = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        rb.MovePosition(Place.position);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.7f);

        Scene currentScene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(Player);
        SceneManager.LoadScene(currentScene.buildIndex + 1); // Загрузка следующей сцены
        
        // Перемещение точки возрождения и игрока в условное начало следующего уровня
        GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>().position = new Vector3(0.0f, 1.5f, -3.0f);
        rb.MovePosition(new Vector3(0.0f, 1.5f, -3.0f));
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
