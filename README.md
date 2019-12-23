# Uso
Nos dirigimos a http://ip/api/main para obtener el pronostico hasta diez años desde el dia de la fecha o bien http://ip/api/main/n donde n es un entero entre [1;3650] y que retorna el clima del dia especificado por parametro
 
 # Decisiones tomadas
Al ser un problema de simulación matemática y por las características del mismo, un lenguaje orientado a objetos era muy apropiado al existir entidades definidas (Planetas, Sistema Solar, Sistemas de coordenadas, etc.)
En particular, elegí realizarlo en una aplicacion de consola en C# Framework 4.5.2 como tecnología para resolverlo debido a la comodidad de ya tener todo el entorno instalado y configurado en la computadora donde realice el desarrollo.


Lo primero que tuve que pensar al resolver el problema era cómo realizar los cálculos para determinar la posición de los planetas. 
Como los mismos tienen órbitas circulares y una distancia fija respecto del eje de coordenadas (el Sol u origen), lo más apropiado 
era utilizar un sistema de coordenadas polares. De esta forma, la rotación se logra simplemente incrementando el ángulo de las 
coordenadas polares.

Por otra parte, las condiciones climáticas se dan a partir de la relación entre las posiciones de los tres planetas. Para resolver este 
tema utilice una entidad (Sistema Solar) que alberga una lista con tres planetas y ademas puede simular un día y calcular el clima que se 
da en ese día particular.

Para modelar el clima utilice el patrón Factory Method para construir Climas válidos (que son 4). Todos poseen una intensidad de lluvia igual a cero
excepto en los dias lluviosos.


Para el bonus consideré utilizar una base de datos NoSql. Fue un desafio ya que jamas utilice una base de este estilo. Considere que al 
no tener esquema, suele ser mucho más fácil persistir datos del modelo de clases, además de que no es necesaria una alta consistencia y 
siendo únicamente una API de consulta, una base de datos NoSql se adaptaba bien.
En particular elegí MongoDb porque es una de las mas populares y pude observar que tiene drivers para todos los lenguajes populares. 
Asi mismo existe una una solución Cloud de Mongo, Atlas, que es muy fácil de utilizar y configurar.
