# LA_1500
# Lern-Bericht
Gruppe Chrysanthemum
Mitglieder: Giovanni Innamorato, Leon Dakaj, Kamil Bielski

## Einleitung

Wir haben in unserer Gruppenarbeit einen First-Person-Shooter in Unity entwickelt, bei dem wir die Vector 3 Mathematik in Unity angewendet haben, um die Bewegungen und Handlungen der Spielobjekte zu kontrollieren.
## Was habe ich gelernt?

Wir haben gelernt, wie man die Vector 3 Mathematik in Unity nutzen kann, um die Position, Rotation und Skalierung von Spielobjekten in einer 3D-Szene zu steuern und zu verändern.
## Beschreibung

Die Verwendung der Vector 3-Klasse in Unity gibt uns die Möglichkeit, die Position, Rotation und Skalierung von Spielobjekten zu steuern. Beispielsweise können wir mithilfe der Vector 3-Mathematik die Geschwindigkeit und Richtung eines Schusses berechnen oder die Drehung eines Objekts um eine bestimmte Achse bestimmen.

``` c sharp
public class Player : MonoBehaviour {

[SerializeField] private float speed; // Serializes a field in Unity, where you can adjust the Speed

void Start() {
    rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the current GameObject
  }

// Update is called once per frame
void FixedUpdate() {
    // Get input values from user for movement in the x and z axis
    float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
    float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

    // Calculate the direction of movement based on user input
    Vector3 direction = new Vector3(xMove, 0, zMove);
    direction.Normalize(); // Ensure that the direction vector has a magnitude of 1

    // Set the player's velocity based on the direction and speed
    rb.velocity = transform.TransformDirection(direction) * speed * Time.deltaTime; 
    // Scale the Rigidbody's velocity by Time.deltaTime to ensure that movement speed is consistent and independent of the frame rate of the game.
  }
}

```

YT Video zur Veranschaulichung der Bewegung mit Vector 3: [Vector 3 Movement](https://youtu.be/XiK3oven-LY)


## Verifikation

Durch die textliche Beschreibung, das Video und den Code-Ausschnitt zeigen wir auf, wie wir die Vector 3-Klasse in Unity verwenden, um die Bewegung der Spielobjekte in unserem First-Person-Shooter zu kontrollieren.
# Reflektion zum Arbeitsprozess

👍 Überlegen Sie sich jeweils etwas, was gut an Ihrer Arbeit lief; 

👎 und etwas, was nicht gut lief.

**VBV**: ✍️ Formulieren Sie davon ausgehend einen *handelbaren* Verbesserungsvorschlag.
