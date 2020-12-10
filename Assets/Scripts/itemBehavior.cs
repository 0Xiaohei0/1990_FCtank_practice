using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// items disappear after a certain time, triggered when picked up
public class itemBehavior : MonoBehaviour
{
    [SerializeField] float flashWaitTime = 0.75f;
    [SerializeField] float flashTime = 8f;
    [SerializeField] float timeBeforeFlash = 8f;
    [SerializeField] bool isFlashing = false;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        StartCoroutine(startItemCountdown());
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
        if (sprite.enabled == false)
            sprite.enabled = true;
        else if(sprite.enabled == true)
            sprite.enabled = false;
        yield return new WaitForSeconds(flashWaitTime);
    }
    IEnumerator startItemCountdown()
    {
        yield return new WaitForSeconds(timeBeforeFlash);
        isFlashing = true;
        yield return new WaitForSeconds(flashTime);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
