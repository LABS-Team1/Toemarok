using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    [SerializeField]
    private int testHP = 9;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            UIManager.Instance.FindUIComponent<StatBar>("HP_Bar").IncreaseStat(testHP, 10);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            UIManager.Instance.FindUIComponent<StatBar>("HP_Bar").DecreaseStat(testHP, 10);
        }
    }
}
