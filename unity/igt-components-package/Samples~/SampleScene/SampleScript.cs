using InfinityGameTable;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    public void OnRumbleClick()
    {
        InfinityGameTableHelper.Rumble(500);
    }
}
