using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField]
    private float fadeTime = 0.5f;

    [SerializeField]
    private List<CanvasGroup> uiObject = new List<CanvasGroup>(); // �̸� �־���� UI �����յ�
    private Dictionary<string, CanvasGroup> uiPrefabs = new Dictionary<string, CanvasGroup>();

    // UI�� Show & Hide �Ǵ� Component�� ������ �� �̸��� �ν����ͻ� �ش� ������Ʈ �̸��� �־��ָ� �˴ϴ�.

    protected override void Awake()
    {
        dontDestroyOnLoad = true;
        base.Awake();
    }

    private void Start()
    {
        foreach (CanvasGroup ui in uiObject)
        {
            AddUIPrefab(ui.name, ui);
        }
    }

    public void AddUIPrefab(string uiName, CanvasGroup ui)
    {
        uiPrefabs.Add(uiName, ui);
    }

    public void RemoveUIPrefab(string uiName)
    {
        uiPrefabs.Remove(uiName);
    }

    public T FindUIComponent<T>(string uiName) where T : Component
    {
        if (uiPrefabs.ContainsKey(uiName))
        {
            CanvasGroup uiObject = uiPrefabs[uiName];

            if (uiObject != null && uiObject.TryGetComponent(out T ui))
            {
                return ui;
            }

            Debug.LogError($"�ش� Key�� UI ������Ʈ�� {nameof(T)} ������Ʈ�� �����ϰ� ���� �ʽ��ϴ�.");
            return null;
        }
        else
        {
            Debug.LogError("�ش� Key�� UI ������Ʈ�� �������� �ʽ��ϴ�.");
            return null;
        }
    }

    public void ShowUIPrefab(string uiName)
    {
        if (uiPrefabs.ContainsKey(uiName))
        {
            CanvasGroup ui = uiPrefabs[uiName];

            if (ui != null)
            {
                if (ui.gameObject.activeSelf == false)
                {
                    ui.gameObject.SetActive(true);
                }

                StartCoroutine(FadeIn(ui));
            }
        }
        else
        {
            Debug.LogError("�ش� Key�� UI ������Ʈ�� �������� �ʽ��ϴ�.");
        }
    }

    public void HideUIPrefab(string uiName)
    {
        if (uiPrefabs.ContainsKey(uiName))
        {
            CanvasGroup ui = uiPrefabs[uiName];

            if (ui != null && ui.alpha == 1)
            {
                if (ui.gameObject.activeSelf == true)
                {
                    ui.gameObject.SetActive(false);
                }

                ui.alpha = 0;
            }
        }
        else
        {
            Debug.LogError("�ش� Key�� UI ������Ʈ�� �������� �ʽ��ϴ�.");
        }
    }

    public void SetPositionUI(string uiName, Vector2 position)
    {
        if (uiPrefabs.ContainsKey(uiName))
        {
            GameObject ui = uiPrefabs[uiName].gameObject;
            ui.transform.position = position;
        }
        else
        {
            Debug.LogError("�ش� Key�� UI ������Ʈ�� �������� �ʽ��ϴ�.");
        }
    }

    private IEnumerator FadeIn(CanvasGroup ui)
    {
        if (ui == null)
        {
            ui = gameObject.GetComponent<CanvasGroup>();
        }

        while (ui.alpha < 1f)
        {
            ui.alpha += Time.deltaTime / fadeTime;
            ui.alpha = 1;
            yield return null;
        }
    }
}
