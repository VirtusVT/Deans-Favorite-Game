using UnityEngine;
using UnityEngine.UIElements;

public class InGameUIController : MonoBehaviour
{
    [SerializeField] private UIDocument inGameDocument;
    private VisualElement rootElement;
    void Start()
    {
        rootElement = inGameDocument.rootVisualElement;
        rootElement.Q<Button>("ShopButton").clicked += ShowShop;
    }

    public void ShowShop()
    {
        if (rootElement.Q<Button>("TurretA").style.display == DisplayStyle.Flex)
        {
            rootElement.Q<Button>("TurretA").style.display = DisplayStyle.None;
        }
        else
        {
            rootElement.Q<Button>("TurretA").style.display = DisplayStyle.Flex;
        }
    }
}
