# 🦊✨ Spirit Fox: The Enchanted Forest

> Un viaje contemplativo por un bosque mágico donde restauras el equilibrio como un zorro espiritual

![Unity](https://img.shields.io/badge/Unity-2022.3_LTS-black?style=flat-square&logo=unity)
![Platform](https://img.shields.io/badge/Platform-Windows-blue?style=flat-square)
![Genre](https://img.shields.io/badge/Genre-Platformer_2D-purple?style=flat-square)
![License](https://img.shields.io/badge/License-Educational-green?style=flat-square)

---

## 🌿 Descripción

**Spirit Fox** es un juego de plataformas 2D de exploración contemplativa donde encarnas a un zorro místico con una cola mágica radiante. Tu misión: atravesar un bosque encantado corrompido por energía oscura, purificando criaturas perdidas y restaurando el equilibrio natural.

Inspirado en **The Legend of Zelda: Ocarina of Time** y **Ori and the Blind Forest**, este proyecto fusiona mecánicas clásicas de plataformas con una atmósfera mágica y una estética única basada en tonos **granates, verdes profundos y luz dorada**.

Desarrollado como **Proyecto Integrador** del módulo de Desarrollo de Videojuegos (2º DAM).

---

## ✨ Características

- 🦊 **Protagonista único:** Zorro espiritual con una cola majestuosa y brillante
- 🌲 **Bosque encantado:** Explora ruinas antiguas cubiertas de vegetación mágica
- 🔮 **Puzzles contemplativos:** Activa piedras rúnicas para abrir caminos de luz
- 💎 **Esencias místicas:** Recolecta orbes de luz para restaurar el bosque
- 👤 **Purificación, no combate:** Libera criaturas corrompidas en lugar de destruirlas
- 🎨 **Estética única:** Paleta de granates y verdes con iluminación mágica dorada
- 🎵 **Atmósfera contemplativa:** Diseño sonoro que invita a la exploración pausada

---

## 🎮 Controles

| Acción | Tecla |
|--------|-------|
| Mover izquierda/derecha | ← → o A/D |
| Saltar | Espacio o W |
| Interactuar / Purificar | E o Z |
| Pausa | ESC |

### Mecánicas Especiales
- **Planeo con la cola:** Mantén Espacio en el aire para descender suavemente
- **Activar Piedras Rúnicas:** Toca 3 piedras para abrir caminos de luz
- **Purificar Sombras:** Acércate a criaturas corrompidas y presiona E

---

## 🚀 Cómo Jugar

### Opción 1: Descargar Ejecutable (Recomendado)

1. Ve a la sección [**Releases**](../../releases)
2. Descarga la última versión (`SpiritFox_v1.0.zip`)
3. Extrae el archivo ZIP
4. Ejecuta `SpiritFox.exe`
5. ¡Disfruta del bosque encantado! 🌟

### Opción 2: Compilar desde Código Fuente

**Requisitos:**
- Unity 2022.3 LTS o superior
- Windows 10/11
- Git (para clonar el repositorio)

**Pasos:**
```bash
# 1. Clonar el repositorio
git clone https://github.com/mariarodriguezgarcia89/spirit-fox-game.git

# 2. Abrir en Unity Hub
# - Abre Unity Hub
# - Add → Selecciona la carpeta del proyecto
# - Open Project

# 3. Jugar en el editor
# - Abre la escena MainMenu en Assets/Scenes/
# - Presiona Play ▶️

# 4. Generar build (opcional)
# - File → Build Settings
# - Platform: Windows
# - Build
```

---

## 📂 Estructura del Proyecto

```
SpiritFox/
├── Assets/
│   ├── Scenes/              # Escenas del juego
│   │   ├── MainMenu.unity
│   │   ├── GameLevel.unity
│   │   ├── Victory.unity
│   │   └── GameOver.unity
│   ├── Scripts/             # Código C#
│   │   ├── Player/
│   │   ├── Enemies/
│   │   ├── Collectibles/
│   │   ├── Systems/
│   │   ├── UI/
│   │   └── Camera/
│   ├── Sprites/             # Arte 2D
│   │   ├── Player/          # Zorro y animaciones
│   │   ├── Enemies/         # Sombras, espinas
│   │   ├── Environment/     # Plataformas, ruinas, vegetación
│   │   ├── Collectibles/    # Esencias, corazones
│   │   └── UI/              # Iconos, botones
│   ├── Prefabs/             # Objetos reutilizables
│   ├── Audio/               # Música y efectos de sonido
│   │   ├── Music/
│   │   └── SFX/
│   ├── Animations/          # Controladores de animación
│   └── Materials/           # Materiales y shaders
├── Builds/                  # Ejecutables compilados
├── Docs/                    # Documentación del proyecto
│   ├── GDD.md              # Game Design Document
│   ├── Technical.md        # Documentación técnica
│   └── Postmortem.md       # Reflexión post-desarrollo
├── .gitignore              # Archivos ignorados por Git
└── README.md               # Este archivo
```

---

## 🛠️ Tecnologías y Herramientas

### Motor y Lenguaje
- **Unity 2022.3 LTS** - Motor de juego
- **C#** - Lenguaje de programación

### Control de Versiones
- **Git** - Sistema de control de versiones
- **GitHub** - Repositorio remoto y colaboración

### Herramientas de Desarrollo
- **Visual Studio Code / Visual Studio** - Editor de código
- **Unity Asset Store / itch.io** - Recursos gráficos y audio

---

## 📚 Documentación

### 📋 Diseño
- [**Game Design Document (GDD)**](Docs/GDD.md)
  - Concepto completo del juego
  - Mecánicas y sistemas
  - Referencias y contexto histórico
  - Plan de desarrollo

### ⚙️ Técnica
- [**Documentación Técnica**](Docs/Technical.md)
  - Arquitectura de scripts
  - Decisiones técnicas
  - Assets utilizados (con créditos)
  - Guía de instalación

### 📝 Reflexión
- [**Postmortem**](Docs/Postmortem.md)
  - Qué funcionó bien
  - Desafíos encontrados
  - Aprendizajes clave
  - Mejoras futuras

---

## 🎯 Requisitos del Proyecto Cumplidos

### ✅ Diseño y Concepto (Tema 5)
- [x] Género definido: Plataformas 2D / Aventura / Puzzle
- [x] Público objetivo: Jugadores que disfrutan exploración contemplativa
- [x] Referencias: Zelda OoT, Ori and the Blind Forest, Journey, Gris
- [x] Mecánicas: Exploración, puzzles, purificación, recolección
- [x] Contexto histórico: Relación con evolución del género de plataformas

### ✅ Desarrollo Técnico (Tema 6)
- [x] **Escenas independientes:**
  - MainMenu (menú principal)
  - GameLevel (nivel jugable)
  - Victory (pantalla de victoria)
  - GameOver (pantalla de derrota)
- [x] **Jugador controlable:**
  - Movimiento fluido (Input System)
  - Físicas con Rigidbody2D
  - Colisiones correctas
- [x] **Sistema de cámara:**
  - Seguimiento suave del jugador
  - FOV adecuado para plataformas 2D
- [x] **Enemigos y obstáculos:**
  - Sombras Errantes (IA de patrullaje)
  - Espinas venenosas (obstáculos estáticos)
  - Interacción real (daño al jugador)
- [x] **HUD / Interfaz:**
  - Indicadores de vida (corazones)
  - Contador de puntuación (esencias)
  - Feedback visual claro
- [x] **Animaciones:**
  - Animator para el zorro (idle, walk, jump)
  - Transiciones suaves
- [x] **Build ejecutable:**
  - Windows (.exe funcional)

---

## 🎨 Identidad Visual

### Paleta de Colores
El juego utiliza una paleta única inspirada en tonos naturales y mágicos:

| Color | Hex | Uso |
|-------|-----|-----|
| **Granate Profundo** | `#722F37` | Zorro, ruinas antiguas |
| **Verde Bosque** | `#2D5016` | Vegetación, plataformas |
| **Dorado Cálido** | `#D4AF37` | Luz mágica, esencias |
| **Púrpura Místico** | `#7B2869` | Energía mágica, cielo |
| **Verde Esmeralda** | `#50C878` | Vida, purificación |

### Inspiración Artística
- **Ori and the Blind Forest** - Iluminación y atmósfera
- **The Legend of Zelda** - Diseño de templos y puzzles
- **Spirit (película)** - Estilo artístico de naturaleza
- **Gris** - Narrativa visual emocional

---

## 📊 Estado del Desarrollo

### Completado ✅
- [x] Diseño conceptual (GDD)
- [x] Prototipo de movimiento
- [x] Sistema de cámara
- [x] Nivel principal diseñado
- [x] Enemigos con IA básica
- [x] Sistema de vida y puntuación
- [x] UI completa (menús + HUD)
- [x] Build ejecutable Windows

### En Progreso 🔄
- [ ] Animaciones avanzadas del zorro
- [ ] Partículas mágicas en la cola
- [ ] Audio completo (música + SFX)

### Planeado para el Futuro 🌟
- [ ] Segundo nivel (Caverna Cristalina)
- [ ] Sistema de power-ups (cola con nuevas habilidades)
- [ ] Modo desafío (speedrun)
- [ ] Parallax multicapa en el fondo
- [ ] Efectos de iluminación dinámica

---

## 🐛 Problemas Conocidos

_(Se actualizará durante el desarrollo)_

- Ninguno reportado hasta el momento

**¿Encontraste un bug?** Abre un [Issue](../../issues) en GitHub describiendo:
1. Qué estabas haciendo
2. Qué esperabas que pasara
3. Qué pasó en realidad
4. Captura de pantalla (si aplica)

---

## 🔮 Roadmap Futuro

### v1.1 - Pulido Visual (Post-entrega)
- Partículas avanzadas
- Parallax de 3 capas
- Iluminación dinámica con luces puntuales
- Vegetación interactiva (hierba que se mueve al pasar)

### v1.2 - Expansión de Contenido
- Nivel 2: "Caverna Cristalina"
- Nuevas criaturas para purificar
- Power-up: "Doble Salto"

### v2.0 - Características Avanzadas
- Sistema de guardado automático
- Logros/Achievements
- Modo foto (para capturar momentos del bosque)
- Música original compuesta específicamente

---

## 🙏 Créditos y Agradecimientos

### Desarrollo
- **Diseño y Programación:** [Tu nombre]
- **Game Design:** [Tu nombre]
- **Dirección Artística:** [Tu nombre]

### Assets de Terceros
_(Se completará durante el desarrollo)_

**Sprites:**
- [Nombre del asset] por [Autor] - [Licencia]
- Fuente: [URL]

**Audio:**
- [Nombre de la pista] por [Compositor] - [Licencia]
- Fuente: [URL]

**Fuentes:**
- [Nombre de la fuente] - [Licencia]

### Inspiración y Referencias
- Nintendo (The Legend of Zelda series)
- Moon Studios (Ori and the Blind Forest)
- Nomada Studio (Gris)
- Thatgamecompany (Journey)

### Agradecimientos Especiales
- Profesor/a del módulo de Desarrollo de Videojuegos por la guía
- Comunidad de Unity por tutoriales y documentación
- Familia y amigos por el apoyo durante el desarrollo

---

## 📜 Licencia

Este proyecto fue desarrollado con fines **educativos** como parte del ciclo formativo de **Desarrollo de Aplicaciones Multiplataforma (DAM)**.

Los assets de terceros utilizados están sujetos a sus respectivas licencias (ver sección de Créditos y documentación técnica para detalles completos).

El código fuente desarrollado para este proyecto está disponible bajo licencia MIT (ver archivo LICENSE para más detalles).

---

## 📧 Contacto

**María Rodríguez García**
- 🎓 Estudiante de 2º DAM
- 💼 GitHub: [mariarodriguezgarcia89](https://github.com/mariarodriguezgarcia89)
- 📧 Email: rodriguezgarciamaria89@gmail.com
- 🎮 Proyecto: Spirit Fox: The Enchanted Forest

---

## 🌟 Detrás del Proyecto

**¿Por qué un zorro espiritual?**  
Este proyecto nació de una visión personal: crear una experiencia que refleje la conexión con la naturaleza y la magia de los bosques. El zorro, con su astucia y gracia, representa el equilibrio entre lo salvaje y lo místico.

**¿Por qué granate?**  
El granate es más que un color - es una elección que rompe con los tonos típicos de juegos de fantasía, creando una identidad visual única y personal.

**La filosofía del juego:**  
En lugar de combatir y destruir, en Spirit Fox **purificamos y restauramos**. No eres un conquistador, sino un guardián. Esta decisión de diseño refleja una visión más contemplativa de qué pueden ser los videojuegos.

---

<div align="center">

**🦊 Desarrollado con ❤️ y magia del bosque ✨**

![Spirit Fox](https://img.shields.io/badge/Spirit_Fox-The_Enchanted_Forest-722F37?style=for-the-badge)

*"En cada sombra purificada, el bosque respira luz de nuevo."*

---

### 🌲 ¡Gracias por explorar el bosque encantado! 🌲

</div>
