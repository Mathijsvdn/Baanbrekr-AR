using UnityEngine;
using UnityEngine.UI;

public class UIPanelHelp : MonoBehaviour
{
    public GameObject originPanel;
    public GameObject helpPanel;

    public void Start()
    {
        if (originPanel == null || helpPanel == null) return;

        foreach (Button btn in originPanel.GetComponentsInChildren<Button>(true))
        {
            if (btn.CompareTag("helpButton"))
            {
                btn.onClick.AddListener(SwitchToHelp);
                break;
            }
        }
    }

    public void SwitchToHelp()
    {
        originPanel.SetActive(false);
        helpPanel.SetActive(true);
    }
}

