using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour { 

    private GameObject menu;
    private GameObject imageOption;
    private GameObject woundType;
    private GameObject gunshotOption;
    private GameObject slashOption;
    private GameObject stabOption;
    private GameObject confirmMenu;
    private GameObject selectedWoundView;
    private Button image1;
    private Button image2;
    private Button image3;
    private Button image4;
    private Button image5;
    private Button gunshot;
    private Button slash;
    private Button stab;
    private Button gunshot1;
    private Button gunshot2;
    private Button slash1;
    private Button slash2;
    private Button stab1;
    private Button stab2;
    private Button confirmAndExit;
    private Button confirmAndNext;

    private ColorBlock onClickedHighlight;
    private Color green;
    private Color blue;
    private Color white;

    private GameObject imageSelected = null;
    private string woundSelected = null;

    private void Start()
    {
        menu = GameObject.Find("Menu").gameObject;
        imageOption = menu.transform.Find("ImageOption").gameObject;
        woundType = menu.transform.Find("WoundType").gameObject;
        gunshotOption = menu.transform.Find("GunshotOption").gameObject;
        slashOption = menu.transform.Find("SlashOption").gameObject;
        stabOption = menu.transform.Find("StabOption").gameObject;
        confirmMenu = menu.transform.Find("ConfirmMenu").gameObject;
        selectedWoundView = confirmMenu.transform.Find("SelectedWoundView").gameObject;
        image1 = imageOption.transform.Find("Image1").GetComponent<Button>();
        image2 = imageOption.transform.Find("Image2").GetComponent<Button>();
        image3 = imageOption.transform.Find("Image3").GetComponent<Button>();
        image4 = imageOption.transform.Find("Image4").GetComponent<Button>();
        image5 = imageOption.transform.Find("Image5").GetComponent<Button>();
        gunshot = woundType.transform.Find("Gunshot").GetComponent<Button>();
        slash = woundType.transform.Find("Slash").GetComponent<Button>();
        stab = woundType.transform.Find("Stab").GetComponent<Button>();
        gunshot1 = gunshotOption.transform.Find("Gunshot1").GetComponent<Button>();
        gunshot2 = gunshotOption.transform.Find("Gunshot2").GetComponent<Button>();
        slash1 = slashOption.transform.Find("Slash1").GetComponent<Button>();
        slash2 = slashOption.transform.Find("Slash2").GetComponent<Button>();
        stab1 = stabOption.transform.Find("Stab1").GetComponent<Button>();
        stab2 = stabOption.transform.Find("Stab2").GetComponent<Button>();
        confirmAndExit = confirmMenu.transform.Find("ConfirmAndExit").GetComponent<Button>();
        confirmAndNext = confirmMenu.transform.Find("ConfirmAndNext").GetComponent<Button>();

        green = new Color();
        ColorUtility.TryParseHtmlString("#7ADFBBFF", out green);
        blue = new Color();
        ColorUtility.TryParseHtmlString("#6BC8E6FF", out blue);
        white = new Color();
        ColorUtility.TryParseHtmlString("#FFFFFFFF", out white);

        RectTransform rectMenu = (RectTransform)menu.transform;
        Vector2 size = rectMenu.sizeDelta;
        BoxCollider collider = menu.GetComponent<BoxCollider>();
        collider.center = new Vector3(rectMenu.pivot.x, rectMenu.pivot.y, rectMenu.position.z);
        collider.size = size;
    }


    public void openImageOption()
    {
        menu.transform.Find("MainMenu").gameObject.SetActive(false);
        imageOption.SetActive(true);
    }

    public void openWoundType(Button button)
    {
        clearOptionPanels();
        confirmMenu.SetActive(false);
        imageOptionColorReset();
        woundTypeColorReset();
        woundOptionColorReset();
        woundType.SetActive(true);
        onClickedHighlight = button.colors;
        onClickedHighlight.highlightedColor = green;
        onClickedHighlight.normalColor = green;
        button.colors = onClickedHighlight;
        string name = button.name;
        string img = name.Substring(0, 5) + "Target" + name.Substring(5, name.Length - 5);
        imageSelected = GameObject.Find(img);
    }

    public void openWoundOption(Button button)
    {
        clearOptionPanels();
        woundTypeColorReset();
        woundOptionColorReset();
        menu.transform.Find(button.name + "Option").gameObject.SetActive(true);
        onClickedHighlight = button.colors;
        onClickedHighlight.highlightedColor = green;
        onClickedHighlight.normalColor = green;
        button.colors = onClickedHighlight;
    }

    public void selectWound(Button button)
    {
        clearSelected();
        woundOptionColorReset();
        onClickedHighlight = button.colors;
        onClickedHighlight.highlightedColor = green;
        onClickedHighlight.normalColor = green;
        button.colors = onClickedHighlight;
        confirmMenu.SetActive(true);
        selectedWoundView.SetActive(true);
        selectedWoundView.transform.Find(button.name).gameObject.SetActive(true);
        woundSelected = button.name;
    }

    private void clearOptionPanels()
    {
        gunshotOption.gameObject.SetActive(false);
        slashOption.gameObject.SetActive(false);
        stabOption.gameObject.SetActive(false);
    }

    private void imageOptionColorReset()
    {
        onClickedHighlight = image1.colors;
        onClickedHighlight.highlightedColor = blue;
        onClickedHighlight.normalColor = white;

        image1.colors = onClickedHighlight;
        image2.colors = onClickedHighlight;
        image3.colors = onClickedHighlight;
        image4.colors = onClickedHighlight;
        image5.colors = onClickedHighlight;
    }

    private void woundTypeColorReset()
    {
        onClickedHighlight = gunshot.colors;
        onClickedHighlight.highlightedColor = blue;
        onClickedHighlight.normalColor = white;

        gunshot.colors = onClickedHighlight;
        slash.colors = onClickedHighlight;
        stab.colors = onClickedHighlight;
    }

    private void woundOptionColorReset()
    {
        onClickedHighlight = gunshot1.colors;
        onClickedHighlight.highlightedColor = blue;
        onClickedHighlight.normalColor = white;

        gunshot1.colors = onClickedHighlight;
        gunshot2.colors = onClickedHighlight;
        slash1.colors = onClickedHighlight;
        slash2.colors = onClickedHighlight;
        stab1.colors = onClickedHighlight;
        stab2.colors = onClickedHighlight;
    }

    private void clearSelected()
    {
        selectedWoundView.transform.Find("Gunshot1").gameObject.SetActive(false);
        selectedWoundView.transform.Find("Gunshot2").gameObject.SetActive(false);
        selectedWoundView.transform.Find("Stab1").gameObject.SetActive(false);
        selectedWoundView.transform.Find("Stab2").gameObject.SetActive(false);
        selectedWoundView.transform.Find("Slash1").gameObject.SetActive(false);
        selectedWoundView.transform.Find("Slash2").gameObject.SetActive(false);
    }

    public void confirmExit()
    {
        if (imageSelected != null && woundSelected != null)
        {
            SetConfigCheck(imageSelected);
            clearWoundsOfTarget(imageSelected);
            imageSelected.transform.Find(woundSelected).gameObject.SetActive(true);
            clearSelected();
            imageOptionColorReset();
            woundTypeColorReset();
            woundOptionColorReset();
            clearOptionPanels();
            imageOption.SetActive(false);
            woundType.SetActive(false);
            confirmMenu.SetActive(false);
            imageSelected = null;
            woundSelected = null;
        }
    }

    public void confirmNext()
    {
        if (imageSelected != null && woundSelected != null)
        {
            SetConfigCheck(imageSelected);
            clearWoundsOfTarget(imageSelected);
            imageSelected.transform.Find(woundSelected).gameObject.SetActive(true);
            clearSelected();
            imageOptionColorReset();
            woundTypeColorReset();
            woundOptionColorReset();
            clearOptionPanels();
            woundType.SetActive(false);
            confirmMenu.SetActive(false);
            imageSelected = null;
            woundSelected = null;
        }
    }

    private void clearWoundsOfTarget(GameObject target)
    {
        target.transform.Find("Gunshot1").gameObject.SetActive(false);
        target.transform.Find("Gunshot2").gameObject.SetActive(false);
        target.transform.Find("Stab1").gameObject.SetActive(false);
        target.transform.Find("Stab2").gameObject.SetActive(false);
        target.transform.Find("Slash1").gameObject.SetActive(false);
        target.transform.Find("Slash2").gameObject.SetActive(false);
    }

    public void resetImage(Button button)
    {
        string parentName = button.transform.parent.gameObject.name;
        GameObject image = GameObject.Find("ImageTarget" + parentName.Substring(5, name.Length - 5));
        clearWoundsOfTarget(image);
        button.gameObject.SetActive(false);
    }

    private void SetConfigCheck(GameObject img)
    {
        string image = "Image" + img.name.Substring(11, img.name.Length - 11);
        imageOption.transform.Find(image).transform.Find("ConfigCheck").gameObject.SetActive(true);
    }
}
