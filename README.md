# Light in a Dark Place

Name: Nikolay Malyshev

Student Number: C18333703

Class Group: DT282/4

# Description of the project

The project contains a small realm where a user controls a toy tank which can shoot multiple different types of weapons. There is an objective to destroy all the blocks in this realm. When the player thinks they are getting somewhere with their task, more start dropping from the sky. While all this is going on, there is a visualizer for the player to get distracted while watching and listening.

# Instructions for use

- Start the scene titled "Light in a Dark Place"
- Move the tank by using the WASD Keys
- Rotate the turret using the left and right ARROW keys
- If you are ever stuck sideways, or upside down, press the F key.

- If the skybox was not loaded in, it is because you do not have the asset downloaded. Retrieve the asset from:
  [asset-store](https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-11633).
  - Download and Import it into the Unity folder.
  - Open the StarSkybox04 folder located in "Assets/Real Stars Skybox/StarSkybox04/" and drag "Cubemap Stars" onto an empty part of the Scene.

# How it works

## Grid

A grid is created using the values that are input by the user in the "Call Grid" script. This gives the script "gridCreate" the values needed to create an array.

```c#
    public static int x = 20;
    public static int y = 20;

    private void Start()
    {
        // Putting the Values to determine size of grid
        // These Values Must be Equal!
        if (x == y)
        {
            gridCreate gridCreate = new gridCreate(x, y);
        }
    }
```

This array is responsible for creating all the cubes in the world space. Initially, all grid values are set to 1 which indicates that blocks can spawn here.

```c#

// Set all values in array to 1
for (int x = 0; x < gridArray.GetLength(0); x++)
{
    for (int y = 0; y < gridArray.GetLength(1); y++)
    {
        gridArray[x, y] = 1;
    }
}
```

Then randomly, there are rows and columns of the array that are set to areas where the blocks are allowed to spawn. These blocks are multicolored and have the same functionality -> be destroyed when hit by a projectile.

```c#
int randomH = 0;
int randomW = 0;
for (int i = 0; i < SizeX; i++)
{
    // Set Values by Height
    for (int j = 0; j < gridArray.GetLength(0); j++)
    {
        gridArray[randomH, j] = 2;
    }
    randomH = Increment_randomH(randomH);
    if (randomH >= width)
    {
        break;
    }
}
for (int z = 0; z < SizeY; z++)
{
    // Set Values by Width
    for (int w = 0; w < gridArray.GetLength(1); w++)
    {
    gridArray[w, randomW] = 2;
    }
    randomW = Increment_randomW(randomW);
    if (randomW >= height)
    {
        break;
    }
}
```

```c#
// Heights of Pillars
int eheightV = 0, rr = 0, heightV = 0;
// Call RandomRandom to decide whether its
// a tall pillar or not
var cubeBottom = GameObject.CreatePrimitive(PrimitiveType.Cube);
cubeBottom.name = "Building1high " + x + " " + y;
cubeBottom.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
Material mat = cubeBottom.GetComponent<Renderer>().sharedMaterial;
mat.SetFloat("_Metallic", 0.5f);
cubeBottom.transform.position = new Vector3(x, 0.2f, y);
Rigidbody RigidBodycubeBottom = cubeBottom.AddComponent<Rigidbody>();
RigidBodycubeBottom.useGravity = false;
cubeBottom.tag = "Cube";
cubeBottom.layer = 6;
```

On top of that, there are black colored boxes that spawn at a lower rate which upgrade the players weapon, going from a basic weapon, to a laser, to a rocket launcher.

```c#
// Create Object that changes the weapon of a player
// spawn more objects that do so depending on size of array
// Spawn 4 of them, even though there are only 2 upgrades
float randomGridx = 0;
float randomGridy = 0;
for (int i = 0; i < 4; i++)
{
    randomGridx = randomGridX(randomGridx);
    randomGridy = randomGridY(randomGridy);
    var cubeWeapon = GameObject.CreatePrimitive(PrimitiveType.Cube);
    cubeWeapon.name = "cubeWeapon " + i;
    cubeWeapon.GetComponent<Renderer>().material.color = black;
    cubeWeapon.transform.position = new Vector3(randomGridx, 10.5f, randomGridy);
    cubeWeapon.tag = "cubeWeapon";
    Rigidbody RigidBodyCube = cubeWeapon.AddComponent<Rigidbody>();
    cubeWeapon.layer = 6;
}
```

