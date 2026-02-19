# 🦊 GDD – Spirit Fox
**Game Design Document v1.0**  
**Autor:** María Rodríguez  
**Módulo:** Desarrollo de Aplicaciones Multiplataforma – 2º DAM  
**Motor:** Unity 2D (LTS)  
**Fecha:** Febrero 2026

## Índice

1. [Concepto del juego](#1-concepto-del-juego)
2. [Género y subgénero](#2-género-y-subgénero)
3. [Público objetivo](#3-público-objetivo)
4. [Referencias e inspiraciones](#4-referencias-e-inspiraciones)
5. [Mecánicas principales](#6-mecánicas-principales)
6. [Personaje principal](#7-personaje-principal)
7. [Enemigos](#8-enemigos)
8. [Mundo y nivel](#9-mundo-y-nivel)
9. [HUD e Interfaz de Usuario](#10-hud-e-interfaz-de-usuario)
10. [Audio](#11-audio)
11. [Relación con el Tema 5 – Historia y evolución del videojuego](#12-relación-con-el-tema-5--historia-y-evolución-del-videojuego)

## 1. Concepto del juego

**Spirit Fox** es un videojuego de plataformas 2D en el que el jugador controla a un zorro mágico que debe ascender a través de un bosque encantado, recolectando manzanas y superando enemigos para alcanzar la cima.

El juego combina la jugabilidad clásica de plataformas de desplazamiento vertical con una estética natural y atmosférica. La experiencia busca transmitir sensación de aventura, tranquilidad y fluidez. 

## 2. Género y subgénero

| **Género principal** | Plataformas 2D | 
| **Subgénero** | Plataformas de desplazamiento vertical / Arcade de exploración | 
| **Perspectiva** | Vista lateral 2D | 
| **Modo de juego** | Un jugador | 

## 3. Público objetivo

- **Edad:** 10–30 años
- **Perfil:** Jugadores casuales y fans del género plataformas que disfrutan de juegos con atmósfera tranquila.
- **Experiencia requerida:** Ninguna — curva de aprendizaje suave, controles intuitivos.
- **Plataforma objetivo:** PC (Windows)

## 4. Referencias e inspiraciones

### Super Mario Bros (Nintendo, 1985)
La referencia fundacional del género. De Mario se toma la estructura de niveles basada en plataformas, la recolección de objetos como mecánica central y la progresión por zonas con enemigos que siguen patrones predefinidos. Spirit Fox adapta este esquema a una dirección vertical en lugar de horizontal.

### The Legend of Zelda: Ocarina of Time (Nintendo, 1998)
La aldea Kokiri y el Bosque Perdido de Zelda son la inspiración directa para la ambientación de Spirit Fox. La idea de un bosque mágico habitado por seres mágicos, con una atmósfera misteriosa pero no amenazante, define la identidad visual y narrativa del juego. Spirit Fox reimagina esta estética en 2D con un lenguaje visual de pixel art más moderno.

### Ori and the Blind Forest (Moon Studios, 2015)
La referencia más cercana en espíritu (nunca mejor dicho). Ori comparte con Spirit Fox el protagonista animal en un bosque encantado, la paleta de colores luminosos sobre fondos oscuros, y la sensación de movimiento ágil y expresivo. De Ori se toma la inspiración para el diseño visual del personaje y la importancia de transmitir emoción a través del movimiento.

## 5. Mecánicas principales

### Core Gameplay Loop

Entrar al nivel → Moverse y saltar entre plataformas → Recolectar gemas → 
Evitar o eliminar enemigos → Llegar a la zona final → Victoria

Si el jugador pierde toda la vida o el tiempo llega a cero, se muestra la pantalla de derrota y puede reiniciar.

### Movimiento del jugador

| Moverse izquierda/derecha | `A/D` o flechas | Velocidad horizontal: `8f` |
| Saltar | `Espacio` | Fuerza de salto: `16f` aplicada como impulso en Rigidbody2D |
| Caída acelerada | Automático | Fall multiplier: `×2.5` sobre la gravedad base para caída más natural |
| Baja gravedad ascendente | Automático | Low jump multiplier: `×2f` al soltar el botón de salto antes del peak |

**Sistema de detección de suelo:** Se utiliza un `Physics2D.OverlapCircle` en la base del personaje con radio `0.2f` sobre la capa `Ground`. Solo se puede saltar cuando `isGrounded == true`.

**Sprite flip automático:** El sprite del personaje se voltea horizontalmente según la dirección de movimiento (`transform.localScale.x = ±1`).

###  Sistema de combate / interacción con enemigos

| Jugador toca enemigo lateralmente | Pierde 1 punto de vida, knockback aplicado |
| Jugador cae sobre enemigo (desde arriba) | Enemigo destruido, partículas de derrota |
| Jugador sin vida | Game Over, carga pantalla de derrota |

El knockback se aplica directamente sobre el `Rigidbody2D` del jugador con una fuerza fija en dirección contraria al enemigo.

### Recolección de manzanas

- Las manzanas son `Triggers` con `OnTriggerEnter2D`
- Al recogerlas suman **+10 puntos** al marcador
- Se destruye el objeto con `Destroy(gameObject)`
- La puntuación se guarda en `PlayerPrefs` antes de cada transición de escena para persistir entre escenas

### Sistema de tiempo

- Temporizador de cuenta regresiva iniciado en **60 segundos**
- Se actualiza cada frame: `tiempoRestante -= Time.deltaTime`
- Aviso visual cuando quedan ≤15 segundos (texto cambia de color)
- Al llegar a 0: se lanza el evento de Game Over
- El tiempo restante se guarda en `PlayerPrefs` y se muestra en la pantalla de victoria

### Condiciones de victoria y derrota

| Jugador llega a la zona de meta | Victoria – carga `VictoryScene` |
| Jugador pierde toda la vida (3 puntos) | Derrota – carga `GameOverScene` |
| El temporizador llega a 0 | Derrota – carga `GameOverScene` |

## 7. Personaje principal

**Nombre:** Spirit Fox  
**Descripción:** Un zorro pequeño y ágil con un pelaje de tonos granates y una cola grande y expresiva que refleja su estado emocional.

| Idle | Loop de respiración suave | Velocidad horizontal ≈ 0 y en suelo |
| Running | Ciclo de carrera de 4 frames | Velocidad horizontal > 0.1 y en suelo |
| Jumping | Frame de salto | `isGrounded == false` |

El Animator Controller gestiona las transiciones mediante parámetros `Bool` (`isRunning`, `isGrounded`) actualizados cada frame desde el script del jugador.

**Vida:** 3 puntos. Se representa visualmente en el HUD mediante iconos de corazón.

## 8. Enemigos

### Rana Encantada (Frog Enemy)

El único tipo de enemigo presente en la versión actual del juego.

| Tipo de movimiento | Patrulla horizontal entre dos puntos |
| Velocidad de patrulla | `2f` |
| Comportamiento adicional | Salto aleatorio cada 2–5 segundos |
| Detección de bordes | Raycast hacia abajo; invierte dirección al detectar vacío |
| Daño al jugador | 1 punto de vida al contacto lateral |
| Derrota | Salto encima del enemigo; se destruye con efecto de partículas |

**Sistema de IA:**
La rana usa un patrón de máquina de estados simple:
- **Estado Patrulla:** Se mueve horizontalmente, invierte al llegar al borde o a una pared.
- **Estado Salto:** Activado por corrutina con tiempo aleatorio (`Random.Range(2f, 5f)`), aplica fuerza vertical al Rigidbody2D.

## 9. Mundo y nivel

### Estructura general

El nivel es de **desplazamiento vertical**: el jugador comienza en la parte inferior del mapa y debe ascender hasta la zona de meta en la parte superior.

La cámara sigue al jugador con límites (`confiner`) que impiden mostrar zonas fuera del fondo del escenario.

### Elementos del escenario

| Plataformas principales | Tiles sólidos con `Composite Collider 2D` para optimizar físicas |
| Plataformas flotantes | Prefabs con `Platform Effector 2D` (solo colisión desde arriba) |
| Fondo | Imagen de bosque encantado generada con IA, aplicada como `Sprite Renderer` en capa de fondo |
| Mariposas decorativas | Sprites animados que se mueven de izquierda a derecha con posición Y aleatoria, destruidos al salir de cámara y reaparecidos al otro lado |
| Manzanas | Prefabs con trigger, distribuidas por el nivel a distintas alturas |
| Zona de meta | Trigger en la parte superior del mapa que activa la transición a victoria |

### Paleta visual

- Fondos: verde oscuro, azul noche, tonos morados
- Plataformas: tierra y roca con vegetación pixel art
- Personaje: granate, naranja y blanco
- Manzanas: rojas y naturales

## 10. HUD e Interfaz de Usuario

### Escenas

| `MainMenu` | Menú principal con título, botón de jugar y fondo animado |
| `GameScene` | Escena de juego principal |
| `VictoryScene` | Pantalla de victoria con puntuación y tiempo |
| `GameOverScene` | Pantalla de derrota con opción de reintentar |

### HUD durante el juego

| Puntuación | Arriba izquierda | TextMeshPro con icono de gema, panel decorativo detrás |
| Tiempo restante | Arriba derecha | Cuenta atrás en segundos, cambia de color al <15s |
| Vida (corazones) | Arriba centro | 3 iconos de corazón; se desactivan al perder vida |

Todos los elementos de UI usan **TextMeshPro** con outline para legibilidad sobre fondos complejos. La gestión del HUD está centralizada en el `UIManager`.

## 11. Audio

El sistema de audio está centralizado en un `AudioManager` implementado como Singleton que persiste entre escenas (`DontDestroyOnLoad`).

| Música de menú | BGM en loop | Pantalla principal |
| Música de juego | BGM en loop | Durante la partida |
| Recolección de manzanas | SFX | Al tocar una gema |
| Salto | SFX | Al ejecutar el salto |
| Daño recibido | SFX | Al perder vida |
| Derrota de enemigo | SFX | Al eliminar una rana |
| Victoria / Derrota | SFX | Al cargar la escena correspondiente |

## 12. Relación con el Tema 5 – Historia y evolución del videojuego

Spirit Fox no existe en un vacío: es el resultado directo de décadas de evolución del videojuego, y sus decisiones de diseño dialogan conscientemente con esa historia.

### El origen del plataformas: Donkey Kong y Mario (1981–1985)

El género de plataformas nació con **Donkey Kong** (Nintendo, 1981), donde por primera vez el movimiento vertical y el salto se convirtieron en la mecánica central. **Super Mario Bros** (1985) perfeccionó la fórmula introduciendo el desplazamiento lateral, los enemigos con patrones simples y la recolección de ítems como fuente de puntuación.

Spirit Fox hereda directamente de esta tradición: el salto como mecánica principal, las plataformas como puzzle espacial, y las gemas como recompensa de exploración son elementos que llevan 40 años definiendo el género.

### La evolución hacia la narrativa y la atmósfera (años 90–2000s)

Con **Zelda: Ocarina of Time** (1998) y otros títulos de la era 3D, los videojuegos demostraron que un mundo podía tener alma propia. La aldea Kokiri, rodeada de un bosque eterno y misterioso, estableció que un entorno de juego podía transmitir emociones sin necesidad de texto o cinemáticas.

Spirit Fox aplica esta lección al diseño de su único nivel: la progresión de oscuridad a luz no es decorativa, es narrativa.

### El indie renaissance y la vuelta al pixel art (2010s)

La llegada de plataformas digitales como Steam y la proliferación de motores accesibles como Unity generaron a partir de 2010 un renacimiento del juego indie. Títulos como **Celeste** (2018) o **Ori and the Blind Forest** (2015) demostraron que pequeños equipos podían crear experiencias con impacto emocional comparable al de grandes estudios, recuperando la estética pixel art y los controles precisos de los clásicos con una capa de profundidad emocional nueva.

Spirit Fox pertenece a esta generación: desarrollado individualmente con Unity, assets de pixel art, y una propuesta estética personal, encarna exactamente el espíritu del desarrollo indie contemporáneo que el Tema 5 describe.

### Conclusión

Spirit Fox es un juego que mira al pasado con respeto y al presente con ambición. Cada decisión de diseño — desde el salto físico con fall multiplier hasta las mariposas decorativas — tiene detrás una historia de cuarenta años de diseño de videojuegos que este proyecto trata de honrar y, en su pequeña medida, continuar.

---

*Documento elaborado para el Proyecto Integrador de 2º DAM.*  
*Spirit Fox © 2026 – Proyecto académico.*
