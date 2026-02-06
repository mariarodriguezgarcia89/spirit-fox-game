# Game Design Document (GDD)
## Spirit Fox: The Enchanted Forest 🦊✨

---

## 1. Información General

**Título:** Spirit Fox: The Enchanted Forest  
**Género:** Plataformas 2D / Aventura / Puzzle  
**Plataforma:** PC (Windows)  
**Motor:** Unity (2D)  
**Público objetivo:** Jugadores que disfrutan de experiencias contemplativas, exploración y conexión con la naturaleza  
**Equipo:** [Tu nombre]  
**Fecha:** Febrero 2026

---

## 2. Concepto del Juego

### 2.1 Elevator Pitch
Eres un zorro espiritual con una cola mágica luminosa que debe restaurar el equilibrio de un bosque encantado, explorando ruinas antiguas cubiertas de vegetación, resolviendo puzzles ancestrales y purificando criaturas corrompidas por energía oscura.

### 2.2 Pilares del Diseño
1. **Exploración Contemplativa:** Un mundo que invita a detenerse, observar y descubrir
2. **Conexión con la Naturaleza:** Mecánicas que refuerzan la armonía con el entorno
3. **Estética Mística:** Paleta de granates, verdes profundos y luz dorada que crea atmósfera mágica
4. **Puzzles Intuitivos:** Desafíos basados en observación y lógica natural, no en reflejos

