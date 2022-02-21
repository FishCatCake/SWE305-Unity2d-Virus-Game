using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillUI : MonoBehaviour
{
    public int startPillNumber;

    public Text pillNumber;
    public static int currentPillNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        currentPillNumber = startPillNumber;
    }

    // Update is called once per frame
    void Update()
    {
        pillNumber.text = currentPillNumber.ToString();
    }
}
