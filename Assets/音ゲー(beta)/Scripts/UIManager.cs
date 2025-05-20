using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public bool init;
    public bool flgFade;
    Color color;

    public Image image;
    public TextMeshProUGUI _hispeedText;
    public TextMeshProUGUI _offsetText;

    // Start is called before the first frame update
    void Start()
    {
        color = image.GetComponent<Image>().color;
        color.r = 0.0f;
        color.g = 0.0f;
        color.b = 0.0f;
        color.a = 1.0f;
        image.GetComponent<Image>().color = color;

        init = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (init == true)
        {
            color.a -= 0.1f;
            image.GetComponent<Image>().color = color;

            //暗くなった
            if (color.a <= 0)
            {
                init = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FadeOn();
        }

        //条件を満たしたらフェードアウト
        if (flgFade == true)
        {
            color.a += 0.1f;
            image.GetComponent<Image>().color = color;

            //暗くなった
            if (color.a >= 1)
            {
                flgFade = false;
                SceneManager.LoadScene(0);
            }
        }
    }

    public void FadeOn()
    {
        flgFade = true;
    }

    public void TextUpdate_Speed(float speed)
    {
        _hispeedText.text = "HiSpeed : " + speed.ToString();
    }

    public void TextUpdate_Offset(float offset)
    {
        _offsetText.text = "Offset : " + offset.ToString("F2");
    }
}
