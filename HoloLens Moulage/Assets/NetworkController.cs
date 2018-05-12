using UnityEngine;
using UnityEngine.Networking;
public class NetworkController : MonoBehaviour
{
    NetworkManager netManager;
    NetworkClient host;
    void Start()
    {
        netManager = GetComponent<NetworkManager>();
    }
    public void StartHost()
    {
        Debug.Log("Starting host");
        netManager.StartHost();
        Debug.Log("Started host");
    }
    public void StartClient()
    {
        NetworkClient client = netManager.StartClient();
    }
    public void OnDestroy()
    {
        netManager.StopClient();
        netManager.StopHost();
    }
}