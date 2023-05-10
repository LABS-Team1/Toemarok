using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    // Font 결정 후 TMP로 나중에 수정

    [SerializeField]
    private Text money;

    public void UpdateMoney(int moneyAmount) => money.text = moneyAmount.ToString();
}
