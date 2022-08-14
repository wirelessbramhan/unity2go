using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PostRequest : MonoBehaviour
{
    public Serializer Serializer;
    public Deserializer Deserializer;
    
    public string rawJSONData;
    public string requestData;

    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("X-I2CE-ENTERPRISE-ID", "dave_expo");
        
        request.SetRequestHeader("X-I2CE-USER-ID", "74710c52-42a5-3e65-b1f0-2dc39ebe42c2");
        request.SetRequestHeader("X-I2CE-API-KEY", "NzQ3MTBjNTItNDJhNS0zZTY1LWIxZjAtMmRjMzllYmU0MmMyMTYwNzIyMDY2NiAzNw__");
        
        yield return request.SendWebRequest();
        
        Debug.Log("Status Code: " + request.responseCode);

        Debug.Log(request.downloadHandler.text);

        Deserializer.CreateFromJSON(request.downloadHandler.text);
        Debug.Log(Deserializer.placeholder);
        
        //StartCoroutine(GetAudioClip());
    }

    IEnumerator GetAudioClip()
    {
        using UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(Deserializer.response_channels.voice, AudioType.WAV);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(www.error);
        }
        else
        {
            AudioClip voiceClip = DownloadHandlerAudioClip.GetContent(www);
            AudioSource.clip = voiceClip;
        }
    }

    public void PostData()
    {
        rawJSONData = Serializer.SaveToString();
        StartCoroutine(Post("https://test.iamdave.ai/conversation/exhibit_aldo/74710c52-42a5-3e65-b1f0-2dc39ebe42c2", rawJSONData));
    }

    public void DisplayResponse()
    {
        AudioSource.Play();
    }
}
