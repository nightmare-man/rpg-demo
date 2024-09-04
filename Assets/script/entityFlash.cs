using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityFlash : MonoBehaviour
{
    private SpriteRenderer sr;
    private Material origin;
    [SerializeField] Material flashMaterial;
    [SerializeField] float flashTime;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        origin = sr.material;
    }
    private IEnumerator fx()
    {
        sr.material = flashMaterial;
        yield return new WaitForSeconds(flashTime);
        sr.material = origin;
    }
    private void blinkColor() {
        if (sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }
    private void cancelBlink()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
