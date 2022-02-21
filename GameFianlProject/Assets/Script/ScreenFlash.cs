using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image img;

    public float time;

    public Color falshColor;

    private Color defautColor;
    
    // Start is called before the first frame update
    void Start()
    {
        defautColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        img.color = falshColor;
        yield return new WaitForSeconds(time);
        img.color = defautColor;
        
    }
    
}
