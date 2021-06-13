using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchPrompt : MonoBehaviour
{
    public Text punchPromptShadow;
    public Text punchPromptText;
    // Start is called before the first frame update
    void Start()
    {
        punchPromptShadow.gameObject.SetActive(false);
        punchPromptText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.player.getPunchBool())
        {
            punchPromptShadow.gameObject.SetActive(true);
            punchPromptText.gameObject.SetActive(true);
            TextAnimator.flashTextRed(punchPromptShadow);
        }
        else
        {
            punchPromptShadow.gameObject.SetActive(false);
            punchPromptText.gameObject.SetActive(false);
        }
    }
}
