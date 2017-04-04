using UnityEngine;
using System.Collections;

public class PickupPowerup : MonoBehaviour
{
    public static float fastTimeScale = 3F;
    public static float normalTimeScale = 1f;
    public static float timeOut = 10f;

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


            other.GetComponent<SimplePlatformController>().StartCoroutine(CountDown());
            Destroy(gameObject);
        }
    }

    public static IEnumerator CountDown()
    {
        Time.timeScale = fastTimeScale;
        yield return new WaitForSeconds(timeOut);
        Time.timeScale = normalTimeScale;
    }
}

