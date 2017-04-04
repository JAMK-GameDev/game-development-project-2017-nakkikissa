using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
    public static float normalTime = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            Time.timeScale = normalTime;
            Application.LoadLevel(Application.loadedLevel);

        }

    }

}

