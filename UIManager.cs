using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Variables
    public Image keyShift;
    public Image keyCtrl;
    public Image keyQ;
    public Image keyE;
    public Image keyS;
    public Image keyW;
    public Image keyA;
    public Image keyD;

    private Color defaultColor = new(1f, 1f, 1f); // Blanc (RGB 255, 255, 255)
    private Color pressedColor = new Color(150f / 255f, 150f / 255f, 150f / 255f); // Gris (RGB 150, 150, 150)



    // Update is called once per frame
    void Update()
    {
        UpdateIcons();
    }

    public void UpdateIcons()
    {
        // Touche W
        if (Input.GetKey(KeyCode.W))
        {
            keyW.color = pressedColor;
        }
        else
        {
            keyW.color = defaultColor;
        }

        // Touche A
        if (Input.GetKey(KeyCode.A))
        {
            keyA.color = pressedColor;
        }
        else
        {
            keyA.color = defaultColor;
        }

        // Touche S
        if (Input.GetKey(KeyCode.S))
        {
            keyS.color = pressedColor;
        }
        else
        {
            keyS.color = defaultColor;
        }

        // Touche D
        if (Input.GetKey(KeyCode.D))
        {
            keyD.color = pressedColor;
        }
        else
        {
            keyD.color = defaultColor;
        }

        // Touche Q
        if (Input.GetKey(KeyCode.Q))
        {
            keyQ.color = pressedColor;
        }
        else
        {
            keyQ.color = defaultColor;
        }

        // Touche E
        if (Input.GetKey(KeyCode.E))
        {
            keyE.color = pressedColor;
        }
        else
        {
            keyE.color = defaultColor;
        }

        // Touche Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            keyShift.color = pressedColor;
        }
        else
        {
            keyShift.color = defaultColor;
        }

        // Touche Ctrl
        if (Input.GetKey(KeyCode.LeftControl))
        {
            keyCtrl.color = pressedColor;
        }
        else
        {
            keyCtrl.color = defaultColor;
        }
    }
}
