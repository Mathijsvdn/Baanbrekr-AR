using UnityEngine;
using UnityEngine.UI;

public class UIPanelStep : MonoBehaviour
{
    public GameObject originPanel;
    public GameObject targetPanel;
    public GameObject previousPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupButton("nextButton", targetPanel);
        SetupButton("backButton", previousPanel);
    }

    void SetupButton(string tag, GameObject panelToActivate)
    {
        if (originPanel == null || panelToActivate == null) return;

        foreach (Button btn in originPanel.GetComponentsInChildren<Button>(true))
        {
            if (btn.CompareTag(tag))
            {
                btn.onClick.AddListener(() => SwitchPanel(panelToActivate));
                break;
            }
        }
    }

    void SwitchPanel(GameObject panelToActivate)
    {
        originPanel.SetActive(false);
        panelToActivate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
