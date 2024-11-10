using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Image[] itemSlots; // 4���� ItemSlot �̹����� ���� �迭

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject);
        }

        // itemSlots �迭�� ����ִ� ��� ��� �޽��� ǥ��
        if (itemSlots == null || itemSlots.Length == 0)
        {
            Debug.LogWarning("itemSlots �迭�� ��� �ֽ��ϴ�. Inspector���� itemSlots�� ������ �Ҵ��� �ּ���.");
        }
    }

    public void AddItemToSlot(Sprite itemSprite)
    {
        bool itemAdded = false; // �������� �߰��Ǿ����� Ȯ���ϴ� ����

        foreach (var slot in itemSlots)
        {
            if (slot == null)
            {
                Debug.LogWarning("Slot is null.");
                continue; // ������ null�� ��� �ǳʶݴϴ�.
            }

            Debug.Log($"Slot sprite: {slot.sprite}");

            if (slot.sprite == null) // �� ������ ã��
            {
                slot.sprite = itemSprite; // ������ �̹��� �Ҵ�
                itemAdded = true; // �������� �߰����� ǥ��
                break; // ù ��° �� ���Կ��� �Ҵ��ϰ� �Լ� ����
            }
        }

        if (!itemAdded)
        {
            Debug.LogWarning("��� ������ �̹� ���� á���ϴ�.");
            SceneManager.LoadScene("collectTreasure"); // collectTreasure ������ ��ȯ
        }
    }
}
