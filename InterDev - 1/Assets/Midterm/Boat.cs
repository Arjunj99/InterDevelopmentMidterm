public class Boat {
    private string name;
    private float currentSpeed;
    private bool inMotion;
    private float currentRotation;

    
    // private float d;
    // private float moveSpeed;
    // private float rotationSpeed;
    // private float maxSpeed;
    // private

    public Boat() {
        this.name = null;
        currentSpeed = 0;
        inMotion = false;
        currentRotation = 0;
    }
    
    public Boat(string name) {
        this.name = name;
        currentSpeed = 0;
        inMotion = false;
        currentRotation = 0;
    }

    public float GetCurrentSpeed() {
        return currentSpeed;
    }

    public void SetCurrentSpeed(float speed) {
        currentSpeed = speed;
    }

    public bool GetInMotion() {
        return inMotion;
    }

    public void SetInMotion(bool motion) {
        inMotion = motion;
    }

    public float GetCurrentRotation() {
        return currentRotation;
    }

    public void SetCurrentRotation(float speed) {
        currentRotation = speed;
    }
}
