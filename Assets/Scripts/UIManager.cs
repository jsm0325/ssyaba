using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public AudioListener audioListener;
    public AudioMixer masterMixer;
    public Sprite AudioOnImage;
    public Sprite AudioOffImage;

    public static UIManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(UIManager)) as UIManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        //씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않음
        DontDestroyOnLoad(gameObject);
    }
    public void AudioControl(string soundName)
    {
        Slider audioSlider = GameObject.Find(soundName + "Volume").GetComponent<Slider>();
        float sound = audioSlider.value;

        if(sound == -40f)
        {
            masterMixer.SetFloat(soundName, -80);
        }
        else
        {
            masterMixer.SetFloat(soundName, sound);
        }
    }

    public void ResetSetting()
    {

        //뮤트 리셋
        if (audioListener == null)
        {
            audioListener = GameObject.FindWithTag("MainCamera").GetComponent<AudioListener>();
        }
        AudioListener.volume = 1;
        GameObject button = GameObject.Find("Mute");
        Image buttonImage = button.GetComponent<Image>();
        buttonImage.sprite = AudioOnImage;

        //이펙트 리셋
        GameManager.Instance.ReSetCameraEffectState();
        button = GameObject.Find("EffectButton");
        buttonImage = button.GetComponent<Image>();
        Color color = buttonImage.color;
        color.a = 1;
        buttonImage.color = color;

        //오디오 리셋
        GameObject audio = GameObject.Find("Mute");
        string[] soundName = { "Master", "BGM", "SFX" };
        for(int i=0; i<3; i++)
        {
            Slider audioSlider = GameObject.Find(soundName[i] + "Volume").GetComponent<Slider>();
            audioSlider.value = 0;
            masterMixer.SetFloat(soundName[i], 0);
        }

    }

    public void ToggleAudioVolume(GameObject button)
    {
        if (audioListener == null)
        {
            audioListener = GameObject.FindWithTag("MainCamera").GetComponent<AudioListener>();
        }
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage.sprite == AudioOnImage)
        {
            buttonImage.sprite = AudioOffImage;
        }
        else
        {
            buttonImage.sprite = AudioOnImage;
        }
    }

    public void ToggleEffectButton(GameObject button)
    {
        Image buttonImage = button.GetComponent<Image>();

        if (GameManager.Instance.ReturnCameraEffectState() == true)
        {
            GameManager.Instance.SetCameraEffectState();
            Color color = buttonImage.color;
            color.a = 0;
            buttonImage.color = color;
        }
        else
        {
            GameManager.Instance.SetCameraEffectState();
            Color color = buttonImage.color;
            color.a = 1;
            buttonImage.color = color;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        GameManager.Instance.ReSetIsPaused();
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        GameManager.Instance.SetIsPaused();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        GameManager.Instance.SetIsPaused();
    }
    public void ResetScene()
    {
        GameManager.Instance.ResetGame();
    }
}
