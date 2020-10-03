using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera camera;

    [SerializeField]
    private float gameTime = 90.0f;
    [SerializeField]
    private bool IsGameStarted;

    [SerializeField]
    private GameObject alarmClockPrefab;

    private Vector3 scaleMin;
    private Vector3 scaleMax;
    [SerializeField]
    private float scaleMultiplicator; // De combien l'objet va grossir

    private float counter = 0f;


    void Start()
    {
        IsGameStarted = true;
        transform.localScale = scaleMin;
        scaleMin = alarmClockPrefab.transform.localScale;
        scaleMax = scaleMin * scaleMultiplicator;
        camera = Camera.main;


    }
    
    void Update()
    {
        counter += Time.deltaTime;

        if(counter > gameTime)
        {
            // Game Over
            camera.GetComponent<Animator>().SetTrigger("Shake");
        }

        StartCoroutine(LerpScale());
    }

    IEnumerator LerpScale()
    {
        for(float t = 0.0f; t < gameTime; t += Time.deltaTime / gameTime)
        {
            alarmClockPrefab.transform.localScale = Vector3.Lerp(scaleMin, scaleMax, t);
            yield return null;
        }
       
    }

}
