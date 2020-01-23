using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers
 
public class ColourChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler { // Extends the pointer handlers
 
 public Text text;
 public Color color1;
 public Color color2;
    void Start () 
    {
       text = gameObject.GetComponent<Text> ();
       //text.color = Color.yellow;
       StartCoroutine(Instructions());
       
    }

    IEnumerator Instructions () {
        while(true){
        text.color = color1;
         yield return new WaitForSecondsRealtime(0.9f);
         text.color = color2;
         yield return new WaitForSecondsRealtime(0.9f);
        }
        
         
       
    }

    // Test for enter and exit:
    public void OnPointerEnter(PointerEventData eventData) {
          text.color = Color.gray; // Changes the colour of the text
    }
 
    public void OnPointerExit(PointerEventData eventData) {
          text.color = Color.black; // Changes the colour of the text
    }
}
