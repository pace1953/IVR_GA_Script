using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class NPC_Context
{
    public string content;
    public float timer = 0;
    public AudioClip audio;
}

[RequireComponent(typeof(AudioSource))]
public class Single_Context_Controller : MonoBehaviour
{
    public Text ui_text;
    public string NPCName;
    public Text nameText;
    public Image head_ui;
    public Sprite head_img;
    public bool auto_play = false;
    public bool step_by_step = false;
    public float speed = 0.1f;

    public List<NPC_Context> context_list;
    int index = 0;
    public UnityEvent finish_event;
    bool is_end = true;
    bool isAutoPlaying = false;

    void OnEnable()
    {
        if (head_ui)
        {
            if (head_img) head_ui.sprite = head_img;
        }

        ShowFirstContext();
    }

    public void ShowFirstContext()
    {
        if (context_list == null || context_list.Count == 0)
        {
            Debug.LogWarning("對話文本是空的");
            return;
        }

        index = 0;
        NPC_Context firstContext = context_list[0];
        nameText.text = NPCName;
        ui_text.text = firstContext.content;

        if (firstContext.audio)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = firstContext.audio;
            audioSource.Play();
        }

        is_end = true;
    }

    public void Play()
    {
        if (is_end == false) return;
        StartCoroutine(IPlay());
    }

    public void Again()
    {
        if (is_end == false) return;
        if (index > 0)
            index--;
        StartCoroutine(IPlay());
    }

    IEnumerator IPlay()
    {
        is_end = false;
        NPC_Context context = context_list[index];
        nameText.text = NPCName;
        if (context.audio)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = context.audio;
            audioSource.Play();
        }

        if (step_by_step)
        {
            string content = "";
            for (int i = 0; i < context.content.Length; i++)
            {
                content += context.content[i];
                ui_text.text = content;
                yield return new WaitForSeconds(speed);
            }
        }
        else
        {
            ui_text.text = context.content;
        }

        yield return new WaitForSeconds(context.timer);

        is_end = true;
    }

    public void Replay()
    {
        index = 0;
        Play();
    }

    public void NextContext()
    {
        StopAllCoroutines();

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

        isAutoPlaying = false;
        is_end = true;

        if (ui_text != null)
        {
            ui_text.text = "";
        }

        if (context_list == null || context_list.Count == 0)
        {
            Debug.LogWarning("對話文本是空的");
            return;
        }

        if (index < context_list.Count - 1)
        {
            index++;
        }
        else
        {
            Debug.Log("對話文本結束，觸發事件");
            finish_event.Invoke();
            return;
        }

        Debug.Log($"Current Index: {index}");

        StartCoroutine(IPlay());
    }
}