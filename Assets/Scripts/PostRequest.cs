using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class PostRequest : MonoBehaviour
{
    public Serializer Serializer; // serializes customer_state value on button click
    public Deserializer Deserializer; // reads WebRequest Response
    
    public string rawJSONData; // deserialized json to pass to API USING Serializer
    public string requestData; // serialized json string to create Response Objects

    public AudioSource AudioSource; // AudioSource to hold the audio Clip

    IEnumerator Post(string url, string bodyJsonString) // Coroutine to Run WebRequest
    {
        var request = new UnityWebRequest(url, "POST"); // variables to hold request object and Raw Data to pass to API
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw); // explicit buffers to avoid errors
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer(); // as above
        
        request.SetRequestHeader("Content-Type", "application/json"); // custom headers for authentication and content type
        request.SetRequestHeader("X-I2CE-ENTERPRISE-ID", "dave_expo");
        
        request.SetRequestHeader("X-I2CE-USER-ID", "74710c52-42a5-3e65-b1f0-2dc39ebe42c2");
        request.SetRequestHeader("X-I2CE-API-KEY", "NzQ3MTBjNTItNDJhNS0zZTY1LWIxZjAtMmRjMzllYmU0MmMyMTYwNzIyMDY2NiAzNw__");
        
        yield return request.SendWebRequest();
        
        Debug.Log("Status Code: " + request.responseCode);

        Debug.Log(request.downloadHandler.text);

        Deserializer.CreateFromJSON(request.downloadHandler.text); // Deserialize Response into classes
        Debug.Log(Deserializer.placeholder);
        
        //StartCoroutine(GetAudioClip()); // Audio Clip could not be Parsed accurately
    }

    IEnumerator GetAudioClip() // Coroutine to get Audio CLip after successful Call
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

    public void PostData() // Post Data button calls function on Click after serializing Raw Data to json
    {
        rawJSONData = Serializer.SaveToString();
        StartCoroutine(Post("https://test.iamdave.ai/conversation/exhibit_aldo/74710c52-42a5-3e65-b1f0-2dc39ebe42c2", rawJSONData));
    }

    public void DisplayResponse() // plays the result Clip
    {
        AudioSource.Play();
    }
}
