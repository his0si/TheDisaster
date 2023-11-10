using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    public MediManager mediManager;

    private void Start()
    {
        mediManager = GameObject.Find("MediManager").GetComponent<MediManager>();
    }

    public void ClickMaterialButton()
    {
        // 매니저 재료 배열 두번째에 차있으면 리턴
            // 텍스트 업데이트
            // 매니저의 재료 배열에 추가 (첫번째 차있으면 두번째)
    }


}
