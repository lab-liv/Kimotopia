using System;
using UnityEngine;
using UnityEngine.Networking;

public class CaptainsMessDebugGUI : MonoBehaviour
{
	private CaptainsMess mess;
	private CaptainsMessNetworkManager networkManager;

	public void Awake()
	{
		mess = FindObjectOfType(typeof(CaptainsMess)) as CaptainsMess;
		networkManager = GetComponent<CaptainsMessNetworkManager>();
	}

	string NetworkDebugString()
	{
		string serverString = "[SERVER]\n";
		if (NetworkServer.active && networkManager.numPlayers > 0)
		{
			/*serverString += "Hosting at " + Network.player.ipAddress + "\n";*/
			serverString += String.Format("Players Ready = {0}/{1}", networkManager.NumReadyPlayers(), networkManager.NumPlayers()) + "\n";
		}
		if (networkManager.discoveryServer.running && networkManager.discoveryServer.isServer)
		{
			serverString += "Broadcasting: " + networkManager.discoveryServer.broadcastData + "\n";
		}

		string clientString = "[CLIENT]\n";
		if (networkManager.IsClientConnected())
		{
			clientString += "Connected to server: " + networkManager.client.connection.address + "\n";
		}
		if (networkManager.discoveryClient.running && networkManager.discoveryClient.isClient)
		{
			// Discovered servers
			clientString += "Discovered servers =";
			foreach (DiscoveredServer server in networkManager.discoveryClient.discoveredServers.Values)
			{
				bool isMe = (server.peerId == networkManager.peerId);
				clientString += "\n- ";
				if (isMe) {
					clientString += "(me) ";
				}
				clientString += server.ipAddress + " : " + server.rawData;
			}
			clientString += "\n";

			// Received broadcasts
			clientString += "Received broadcasts =";
			foreach (var entry in networkManager.discoveryClient.receivedBroadcastLog) {
				clientString += "\n" + entry;
			}
			clientString += "\n";
		}

		return serverString + "\n" + clientString;
	}


	void Start()
	{
		//To connect like server
		mess.StartHosting();
		//To connect like client
		//mess.StartJoining();
	}


}