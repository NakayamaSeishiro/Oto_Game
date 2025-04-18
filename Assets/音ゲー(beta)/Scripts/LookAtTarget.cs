using UnityEngine;

internal class LookAtTarget : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // カメラを取得
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // カメラ方向を計算
        Vector3 lookDir = mainCameraTransform.position - transform.position;
        lookDir.x = 0f; // Y軸回転のみなので、X成分を0に設定する

        // オブジェクトのY軸のみカメラの方向に向ける
        if (lookDir != Vector3.zero)
        {
            transform.forward = lookDir.normalized;
        }
    }
}