using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    // Font ���� �� TMP�� ���߿� ����

    [SerializeField]
    private Text money;

    public void UpdateMoney(int moneyAmount) => money.text = moneyAmount.ToString();
}
