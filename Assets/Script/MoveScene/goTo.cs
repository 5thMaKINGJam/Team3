using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goTo : MonoBehaviour
{
    
     public void GoToMainScene()
    {
        SceneManager.LoadScene("collectTreasure"); // "MainScene"�� Main ���� ��Ȯ�� �̸����� ����
    }
}