### 2.3 Identidad Visual
**Paleta de Colores Principal:**
- **Granate profundo** (#722F37) - Color principal del zorro, piedras antiguas
- **Verde bosque** (#2D5016) - Vegetación, árboles, plataformas
- **Dorado cálido** (#D4AF37) - Luz mágica, esencias, efectos
- **Verde esmeralda** (#50C878) - Vegetación brillante, vida
- **Púrpura místico** (#7B2869) - Energía mágica, auras

**Referencias Visuales:**
- Ori and the Blind Forest (iluminación, atmósfera)
- The Legend of Zelda: Ocarina of Time (templos, puzzles)
- Spirit (la película) - estilo artístico de naturaleza
- Gris (estética minimalista pero emocional)

---

## 3. Referencias y Contexto (Tema 5)

### 3.1 Referencias de Juegos Existentes

**Mecánicas de Exploración:**
- **The Legend of Zelda: Ocarina of Time** - Exploración de templos, puzzles ambientales
- **Ori and the Blind Forest** - Movimiento fluido, conexión emocional con el entorno
- **Celeste** - Plataformas precisas, sensación de control

**Estética y Atmósfera:**
- **Gris** - Narrativa visual sin palabras, arte emocional
- **Journey** - Experiencia contemplativa, belleza minimalista
- **Hollow Knight** - Exploración de mundo interconectado, criaturas místicas

### 3.2 Relación con la Historia del Videojuego

Este proyecto se inspira en dos tradiciones fundamentales del videojuego:

**1. La tradición de Aventuras de Exploración (años 90-2000s):**
Hereda de Zelda el concepto de "templos/dungeons" como espacios de puzzles donde el jugador debe usar observación y lógica. Estos juegos establecieron que la exploración puede ser tan gratificante como la acción.

**2. El movimiento Indie de Juegos Artísticos (2010s):**
Juegos como Journey, Ori y Gris demostraron que los videojuegos pueden ser experiencias contemplativas y emocionales sin necesitar combate violento o narrativas complejas. El diseño visual y la atmósfera se convierten en protagonistas.

**Innovación del Proyecto:**
Fusiona la estructura clásica de plataformas 2D con una narrativa ambiental (environmental storytelling) donde el bosque mismo cuenta su historia a través de ruinas, luz y vegetación. El protagonista no es un héroe conquistador, sino un espíritu restaurador que trabaja EN ARMONÍA con la naturaleza.

---

## 4. Narrativa y Ambientación

### 4.1 Historia (Minimalista - Contada Visualmente)

**Premisa:**
Un antiguo bosque mágico ha sido corrompido por una energía oscura. Las criaturas que antes protegían el bosque ahora vagan confundidas. Tú eres un zorro espiritual, guardián ancestral del bosque, que despierta para restaurar el equilibrio.

**Estructura Narrativa:**
- **Inicio:** El zorro despierta en un claro iluminado (zona tutorial)
- **Desarrollo:** Atraviesa el bosque, purifica criaturas, activa altares antiguos
- **Clímax:** Alcanza el Árbol Ancestral (meta del nivel)
- **Cierre:** El bosque recupera su luz, flores brotan

**Sin Diálogos:** La historia se cuenta a través de:
- Cambios visuales en el entorno (de oscuro a luminoso)
- Animaciones y comportamiento del zorro
- Partículas de luz que guían sutilmente
- Música y sonido ambiental

### 4.2 El Protagonista: Spirit Fox

**Apariencia:**
- Zorro estilizado con proporciones semi-realistas
- Color principal: **Granate profundo** con marcas doradas
- **Cola ENORME y majestuosa** con efecto de luz/partículas
- Ojos expresivos color ámbar brillante
- Aura sutil de energía mágica

**Personalidad (a través de animación):**
- Curioso: olfatea el aire, mira alrededor
- Grácil: movimientos fluidos y elegantes
- Conectado: reacciona al entorno (mira pájaros, flores)
- Sabio: pausas contemplativas antes de puzzles

---

## 5. Mecánicas de Juego

### 5.1 Core Gameplay Loop
1. Exploras el bosque saltando entre plataformas naturales
2. Observas el entorno para encontrar puzzles y secretos
3. Recolectas Esencias de Luz (orbes mágicos)
4. Activas Piedras Rúnicas para abrir caminos
5. Purificas criaturas corrompidas (no las "matas")
6. Alcanzas el Árbol Ancestral para completar el nivel

### 5.2 Controles

**Movimiento:**
- **Flechas ← →** o **A/D**: Caminar/correr
- **Espacio** o **W**: Saltar
- **Espacio (mantener)**: Planeo suave con la cola (descenso lento)

**Interacción:**
- **E** o **Z**: Interactuar con altares/piedras rúnicas
- **E** (cerca de criatura corrompida): Purificar

**Sistema:**
- **ESC**: Pausa

### 5.3 Sistemas del Juego

#### Sistema de Esencias (Puntuación)

**Esencias de Luz** (orbes flotantes):
- **Pequeña (blanca):** +10 puntos - Común en el camino
- **Mediana (dorada):** +25 puntos - En lugares ligeramente ocultos
- **Grande (púrpura):** +50 puntos - Secretos bien escondidos
- **Flor Ancestral:** +100 puntos - Una por nivel, muy escondida

Las esencias no solo dan puntos, tienen **propósito narrativo**: representan la energía vital del bosque que el zorro está restaurando.

#### Sistema de Vida

**Corazones de Vida:** ❤️❤️❤️
- Inicio: 3 corazones
- Perder vida: Tocar zonas de corrupción oscura o espinas venenosas
- Recuperar: Flores de Sanación (corazón flotante)

**Nota de Diseño:** El juego NO es sobre combate, así que las amenazas son ambientales (trampas, zonas tóxicas) no enemigos agresivos.

#### Sistema de Puzzles

**Piedras Rúnicas:**
- Están dispersas por el nivel
- Cuando el zorro las toca, su cola BRILLA y activa la piedra
- 3 piedras activas = Se abre un camino/puente de luz

**Plataformas de Luz:**
- Aparecen temporalmente cuando activas un altar
- Debes usarlas antes de que desaparezcan (15 segundos)

**Caminos Ocultos:**
- Enredaderas que se apartan al acercarte
- Muros ilusorios que brillan sutilmente

#### Criaturas del Bosque

**Filosofía:** No hay "enemigos", solo criaturas confundidas que necesitan ayuda.

**1. Sombras Errantes** 👤
- Apariencia: Siluetas oscuras con ojos tristes
- Comportamiento: Patrullan lentamente de lado a lado
- Purificación: Acércate y presiona E → Se convierten en mariposas de luz
- Recompensa: Sueltan esencia mediana
- Daño: Si te tocan ANTES de purificar (-1 corazón)

**2. Espinas Venenosas** 🌿
- Apariencia: Plantas con aura púrpura oscura
- Comportamiento: Estáticas, pero peligrosas al contacto
- Purificación: No se pueden purificar, se EVITAN
- Daño: -1 corazón
- Diseño: Crean desafío de plataformas

**3. Luciérnagas Confundidas** ✨ (Opcional)
- Apariencia: Lucecitas que vuelan erráticamente
- Comportamiento: Movimiento impredecible en patrón circular
- No dañan: Son neutras, solo obstáculos visuales
- Purificación: Al purificar Sombras cercanas, las luciérnagas recuperan su luz dorada

---

## 6. Mundo y Niveles

### 6.1 Diseño del Nivel Principal
**Nombre:** "The Whispering Grove" (El Bosque Susurrante)

**Ambientación:**
- Bosque antiguo en penumbra mágica
- Ruinas de piedra cubiertas de musgo y enredaderas
- Árboles gigantes con raíces que forman plataformas
- Luz filtrada a través del dosel (rayos de luz volumétrica)
- Hongos luminosos que marcan el camino

**Capas Visuales (Parallax):**
- **Fondo lejano:** Siluetas de montañas, cielo crepuscular granate-púrpura
- **Capa media:** Árboles grandes, ruinas distantes
- **Capa frontal:** Vegetación detallada, flores, hierba interactiva
- **Primer plano:** Partículas de polen/luz flotando

**Estructura del Nivel:**
```
┌─────────────────────────────────────────────────┐
│ [INICIO] Claro del Despertar                    │
│    ↓                                             │
│ [ZONA 1] Sendero de Raíces (Tutorial)           │
│    ↓                                             │
│ [ZONA 2] Ruinas del Altar (Puzzles)             │
│    ↓                                             │
│ [ZONA 3] Jardín de Espinas (Plataformas)        │
│    ↓                                             │
│ [ZONA 4] Puente de Luz (Puzzle + Plataformas)   │
│    ↓                                             │
│ [META] El Árbol Ancestral                       │
└─────────────────────────────────────────────────┘
```

### 6.2 Progresión de Dificultad

**Zona 1: Claro del Despertar + Sendero de Raíces** (Tutorial implícito - 30 seg)
- Plataformas bajas, fáciles
- 2-3 esencias a la vista
- Primera Piedra Rúnica (enseña mecánica)
- Sin peligros

**Zona 2: Ruinas del Altar** (Introducción a puzzles - 45 seg)
- Primera Sombra Errante (enseña purificación)
- Puzzle simple: 3 piedras rúnicas abren puerta
- Saltos más largos
- Esencias en lugares ligeramente ocultos

**Zona 3: Jardín de Espinas** (Desafío de plataformas - 1 min)
- Espinas venenosas entre plataformas
- 2 Sombras Errantes patrullando
- Saltos precisos
- Flor de Sanación escondida

**Zona 4: Puente de Luz** (Puzzle temporal + habilidad - 45 seg)
- Activas altar → Plataformas de luz aparecen por 15 seg
- Debes cruzar rápido
- 3 Sombras al final (opcional purificarlas)
- Última esencia grande antes de la meta

**Meta: El Árbol Ancestral** (Recompensa visual - 15 seg)
- Cinemática corta: el zorro toca el árbol, luz restaurada
- Flores brotan, música triunfal suave
- Pantalla de victoria

### 6.3 Estimación de Tiempo
- Speedrun: ~2 minutos
- Jugador casual: ~3-4 minutos
- Jugador completista (100%): ~5-6 minutos

---

## 7. Estética Visual y Audio

### 7.1 Dirección Artística

**Estilo:**
- **2D Painted/Hand-drawn look** (aspecto pictórico)
- Siluetas claras, colores ricos
- Iluminación suave con puntos de luz brillante
- Énfasis en atmósfera sobre realismo

**Inspiración Visual:**
- Paleta de Ori and the Blind Forest
- Diseño de personaje de Spirit (película)
- Arquitectura de ruinas de Zelda
- Vegetación estilizada pero detallada

### 7.2 El Protagonista: Diseño Visual del Zorro

**Características Clave:**
- **Tamaño:** Proporción 1:3 (cabeza pequeña, cuerpo largo, COLA ENORME)
- **Color base:** Granate profundo (#722F37)
- **Marcas:** Líneas doradas en frente y patas (símbolos místicos)
- **Cola:** 2-3 veces el tamaño del cuerpo, efecto de "llama mágica" púrpura-dorada
- **Ojos:** Ámbar brillante (#FFBF00), expresivos
- **Aura:** Partículas doradas flotando sutilmente alrededor

**Animaciones Clave:**
1. **Idle:** Respiración suave, cola ondulando, ocasionalmente mira alrededor
2. **Caminar:** Paso elegante, cola fluyendo tras él
3. **Correr:** Postura baja, orejas hacia atrás, cola extendida
4. **Saltar:** Impulso grácil, cola envuelve el cuerpo
5. **Caída/Planeo:** Cola se expande como paracaídas luminoso
6. **Interactuar:** Se sienta, cola forma círculo, brilla intensamente
7. **Purificar:** Toca con la nariz, onda de luz desde la cola

### 7.3 Paleta Completa del Juego

**Naturaleza:**
- Árboles: #2D5016 (verde oscuro) + #4A7C3A (verde medio)
- Musgo/Hierba: #7CB342 (verde vibrante)
- Flores: #D4AF37 (dorado), #FF6B9D (rosa), #9370DB (violeta)

**Ruinas y Piedra:**
- Piedra base: #5C5C5C (gris)
- Piedras rúnicas inactivas: #4A4A4A (gris oscuro)
- Piedras rúnicas activas: #D4AF37 (dorado brillante)

**Magia y Efectos:**
- Esencias: #FFFFFF (blanco), #FFD700 (dorado), #9370DB (púrpura)
- Corrupción: #2E0854 (púrpura oscuro), #1C0B2C (casi negro)
- Luz purificadora: #F0E68C (amarillo suave) + partículas doradas

**Cielo y Fondo:**
- Crepúsculo superior: #7B2869 (púrpura)
- Horizonte: #D4698B (granate suave)
- Nubes: #4A2C42 (púrpura oscuro translúcido)

### 7.4 Audio (Referencia)

**Música:**
- **Estilo:** Ambiental, orquestal minimalista
- **Instrumentos:** Flauta, arpa, cuerdas suaves, percusión tribal leve
- **Referencia:** Música de Ori, Zelda Forest Temple, Journey
- **Tempo:** Lento, contemplativo (60-80 BPM)

**Efectos de Sonido:**

*Zorro:*
- Pasos: Suave roce de hierba
- Salto: "Whooosh" aéreo sutil
- Aterrizaje: Hojas crujiendo
- Interacción: Campanita cristalina

*Ambiente:*
- Viento entre árboles
- Pájaros lejanos
- Agua corriendo suavemente
- Hojas cayendo ocasionalmente

*Magia:*
- Recolectar esencia: Tintineo luminoso ascendente
- Activar piedra: Resonancia profunda ("VVVMMMM")
- Purificar: Onda de luz (sonido de "cristal expandiéndose")
- Abrir camino: Energía fluyendo

*UI:*
- Pausa: Suave "clic"
- Navegación menú: Tonos de arpa
- Selección: Campanita confirmativa

---

## 8. Interfaz de Usuario (UI)

### 8.1 Filosofía de UI
**Minimalista y Diegética:** La UI no interrumpe la experiencia. Elementos integrados naturalmente en el mundo.

### 8.2 HUD (Heads-Up Display)

**Durante el juego:**

*Esquina Superior Izquierda:*
- **Vida:** 3 corazones estilizados como flores luminosas 🌸🌸🌸
- Diseño: Flores granates con centro dorado
- Al perder vida: Flor se marchita (animación sutil)

*Esquina Superior Derecha:*
- **Esencias Recolectadas:** Contador con icono de orbe
- Formato: "✨ 150"  (número en fuente elegante pero legible)
- Color: Dorado brillante

*Centro Superior (Opcional):*
- **Indicador de Puzzle:** Aparece solo cuando hay puzzle activo
- Ejemplo: "🔮 2/3 Piedras Activadas"
- Desaparece al completar

**Lo que NO aparece en el HUD:**
- Minimapa (el nivel es lineal, innecesario)
- Barra de experiencia (no hay progresión RPG)
- Tutorial intrusivo (se aprende jugando)

### 8.3 Menús

**Menú Principal:**
```
╔════════════════════════════════════════╗
║                                        ║
║     🦊 SPIRIT FOX 🦊                   ║
║   The Enchanted Forest                 ║
║                                        ║
║         [▶ COMENZAR]                   ║
║         [⚙ OPCIONES]                   ║
║         [❌ SALIR]                      ║
║                                        ║
╚════════════════════════════════════════╝
```

**Diseño Visual:**
- Fondo: Bosque animado suavemente (paralaje lento)
- Partículas de luz flotando
- Zorro sentado contemplando en la esquina
- Fuente: Elegante pero legible (estilo "Cinzel" o similar)

**Pantalla de Pausa:**
```
╔════════════════════════════════════════╗
║          PAUSA                         ║
║                                        ║
║         [▶ CONTINUAR]                  ║
║         [↻ REINICIAR]                  ║
║         [🏠 MENÚ PRINCIPAL]             ║
║         [⚙ OPCIONES]                   ║
║                                        ║
╚════════════════════════════════════════╝
```

- Fondo: Juego congelado con filtro oscuro (overlay 50% negro)
- Blur sutil en el fondo

**Pantalla de Victoria:**
```
╔════════════════════════════════════════╗
║                                        ║
║      🌟 ¡BOSQUE RESTAURADO! 🌟         ║
║                                        ║
║     El equilibrio ha vuelto...         ║
║                                        ║
║      Esencias recolectadas: 250/300    ║
║      Tiempo: 3:42                      ║
║                                        ║
║      [↻ JUGAR DE NUEVO]                ║
║      [🏠 MENÚ PRINCIPAL]                ║
║                                        ║
╚════════════════════════════════════════╝
```

**Animación de Victoria:**
- Zoom suave al Árbol Ancestral brillando
- Flores brotando en time-lapse rápido
- Zorro sentado frente al árbol, cola brillante
- Partículas de luz subiendo como luciérnagas
- Música triunfal suave

**Pantalla de Game Over:**
```
╔════════════════════════════════════════╗
║                                        ║
║      La oscuridad persiste...          ║
║                                        ║
║      [↻ INTENTAR DE NUEVO]             ║
║      [🏠 MENÚ PRINCIPAL]                ║
║                                        ║
╚════════════════════════════════════════╝
```

- Tono: NO punitivo, contemplativo
- Visual: Bosque en penumbra, zorro descansando
- Sin "YOU DIED" agresivo - es un juego tranquilo

### 8.4 Opciones (Menú de Configuración)

```
╔════════════════════════════════════════╗
║         OPCIONES                       ║
║                                        ║
║  🔊 Volumen Música:    [====----]      ║
║  🔉 Volumen SFX:       [======--]      ║
║                                        ║
║  [✓] Pantalla Completa                 ║
║  [ ] Modo Ventana                      ║
║                                        ║
║         [← VOLVER]                     ║
║                                        ║
╚════════════════════════════════════════╝
```

---

## 9. Alcance del Proyecto (MVP vs. Polish)

### 9.1 ✅ MVP - Versión Mínima Entregable (Obligatorio)

**Nivel:**
- 1 nivel completo jugable (The Whispering Grove)
- 4-5 zonas diferenciadas
- Meta alcanzable (Árbol Ancestral)

**Personaje:**
- Zorro controlable (sprite básico pero reconocible)
- Movimiento: caminar, correr, saltar
- Cola visible y grande (aunque sea sprite simple)
- Animaciones básicas: idle, walk, jump

**Enemigos/Obstáculos:**
- 1 tipo: Sombras Errantes (patrullaje simple)
- Espinas venenosas (obstáculos estáticos)

**Sistemas:**
- ✅ Vida (3 corazones)
- ✅ Puntuación (esencias recolectadas)
- ✅ Colisiones y físicas

**UI:**
- ✅ HUD (vida + puntos)
- ✅ Menú principal funcional
- ✅ Pantalla Victoria/Game Over
- ✅ Pausa

**Cámara:**
- ✅ Sigue al jugador suavemente

**Escenas:**
- ✅ MainMenu
- ✅ GameLevel
- ✅ Victory
- ✅ GameOver

**Build:**
- ✅ Ejecutable Windows funcional

### 9.2 🌟 Features de PULIDO (Si hay tiempo - Días 8-9)

**Visual:**
- Animaciones más fluidas (6-8 frames)
- Partículas de luz en la cola del zorro
- Parallax en el fondo (2-3 capas)
- Iluminación dinámica (luces puntuales)
- Vegetación interactiva (hierba que se mueve)

**Audio:**
- Música de fondo (1 track ambient)
- SFX completos (saltos, recolección, purificación)
- Sonidos ambientales del bosque

**Gameplay:**
- Mecánica de planeo con la cola
- Purificación de Sombras (interacción E)
- Puzzles de Piedras Rúnicas
- Caminos secretos con esencias escondidas

**Pulido:**
- Transiciones suaves entre escenas (fade in/out)
- Shake de cámara en eventos importantes
- Feedback más rico (slowmotion al purificar)

### 9.3 ❌ Fuera del Alcance (No hacer)

- Múltiples niveles
- Sistema de habilidades/progresión
- Combate complejo
- Cinemáticas elaboradas
- Multijugador
- Sistema de guardado
- Localización a otros idiomas
- Boss fight

---

## 10. Plan de Desarrollo (10 Días)

### **Días 1-2: Setup y Fundamentos**
- ✅ Configuración del proyecto Unity
- ✅ Repositorio GitHub con .gitignore
- ✅ Documentación (GDD, README)
- ✅ Estructura de carpetas
- ✅ Buscar/crear assets básicos (sprites placeholder)

**Entregable:** Proyecto configurado, docs en GitHub

---

### **Días 3-4: Personaje Jugador**
- Sprite del zorro (puede ser placeholder simple)
- Script PlayerController.cs
  - Movimiento horizontal (Input)
  - Salto con físicas
  - Animaciones básicas (idle, walk, jump)
- Rigidbody2D + Collider2D configurados
- Cámara siguiendo al jugador (script CameraFollow.cs)

**Entregable:** Zorro controlable en escena de prueba

---

### **Días 5-6: Nivel y Obstáculos**
- Diseño del nivel en Unity (Tilemap o Sprites)
  - Plataformas de raíces
  - Ruinas de piedra
  - Fondo (1 capa mínimo)
- Sombras Errantes (EnemyPatrol.cs)
- Espinas (daño por colisión)
- Sistema de vida (HealthSystem.cs)
- Esencias recolectables (Collectible.cs)

**Entregable:** Nivel jugable con peligros y coleccionables

---

### **Días 7: UI y Sistemas**
- HUD (vida + puntos)
  - Script UIManager.cs
  - Canvas con TextMeshPro
- Menú Principal (escena MainMenu)
  - Botones: Jugar, Opciones, Salir
  - Script MainMenu.cs
- Pantallas Victoria/Game Over
  - Condición de victoria (llegar a meta)
  - Condición de derrota (vida = 0)
- Pausa (con ESC)

**Entregable:** Flujo completo de juego funcional

---

### **Día 8: Pulido y Audio**
- Animaciones mejoradas (si hay tiempo)
- Partículas básicas (cola del zorro, esencias)
- Audio:
  - Música de fondo (asset gratis)
  - 3-5 SFX básicos (salto, recolectar, daño)
- Ajuste de dificultad (testear y equilibrar)

**Entregable:** Juego con polish básico

---

### **Día 9: Build y Documentación Final**
- Generar Build ejecutable Windows
  - Comprimir en .zip
  - Subir a GitHub Releases
- Completar documentación técnica (Technical.md)
  - Arquitectura de scripts
  - Decisiones técnicas
  - Assets utilizados con créditos
- Escribir Postmortem.md
  - Qué funcionó
  - Desafíos
  - Aprendizajes

**Entregable:** Build final + docs completas en GitHub

---

### **Día 10: Preparación Defensa Oral**
- Crear presentación (slides simples o guión)
- Ensayar demo (2-3 minutos jugando)
- Preparar explicación técnica:
  - Mostrar scripts clave
  - Explicar arquitectura
  - Hablar de problemas resueltos
- Grabar video de gameplay (opcional, por si falla demo en vivo)

**Entregable:** Presentación lista, confianza para defender

---

## 11. Arquitectura Técnica (Referencia)

### 11.1 Estructura de Scripts Principal

```
Scripts/
├── Player/
│   ├── PlayerController.cs      # Movimiento, input, físicas
│   ├── PlayerAnimator.cs        # Control de animaciones
│   └── PlayerHealth.cs          # Sistema de vida del jugador
│
├── Enemies/
│   ├── EnemyPatrol.cs           # IA de patrullaje para Sombras
│   └── EnemyDamage.cs           # Daño al contacto
│
├── Collectibles/
│   ├── Essence.cs               # Esencias recolectables
│   └── HealthPickup.cs          # Flores de sanación
│
├── Systems/
│   ├── GameManager.cs           # Estado del juego, puntuación
│   └── AudioManager.cs          # Gestión de música/SFX
│
├── UI/
│   ├── UIManager.cs             # HUD (vida, puntos)
│   ├── MainMenu.cs              # Lógica del menú principal
│   ├── PauseMenu.cs             # Lógica de pausa
│   └── VictoryScreen.cs         # Pantalla de victoria
│
└── Camera/
    └── CameraFollow.cs          # Cámara sigue al jugador
```

### 11.2 Managers Pattern

**GameManager.cs** (Singleton)
- Control global del estado del juego
- Puntuación total
- Gestión de victoria/derrota
- Persistencia entre escenas

**UIManager.cs**
- Actualiza HUD (vida, puntos)
- Referencias a elementos UI
- Animaciones de UI (opcional)

**AudioManager.cs** (Opcional)
- Play/Stop música
- Play SFX con pools
- Control de volumen

### 11.3 Convenciones de Código

**Nombres:**
- Clases: PascalCase (PlayerController)
- Variables: camelCase (currentHealth)
- Constantes: UPPER_SNAKE_CASE (MAX_HEALTH)

**Comentarios:**
- Cada script con header comentado explicando propósito
- Métodos públicos comentados
- Código complejo con comentarios inline

**Ejemplo:**
```csharp
/// <summary>
/// Controla el movimiento y físicas del zorro jugador
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    
    // Referencias
    private Rigidbody2D rb;
    private Animator animator;
    
    // Estado
    private bool isGrounded;
    
    // ... resto del código
}
```

---

## 12. Assets y Recursos

### 12.1 Sprites Necesarios

**Personaje (Zorro):**
- Idle (1-2 frames mínimo)
- Walk (4-6 frames)
- Jump (2-3 frames)
- Fall (1 frame)
- **Nota:** La cola debe ser PROMINENTE en todos los sprites

**Entorno:**
- Plataformas (raíces, piedra, madera)
- Fondo (árboles, ruinas, cielo)
- Decoración (flores, musgo, hierba)

**Coleccionables:**
- Esencias (3 tipos: pequeña, mediana, grande)
- Corazón de vida

**Enemigos:**
- Sombra Errante (2-3 frames de animación)
- Espina venenosa (sprite estático)

**UI:**
- Iconos de corazón (lleno, vacío)
- Icono de esencia
- Botones (normal, hover, pressed)

### 12.2 Fuentes de Assets Gratuitos

**Sprites 2D:**
- itch.io (buscar "free 2D forest assets")
- OpenGameArt.org
- Kenney.nl (assets generic pero útiles)
- Unity Asset Store (filtro: Free)

**Audio:**
- Freesound.org (SFX)
- Incompetech.com (música de Kevin MacLeod)
- Purple Planet Music (música ambient)

**Fuentes:**
- Google Fonts (Cinzel, Philosopher)
- DaFont (buscar "fantasy fonts")

### 12.3 Créditos y Licencias

**IMPORTANTE:** Documenta TODOS los assets de terceros en Technical.md:
- Nombre del asset
- Autor
- Licencia (Creative Commons, etc.)
- URL de descarga

**Ejemplo:**
```markdown
## Créditos de Assets

### Sprites
- "Forest Tileset" por usuario123 - CC0 License
  https://itch.io/...
  
### Audio
- "Mystical Forest" por Kevin MacLeod - CC BY 3.0
  https://incompetech.com/...
```

---

## 13. Riesgos y Mitigación

| Riesgo | Probabilidad | Impacto | Mitigación |
|--------|--------------|---------|------------|
| **Falta assets visuales** | Alta | Medio | Usar placeholders (cuadrados de color) + buscar assets gratuitos en itch.io |
| **Animaciones complejas** | Media | Bajo | Empezar con 2 frames por animación, mejorar si hay tiempo |
| **Bugs en físicas** | Alta | Alto | Testing constante, usar configuración estándar de Rigidbody2D |
| **Complejidad de puzzles** | Baja | Medio | Mantener puzzles simples (activar 3 piedras), evitar lógica compleja |
| **Falta de tiempo** | Media | Alto | Priorizar MVP, dejar pulido para el final |
| **Problemas con Git** | Media | Medio | Commits frecuentes, nunca trabajar sin subir cambios |

---

## 14. Métricas de Éxito

### 14.1 Técnicas
- ✅ 0 errores críticos en el build
- ✅ Framerate estable (60 FPS)
- ✅ Todos los sistemas del MVP funcionando
- ✅ Build ejecutable sin dependencias externas

### 14.2 Diseño
- ✅ El juego se completa en 3-5 minutos
- ✅ Controles responsivos (<50ms input lag)
- ✅ Feedback claro en cada acción
- ✅ El jugador entiende qué hacer sin tutorial explícito

### 14.3 Académicas
- ✅ Cumple TODOS los requisitos mínimos del proyecto
- ✅ Documentación profesional completa
- ✅ Código limpio y comentado
- ✅ Commits regulares en GitHub (min. 20 commits)
- ✅ Nota objetivo: 8-10

### 14.4 Personales
- ✅ El juego refleja TU visión y gustos
- ✅ Estás orgullosa del resultado
- ✅ Aprendiste habilidades aplicables en futuros proyectos
- ✅ Puedes explicar con confianza cada parte técnica

---

## 15. Conclusión

**Spirit Fox: The Enchanted Forest** es más que un proyecto académico - es una oportunidad para crear una experiencia personal y significativa que refleja tus gustos y valores.

El enfoque en **exploración contemplativa** sobre combate frenético, la **conexión con la naturaleza** sobre la conquista, y la **estética cuidada** sobre el realismo, son decisiones de diseño deliberadas que hacen este juego único.

La paleta de **granates profundos** y **verdes místicos**, combinada con un protagonista que es un **zorro espiritual de cola majestuosa**, crea una identidad visual fuerte y memorable.

Este GDD está diseñado para ser **realista en alcance** (completable en 10 días) pero **ambicioso en visión** (un juego del que puedes estar orgullosa). Prioriza el MVP, pero si el tiempo lo permite, el pulido transformará esto en algo verdaderamente especial.

---

**"En el bosque, cada luz es una esperanza.  
En este proyecto, cada línea de código es un paso hacia tu visión."**

---

**Documento creado por:** [Tu nombre]  
**Última actualización:** Febrero 2026  
**Versión:** 1.0  
**Dedicado a:** Todos los que creen que los juegos pueden ser arte contemplativo 🦊✨

---

## Apéndice A: Glosario Técnico

- **MVP:** Minimum Viable Product (Producto Mínimo Viable)
- **Parallax:** Efecto visual donde capas de fondo se mueven a diferentes velocidades
- **Rigidbody2D:** Componente de Unity para físicas 2D
- **Tilemap:** Sistema de Unity para crear niveles con "azulejos" reutilizables
- **Prefab:** Plantilla reutilizable de objeto en Unity
- **Singleton:** Patrón de diseño donde solo existe una instancia de una clase
- **Canvas:** Sistema de UI de Unity
- **Diegetic UI:** Interfaz integrada en el mundo del juego (vs. overlay externo)

## Apéndice B: Checklist de Requisitos del Proyecto

**Diseño y Concepto (Tema 5):**
- [x] Género y subgénero definidos (Plataformas 2D / Aventura / Puzzle)
- [x] Público objetivo identificado (Jugadores contemplativos)
- [x] Referencias reales documentadas (Zelda, Ori, Journey, etc.)
- [x] Mecánicas principales descritas (Exploración, puzzles, purificación)
- [x] Relación con historia del videojuego explicada

**Desarrollo Técnico (Tema 6):**
- [ ] Escena: Menú principal
- [ ] Escena: Juego (nivel)
- [ ] Escena: Victoria
- [ ] Escena: Game Over
- [ ] Jugador controlable con movimiento fluido
- [ ] Input correctamente implementado
- [ ] Físicas y colisiones coherentes
- [ ] Cámara funcional (seguimiento)
- [ ] Enemigos con IA simple (patrullaje)
- [ ] Interacción real con jugador
- [ ] HUD (vida, puntos)
- [ ] Feedback visual (animaciones)
- [ ] Build ejecutable Windows

**GitHub:**
- [ ] Repositorio público
- [ ] README.md profesional
- [ ] /Docs/GDD.md
- [ ] /Docs/Technical.md
- [ ] /Docs/Postmortem.md
- [ ] /Build/ o Release
- [ ] Historial de commits real (min. 20)

**Defensa Oral:**
- [ ] Presentación del juego preparada
- [ ] Demo funcional ensayada
- [ ] Explicación técnica clara
- [ ] Problemas y soluciones documentados

---

*Fin del Game Design Document*
