using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    private bool isCrouching = false;
    private Animator _anim;
    private CharacterController _characterController;

    public float standingHeight = 2.0f;
    public float crouchHeight = 1.0f;
    public float crouchCenterY = 0.5f;
    public float standingCenterY = 1.0f;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Eğilme tuşuna basıldığında
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            _characterController.height = crouchHeight;
            _characterController.center = new Vector3(_characterController.center.x, crouchCenterY, _characterController.center.z);
        }

        // Eğilme tuşu bırakıldığında
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            _characterController.height = standingHeight;
            _characterController.center = new Vector3(_characterController.center.x, standingCenterY, _characterController.center.z);
        }

        // Animator parametresini ayarla
        _anim.SetBool("IsCrouching", isCrouching);   
    }
}
