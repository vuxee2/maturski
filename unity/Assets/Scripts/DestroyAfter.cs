using UnityEngine;
using System.Collections;
public class DestroyAfter : MonoBehaviour
{
    public float destroyDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyWithDelay(destroyDelay));
    }

    private IEnumerator DestroyWithDelay(float destroyDelay)
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