## Tank ( Player Vehicle )

First the tank was created by using an asset taken from the asset store:
[asset-store](https://assetstore.unity.com/packages/3d/vehicles/land/cartoon-tank-free-165189)
Then, I worked on letting the user move in the tank.

```c#
if (Input.GetKey(KeyCode.W))
{
    transform.Translate(0.0f, 0f, movementSpeed * Time.deltaTime);
}
if (Input.GetKey(KeyCode.S))
{
    transform.Translate(0.0f, 0f, -movementSpeed * Time.deltaTime);
}
if (Input.GetKey(KeyCode.D))
{
    transform.Rotate(0f, movementSpeed * rotationSpeed * Time.deltaTime, 0f);
}
if (Input.GetKey(KeyCode.A))
{
    transform.Rotate(0f, -movementSpeed * rotationSpeed * Time.deltaTime, 0f);
}
if (Input.GetKey(KeyCode.None))
{
    rb.velocity = transform.forward * 0;
}
```

Rotation to the turret was added, which the user can control using the arrow keys.

```C#
// Rotate Weappon Using Arrow Keys
if (Input.GetKey(KeyCode.RightArrow))
{
    Weapon.Rotate(0f, movementSpeed * rotationSpeed * Time.deltaTime, 0f);
}
if (Input.GetKey(KeyCode.LeftArrow))
{
    Weapon.Rotate(0f, -movementSpeed * rotationSpeed * Time.deltaTime, 0f);
}
```

#### Shooting

After Rotation & Movement was added successfully, I moved to creating the weapons. All of the weapons work similarly, where they instantiate a projectile. The projectile then travels in the direction that the turret is facing and gets destroyed, whether it be to time or impact.

```C#
// Wait a little until weapon starts ( so player can center mouse in time )
if (timeCounter < startDelay)
{
    timeCounter += Time.deltaTime;
    return;
}

if (timeBetweenShot <= 0)
{
    if (Input.GetKey(KeyCode.Space))
    {
        Instantiate(projectile, ShotPoint.position, transform.rotation);
        timeBetweenShot = starttimeBetweenShot;
    }
}
else
{
    timeBetweenShot -= Time.deltaTime;
}
```

```C#
void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Cube")
    {
        Destroy(collision.gameObject);
        deathCounterVariable += 1;
        dtc = FindObjectOfType<movement>();
        dtc.dtcCounter(deathCounterVariable);
    }
    if (collision.gameObject.tag == "cubeWeapon")
    {
        Destroy(collision.gameObject);
        waeponCounterVariable = 1;
        deathCounterVariable += 1;
        wcc = FindObjectOfType<movement>();
        wcc.wcCounter(waeponCounterVariable);
    }
    Destroy(gameObject);
}
```

There is a difference between the weapons. Such as the laser not being destroyed on impact, and the rocket launcher which instantiates an explosion.

```C#
 void Start()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            Rigidbody rb = near.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
```

## Block Rain

After a certain number of blocks destroyed, more blocks begin to start falling from the sky.

```C#
InvokeRepeating("CubeRainRoutine", 1f, 5f);
```

```C#
public void CubeRainRoutine()
{
    float randomGridx = 0;
    float randomGridy = 0;
    for (int i = 0; i < 4; i++)
    {
        randomGridx = randomGridX(randomGridx);
        randomGridy = randomGridY(randomGridy);
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "cube " + i;
        cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        cube.transform.position = new Vector3(randomGridx, 10.5f, randomGridy);
        cube.tag = "Cube";
        Rigidbody RigidBodyCube = cube.AddComponent<Rigidbody>();
        cube.layer = 6;
    }
}
```

## Visualizer

The visualizer was created using spectrum data.

```C#
// Get Spectrum Data
float[] spectrumData = new float[256];
AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);
```

The spectrum data is used to manipulate the size of the image objects.

```C#
for (int i = 0; i < visualizerObjects.Length; i++)
{
    // Set New Size
    Vector2 newImageSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;
    // Mathf.Lert smooths the size changing
    newImageSize.y = Mathf.Lerp(newImageSize.y, imageMinHeight + (spectrumData[i] * (imageHeight - imageMinHeight) * 5.0f), 0.25f);
    // Change Size on object
    visualizerObjects[i].GetComponentInParent<RectTransform>().sizeDelta = newImageSize;
}
```

The image objects were created using the following code:

```C#
int gap = 10;
for (int col = 0; col < SizeX + gap; col++)
{
    // Create Image which displays Visualizer
    GameObject image = new GameObject();
    Image Newimage = image.AddComponent<Image>();
    //Newimage.transform.parent = this.transform;
    Newimage.GetComponentInParent<RectTransform>().SetParent(parent.transform);
    Newimage.rectTransform.sizeDelta = new Vector2(1, 1);
    Newimage.rectTransform.Translate(new Vector3(col - (gap / 2), 3f, -5));
    Newimage.name = "Visualizer Image : " + col;
    image.AddComponent<VisualizerObject>();
    image.GetComponent<Image>().color = color1;

}
```

# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference

| Class/asset         | Source                                                                                               |
| ------------------- | ---------------------------------------------------------------------------------------------------- |
| WeaponMovement.cs   | Self written                                                                                         |
| Weapon1.cs          | Self written                                                                                         |
| RocketWeapon.cs     | Self written                                                                                         |
| RocketProjectile.cs | Self written                                                                                         |
| Projectile1.cs      | Self written                                                                                         |
| movement.cs         | Self written                                                                                         |
| LaserWeapon.cs      | Self written                                                                                         |
| LaserProjectile.cs  | Self written                                                                                         |
| flipped.cs          | Self written                                                                                         |
| ExplosionRocket.cs  | Self written                                                                                         |
| callGrid.cs         | Self written                                                                                         |
| gridCreate.cs       | Self written                                                                                         |
| center.cs           | Self written                                                                                         |
| centerPlane.cs      | Self written                                                                                         |
| Sun.cs              | Self written                                                                                         |
| Visualizer.cs       | Modified from [youtube](https://www.youtube.com/watch?v=PgXZsoslGsg&ab_channel=MediaMax) By MediaMax |
| VisualizerObject.cs | Modified from [youtube](https://www.youtube.com/watch?v=PgXZsoslGsg&ab_channel=MediaMax) By MediaMax |

# References

Visualizer Modified from [youtube](https://www.youtube.com/watch?v=PgXZsoslGsg&ab_channel=MediaMax) By MediaMax.
Skybox Asset from [asset-store](https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-11633)
Tank Asset from [asset-store](https://assetstore.unity.com/packages/3d/vehicles/land/cartoon-tank-free-165189)
Music from [free-stock-music](https://www.free-stock-music.com/keys-of-moon-tropical-aura.html)

# What I am most proud of in the assignment

This assignment has done a lot for me. It showed what I can create in unity with a bit of time put in and has made me learn a lot. One of the most useful things is that there are many solutions to one problem. If one thing breaks, there is no need to panic as all that needs to be done is - take a step back, look at it from a different angle, and try something new. Alongside that, learning how a 3d space works and how objects operate inside of it was also very useful. I am proud of the knowledge that I have gained from this, but I am also proud of what I created. I think it is a unique mix of elements that comes together to create an interesting experience that ties together quite nicely for the player.

# Video

[Youtube](https://youtu.be/3AkTyzUBOO8)

# Proposal submitted earlier can go here:

The project will create a city which is procedurally generated. The user is able to drive around the city in various vehicles. There are different types of cities that the person is able to go to. Each one with a unique theme, and a unique vehicle. To visit these different cities, the user will change the song that is playing on the radio in their vehicle. The city themes could be a WW2 setting, a city which is celebrating new years, a hot summer etc etc. There will be anywhere from 2-5 cities that the user can traverse to enjoy the music and most importantly, admire the setting.
