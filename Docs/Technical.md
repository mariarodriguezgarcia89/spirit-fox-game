# ⚙️ Technical.md – Spirit Fox
**Documentación Técnica v1.0**  
**Autor:** María  
**Módulo:** Desarrollo de Aplicaciones Multiplataforma – 2º DAM  
**Motor:** Unity 2D (LTS)  
**Fecha:** Febrero 2026

---

## Índice

1. [Entorno de desarrollo](#1-entorno-de-desarrollo)
2. [Estructura del proyecto](#2-estructura-del-proyecto)
3. [Arquitectura del código](#3-arquitectura-del-código)
4. [Sistemas principales](#4-sistemas-principales)
5. [Físicas y colisiones](#5-físicas-y-colisiones)
6. [Animaciones](#6-animaciones)
7. [Gestión de escenas y persistencia de datos](#7-gestión-de-escenas-y-persistencia-de-datos)
8. [Audio](#8-audio)
9. [Assets y licencias](#9-assets-y-licencias)
10. [Decisiones técnicas justificadas](#10-decisiones-técnicas-justificadas)
11. [Bugs resueltos](#11-bugs-resueltos)

---

## 1. Entorno de desarrollo

| **Motor** | Unity 2D (versión LTS del curso) |
| **Lenguaje** | C# |
| **IDE** | Visual Studio / VS Code |
| **Control de versiones** | Git + GitHub |
| **Plataforma de build** | Windows (x86_64) |
| **Librerías adicionales** | TextMeshPro (incluida en Unity) |

## 2. Estructura del proyecto

Assets/
├── Animations/          # Animation Clips y Animator Controllers
├── Audio/               # Música BGM y efectos SFX (.mp3 / .wav)
├── Fonts/               # Fuentes para TextMeshPro
├── Materials/           # Materiales físicos y visuales
├── Prefabs/             # Prefabs reutilizables (gemas, enemigos, efectos)
├── Scenes/              # MainMenu, GameScene, VictoryScene, GameOverScene
├── Scripts/             # Todos los scripts C#
│   ├── Player/
│   ├── Enemies/
│   ├── Managers/
│   ├── UI/
│   └── Collectibles/
├── Sprites/             # Spritesheets del personaje, enemigos y entorno
└── Tilemaps/            # Tiles y paletas del nivel

Build/
└── SpiritFox.exe        # Ejecutable Windows

Docs/
├── GDD.md
├── Technical.md
└── Postmortem.md

README.md

## 3. Arquitectura del código

El proyecto sigue una arquitectura basada en **Managers centralizados** que gestionan sistemas globales, comunicándose entre sí a través de referencias directas o mediante el patrón Singleton.

### 3.1 Diagrama de dependencias

GameManager
    ├── UIManager          (actualiza HUD: puntos, vida, tiempo)
    ├── AudioManager       (reproduce música y SFX)
    └── SceneManager       (transiciones entre escenas)

PlayerController
    ├── → UIManager        (notifica cambios de vida y puntuación)
    └── → AudioManager     (solicita SFX de salto y daño)

EnemyController
    └── → AudioManager     (solicita SFX de derrota)

GemCollectible
    └── → UIManager        (suma puntuación)
    └── → AudioManager     (SFX de recolección)

### 3.2 Scripts principales

| `PlayerController.cs` | Movimiento, salto, detección de suelo, vida, knockback |
| `EnemyController.cs` | Patrulla, detección de bordes, salto aleatorio, daño |
| `GameManager.cs` | Estado global del juego, condiciones de victoria/derrota |
| `UIManager.cs` | Actualización de HUD (vida, puntos, temporizador) |
| `AudioManager.cs` | Singleton de audio, gestión de BGM y SFX |
| `TimerController.cs` | Cuenta atrás, aviso visual, trigger de game over por tiempo |
| `GemCollectible.cs` | Detección de trigger, suma de puntos, auto-destrucción |
| `ButterflyController.cs` | Movimiento decorativo, respawn al salir de cámara |
| `VictoryZone.cs` | Trigger de fin de nivel, transición a VictoryScene |
| `CameraController.cs` | Seguimiento del jugador con límites de mapa |

## 4. Sistemas principales

### 4.1 Movimiento del jugador

El movimiento se gestiona íntegramente en `PlayerController.cs` usando el componente `Rigidbody2D` en modo **Dynamic**.

```csharp
// Movimiento horizontal
float moveInput = Input.GetAxisRaw("Horizontal");
rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

// Salto
if (Input.GetButtonDown("Jump") && isGrounded) {
    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
}

// Fall multiplier para caída más natural
if (rb.velocity.y < 0) {
    rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
} else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
    rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
}
```

**Parámetros configurados en Inspector:**

| `moveSpeed` | `8f` |
| `jumpForce` | `16f` |
| `fallMultiplier` | `2.5f` |
| `lowJumpMultiplier` | `2f` |

### 4.2 Detección de suelo

Se usa `Physics2D.OverlapCircle` en lugar de colisiones directas para mayor fiabilidad en bordes de plataforma:

```csharp
isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
```

- `groundCheck`: Transform hijo del jugador situado en la base del sprite
- `groundCheckRadius`: `0.2f`
- `groundLayer`: Layer específica `"Ground"` para evitar falsos positivos con enemigos u otros objetos

### 4.3 Sistema de vida y daño

El jugador tiene **3 puntos de vida**. Al recibir daño se aplica un breve período de invulnerabilidad (implementado con corrutina) para evitar pérdidas de vida en cadena:

```csharp
IEnumerator DamageInvulnerability() {
    isInvulnerable = true;
    yield return new WaitForSeconds(invulnerabilityTime); // 1.5f
    isInvulnerable = false;
}
```

El knockback se aplica directamente sobre el Rigidbody2D:

```csharp
Vector2 knockbackDir = (transform.position - enemy.transform.position).normalized;
rb.velocity = knockbackDir * knockbackForce;
```

## 5. Físicas y colisiones

### 5.1 Configuración de capas (Layers)

| `Default` | Objetos generales |
| `Ground` | Plataformas y suelo — detectadas por el jugador y enemigos |
| `Player` | Personaje — recibe daño de enemigos |
| `Enemy` | Enemigos — detectados por el jugador para stomp |
| `Collectible` | Gemas — trigger con el jugador |

La matriz de colisiones de Physics2D está configurada para que `Collectible` solo interactúe con `Player`, evitando comprobaciones innecesarias.

### 5.2 Composite Collider 2D en plataformas

Las plataformas del tilemap utilizan `Tilemap Collider 2D` combinado con `Composite Collider 2D`. Esto fusiona todos los colisionadores individuales de los tiles en una única malla de colisión, lo que:

- Elimina los micro-gaps entre tiles que pueden causar que el jugador se enganche
- Reduce significativamente el número de operaciones de física por frame
- Mejora la estabilidad del `OverlapCircle` de detección de suelo

### 5.3 Platform Effector 2D

Las plataformas flotantes usan `Platform Effector 2D` con `Use One Way` activado, permitiendo al jugador saltar a través de ellas desde abajo y aterrizar encima.

## 6. Animaciones

### 6.1 Animator Controller del jugador

El personaje tiene tres estados de animación gestionados por el `Animator` de Unity:

```
[Idle] ←→ [Running]
   ↕
[Jumping]
```

**Parámetros del Animator:**

| `isRunning` | Bool | `true` si `Mathf.Abs(velocity.x) > 0.1f` |
| `isGrounded` | Bool | `true` si `OverlapCircle` detecta suelo |

**Transiciones:**
- `Idle → Running`: `isRunning == true`
- `Running → Idle`: `isRunning == false`
- `Any State → Jumping`: `isGrounded == false`
- `Jumping → Idle`: `isGrounded == true`

Los parámetros se actualizan cada frame en `Update()` desde `PlayerController.cs`.

### 6.2 Sistema de partículas (derrota de enemigos)

Al destruir un enemigo se instancia un `Particle System` prefab en la posición del enemigo. El sistema está configurado con:

- **Burst** de 15–20 partículas en el momento de instanciación
- Partículas de colores que coinciden con la paleta del enemigo
- `Stop Action: Destroy` para auto-destruir el GameObject al completarse
- Duración total: `0.5f` segundos

```csharp
Instantiate(deathParticles, transform.position, Quaternion.identity);
Destroy(gameObject);
```

## 7. Gestión de escenas y persistencia de datos

### 7.1 Transiciones de escena

Las transiciones se realizan mediante `SceneManager.LoadScene()`. Las escenas del proyecto son:

| `MainMenu` | 0 | Pantalla de inicio |
| `GameScene` | 1 | Nivel principal |
| `VictoryScene` | 2 | Pantalla de victoria |
| `GameOverScene` | 3 | Pantalla de derrota |

### 7.2 Persistencia con PlayerPrefs

Dado que Unity destruye todos los objetos de escena al cargar una nueva escena, se usa `PlayerPrefs` para guardar datos que deben mostrarse en pantallas posteriores:

```csharp
// Guardar antes de transición (en GameScene)
PlayerPrefs.SetInt("FinalScore", currentScore);
PlayerPrefs.SetFloat("FinalTime", timeRemaining);
PlayerPrefs.Save();

// Recuperar en VictoryScene
int score = PlayerPrefs.GetInt("FinalScore", 0);
float time = PlayerPrefs.GetFloat("FinalTime", 0f);
```

Se eligió `PlayerPrefs` sobre un `GameManager` con `DontDestroyOnLoad` para mantener la arquitectura simple y evitar conflictos de instancias entre reinicios de partida.

## 8. Audio

### 8.1 AudioManager (Singleton)

El `AudioManager` es un Singleton que persiste entre escenas mediante `DontDestroyOnLoad`:

```csharp
void Awake() {
    if (instance == null) {
        instance = this;
        DontDestroyOnLoad(gameObject);
    } else {
        Destroy(gameObject);
    }
}
```

Expone métodos públicos estáticos para reproducir sonidos desde cualquier script sin necesidad de referencia directa:

```csharp
AudioManager.instance.PlaySFX("jump");
AudioManager.instance.PlayMusic("game");
```

### 8.2 Gestión de BGM entre escenas

Al cargar una nueva escena, el AudioManager detecta el nombre de la escena activa y cambia la música correspondiente, evitando que la misma pista se reinicie si ya está sonando:

```csharp
if (audioSource.clip != targetClip) {
    audioSource.clip = targetClip;
    audioSource.Play();
}
```

## 9. Assets y licencias

| Sprite del jugador | Pixel art | Pixel Adventure (itch.io) | Uso libre / Free asset pack |
| Sprites de enemigos | Pixel art | Pixel Adventure (itch.io) | Uso libre / Free asset pack |
| Tiles de plataformas | Pixel art | Pixel Adventure (itch.io) | Uso libre / Free asset pack |
| Fondo del nivel | Imagen | Generado con IA | Sin restricciones (generado por la autora) |
| Música BGM | Audio | Freesound.org | Creative Commons (CC0 / CC BY) |
| Efectos SFX | Audio | Freesound.org | Creative Commons (CC0 / CC BY) |
| TextMeshPro | Plugin | Unity Package Manager | Incluido en Unity (licencia Unity) |

## 10. Decisiones técnicas justificadas

### ¿Por qué fall multiplier en lugar de ajustar la gravedad de Unity?

Aumentar la `gravityScale` del Rigidbody2D afecta igualmente a la subida y la bajada del salto, haciendo el movimiento pesado en ambas fases. El fall multiplier permite tener una subida suave y una bajada rápida de forma independiente, dando al jugador mayor sensación de control y un salto más expresivo, técnica estándar en plataformas modernos (popularizada tras el artículo *"Better Jumping in Unity"* de Zigurous).

### ¿Por qué Composite Collider en el tilemap?

Durante el desarrollo se detectaron comportamientos erráticos cuando el jugador caminaba sobre las juntas entre tiles: el personaje se enganchaba momentáneamente o perdía velocidad. El Composite Collider resuelve esto fundiendo todos los tiles en una sola geometría continua, eliminando las juntas internas.

### ¿Por qué PlayerPrefs para la puntuación y no un GameManager persistente?

Un `GameManager` con `DontDestroyOnLoad` es más elegante en proyectos grandes, pero introduce complejidad al reiniciar partidas: hay que destruir y recrear la instancia, o resetear todos sus valores manualmente. Para un juego de escala académica, `PlayerPrefs` es más simple, más robusto ante reinicios, y suficiente para la cantidad de datos que se transfieren entre escenas.

### ¿Por qué OverlapCircle para la detección de suelo en lugar de OnCollisionStay?

`OnCollisionStay` puede generar falsos positivos al rozar paredes laterales, haciendo que el jugador pueda saltar mientras está pegado a una pared vertical. `OverlapCircle` en la base del personaje es más predecible y fácil de depurar visualmente con `Gizmos.DrawWireSphere` durante el desarrollo.

### ¿Por qué TextMeshPro en lugar del Text estándar de Unity?

El componente `Text` de Unity Legacy presenta problemas de nitidez en resoluciones no estándar y opciones de estilizado limitadas. TextMeshPro ofrece renderizado vectorial (SDF), outline y shadow nativos sin shaders adicionales, y es el estándar recomendado por Unity desde 2018.

*Documentación técnica elaborada para el Proyecto Integrador de 2º DAM.*  
*Spirit Fox © 2026 – Proyecto académico.*
