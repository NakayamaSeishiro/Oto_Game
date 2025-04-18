using UnityEngine;

internal class LookAtTarget : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // �J�������擾
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // �J�����������v�Z
        Vector3 lookDir = mainCameraTransform.position - transform.position;
        lookDir.x = 0f; // Y����]�݂̂Ȃ̂ŁAX������0�ɐݒ肷��

        // �I�u�W�F�N�g��Y���̂݃J�����̕����Ɍ�����
        if (lookDir != Vector3.zero)
        {
            transform.forward = lookDir.normalized;
        }
    }
}