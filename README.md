# Que es?
Es una aplicacion de consola que se encarga de resolver el challenge de ML

# Uso
Ejecutar la aplicacion WeatherConsoleApp.exe que se encuentra dentro del directorio \bin. En ella aparecera un menu para elegir las 2 acciones a tomar respecto a la base: Generar un nuevo juego de datos o bien borrar la base (no se recomienda ejecutar esto ultimo ya que generaria conflictos en la ejecucion del servicio de consultas).

# Decisiones tomadas
Al ser un problema de simulación matemática y por las características del mismo, un lenguaje orientado a objetos era muy apropiado al existir entidades definidas (Planetas, Sistema Solar, Sistemas de coordenadas, etc.)
En particular, elegí a través de una aplicación de consola en .Net con el lenguaje C# en el Framework 4.5.2 como tecnología para resolverlo debido a la comodidad de ya tener todo el entorno instalado y configurado en la computadora donde realice el desarrollo.

Lo primero que tuve que pensar al resolver el problema era cómo realizar los cálculos para determinar la posición de los planetas. 
Como los mismos tienen órbitas circulares y una distancia fija respecto del eje de coordenadas (el Sol u origen), lo más apropiado 
era utilizar un sistema de coordenadas polares. De esta forma, la rotación se logra simplemente incrementando el ángulo de las 
coordenadas polares.

Por otra parte, las condiciones climáticas se dan a partir de la relación entre las posiciones de los tres planetas. Para resolver este 
tema utilice una entidad (Sistema Solar) que alberga una lista con tres planetas y además puede simular un día y calcular el clima que se 
da en ese día particular.

Para modelar el clima utilice el patrón Factory Method para construir Climas válidos. Todos poseen una intensidad de lluvia igual a cero excepto obviamente en los días lluviosos.
