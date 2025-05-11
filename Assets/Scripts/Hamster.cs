using UnityEngine;

public class Hamster : MonoBehaviour
{
    public HamsterData data;

    void Update()
    {
        
    }

    public void Init(HamsterData _data)
    {
        data = _data;
    }

    public void EatSeed(int seedCal)
    {
        data.Satiety += seedCal;
    }

    public void OnMouse()
    {

    }
    public void OutMouse()
    {
        
    }
}
