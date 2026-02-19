# 🪲 Postmortem – Spirit Fox
**Registro de Problemas y Soluciones**  
**Autor:** María Rodríguez García 
**Módulo:** Desarrollo de Aplicaciones Multiplataforma – 2º DAM  
**Motor:** Unity 2D (LTS)  
**Fecha:** Febrero 2026

---

## Introducción

Este documento recoge cronológicamente los bugs y problemas técnicos encontrados durante el desarrollo de Spirit Fox. El proyecto duró 18 días partiendo de cero conocimiento de Unity, por lo que la mayoría de los problemas reflejan la curva de aprendizaje natural del motor.

---

## Registro de bugs

| # | Bug | Fase | Causa raíz | Solución |
|---|---|---|---|---|
| 1 | Escenas no cargaban al pulsar "Jugar" | Días 3–4 | Escenas no registradas en Build Settings | Añadir todas las escenas a `File → Build Settings` con MainMenu en índice 0 |
| 2 | BoxCollider gigante en el personaje | Días 3–4 | Collider automático tomaba el spritesheet completo | Reconfigurar manualmente Size a `0.8 / 1.0` y resetear masa del Rigidbody2D a `1` |
| 3 | Personaje flotando sobre el suelo | Días 4–5 | Offset Y del collider en 0, base visual no coincidía con base física | Ajustar Offset Y a `0.5` para alinear los pies del sprite con el suelo |
| 4 | Techo invisible impedía saltar | Días 5–6 | Collider sobrante en objeto de fondo sin colisión intencionada | Localizar y desactivar el collider con Gizmos activados en vista Scene |
| 5 | Enemigos caían de plataformas o flotaban | Días 6–7 | Colliders y Raycast de detección de bordes mal dimensionados | Reajustar colliders y longitud del Raycast a la escala real de los objetos |
| 6 | Partículas de derrota invisibles | Días 9–10 | Sorting Layer incorrecto y Position X en -100 por valor residual | Subir Order in Layer a `10` y resetear posición del prefab a `(0, 0, 0)` |
| 7 | Conflicto visual Canvas UI vs Sprite Renderers | Días 11–12 | Paneles decorativos mezclaban sistemas de renderizado incompatibles | Mantener todos los elementos HUD dentro del Canvas en modo Screen Space Overlay |
| 8 | Cursor visible en el ejecutable | Días 15–16 | `Cursor.visible = false` no persistía en el build ante eventos de foco de ventana | Gestionar cursor explícitamente en el `Awake()` de cada escena |
| 9 | Puntuación en 0 en pantalla de victoria | Días 15–16 | Variable del UIManager destruida al cambiar de escena | Guardar puntuación en `PlayerPrefs` antes de la transición y recuperarla en VictoryScene |
| 10 | Fallo al iniciar desde GameLevel directamente | Días 16–17 | Managers globales solo instanciados en MainMenu con DontDestroyOnLoad | Implementar patrón Singleton con auto-instanciación en todos los managers críticos |
| 11 | Cámara cortando el fondo | Días 14–15 | Límites calculados sin compensar el `orthographicSize` de la cámara | Restar `camHalfHeight` y `camHalfWidth` a los límites para que el área visible no salga del fondo |

---

## Aprendizajes clave

**Configuración antes de código.** Varios bugs (colliders gigantes, escenas no registradas, sorting layers) se habrían evitado verificando la configuración de Unity antes de escribir lógica. Comprobar los gizmos en vista Scene es el primer paso ante cualquier problema de física o colisiones.

**El build no es el editor.** Comportamientos como el cursor o la inicialización de managers pueden funcionar correctamente en el editor y fallar en el ejecutable. Probar el build con frecuencia durante el desarrollo evita acumular sorpresas al final.

**El ciclo de vida de las escenas.** En Unity, cambiar de escena destruye todos los objetos. Cualquier dato que deba cruzar escenas necesita `PlayerPrefs`, `DontDestroyOnLoad` o un sistema de guardado explícito — nunca se puede asumir que una variable seguirá existiendo.

---

*Documentación postmortem elaborada para el Proyecto Integrador de 2º DAM.*  
*Spirit Fox © 2026 – Proyecto académico.*
