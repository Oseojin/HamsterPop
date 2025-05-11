using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private GameObject seedPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private InGameUIManager inGameUIManager;
    private GameObject currSeed;
    private GameObject currHamster;
    private bool isHold = false;
    private Vector2 mousePosition;
    
    void Start()
    {
        isHold = false;
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        DetectClickedObject();
        if(isHold)
        {
            currSeed.GetComponent<SunflowerSeed>().FollowMouse(mousePosition);
        }
    }

    private void DetectClickedObject()
    {
        // ���콺�ٿ� => �عٶ�⾾ �׸��̸� �عٶ�� �� ���, �ܽ����̸� ����
        // ���콺�� => �ܽ����̸� �ܽ��� �� ��� ����, �ܽ��Ͱ� �ƴϸ� ���
        // �Ϲ� => ���� �� ���¿��� �ܽ��� ���� �ö󰡸� �ܽ��� ��� ����
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (Input.GetMouseButtonDown(0) && !isHold)
        {
            if (hit.collider == null)
            {
                return;
            }
            GameObject clickObject = hit.collider.gameObject;
            if (clickObject.CompareTag("SeedBowl"))
            {
                isHold = true;
                currSeed = Instantiate(seedPrefab);
            }
            else if(clickObject.CompareTag("Hamster"))
            {
                inGameUIManager.SelectHamster(clickObject.GetComponent<Hamster>().data);
                Debug.Log("�ܽ��� ����");
            }
        }
        else if (Input.GetMouseButtonUp(0) && isHold)
        {
            Destroy(currSeed);
            isHold = false;
            if (hit.collider == null) return;
            GameObject clickObject = hit.collider.gameObject;
            if (clickObject.CompareTag("Hamster"))
            {
                Debug.Log("�ܽ��� �� ��� ����");
                currHamster = null;
            }
        }
        if(hit.collider != null && currHamster == null && isHold)
        {
            GameObject clickObject = hit.collider.gameObject;
            if(clickObject.CompareTag("Hamster"))
            {
                currHamster = clickObject;
                Debug.Log("�ܽ��� ��� ����");
            }
        }
        else if(hit.collider == null && currHamster != null && isHold)
        {
            currHamster = null;
            Debug.Log("�ܽ��� ��� ���� ���");
        }
    }
}
