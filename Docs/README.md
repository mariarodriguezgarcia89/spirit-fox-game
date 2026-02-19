# 🦊 Spirit Fox

![Unity](https://img.shields.io/badge/Unity-2D%20LTS-black?logo=unity) ![Platform](https://img.shields.io/badge/Platform-Windows-blue) ![Language](https://img.shields.io/badge/Language-C%23-purple) ![Status](https://img.shields.io/badge/Status-Completed-brightgreen)

## 🎮 Sobre el juego

**Spirit Fox** es un videojuego de plataformas 2D desarrollado en Unity en el que controlas a un zorro mágico que debe ascender a través de un bosque encantado. Recoge manzanas, esquiva o elimina enemigos y llega a la cima antes de que se acabe el tiempo.

Desarrollado individualmente como Proyecto Integrador de **2º DAM (Desarrollo de Aplicaciones Multiplataforma)**.

## ▶️ Cómo jugar

### Descarga
Descarga el ejecutable desde la sección [Releases](../../releases) de este repositorio.

### Controles

| Moverse | `A / D` o flechas `← →` |
| Saltar | `Espacio` |
| Eliminar enemigo | Saltar encima de él |

### Objetivo
- Llega a la **caja mágica** en la parte superior del nivel
- Recoge el mayor número de **manzanas** posible (+10 puntos cada una)
- Tienes **60 segundos** y **3 vidas**

## 🕹️ Características

- **Movimiento fluido con fall multiplier** para un salto expresivo y natural
- **Enemigos con IA** — ranas que patrullan, detectan bordes y saltan aleatoriamente
- **Sistema de puntuación** con persistencia entre escenas
- **Temporizador de 60 segundos** con aviso visual al quedar poco tiempo
- **Efectos de partículas** al eliminar enemigos
- **Mariposas animadas** decorativas que refuerzan la atmósfera del bosque
- **4 pantallas completas**: Menú principal, Juego, Victoria y Game Over
- **Sistema de audio centralizado** con música y efectos de sonido

## 🗂️ Estructura del repositorio

```
/
├── Assets/              # Código fuente y assets del proyecto Unity
├── Build/               # Ejecutable Windows (.exe)
├── Docs/
│   ├── GDD.md           # Game Design Document
│   ├── Technical.md     # Arquitectura y decisiones técnicas
│   └── Postmortem.md    # Registro de bugs y aprendizajes
└── README.md
```

## 📄 Documentación

| [GDD.md](Docs/GDD.md) | Concepto, género, referencias, mecánicas y relación con la historia del videojuego |
| [Technical.md](Docs/Technical.md) | Arquitectura del código, sistemas, físicas y decisiones técnicas justificadas |
| [Postmortem.md](Docs/Postmortem.md) | Registro cronológico de los 11 bugs encontrados y resueltos durante el desarrollo |

## 🛠️ Tecnologías

- **Motor:** Unity 2D (LTS)
- **Lenguaje:** C#
- **UI:** TextMeshPro
- **Control de versiones:** Git + GitHub
- **Assets de audio:** [Freesound.org](https://freesound.org) (licencias Creative Commons)
- **Assets visuales:** Pixel Adventure (itch.io) + fondos generados con IA

## 📚 Referencias e inspiraciones

- **Super Mario Bros** (Nintendo, 1985) — estructura de plataformas y recolección
- **The Legend of Zelda: Ocarina of Time** (Nintendo, 1998) — atmósfera de bosque mágico
- **Ori and the Blind Forest** (Moon Studios, 2015) — protagonista animal en entorno encantado
- **Hollow Knight** (Team Cherry, 2017) — feedback visual y diseño de enemigos

## 👩‍💻 Autora

**María Rodríguez García**  
2º DAM · Desarrollo de Aplicaciones Multiplataforma  
Proyecto Integrador — Febrero 2026

*Spirit Fox © 2026 – Proyecto académico.*
