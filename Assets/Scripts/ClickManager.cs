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
        // 마우스다운 => 해바라기씨 그릇이면 해바라기 씨 들기, 햄스터이면 선택
        // 마우스업 => 햄스터이면 햄스터 씨 까기 상태, 햄스터가 아니면 취소
        // 일반 => 씨를 든 상태에서 햄스터 위로 올라가면 햄스터 대기 상태
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
                Debug.Log("햄스터 선택");
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
                Debug.Log("햄스터 씨 까기 시작");
                currHamster = null;
            }
        }
        if(hit.collider != null && currHamster == null && isHold)
        {
            GameObject clickObject = hit.collider.gameObject;
            if(clickObject.CompareTag("Hamster"))
            {
                currHamster = clickObject;
                Debug.Log("햄스터 대기 상태");
            }
        }
        else if(hit.collider == null && currHamster != null && isHold)
        {
            currHamster = null;
            Debug.Log("햄스터 대기 상태 취소");
        }
    }
}
