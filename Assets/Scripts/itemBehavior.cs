using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehavior : MonoBehaviour
{
    [SerializeField] float flashWaitTime = 0.25f;
    [SerializeField] float flashTime = 8f;
    [SerializeField] float timeBeforeFlash = 8f;
    [SerializeField] bool isFlashing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlashing)
        {
            StartCoroutine(Flash());
        }

    }
    IEnumerator Flash()
    {
        yield return new WaitForSeconds(0.25f);
    }
    IEnumerator startItemCountdown()
    {
        yield return new WaitForSeconds(timeBeforeFlash);

        yield return new WaitForSeconds(flashTime);
    }
}
