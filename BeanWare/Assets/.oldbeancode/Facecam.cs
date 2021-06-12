using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Facecam : MonoBehaviour {
    public Player player;
    public Image myImage;
    public Sprite imageStage1;
    public Sprite imageStage2;
    public Sprite imageStage3;
    public Sprite imageStage4;


    private void Start() {
        myImage = GetComponent<Image>();
    }
    public void UpdateFacecam(int powerState) { 

        // Idea - update the facecam depending on the status of the crazy bar
        // change the state of the facecam, scaling with power level
        // switch case for changing dynamically between assets?

       switch (powerState)
       {
            case 1:
                SetStage1();
                break;
            case 2:
                SetStage2();
                break;
            case 3:
                SetStage3();
                break;
            case 4:
                SetStage4();
                break;
           default:
                break;
       }      
    }

    public void SetStage1() {
        myImage.sprite = imageStage1;
    }
    public void SetStage2() {
        myImage.sprite = imageStage2;
    }
    public void SetStage3() {
        myImage.sprite = imageStage3;
    }
    public void SetStage4() {
        myImage.sprite = imageStage4
;
    }

}
