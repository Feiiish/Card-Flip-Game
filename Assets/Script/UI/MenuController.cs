using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// Menu controller: layout dropdown (2×3, 3×4, 4×4) and Start Game.
/// Assign GameTracker and (optionally) a Dropdown; if Dropdown is missing, one is created at runtime.
/// </summary>
public class MenuController : MonoBehaviour
{
    [SerializeField] GameTracker gameTracker;
    [SerializeField] Dropdown layoutDropdown;
    [SerializeField] RectTransform dropdownParent;

    static readonly string[] LayoutLabels = { "2×3 (6 cards)", "3×4 (12 cards)", "4×4 (16 cards)" };

    void Start()
    {
        if (gameTracker == null)
        {
            Debug.LogError("MenuController: Assign GameTracker in the Inspector.");
            return;
        }

        if (layoutDropdown == null)
            layoutDropdown = CreateDropdown();

        if (layoutDropdown != null)
        {
            layoutDropdown.ClearOptions();
            layoutDropdown.AddOptions(new List<string>(LayoutLabels));
            layoutDropdown.value = (int)gameTracker.gameSet;
            layoutDropdown.RefreshShownValue();
            layoutDropdown.onValueChanged.RemoveAllListeners();
            layoutDropdown.onValueChanged.AddListener(OnLayoutChanged);
        }
    }

    void OnLayoutChanged(int index)
    {
        if (gameTracker != null && index >= 0 && index <= 2)
            gameTracker.gameSet = (GameSet)index;
    }

    public void StartGame()
    {
        if (layoutDropdown != null && gameTracker != null)
            gameTracker.gameSet = (GameSet)Mathf.Clamp(layoutDropdown.value, 0, 2);
        SceneManager.LoadScene("Game");
    }

    Dropdown CreateDropdown()
    {
        RectTransform parent = dropdownParent != null ? dropdownParent : GetComponent<RectTransform>();
        if (parent == null)
        {
            var canvas = GetComponentInParent<Canvas>();
            if (canvas != null) parent = canvas.GetComponent<RectTransform>();
        }
        if (parent == null)
        {
            Debug.LogError("MenuController: No RectTransform found for dropdown parent.");
            return null;
        }

        GameObject go = new GameObject("LayoutDropdown");
        go.transform.SetParent(parent, false);

        RectTransform rt = go.AddComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.sizeDelta = new Vector2(200, 30);
        rt.anchoredPosition = new Vector2(0, 60);

        var bgImage = go.AddComponent<Image>();
        bgImage.color = new Color(0.22f, 0.22f, 0.22f);
        go.AddComponent<CanvasGroup>();

        Dropdown drop = go.AddComponent<Dropdown>();

        GameObject labelGo = new GameObject("Label");
        labelGo.transform.SetParent(go.transform, false);
        var labelRt = labelGo.AddComponent<RectTransform>();
        labelRt.anchorMin = Vector2.zero;
        labelRt.anchorMax = Vector2.one;
        labelRt.offsetMin = new Vector2(10, 2);
        labelRt.offsetMax = new Vector2(-25, -2);
        var labelText = labelGo.AddComponent<Text>();
        labelText.text = LayoutLabels[0];
        labelText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        labelText.fontSize = 14;
        drop.captionText = labelText;

        GameObject arrowGo = new GameObject("Arrow");
        arrowGo.transform.SetParent(go.transform, false);
        var arrowRt = arrowGo.AddComponent<RectTransform>();
        arrowRt.anchorMin = new Vector2(1, 0.5f);
        arrowRt.anchorMax = new Vector2(1, 0.5f);
        arrowRt.pivot = new Vector2(1, 0.5f);
        arrowRt.anchoredPosition = new Vector2(-10, 0);
        arrowRt.sizeDelta = new Vector2(20, 20);
        var arrowImage = arrowGo.AddComponent<Image>();
        arrowImage.color = Color.black;

        GameObject templateGo = new GameObject("Template");
        templateGo.transform.SetParent(go.transform, false);
        var templateRt = templateGo.AddComponent<RectTransform>();
        templateRt.anchorMin = new Vector2(0, 0);
        templateRt.anchorMax = new Vector2(1, 0);
        templateRt.pivot = new Vector2(0.5f, 1);
        templateRt.anchoredPosition = new Vector2(0, 2);
        templateRt.sizeDelta = new Vector2(0, 150);
        var templateImage = templateGo.AddComponent<Image>();
        templateImage.color = new Color(0.2f, 0.2f, 0.2f);
        var templateScroll = templateGo.AddComponent<ScrollRect>();
        templateGo.AddComponent<RectMask2D>();
        templateGo.SetActive(false);
        drop.template = templateRt;

        GameObject viewportGo = new GameObject("Viewport");
        viewportGo.transform.SetParent(templateGo.transform, false);
        var viewportRt = viewportGo.AddComponent<RectTransform>();
        viewportRt.anchorMin = Vector2.zero;
        viewportRt.anchorMax = Vector2.one;
        viewportRt.offsetMin = Vector2.zero;
        viewportRt.offsetMax = Vector2.zero;
        viewportGo.AddComponent<Image>();
        viewportGo.AddComponent<Mask>().showMaskGraphic = false;

        GameObject contentGo = new GameObject("Content");
        contentGo.transform.SetParent(viewportGo.transform, false);
        var contentRt = contentGo.AddComponent<RectTransform>();
        contentRt.anchorMin = new Vector2(0, 1);
        contentRt.anchorMax = new Vector2(1, 1);
        contentRt.pivot = new Vector2(0.5f, 1);
        contentRt.sizeDelta = new Vector2(0, 28);
        templateScroll.content = contentRt;

        GameObject itemGo = new GameObject("Item");
        itemGo.transform.SetParent(contentGo.transform, false);
        var itemRt = itemGo.AddComponent<RectTransform>();
        itemRt.anchorMin = new Vector2(0, 0.5f);
        itemRt.anchorMax = new Vector2(1, 0.5f);
        itemRt.sizeDelta = new Vector2(0, 25);
        var itemBg = itemGo.AddComponent<Image>();
        itemBg.color = new Color(0.3f, 0.3f, 0.3f);
        var itemToggle = itemGo.AddComponent<Toggle>();

        GameObject itemLabelGo = new GameObject("Item Label");
        itemLabelGo.transform.SetParent(itemGo.transform, false);
        var itemLabelRt = itemLabelGo.AddComponent<RectTransform>();
        itemLabelRt.anchorMin = Vector2.zero;
        itemLabelRt.anchorMax = Vector2.one;
        itemLabelRt.offsetMin = new Vector2(10, 2);
        itemLabelRt.offsetMax = new Vector2(-10, -2);
        var itemLabelText = itemLabelGo.AddComponent<Text>();
        itemLabelText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        itemLabelText.fontSize = 14;
        itemToggle.targetGraphic = itemBg;
        itemToggle.graphic = null;
        itemToggle.isOn = true;
        drop.itemText = itemLabelText;

        templateScroll.viewport = viewportRt;
        templateScroll.horizontal = false;
        templateScroll.vertical = true;
        templateScroll.movementType = ScrollRect.MovementType.Clamped;
        templateScroll.scrollSensitivity = 10;

        return drop;
    }
}
