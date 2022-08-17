using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using KKSpeech;
using TMPro;

public class RecordingCanvas : MonoBehaviour
{
    public Button startRecordingButton;
    public Text resultText;
    public List<string> jawaban;
    public List<Image> listObjectImg;
    public TextMeshProUGUI bacakan;
    public AudioSource audio;
    public AudioClip sfx;
    public Animator message;
    public Animator benarAnim;

    private int level=0;

      void Start()
      {
        if (SpeechRecognizer.ExistsOnDevice())
        {
          SpeechRecognizerListener listener = GameObject.FindObjectOfType<SpeechRecognizerListener>();
          listener.onAuthorizationStatusFetched.AddListener(OnAuthorizationStatusFetched);
          listener.onAvailabilityChanged.AddListener(OnAvailabilityChange);
          listener.onErrorDuringRecording.AddListener(OnError);
          listener.onErrorOnStartRecording.AddListener(OnError);
          listener.onFinalResults.AddListener(OnFinalResult);
          listener.onPartialResults.AddListener(OnPartialResult);
          listener.onEndOfSpeech.AddListener(OnEndOfSpeech);
          SpeechRecognizer.RequestAccess();
        }
        else
        {
          resultText.text = "Sorry, but this device doesn't support speech recognition";
          startRecordingButton.enabled = false;
        }
        bacakan.text = jawaban[0];
        listObjectImg[0].color = Color.green;

      }

      public void OnFinalResult(string result)
      {
        resultText.text = result;
        if (result.Equals(jawaban[level].ToLower()))
        {
            if (level < 4)
            {
                audio.PlayOneShot(sfx);
                level++;
                StartCoroutine(playBenar());
                if (level == 4)
                {
                    message.SetTrigger("success");
                }
            }
            
        }
        startRecordingButton.enabled = true;
      }

    IEnumerator playBenar()
    {
        benarAnim.SetTrigger("benar");
        yield return new WaitForSeconds(1.5f);
        bacakan.text = jawaban[level];
        listObjectImg[level - 1].color = Color.white;
        listObjectImg[level].color = Color.green;
        
    }

      public void OnPartialResult(string result)
      {
        resultText.text = result;
      }

      public void OnAvailabilityChange(bool available)
      {
        startRecordingButton.enabled = available;
        if (!available)
        {
          resultText.text = "Device Tidak Mendukung :(";
        }
        else
        {
          resultText.text = "Katakan sesuatu :-)";
        }
      }

      public void OnAuthorizationStatusFetched(AuthorizationStatus status)
      {
        switch (status)
        {
          case AuthorizationStatus.Authorized:
            startRecordingButton.enabled = true;
            break;
          default:
            startRecordingButton.enabled = false;
            resultText.text = "Cannot use Speech Recognition, authorization status is " + status;
            break;
        }
      }

      public void OnEndOfSpeech()
      {
      }

      public void OnError(string error)
      {
        Debug.LogError(error);
        startRecordingButton.enabled = true;
      }

      public void OnStartRecordingPressed()
      {
        if (SpeechRecognizer.IsRecording())
        {
    #if UNITY_IOS && !UNITY_EDITOR
			    SpeechRecognizer.StopIfRecording();
			    startRecordingButton.GetComponentInChildren<Text>().text = "Stopping";
			    startRecordingButton.enabled = false;
    #elif UNITY_ANDROID && !UNITY_EDITOR
			    SpeechRecognizer.StopIfRecording();
			    startRecordingButton.GetComponentInChildren<Text>().text = "Start Recording";
    #endif
        }
        else
        {
          SpeechRecognizer.StartRecording(true);
          resultText.text = "Katakan sesuatu :-)";
        }
      }
}
