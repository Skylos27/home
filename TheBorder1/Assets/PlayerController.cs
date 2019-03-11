using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] //Afficher cette variable dans l'inspector
    private float speed = 3f; //Vitesse de déplacement
    [SerializeField]
    private float lookSensitivityX = 3f; //Vitesse de rotation de la caméra sur l'axe X
    [SerializeField]
    private float lookSensitivityY = 2.6f; //Vitesse de rotation de la caméra sur l'axe Y

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        //Calculer la vélocité du mouvement du joueur en un Vecteur 3D
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed; //On a donc la vélocité ici !
        motor.Move(_velocity);

        //Calculer la rotation du joueur en un Vecteur 3D
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivityX;
        motor.Rotate(_rotation);

        //Calculer la rotation de la caméra en un Vecteur 3D
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * lookSensitivityY;
        motor.RotateCamera(_cameraRotation);
    }
}
